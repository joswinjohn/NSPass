using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.IO;
using System.Diagnostics;

namespace NSPass
{
    public partial class NSPass : Form
    {
        public NSPass()
        {
            InitializeComponent();
        }

        static TcpClient client = null;
        private void ClientConnect(string server, int port)
        {
            client = new TcpClient(server, port);
        }

        private void ClientMesage(string message, string server, int port)
        {
            if (message == null || message == "")
            {
                Logg("Invalid Domain");
                client.Close();
                return;
            }

            byte[] data = Encoding.ASCII.GetBytes(message);

            NetworkStream stream = client.GetStream();

            stream.Write(data, 0, data.Length);
            Logg(" {CONNECTION} Server Address: " + server + " Port: " + port);
            Logg("Sent: " + message);

            data = new Byte[256];

            try
            {
                int bytes = stream.Read(data, 0, data.Length);
                string responseData = Encoding.ASCII.GetString(data, 0, bytes);

                if (responseData == "0")
                {
                    Logg("Could not connect to DNS Server");
                    client.Close();
                    return;
                }
                if (WriteToStor(responseData, message))
                {
                    Logg("Writing Completed");
                } else
                {
                    Logg("{ERROR} Writing Failed");
                }
                Logg(Color.Green, " {RECEIVING} DNS Server Address:" + responseData + " For Domain: " + message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Logg("{ERROR} Writing Error, Denied Access");
                client.Close();
                return;
            }

            client.Close();
        }

        private bool ControlChecks()
        {
            if (serverBox.Text == null || serverBox.Text == "")
            {
                Logg("Invalid NSPass Server Address");
                return false;
            }

            if (domainBox.Text == null || domainBox.Text == "")
            {
                Logg("Invalid Domain");
                return false;
            }

            if (portBox.Text == null || portBox.Text == "")
            {
                Logg("Invalid NSPass Server Port");
                return false;
            }
            return true;
        }

        private void onButton_Click(object sender, EventArgs e)
        {
            if (ControlChecks())
            {
                string address = serverBox.Text;
                int port = int.Parse(portBox.Text);
                string domain = domainBox.Text;

                BlockedCheck(domain);

                Logg("Starting... ");
                ClientConnect(address, port);
                ClientMesage(domain, address, port);

                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nspass.cache");
                CacheObj cache = new CacheObj
                {
                    Server = address,
                    Port = port.ToString(),
                    Domain = domain,
                };

                File.WriteAllText(path, Newtonsoft.Json.JsonConvert.SerializeObject(cache, Newtonsoft.Json.Formatting.Indented));
            }
        }

        void Logg(params string[] messages)
        {
            foreach (string message in messages)
            {
                consoleBox.Text += "\n[" + DateTime.Now.ToString() + "] " + message + " ";
            }
        }

        void Logg(Color color, string message)
        {
            consoleBox.SelectionStart = consoleBox.TextLength;
            consoleBox.SelectionLength = 0;

            consoleBox.SelectionColor = color;
            consoleBox.SelectionFont = new Font(consoleBox.Font, FontStyle.Bold);

            consoleBox.AppendText("\n[" + DateTime.Now.ToString() + "] " + message + " ");
            consoleBox.SelectionColor = consoleBox.ForeColor;
        }

        private bool WriteToStor(string address, string domain)
        {
            string currentTime = DateTime.Now.ToString();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "hosts.txt");
            string previousTxt = File.ReadAllText(path);

            string writeTxt = String.Format("{0}\t{1}", address, domain);

            Logg(path);
            
            try
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                }
                
                if (previousTxt.Contains(writeTxt))
                {
                    return true;
                }
                else
                {
                    File.WriteAllText(path, previousTxt + "\n\n# " + currentTime + "\n\n" + writeTxt);
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            
        }

        static bool blocked;

        void BlockedCheck(string domain)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            options.DontFragment = true;

            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;

            try
            {
                PingReply reply = pingSender.Send(domain, timeout, buffer, options);
                if (reply.Status == IPStatus.Success)
                {
                    blocked = false;
                }
                else
                {
                    blocked = true;
                }
            }
            catch
            {
                blocked = true;
            }

            if (blocked)
            {
                blockCheck.ForeColor = Color.Red;
                blockCheck.Text = "Blocked";
            } else
            {
                blockCheck.ForeColor = Color.Green;
                blockCheck.Text = "Not Blocked";
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Stream saveStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((saveStream = saveFileDialog1.OpenFile()) != null)
                {
                    string hostPath = @"C:\WINDOWS\System32\Drivers\etc\hosts";
                    string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "hosts.txt");

                    string rawTxt = File.ReadAllText(hostPath) + "\n\n" + DateTime.Now.ToString() + File.ReadAllText(path);
                    byte[] buffer = Encoding.ASCII.GetBytes(rawTxt);
                    saveStream.Write(buffer, 0, buffer.Length);

                    saveStream.Close();
                }
            }
        }

        private void NSPass_Load(object sender, EventArgs e)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nspass.cache");
            if (!File.Exists(path))
            {
                File.CreateText(path);
            } 
            else if (File.ReadAllText(path) == "" || File.ReadAllText(path) == null)
            {

            }
            else
            {
                string rawTxt = File.ReadAllText(path);
                CacheObj cache = Newtonsoft.Json.JsonConvert.DeserializeObject<CacheObj>(rawTxt);

                serverBox.Text = cache.Server;
                portBox.Text = cache.Port;
                domainBox.Text = cache.Domain;
            }
        }
    }

    public class CacheObj 
    { 
        public string Server { get; set; }
        public string Port { get; set; }
        public string Domain { get; set; }
    }

}
