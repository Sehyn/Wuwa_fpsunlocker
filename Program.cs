using System;
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

            Console.WriteLine("Steps:");
            Console.WriteLine("1) Make sure to have the game running");
            Console.WriteLine("2) Once unlocker finished restart game + launcher");
            Console.WriteLine("3) Make sure within games settings to DISABLE vsync");
            Console.WriteLine("4) Profit\n");
            Console.WriteLine("NOTE:");
            Console.WriteLine("Game looks poorly optimized and bugged.\nTry windowered mode if unlocker not working aswell of lower resolution\nFPS counter EG Nvidia will still show 60 FPS but you will noticed the +120fps smooth.\n");
            Console.WriteLine("Discord: impots");
            Console.WriteLine("Press any key to unlock your FPS.");
            Console.ReadKey();
            // Define the filename and the keyword we are looking for
            string fileName = "GameUserSettings.ini";
            string requiredPathKeyword = "Wuthering Waves";
            bool fileFound = false;

            // Start the search from the root of each drive
            foreach (var drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    string foundFile = FindFile(drive.RootDirectory.FullName, fileName, requiredPathKeyword);
                    if (foundFile != null)
                    {
                        Console.WriteLine($"File found: {foundFile}");
                        ProcessFile(foundFile);
                        fileFound = true;
                        break;
                    }
                }
            }

            if (!fileFound)
            {
                Console.WriteLine("File not found on any drive.");
            }

            // Pause the console to view output
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static string FindFile(string rootDirectory, string fileName, string requiredPathKeyword)
        {
            try
            {
                // Get all subdirectories
                foreach (string dir in Directory.GetDirectories(rootDirectory))
                {
                    Console.WriteLine($"Checking directory: {dir}");
                    if (dir.Contains(requiredPathKeyword))
                    {
                        Console.WriteLine($"Directory matches keyword: {dir}");
                        try
                        {
                            // Check files in the current directory
                            foreach (string file in Directory.GetFiles(dir, fileName))
                            {
                                return file;
                            }

                            // Recursive call for subdirectories
                            string foundFile = FindFile(dir, fileName, requiredPathKeyword);
                            if (foundFile != null)
                            {
                                return foundFile;
                            }
                        }
                        catch (UnauthorizedAccessException)
                        {
                            Console.WriteLine($"Unauthorized access to directory: {dir}");
                            // Ignore directories we don't have access to
                        }
                        catch (DirectoryNotFoundException)
                        {
                            Console.WriteLine($"Directory not found: {dir}");
                            // Ignore directories that were removed during the search
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Unauthorized access to directory: {rootDirectory}");
                // Ignore directories we don't have access to
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine($"Directory not found: {rootDirectory}");
                // Ignore directories that were removed during the search
            }
            return null;
        }

        static void ProcessFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("FrameRateLimit="))
                {
                    lines[i] = "FrameRateLimit=0";
                    break;
                }
            }

            File.WriteAllLines(filePath, lines);

            FileInfo fileInfo = new FileInfo(filePath);
            fileInfo.IsReadOnly = true;

            Console.WriteLine($"Updated and set file to read-only: {filePath}");
            Console.Clear();
            Console.WriteLine($"Updated and set file to read-only: {filePath}");
            Console.WriteLine($"Enjoy and have fun.");



        }
    }
}
