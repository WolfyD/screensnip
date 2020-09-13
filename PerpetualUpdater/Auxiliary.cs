using FluentFTP;
using Microsoft.Win32;
using System;

namespace PerpetualUpdater
{
    public static class Auxiliary
    {
        public static void SetSWW(bool SetToOn)
        {
            var reg = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            if (SetToOn)
            {
                reg.SetValue("WolfPaw_PerpetualUpdater",Environment.CurrentDirectory + "\\PerpetualUpdater.exe");
                Properties.Settings.Default.s_SWW = true;
            }
            else
            {
                reg.DeleteValue("WolfPaw_PerpetualUpdater");
                Properties.Settings.Default.s_SWW = false;
            }
            Properties.Settings.Default.Save();
        }

        public static bool CompareMD5(string hash, string path, out string cHash)
        {
            cHash = GetMD5HashForFile(path);

            return cHash == hash;
        }

        public static string GetMD5HashForFile(String Path)
        {
            byte[] filebytes = System.IO.File.ReadAllBytes(Path);
            byte[] md5bytes = System.Security.Cryptography.MD5CryptoServiceProvider.Create().ComputeHash(filebytes, 0, filebytes.Length);
            string md5 = "";
            foreach (byte b in md5bytes)
            {
                md5 += b.ToString("X2").ToUpper();
            }

            return md5;
        }
    }
}
