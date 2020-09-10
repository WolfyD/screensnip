using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Up2Site
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            Console.WriteLine("Hello, this is a test!");
            Console.WriteLine("Testing FTP folder creation...");
            //FTP ftp = new FTP("wolfpaw.hu", "8f8a39fb0577", "ftp.wolfpaw.hu", "test.test.1.1");
            FTP ftp = new FTP(UN:"wolfpaw.hu", PWD:"8f8a39fb0577", ADDR:"ftp.wolfpaw.hu", DIR:"versions/test");
            ftp.Test();
            Console.WriteLine("Folder creation test done.");

#endif
            Console.ReadLine();

        }
    }

    public static class Settings
    {

    }

    public static class DrawMenu
    {

    }

    public static class GetVersionNum
    {

    }

    public static class UploadData
    {

    }
}
