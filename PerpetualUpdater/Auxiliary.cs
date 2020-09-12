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
    }
}
