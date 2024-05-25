namespace Wuwa_fpsunlocker
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtDbPath = new System.Windows.Forms.TextBox();
            this.btnLoadJson = new System.Windows.Forms.Button();
            this.treeViewJson = new System.Windows.Forms.TreeView();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblKey = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDbPath
            // 
            this.txtDbPath.Location = new System.Drawing.Point(104, 12);
            this.txtDbPath.Name = "txtDbPath";
            this.txtDbPath.Size = new System.Drawing.Size(456, 20);
            this.txtDbPath.TabIndex = 0;
            this.txtDbPath.Text = "C:\\Wuthering Waves\\Wuthering Waves Game\\Client\\Saved\\LocalStorage\\LocalStorage.db" +
    "";
            // 
            // btnLoadJson
            // 
            this.btnLoadJson.Location = new System.Drawing.Point(566, 9);
            this.btnLoadJson.Name = "btnLoadJson";
            this.btnLoadJson.Size = new System.Drawing.Size(75, 23);
            this.btnLoadJson.TabIndex = 1;
            this.btnLoadJson.Text = "Load JSON";
            this.btnLoadJson.UseVisualStyleBackColor = true;
            this.btnLoadJson.Click += new System.EventHandler(this.btnLoadJson_Click);
            // 
            // treeViewJson
            // 
            this.treeViewJson.Location = new System.Drawing.Point(12, 38);
            this.treeViewJson.Name = "treeViewJson";
            this.treeViewJson.Size = new System.Drawing.Size(629, 300);
            this.treeViewJson.TabIndex = 2;
            this.treeViewJson.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewJson_AfterSelect);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(60, 344);
            this.txtKey.Name = "txtKey";
            this.txtKey.ReadOnly = true;
            this.txtKey.Size = new System.Drawing.Size(581, 20);
            this.txtKey.TabIndex = 3;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(60, 370);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(581, 20);
            this.txtValue.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(60, 396);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(581, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(12, 347);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(28, 13);
            this.lblKey.TabIndex = 6;
            this.lblKey.Text = "Key:";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(12, 373);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(37, 13);
            this.lblValue.TabIndex = 7;
            this.lblValue.Text = "Value:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 442);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Credits: Sehyn - GitHub";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "LocalStorage path:";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(654, 464);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.treeViewJson);
            this.Controls.Add(this.btnLoadJson);
            this.Controls.Add(this.txtDbPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wuthering Waves - Editor [V1.3]";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtDbPath;
        private System.Windows.Forms.Button btnLoadJson;
        private System.Windows.Forms.TreeView treeViewJson;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}