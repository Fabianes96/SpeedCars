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

namespace Carro
{
    public partial class Form1 : Form
    {
        List<PictureBox> ListaObstaculos = new List<PictureBox>();
        List<PictureBox> ListaObstaculos2 = new List<PictureBox>();
        Random RnTipoObstaculo = new Random();
        private Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        byte[] receivedBuf = new byte[1024];
        int contadorFinal = 0;
        int contadorJugadores = 0;
        int velocidad1 = 5;
        int velocidad2 = 5;       
        int totalPuntos1;
        int totalPuntos2;
        int tp = 0;
        int miPuntaje=0;
        int maxPuntaje=-10000;
        string texto;
        string direccion ="192.168.0.14";
        public Form1()
        {
            //direccion = Microsoft.VisualBasic.Interaction.InputBox("Escriba la IP",
            //    "Texto del dialogo", "");
           // IPEndPoint miDireccion = new IPEndPoint(IPAddress.Parse(dire));
            texto = Microsoft.VisualBasic.Interaction.InputBox(
                "Escriba un nombre", "Texto del dialogo", "");
            if (texto.Contains(" ")) { texto = texto.Replace(' ', '_'); }
            CheckForIllegalCrossThreadCalls = false;
            Conectar();
            _clientSocket.BeginReceive(receivedBuf, 0, receivedBuf.Length, SocketFlags.None, new AsyncCallback(ReceiveData), _clientSocket);
            byte[] buffer = Encoding.ASCII.GetBytes(texto);
            _clientSocket.Send(buffer);
            InitializeComponent();
            timer3.Enabled = true;
            timer1.Enabled = true;
            timer2.Enabled = true;
            lblpuntos.Text = "0";
            lblPuntos2.Text = "0";
            CrearObstaculo(ListaObstaculos, this, 10, 80);
            CrearObstaculo(ListaObstaculos2, this, 180, 250);

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
                        //_clientSocket.Connect(IPAddress.Loopback, 100);
                        IPEndPoint ienp = new IPEndPoint(IPAddress.Parse(direccion),2027);
                        _clientSocket.Connect(ienp);
                    }
                    catch (SocketException)
                    {                        
                        MessageBox.Show("Conexión fallida: ");
                        Application.Exit();
                    }
                }                
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
                string texto = (Encoding.ASCII.GetString(dataBuf));                
                if (texto.Contains("°"))
                {
                    string aux = texto.Substring(texto.IndexOf("°")+1);
                    contadorFinal++;
                    MessageBox.Show("Aqui pas´´e");
                    if (maxPuntaje< int.Parse(aux))
                    {
                        maxPuntaje = int.Parse(aux);
                    }                    
                }
                
