using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;

namespace Up2Site
{
    public static class GetVersionNum
    {
        public static string GetVersionNumber()
        {
            Properties.Settings.Default.s_x64_Folder = @"F:\[[STORAGE]]\[-PROJECTS]\Repos\screensnip\WolfPaw ScreenSnip\bin\x64";
            FileVersionInfo info = FileVersionInfo.GetVersionInfo(Properties.Settings.Default.s_x64_Folder + @"\Release\WolfPaw ScreenSnip.exe");
            return info.FileVersion;
        }

        public static string GetVNWithHashes(string x86Path, string x64Path, string VN)
        {
            string x86MD5 = GetMD5HashForFile(x86Path);
            string x64MD5 = GetMD5HashForFile(x64Path);

            string ret = $"{VN}\r\n# MD5\r\n# -----------------------------------------------\r\n" +
                $"# x86 - {x86MD5}\r\n" +
                $"# x64 - {x64MD5}\r\n" +
                "# -----------------------------------------------";

            return ret;
        }

        public static string GetMD5HashForFile(String Path)
        {
            byte[] filebytes = File.ReadAllBytes(Path);
            byte[] md5bytes = MD5CryptoServiceProvider.Create().ComputeHash(filebytes, 0, filebytes.Length);
            string md5 = "";
            foreach (byte b in md5bytes)
            {
                md5 += b.ToString("X2").ToUpper();
            }
            
            return md5;
        }
    }
}
