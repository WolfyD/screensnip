using System.IO.Compression;
using System.Windows.Forms;
using WSH = IWshRuntimeLibrary;
using System.Linq;
using System.Net;
using System.IO;
using FluentFTP;
using System;

namespace PerpetualUpdater
{
    class UpdateManager
    {
        private FtpClient ftp = null;
        private string hash = "";

        public bool TryUpdate(bool IsManual = false)
        {
            if (CheckNewerExists())
            {
                string LatestVersion = Properties.Settings.Default.s_LatestVersion;
                string arch = Properties.Settings.Default.s_Architecture;
                string path = Properties.Settings.Default.s_Path;

                if (!IsManual)
                {
                    if (Properties.Settings.Default.s_SkipVersion == LatestVersion) { return false; }
                    if (Properties.Settings.Default.s_AskNext.Date > DateTime.Now.Date) { return false; }
                }

                DialogResult q_upd = DialogResult.No;

                if (!IsManual)
                {
                    q_upd = MessageBox.Show($"New update found.\r\nVersion number [{LatestVersion}]\r\nWould you like to update to this version?", "New update found!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }

                if (IsManual || !Properties.Settings.Default.s_AskBeforeUpdate || q_upd == DialogResult.Yes)
                {
                    if (ftp.DirectoryExists(LatestVersion))
                    {
                        try
                        {
                            ftp.SetWorkingDirectory(LatestVersion);

                            string filename = $"_{LatestVersion}.zip";

                            filename = (arch == "x86" ? "Snip_x86" : "Snip_x64") + filename;

                            ftp.DownloadFile(filename, filename, FtpLocalExists.Overwrite);

                            if (!Auxiliary.CompareMD5(hash, filename, out string cHash)) {
                                Console.WriteLine("Error! -> file hash not matching hash in version file...");
                                Console.WriteLine("Expected hash: " + hash);
                                Console.WriteLine("Calculated hash: " + cHash);
                                return false;
                            }

                            Properties.Settings.Default.s_LastDownload = DateTime.Now;

                            if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }
                            else
                            {
                                string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
                                foreach (string file in files)
                                {
                                    if (File.Exists(file))
                                    {
                                        File.Delete(file);
                                    }
                                }
                            }

                            ZipFile.ExtractToDirectory(filename, path);

                            Properties.Settings.Default.s_ArchitectureInstalled = arch;
                            Properties.Settings.Default.s_CurrentVersion = LatestVersion;
                            
                            HandleIcons();
                            return true;
                        }
                        catch (Exception ex) { Console.WriteLine("Error -> " + ex.Message); }
                    }
                }
                else if (q_upd == DialogResult.No)
                {
                    string msg = @"Would you like to skip this version entirely?

If you click yes, the updater won't
automatically update to this version,
but will still download it if you
click the [Check for Update] button manually";
                    if (MessageBox.Show(msg, "Skip version?",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Properties.Settings.Default.s_SkipVersion = LatestVersion;
                    }
                    else
                    {
                        Properties.Settings.Default.s_AskNext = DateTime.Now.AddDays(1);
                    }
                    Properties.Settings.Default.Save();
                }
            }
            else
            {
                Console.WriteLine("No new update found.");
                Console.WriteLine($"Current version: {Properties.Settings.Default.s_CurrentVersion}");
            }

            return false;
        }

        public void HandleIcons()
        {
            if (!Properties.Settings.Default.s_CreateIcon)
            { return; }
             
            if(!CheckIfIconExists())
            {
                CreateIcon();
            }
        }

        public bool CheckIfIconExists()
        {
            string dt = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            return File.Exists(dt + "\\ScreenSnip.lnk");
        }

        public void CreateIcon()
        {
            string dt = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            dt += "\\ScreenSnip.lnk";

            string shortcutLocation = dt;
            WSH.WshShell shell = new WSH.WshShell();
            WSH.IWshShortcut shortcut = (WSH.IWshShortcut)shell.CreateShortcut(shortcutLocation);
            shortcut.Description = "WolfPaw Screen Snipper tool";
            shortcut.TargetPath = Properties.Settings.Default.s_Path + "\\WolfPaw ScreenSnip.exe";
            shortcut.Save();
        }

        public bool CheckNewerExists()
        {
            var lv = GetVersionNumber();
            Properties.Settings.Default.s_LastCheck = DateTime.Now;
            Properties.Settings.Default.Save();
            string cv = Properties.Settings.Default.s_CurrentVersion;

            if (cv == "" || !Version.TryParse(cv, out Version ver))
            {
                return true;
            }
            else
            {   
                return ver < lv;
            }
        }

        public Version GetVersionNumber()
        {
            ftp.DownloadFile("v.txt", "v.txt", FtpLocalExists.Overwrite, FtpVerify.None);
            string version = File.ReadAllLines("v.txt").Where(x=>x.StartsWith("#") == false).FirstOrDefault();
            hash = File.ReadAllLines("v.txt").Where(x => x.StartsWith("# " + Properties.Settings.Default.s_Architecture)).FirstOrDefault();
            hash = hash.Replace("# x64 - ", "").Replace("# x86 - ", "");
            version = version.Trim();

            if(Version.TryParse(version, out Version ver))
            {
                Properties.Settings.Default.s_LatestVersion = ver.ToString();
                Properties.Settings.Default.Save();
                return ver;
            }
            else
            {
                return null;
            }
        }

        public bool ConnectFtp(string Username, string Password, string Address)
        {
            var creds = new NetworkCredential(Username, Password);
            try
            {
                ftp = new FtpClient(Address, creds);
                ftp.Connect();
                ftp.SocketKeepAlive = true;
                ftp.DataConnectionType = FtpDataConnectionType.PASV;
                Console.WriteLine("FTP connected...");
                Console.WriteLine("Current Working Dir: " + ftp.GetWorkingDirectory());
                return true;
            }
            catch (Exception ex) { Console.WriteLine("Error -> " + ex.Message); }
            return false;
        }

        public void DisconnectFTP()
        {
            if (ftp.IsConnected)
            {
                try
                {
                    ftp.Disconnect();
                    Console.WriteLine("FTP disconnected successfully...");
                }
                catch (Exception ex) { Console.WriteLine("Error -> " + ex.Message); }
            }

            try
            {
                ftp.Dispose();
            }
            catch (Exception ex) { Console.WriteLine("Error -> " + ex.Message); }
        }
    }
}
