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
using static System.Console;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UdpClient cli = new UdpClient();

            string msg = "<01#RCS";
            string msgg = "**";
            string e1 = textBox4.Text;
            string e2 = textBox5.Text;
            string e3 = textBox6.Text;


            //string mss = "Cr";
            byte[] datagram = Encoding.UTF8.GetBytes(String.Format(msg + e1 + e3 + msgg + (char)0x0D));


            // (2) 데이타 송신
            cli.Send(datagram, datagram.Length, "127.0.0.1", 8000);
            WriteLine("[Send] 127.0.0.1:7777 로 {0} 바이트 전송", datagram.Length);

            // (3) 데이타 수신
            IPEndPoint epRemote = new IPEndPoint(IPAddress.Any, 0);
            byte[] bytes = cli.Receive(ref epRemote);
            WriteLine("[Receive] {0} 로부터 {1} 바이트 수신", epRemote.ToString(), bytes.Length);

            // (4) UdpClient 객체 닫기
            cli.Close();

        }


        private void button2_Click(object sender, EventArgs e)
        {
           

        }
    }
}
