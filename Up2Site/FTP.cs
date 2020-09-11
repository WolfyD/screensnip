using System;
using System.IO;
using System.Net;
using FluentFTP;

namespace Up2Site
{
    public class FTP
    {
        private FtpClient ftp = null;
        private readonly String _address;
        private readonly String _username;
        private readonly String _password;
        private readonly String _version;

        /// <summary>
        /// Initiates the FTP class
        /// </summary>
        /// <param name="UN">UserName</param>
        /// <param name="PWD">Password</param>
        /// <param name="ADDR">Host Address</param>
        /// <param name="DIR">Directory in versions folder</param>
        /// <param name="FIL">List of uploadable files</param>
        public FTP(string UN, string PWD, string ADDR, string DIR)
        {
            _address  = ADDR;
            _username = UN;
            _password = PWD;
            _version  = DIR;
        }

        /// <summary>
        /// Handles the process of updating the version file 
        /// and uploading the files to the new versioned directory
        /// </summary>
        public bool Update(string x64, string x86)
        {
            try
            {
                ConnectToFtp(_address, _username, _password);
                CreateVersionFile(_version, x86, x64);
                UploadVersionFile();

                if (CheckVersionFileExists())
                {
                    if (CreateFolder(_version))
                    {
                        UploadVersionFile(_version + "/" + _version + ".txt");
                        DeleteVersionFile();
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine("Error -> " + ex.Message); }
            return false;
        }

        /// <summary>
        /// Uploads file to current working directory
        /// </summary>
        public bool Upload(string _file)
        {
            try
            {
                if (UploadFile(_file, _version))
                {
                    return true;
                }
            }
            catch (Exception ex) { Console.WriteLine("Error -> " + ex.Message); }
            return false;
        }

        /// <summary>
        /// Checks if the v.txt file exists on the FTP server /versions folder
        /// </summary>
        private bool CheckVersionFileExists()
        {
            return ftp.FileExists("v.txt");
        }

        /// <summary>
        /// Deletes the v.txt file
        /// </summary>
        private void DeleteVersionFile()
        {
            File.Delete("v.txt");
        }

        /// <summary>
        /// Uploads file v.txt to current working directory
        /// </summary>
        private void UploadVersionFile(string name = "v.txt")
        {
            try
            {
                ftp.UploadFile("v.txt", name, FtpRemoteExists.Overwrite);

                Console.WriteLine("File uploaded to FTP successfully...");
            }
            catch (Exception ex) { Console.WriteLine("Error -> " + ex.Message); }
        }

        /// <summary>
        /// Creates file v.txt containing latest version number
        /// </summary>
        private void CreateVersionFile(string VersionNumber, string x86, string x64)
        {
            try
            {
                string vn = GetVersionNum.GetVNWithHashes(x86, x64, VersionNumber);

                File.WriteAllText("v.txt", vn);
            }
            catch (Exception ex) { Console.WriteLine("Error -> " + ex.Message); }
        }

        /// <summary>
        /// Creates folder on FTP. Returns true if folder created or already exists
        /// </summary>
        private bool CreateFolder(string Version)
        {
            try
            {
                if (!ftp.DirectoryExists(Version))
                {
                    if (ftp.CreateDirectory(Version, true))
                    {
                        Console.WriteLine("Success!");
                        Console.WriteLine($"Directory created: {ftp.Host}/{Version}");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Failure!");
                        Console.WriteLine($"Directory could not be created: {ftp.Host}/{Version}");
                        Console.WriteLine("Message from server:" + ftp.LastReply.Message);
                    }
                }
                else
                {
                    ftp.SetWorkingDirectory(Version);
                    Console.WriteLine("Skipped directory creation...");
                    Console.WriteLine($"Directory [ {ftp.GetWorkingDirectory()} ] already exists!");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        /// <summary>
        /// Connects to FTP
        /// </summary>
        private bool ConnectToFtp(string Address, string Username, string Password)
        {
            var creds = new NetworkCredential(Username, Password);
            try
            {
                ftp = new FtpClient(Address, creds);
                ftp.Connect();
                ftp.SetWorkingDirectory("./versions");
                ftp.SocketKeepAlive = true;
                ftp.DataConnectionType = FtpDataConnectionType.PASV;
                Console.WriteLine("FTP connected...");
                Console.WriteLine("Current Working Dir: " + ftp.GetWorkingDirectory());
                return true;
            }
            catch(Exception ex) { Console.WriteLine("Error -> " + ex.Message); }
            return false;
        }

        /// <summary>
        /// Disconnects FTP
        /// </summary>
        public void DisconnectFtp()
        {
            if (ftp.IsConnected)
            {
                try
                {
                    ftp.Disconnect();
                    Console.WriteLine("FTP disconnected successfully..."); 
            }
                catch(Exception ex) { Console.WriteLine("Error -> " + ex.Message); }
            }

            try
            {
                ftp.Dispose();
            }
            catch(Exception ex) { Console.WriteLine("Error -> " + ex.Message); }
        }

        /// <summary>
        /// Uploads _file to _folder on FTP
        /// </summary>
        /// <returns></returns>
        private bool UploadFile(string _file, string _folder)
        {
            try
            {
                string fn = _file.Substring(_file.LastIndexOf("/") + 1);
                string ldir = Environment.CurrentDirectory + "/" + _file;
                ftp.UploadFile(ldir, _folder + "/" + fn, FtpRemoteExists.Overwrite);
                return true;
            }
            catch (Exception ex) { Console.WriteLine("Error -> " + ex.Message); }
            return false;
        }
    }
}
