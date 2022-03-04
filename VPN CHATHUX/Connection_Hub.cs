using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace VPN_CHATHUX
{
    public partial class Connection_Hub : Form
    {
        public Connection_Hub()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Server" && radioButton2.Checked)
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                startInfo.Arguments = "--config vpn.ovpn";
                startInfo.Verb = "runas";
                process.StartInfo = startInfo;
                process.Start();
                MessageBox.Show("You've connected to server with UDP");

            }
            else if (comboBox1.Text == "Server" && radioButton1.Checked)
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                startInfo.Arguments = "--config vpn.ovpn";
                startInfo.Verb = "runas";
                process.StartInfo = startInfo;
                process.Start();
                MessageBox.Show("You've connected to server with TCP");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            disconnect();
        }

        private void disconnect()
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "taskkill",
                Arguments = $"/f /im openvpn.exe",
                CreateNoWindow = true,
                UseShellExecute = false
            }).WaitForExit();
        }
    }
}
