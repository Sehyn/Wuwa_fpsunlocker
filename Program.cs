using Newtonsoft.Json.Linq;
using System;
using System.Data.SQLite;
using System.IO;

namespace Wuwa_fpsunlocker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ASCII Art
            Console.WriteLine(@"
 __          __                             ______           _    _       _            _             
 \ \        / /                            |  ____|         | |  | |     | |          | |            
  \ \  /\  / /   ___      ____ _   ______  | |__ _ __  ___  | |  | |_ __ | | ___   ___| | _____ _ __ 
   \ \/  \/ / | | \ \ /\ / / _` | |______| |  __| '_ \/ __| | |  | | '_ \| |/ _ \ / __| |/ / _ \ '__|
    \  /\  /| |_| |\ V  V / (_| |          | |  | |_) \__ \ | |__| | | | | | (_) | (__|   <  __/ |   
     \/  \/  \__,_| \_/\_/ \__,_|          |_|  | .__/|___/  \____/|_| |_|_|\___/ \___|_|\_\___|_|   
                                                | |                                                  
                                                |_|                                                  
");
            Console.WriteLine("GAME PATH HAS TO BE:C:\\Wuthering Waves\\Wuthering Waves Game | I will push an update later so it's dynamic!\n\n");
            Console.WriteLine("Steps:");
            Console.WriteLine("1) Make sure to SET the FPS limit to 60FPS BEFORE");
            Console.WriteLine("2) Then CLOSE the game");
            Console.WriteLine("3) Make sure within games settings to DISABLE vsync and to NOT touch the FPS Limit AFTER patch");
            Console.WriteLine("4) Profit\n");
            Console.WriteLine("NOTE:");
            Console.WriteLine("Game looks poorly optimized and bugged.");
            Console.WriteLine("Discord: impots");
            Console.WriteLine("Press any key to unlock your FPS.");
            Console.ReadKey();
            string dbPath = @"C:\Wuthering Waves\Wuthering Waves Game\Client\Saved\LocalStorage\LocalStorage.db";
            string connectionString = $"Data Source={dbPath};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Editing the file...");

                    // Step 1: Read the GameQualitySetting JSON
                    string selectQuery = "SELECT value FROM LocalStorage WHERE key = 'GameQualitySetting';";
                    string gameQualitySettingJson = null;

                    using (SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, connection))
                    {
                        using (SQLiteDataReader reader = selectCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                gameQualitySettingJson = reader["value"].ToString();
                                Console.WriteLine("Original GameQualitySetting JSON:");
                                Console.WriteLine(gameQualitySettingJson);
                            }
                        }
                    }

                    if (gameQualitySettingJson == null)
                    {
                        Console.WriteLine("No GameQualitySetting found.");
                        return;
                    }

                    // Step 2: Modify the KeyCustomFrameRate value in the JSON
                    var gameQualitySetting = JObject.Parse(gameQualitySettingJson);
                    gameQualitySetting["KeyCustomFrameRate"] = 240;
                    string updatedGameQualitySettingJson = gameQualitySetting.ToString();

                    Console.WriteLine("\nUpdated GameQualitySetting JSON:");
                    Console.WriteLine(updatedGameQualitySettingJson);

                    // Step 3: Update the modified JSON back into the database
                    string updateQuery = "UPDATE LocalStorage SET value = @value WHERE key = 'GameQualitySetting';";
                    using (SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@value", updatedGameQualitySettingJson);
                        int rowsAffected = updateCommand.ExecuteNonQuery();
                        Console.WriteLine($"\n{rowsAffected} row(s) updated.");

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
            Console.Clear();

            Console.WriteLine("\nGame succesfully Patched\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}