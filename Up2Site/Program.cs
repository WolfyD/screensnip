using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Up2Site
{
    class Program
    {
        public static StringBuilder sb = new StringBuilder("LOG - Starting " + Time() + "\r\n\r\n");
        public static int errCount = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                Header();
                if(Menu() == -1) { break; }
            }

            Console.WriteLine("Program terminated. To exit, press [Enter] key!");
            sb.Append("Program terminated at - " + Time());
            if(errCount > 0)
            {
                Properties.Settings.Default.s_LastErrorLog = sb.ToString();
            }

            Properties.Settings.Default.Save();

            Console.ReadLine();
        }

        public static void Header()
        {
            Console.Clear();
            Console.WriteLine("WolfPaw - Up2Site\r\n");
        }

        public static string Time()
        {
            return DateTime.Now.ToLongDateString() + "T" + DateTime.Now.ToLongTimeString();
        }

        public static int Menu()
        {
            Header();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("===== Menu =====");
            Console.WriteLine("");
            Console.WriteLine("Please select your choice:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("0 - Start upload");
            Console.WriteLine("1 - Settings");
            Console.WriteLine("2 - Check data");
            Console.WriteLine("3 - Exit");

            string choice = "";
            int res = -1;

            while (!int.TryParse(choice, out res) || res > 3 || res < 0)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(">                       ");
                Console.SetCursorPosition(3, Console.CursorTop);
                Console.ForegroundColor = ConsoleColor.White;
                choice = Console.ReadLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }

            switch (res)
            {
                case 0:
                    HandleUploadProcess();
                    break;
                case 1:
                    FilePaths();
                    break;
                case 2:
                    Logs();
                    break;
                default:
                    return -1;
            }

            return 0;
        }

        public static int FilePaths()
        {
            Header();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("===== Settings =====");
            Console.WriteLine("");
            Console.WriteLine("Please select your choice:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("0 - Set path for x86 folder");
            Console.WriteLine("1 - Set path for x64 folder");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("2 - Test path for x86 folder");
            Console.WriteLine("3 - Test path for x64 folder");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("4 - Exit");

            string choice = "";
            int res = -1;

            while (!int.TryParse(choice, out res) || res > 3 || res < 0)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(">                       ");
                Console.SetCursorPosition(3, Console.CursorTop);
                Console.ForegroundColor = ConsoleColor.White;
                choice = Console.ReadLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }

            switch (res)
            {
                case 0:
                    SetFilePath("x86");
                    break;
                case 1:
                    SetFilePath("x64");
                    break;
                case 2:
                    Logs();
                    break;
                default:
                    return -1;
            }

            return 0;
        }

        public static void SetFilePath(string architecture)
        {
            Header();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"===== Path setup to {architecture} =====");
            Console.WriteLine("");
            Console.WriteLine("Please write/paste the path to the Release folder of");
            Console.WriteLine($"the {architecture} architecture.");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("> ");
            Console.ForegroundColor = ConsoleColor.White;

            string path = Console.ReadLine();
            if (!Directory.Exists(path))
            {
                //TODO: Warn that there is no such path
                //Yes/No
            }

            //TODO: Ask if sure, if no, call self

            //If sure:
            if(architecture == "x86")
            {
                Properties.Settings.Default.s_x86_Folder = path;
            }
            else
            {
                Properties.Settings.Default.s_x64_Folder = path;
            }
            Properties.Settings.Default.Save();
        }

        public static void TestFilePath(string architecture)
        {
            if(architecture == "x86")
            {
                System.Diagnostics.Process.Start(Properties.Settings.Default.s_x86_Folder);
            }
            else
            {
                System.Diagnostics.Process.Start(Properties.Settings.Default.s_x64_Folder);
            }
        }
        
        public static void Logs()
        {
            //todo: Make screen where user sees logged stuff
        }

        public static void HandleUploadProcess()
        {
            try
            {
                Properties.Settings.Default.s_LastUploadAttempt = DateTime.Now;

                Log("Start...");
                string versionNum = GetVersionNum.GetVersionNumber();
                Properties.Settings.Default.s_LastVersion = versionNum;
                Log("Version number -> " + versionNum, 0);

                Log("Creating FTP...");
                FTP ftp = new FTP(UN: credentials.username, PWD: credentials.password, ADDR: credentials.hostname, DIR: versionNum);
                Log("Success!", 1);

                //TODO: Remove
                Properties.Settings.Default.s_x64_Folder = @"F:\[[STORAGE]]\[-PROJECTS]\Repos\screensnip\WolfPaw ScreenSnip\bin\x64\Release";
                Properties.Settings.Default.s_x86_Folder = @"F:\[[STORAGE]]\[-PROJECTS]\Repos\screensnip\WolfPaw ScreenSnip\bin\x86\Release";
                
                Log("Zipping files...");
                Log("x64...");
                PackFiles.PackFilesToZip(Properties.Settings.Default.s_x64_Folder, versionNum, true, out string path64);
                Log($"Created file [./zip/Snip_x64_{versionNum}.zip] with MD5 [{GetVersionNum.GetMD5HashForFile($"zip/Snip_x64_{versionNum}.zip")}]", 0);
                Log("Success!", 1);
                Log("x86...");
                PackFiles.PackFilesToZip(Properties.Settings.Default.s_x86_Folder, versionNum, false, out string path86);
                Log($"Created file [./zip/Snip_x86_{versionNum}.zip] with MD5 [{GetVersionNum.GetMD5HashForFile($"zip/Snip_x86_{versionNum}.zip")}]", 0);
                Log("Success!", 1);

                Log("Update...");
                ftp.Update(path64, path86);
                Log("Upload...");
                Log("x64...");
                ftp.Upload(path64);
                Log("Success!", 1);
                Log("x86...");
                ftp.Upload(path86);
                Log("Success!", 1);

                Log("Disconnect...");
                ftp.DisconnectFtp();
                Log("Success!", 1);

                Log("\r\nProcess ended successfully : " + DateTime.Now.ToLongTimeString(), 1);

                Properties.Settings.Default.s_LastUploadSuccess = DateTime.Now;
                Properties.Settings.Default.s_WasLastUploadSuccess = true;
            }
            catch (Exception ex)
            {
                Properties.Settings.Default.s_WasLastUploadSuccess = false;
                Properties.Settings.Default.s_LastErrorMessage = ex.Message;
                Log("Error -> " + ex.Message, 3);
            }
        }

        public static void Log(string message, int severity = 2)
        {
            switch (severity)
            {
                case 0: 
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;

                case 3:
                    Console.ForegroundColor = ConsoleColor.Red;
                    errCount++;
                    sb.Append("Error! - Error count: " + errCount);
                    break;
            }

            sb.Append("\r\n" + message + "\r\n");

            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    class crap
    {

        private void tryAutoComplete()
        {
            while (true)
            {
                //var key = Console.ReadKey().Key;
                //
                //if (key == ConsoleKey.Escape) { SetFilePath(architecture); }
                //
                //else if (key == ConsoleKey.Tab)
                //{
                //    if (path.Length > 0)
                //    {
                //        if (AttemptAutoComplete(path, out string AC))
                //        {
                //            path += AC;
                //        }
                //    }
                //}
                //
                //else if (key == ConsoleKey.Backspace)
                //{
                //    if (path.Length > 0)
                //    {
                //        path = path.Substring(0, path.Length - 1);
                //    }
                //}
                //
                //else if (key.ToString().Length == 1) { path += key; }
                //
                //Console.SetCursorPosition(2, Console.CursorTop);
                //Console.Write(path);
            }
        }

        public static bool AttemptAutoComplete(string PathSoFar, out string AC)
        {
            AC = "";
            string normalizedPath = PathSoFar.Replace("\\", "/");
            string[] psf = normalizedPath.Split('/');
            if (psf.Length > 0 && psf[0].Length > 0)
            {
                string drive = psf[0][0].ToString().ToUpper();
                DriveInfo di = new DriveInfo(drive);
                if (di != null && di.IsReady)
                {
                    AC = di.Name;
                }

                List<string> options = new List<string>();
                for (int i = 1; i < psf.Length; i++)
                {
                    options.Clear();
                    options.AddRange(Directory.GetDirectories(AC, "*.*", SearchOption.TopDirectoryOnly));
                    options.AddRange(Directory.GetFiles(AC, "*.*", SearchOption.TopDirectoryOnly));
                    options = options.Select(x => x.Replace("\\", "/").Substring(x.Replace("\\", "/").LastIndexOf("/") + 1).ToUpper()).ToList();
                    options = options.Where(X => X.Length >= psf[i].Length).ToList();

                    List<string> options2 = new List<string>();

                    for (int x = 0; x < psf[i].Length; x++)
                    {
                        options2 = options.Where(Y => Y.Substring(x, 1) == psf[i].Substring(x, 1)).ToList();

                        //for (int y = 0; y < options.Count; y++)
                        //{
                        //    if()
                        //}
                    }
                }

                return true;
            }

            return false;
        }

    }
}
