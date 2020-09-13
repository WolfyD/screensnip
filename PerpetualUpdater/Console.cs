using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerpetualUpdater
{
    public class Console
    {
        private static TextBox tb { get; set; }
        public TextBox TextBox { get { return tb; } set { tb = value; } }

        public static void WriteLine(string line)
        {
            if (line.Contains("Error"))
            {
                tb.Text += "\r\n=============== !! ERROR !! ===============\r\n";
                tb.Text += line + "\r\n";
                tb.Text += "===========================================\r\n";
            }
            else
            {
                tb.Text += line + "\r\n";
            }


            try
            {
                if (!File.Exists("log.txt"))
                {
                    File.Create("log.txt").Close();
                }

                if (line.Contains("Error"))
                {
                    File.AppendAllText("log.txt", "=============== !! ERROR !! ===============\r\n");
                    File.AppendAllText("log.txt", GetDT() + " - " + line + "\r\n");
                    File.AppendAllText("log.txt", "===========================================\r\n");
                }
                else
                {
                    File.AppendAllText("log.txt", GetDT() + " - " + line + "\r\n");
                }
            }
            catch (Exception ex)
            {
                tb.Text += "\r\n\r\n!!!!!!!!\r\n";
                tb.Text += "Error while saving log file!";
            }
        }

        private static string GetDT()
        {
            return DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
        }
    }
}
