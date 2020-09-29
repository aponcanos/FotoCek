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
           
            TCPListenerServer.ClientConnected += ServerForm_ClientConnected;
            TCPListenerServer.DataReceived += ServerForm_DataReceived;
        }

        private void ServerForm_DataReceived(object sender, SimpleTCP.Message e)
        {
            MessageBox.Show("Test");
        }

        private void ServerForm_ClientConnected(object sender, TcpClient e)
        {
            MessageBox.Show("Test");
        }

        private void btnGetir_Click(object sender, EventArgs e)
        {
            

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            SettingForm settingForm=new SettingForm();
            settingForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbClients_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblTarih_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTarih.Text = DateTime.Now.ToString();
        }
    }

  
}