                if (texto.Contains(": "))
                {
                    lblScoreFinal.Text = texto + Environment.NewLine;
                }
                else
                {

                    label2.Text = texto+ Environment.NewLine;
                    contadorJugadores++;
                   
                    //rbPuntaje.AppendText("\nServer: " + label2.Text);              
                }
                _clientSocket.BeginReceive(receivedBuf, 0, receivedBuf.Length, SocketFlags.None, new AsyncCallback(ReceiveData), _clientSocket);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void enviarPuntaje(IAsyncResult ar)
        {
            try
            {
                Socket socket = (Socket)ar.AsyncState;
                int received = socket.EndReceive(ar);
                byte[] dataBuf = new byte[received];
                Array.Copy(receivedBuf, dataBuf, received);
                lblPuntuacion.Text = (Encoding.ASCII.GetString(dataBuf)) + Environment.NewLine;                           
                _clientSocket.BeginReceive(receivedBuf, 0, receivedBuf.Length, SocketFlags.None, new AsyncCallback(enviarPuntaje), _clientSocket);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }
        private void notificarDesconeccion(IAsyncResult ar)
        {
            try
            {
                Socket socket = (Socket)ar.AsyncState;
                int received = socket.EndReceive(ar);
                byte[] dataBuf = new byte[received];
                Array.Copy(receivedBuf, dataBuf, received);
                label5.Text = Encoding.ASCII.GetString(dataBuf);
                _clientSocket.BeginReceive(receivedBuf, 0, receivedBuf.Length, SocketFlags.None, new AsyncCallback(notificarDesconeccion), _clientSocket);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (PictureBox ImagenCarro in ListaObstaculos2)
            {
                int MovimientoY;
                MovimientoY = ImagenCarro.Location.Y;
                MovimientoY = MovimientoY + velocidad2;
                ImagenCarro.Location = new Point(ImagenCarro.Location.X, MovimientoY);
            }
            if (ListaObstaculos2.Count > 0)
            {
                if (ListaObstaculos2[(ListaObstaculos2.Count) - 1].Location.Y > 250)
                {
                    CrearObstaculo(ListaObstaculos2, this, 180, 250);
                }
            }
            if (ListaObstaculos2.Count > 0)
            {
                for (int i = 0; i < ListaObstaculos2.Count; i++)
                {
                    if (ListaObstaculos2[i].Location.Y > 400)
                    {
                        if (ListaObstaculos2[i].Tag.ToString() == "1_1")
                        {
                            velocidad2=5;
                        }
                        Controls.Remove(ListaObstaculos2[i]);
                        ListaObstaculos.Remove(ListaObstaculos2[i]);
                    }
                    if (ListaObstaculos2[i].Bounds.IntersectsWith(carro2.Bounds))
                    {
                        if (ListaObstaculos2[i].Tag.ToString() == "1_2")
                        {
                            Controls.Remove(ListaObstaculos2[i]);
                            
                            totalPuntos2 = int.Parse(lblPuntos2.Text) + 1;
                           
                            if (totalPuntos2 % 2 == 0)
                            {
                                velocidad2++;
                            }
                            
                            lblPuntos2.Text = totalPuntos2.ToString();
                            tp += int.Parse(lblPuntos2.Text);
                            lblPuntuacion.Text = tp.ToString();
                            //int tp= int.Parse(lblPuntuacion.Text) +totalPuntos2;
                            //lblPuntuacion.Text = tp.ToString();
                            ListaObstaculos2.Remove(ListaObstaculos2[i]);
                        }
                        else
                        {
                            Controls.Remove(ListaObstaculos2[i]);
                            ListaObstaculos2.Remove(ListaObstaculos2[i]);
                            velocidad2 = 5;
                            int totalPuntos2 = int.Parse(lblPuntos2.Text) - 1;
                            lblPuntos2.Text = totalPuntos2.ToString();
                            tp += int.Parse(lblPuntos2.Text);
                            lblPuntuacion.Text = tp.ToString();
                            //int tp = int.Parse(lblPuntuacion.Text) + totalPuntos2;
                            //lblPuntuacion.Text =tp.ToString();
                        }
                    }
                }
            }
        }
        public void CrearObstaculo(List<PictureBox> ListaElementos, Form panelJuegoUno, int distanciaUno, int distanciaDos)
        {
            int NumeroCarro = 1;
            int TipoObstaculo = RnTipoObstaculo.Next(1, 3);
            int UbicacionObstaculo = RnTipoObstaculo.Next(1, 3);
            int DistanciaUbicacionObstaculo = (UbicacionObstaculo == 1) ? distanciaUno : distanciaDos;
            PictureBox pb = new PictureBox();
            pb.Location = new Point(DistanciaUbicacionObstaculo, 0);
            pb.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("Obstaculo" + NumeroCarro + TipoObstaculo);
            pb.BackColor = Color.Transparent;
            pb.Tag = NumeroCarro + "_" + TipoObstaculo;
            pb.SizeMode = PictureBoxSizeMode.AutoSize;
            ListaElementos.Add(pb);
            panelJuegoUno.Controls.Add(pb);

        }
        
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int CambioCarro = (carro1.Location.X == 80) ? 10 : 80;
            carro1.Location = new Point(CambioCarro, carro1.Location.Y);

            int CambioCarro2 = (carro2.Location.X == 230) ? 165 : 230;
            carro2.Location = new Point(CambioCarro2, carro2.Location.Y);
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            
            foreach (PictureBox ImagenCarro in ListaObstaculos)
            {
                int MovimientoY;
                MovimientoY = ImagenCarro.Location.Y;
                MovimientoY = MovimientoY + velocidad1;
                ImagenCarro.Location = new Point(ImagenCarro.Location.X, MovimientoY);
            }
            if (ListaObstaculos.Count>0 )
            {
                if (ListaObstaculos[(ListaObstaculos.Count)-1].Location.Y>250)
                {
                    CrearObstaculo(ListaObstaculos, this, 10, 80);
                    
                }
            }
            if (ListaObstaculos.Count>0)
            {
                for (int i = 0; i < ListaObstaculos.Count; i++)
                {
                    if (ListaObstaculos[i].Location.Y>400)
                    {
                        if (ListaObstaculos[i].Tag.ToString()=="1_1")
                        {
                            velocidad1 = 5;                            
                        }
                        Controls.Remove(ListaObstaculos[i]);
                        ListaObstaculos.Remove(ListaObstaculos[i]);
                    }
                    if (ListaObstaculos[i].Bounds.IntersectsWith(carro1.Bounds))
                    {
                        if (ListaObstaculos[i].Tag.ToString()=="1_2")
                        {
                            Controls.Remove(ListaObstaculos[i]);
                            totalPuntos1= int.Parse(lblpuntos.Text)+1;                           

                            if (totalPuntos1 %2==0)
                            {
                                velocidad1++;
                            }
                            
                            lblpuntos.Text = totalPuntos1.ToString();
                            //tp = int.Parse(lblpuntos.Text);
                            tp += int.Parse(lblpuntos.Text);                           
                            lblPuntuacion.Text =tp.ToString();
                            ListaObstaculos.Remove(ListaObstaculos[i]);
                        }
                        else
                        {
                            Controls.Remove(ListaObstaculos[i]);
                            ListaObstaculos.Remove(ListaObstaculos[i]);
                            velocidad1 = 5;
                            totalPuntos1 = int.Parse(lblpuntos.Text) - 1;
                            lblpuntos.Text = totalPuntos1.ToString();
                            //tp = int.Parse(lblpuntos.Text);
                            tp += int.Parse(lblpuntos.Text);
                            lblPuntuacion.Text = tp.ToString();
                            lblPuntuacion.Text = tp.ToString();
                        }
                    }              
                }
            }
            
        }        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
                               
            //_clientSocket.Close();            
            Application.Exit();
        }
        int seg;        
        int min=0;
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (seg==60)
            {
                min++;
                seg = 0;
            }
            seg += 1;
            lblTiempo.Text = seg.ToString();
            
            if (min == 1)
            {
                finJuego();
            }
        }
        void finJuego()
        {
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            miPuntaje = int.Parse(lblPuntuacion.Text);
            MessageBox.Show("Fin del juego, espere el resultado");            
            _clientSocket.BeginReceive(receivedBuf, 0, receivedBuf.Length, SocketFlags.None, new AsyncCallback(enviarPuntaje), _clientSocket);
            byte[] buffer = Encoding.ASCII.GetBytes(texto + ": " + lblPuntuacion.Text);
            _clientSocket.Send(buffer);
            MessageBox.Show(contadorFinal.ToString()+ " " + contadorJugadores.ToString() );
            
            //while (true)
            //{//arreglar esto
            //    if (contadorFinal == contadorJugadores)
            //    {
            //        if (ganador())
            //        {
            //            MessageBox.Show("Felicidades, ha ganado");
            //        }
            //        else
            //        {
            //            MessageBox.Show("Ha perdido");
            //        }
            //        break;
            //    }
            //}
        }
        bool ganador()
        {
            bool ganador=true;
            if (maxPuntaje > miPuntaje)
            {
                ganador = false;
            }
            return ganador;
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
