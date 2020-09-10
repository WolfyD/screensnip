using System;
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

        public FTP(string UN, string PWD, string ADDR, string DIR)
        {
            _address  = ADDR;
            _username = UN;
            _password = PWD;
            _version  = DIR;
        }

        public bool Test()
        {
            return CreateFolder( _version);
        }

        private bool CheckVersionFileExists()
        {
            return false;
        }



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
                    Console.WriteLine("Skipped directory creation...");
                    Console.WriteLine($"Directory [ {ftp.Host}/{Version} ] already exists!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        private void ConnectToFtp(string Address, string Username, string Password)
        {
            var creds = new NetworkCredential(Username, Password);
            ftp = new FtpClient(Address, creds);
            ftp.Connect();
            ftp.SocketKeepAlive = true;
        }

        private void DisconnectFtp()
        {
            if (ftp.IsConnected)
            {
                try
                {
                    ftp.Disconnect();
                }
                catch
                {
                    ftp.Dispose();
                }
            }
            
        }

        public bool UploadFile()
        {
            //WebRequest req = WebRequest.Create($"{Address}/{Version}");
            //req.Credentials = new NetworkCredential(Username, Password);
            //req.Method = WebRequestMethods.Ftp.UploadFile;
            //using (var req_strm = (FtpWebResponse)req.GetResponse())
            //{
            //    Console.WriteLine(req_strm.StatusDescription);
            //}
            return false;
            
        }
    }
}
