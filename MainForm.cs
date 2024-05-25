using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wuwa_fpsunlocker
{
    public partial class MainForm : Form
    {
        private JObject gameQualitySetting;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLoadJson_Click(object sender, EventArgs e)
        {
            string dbPath = txtDbPath.Text;
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string selectQuery = "SELECT value FROM LocalStorage WHERE key = 'GameQualitySetting';";
                    using (SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, connection))
                    {
                        using (SQLiteDataReader reader = selectCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string gameQualitySettingJson = reader["value"].ToString();
                                gameQualitySetting = JObject.Parse(gameQualitySettingJson);
                                DisplayJsonInTreeView(gameQualitySetting);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void DisplayJsonInTreeView(JObject json)
        {
            treeViewJson.Nodes.Clear();
            AddNode(treeViewJson.Nodes, json);
            treeViewJson.ExpandAll();
        }

        private void AddNode(TreeNodeCollection parentNode, JToken token)
        {
            if (token is JValue value)
            {
                parentNode.Add(new TreeNode(value.ToString()) { Tag = value });
            }
            else if (token is JObject obj)
            {
                TreeNode objNode = new TreeNode();
                parentNode.Add(objNode);
                foreach (var prop in obj.Properties())
                {
                    TreeNode propNode = new TreeNode(prop.Name) { Tag = prop };
                    objNode.Nodes.Add(propNode);
                    AddNode(propNode.Nodes, prop.Value);
                }
            }
            else if (token is JArray array)
            {
                TreeNode arrayNode = new TreeNode();
                parentNode.Add(arrayNode);
                for (int i = 0; i < array.Count; i++)
                {
                    TreeNode valueNode = new TreeNode($"[{i}]") { Tag = array[i] };
                    arrayNode.Nodes.Add(valueNode);
                    AddNode(valueNode.Nodes, array[i]);
                }
            }
        }

        private void treeViewJson_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = e.Node;
            if (node.Tag is JProperty prop)
            {
                txtKey.Text = prop.Name;
                txtValue.Text = prop.Value.ToString();
            }
            else if (node.Tag is JValue val)
            {
                txtKey.Text = node.Parent.Text;
                txtValue.Text = val.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var selectedNode = treeViewJson.SelectedNode;
            if (selectedNode?.Tag is JProperty prop)
            {
                prop.Value = txtValue.Text;
                selectedNode.Nodes.Clear();
                AddNode(selectedNode.Nodes, prop.Value);
            }
            else if (selectedNode?.Tag is JValue val)
            {
                val.Value = txtValue.Text;
                selectedNode.Text = val.ToString();
            }

            SaveJsonToDatabase();
        }

        private void SaveJsonToDatabase()
        {
            string dbPath = txtDbPath.Text;
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string updateQuery = "UPDATE LocalStorage SET value = @value WHERE key = 'GameQualitySetting';";
                    using (SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@value", gameQualitySetting.ToString());
                        int rowsAffected = updateCommand.ExecuteNonQuery();
                        MessageBox.Show($"{rowsAffected} row(s) updated.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}