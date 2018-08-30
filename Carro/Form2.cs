using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;



namespace Carro
{    public partial class Form2 : Form
    {
        private Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        byte[] receivedBuf = new byte[1024];
       // Form1 f1 = new Form1();
        Label label;
        public Form2()
        {            
            
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

        }
        private void Conectar()
        {
            try
            {
                int attempts = 0;
                while (!_clientSocket.Connected)
                {
                    try
                    {
                        attempts++;
                        _clientSocket.Connect(IPAddress.Loopback, 100);
                        
                    }
                    catch (SocketException)
                    {
                        //Console.Clear();
                        label3.Text = ("Conexión fallida: " + attempts.ToString());
                    }
                }
                label3.Text = ("Conectado!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }
        private void ReceiveData(IAsyncResult ar)
        {
            try
            {
                Socket socket = (Socket)ar.AsyncState;
                int received = socket.EndReceive(ar);
                byte[] dataBuf = new byte[received];
                Array.Copy(receivedBuf, dataBuf, received);
                label4.Text = (Encoding.ASCII.GetString(dataBuf));
                //rb_chat.AppendText("\nServer: " + lb_stt.Text);            
                _clientSocket.BeginReceive(receivedBuf, 0, receivedBuf.Length, SocketFlags.None, new AsyncCallback(ReceiveData), _clientSocket);

            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }
            
        }
        private void enviarPuntos()
        {
            //string a = f1.lblpuntos.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Conectar();
            _clientSocket.BeginReceive(receivedBuf, 0, receivedBuf.Length, SocketFlags.None, new AsyncCallback(ReceiveData), _clientSocket);
            byte[] buffer = Encoding.ASCII.GetBytes(txtNombre.Text);
            _clientSocket.Send(buffer);
            // f1.timer3.Enabled = true;
            // f1.timer1.Enabled = true;
            // f1.timer2.Enabled = true;
            // Label l = new Label();
            //// Label ll = new Label();
            // l.Height = 13;
            // l.Width = 35;
            // l.Location = new Point(0,0);
            // //ll.Location = new Point(l.Width,0);
            // //y=20, x =
            // l.BackColor = Color.Transparent;

            // //ll.Text = "ddse";           
            // l.Text = "o";            
            // //f1.Controls.Add(l);

            // //f1.panel1.Controls.Add(ll);
            // f1.Show();


            //_clientSocket.BeginReceive(receivedBuf, 0, receivedBuf.Length, SocketFlags.None, new AsyncCallback(ReceiveData), _clientSocket);
            //byte[] buffer = Encoding.ASCII.GetBytes(txtNombre.Text);
            //_clientSocket.Send(buffer);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
