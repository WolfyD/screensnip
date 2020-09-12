using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSnipPerpetualUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Header();
                if (Menu() == -1) { break; }
            }

            Properties.Settings.Default.Save();

            Console.ReadLine();
        }

        public static void Header()
        {
            Console.Clear();
            Console.WriteLine("WolfPaw - ScreenSnip Perpetual Updater\r\n");
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
                    
                    break;
                case 1:
                    FilePaths();
                    break;
                case 2:
                    
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
                    TestFilePath("x86");
                    break;
                case 3:
                    TestFilePath("x64");
                    break;
                default:
                    return -1;
            }
            Properties.Settings.Default.Save();
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

            if (architecture == "x86")
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
            if (architecture == "x86")
            {
                System.Diagnostics.Process.Start(Properties.Settings.Default.s_x86_Folder);
            }
            else
            {
                System.Diagnostics.Process.Start(Properties.Settings.Default.s_x64_Folder);
            }
        }

    }
}
