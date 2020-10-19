using FotoCek.Business.Abstract;
using FotoCek.Business.Concrete;
using System;
using System.Net.Sockets;
using System.Windows.Forms;


namespace FotoCekimi
{
    public partial class ServerForm : Form
    {
        private SimpleTCPServerListener TCPListenerServer;

        public ServerForm()
        {
            InitializeComponent();
            
            INIReadWrite.readWriteIniFile();

            TCPListenerServer = new SimpleTCPServerListener();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            SettingForm settingForm=new SettingForm();
            settingForm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTarih.Text = DateTime.Now.ToString();
        }
    }
  
}