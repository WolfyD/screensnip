using System;
using System.IO;
using System.IO.Compression;

namespace Up2Site
{
    public static class PackFiles
    {
        public static bool PackFilesToZip(string InPath, string VersionNumber, bool x64, out String FilePath)
        {
            try
            {
                if (Directory.Exists("zip")) { Directory.Delete("zip", true); }
                Directory.CreateDirectory("zip");
                string filepath = $"zip/Snip_{((x64 ? "x64_" : "x86_") + VersionNumber)}.zip";
                ZipFile.CreateFromDirectory(InPath, filepath, CompressionLevel.Fastest, false);
                
                FilePath = filepath;
                return true;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" - Error while creating archive!");
                Console.WriteLine(" - Error ->" + ex.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            FilePath = "";
            return false;
        }
    }
}
