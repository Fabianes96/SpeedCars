using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Carro
{
    
    class Servidor
    {
        private readonly int puerto = 2027;
        private readonly int nroConexiones = 2;
        private LinkedList<Socket> usuarios = new LinkedList<Socket>();
        private string mensaje;
        private int turno = 1;
        private bool conectado;
        private Form form;

        public void escuchar(string ip, Form f1, Label l)
        {
            try
            {
                form = f1;
                Socket servidor = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint direccion = new IPEndPoint(IPAddress.Parse(ip),puerto);
                servidor.Bind(direccion);
                servidor.Listen(1);//Escuchando              
                Socket cliente = default(Socket);
                int contador = 0;
                //ciclo infinito esperando jugadores...
                while (true)
                {
                    contador++;
                    cliente = servidor.Accept();
                    l.Text = contador.ToString()+" clientes conectados";                    
                    Thread hiloUsuario = new Thread(new ThreadStart(()=>usuario(cliente)));
                    hiloUsuario.Start();
                    //usuarios.AddLast(cliente);
                    //BaseThread bt = new HiloServidor(cliente, usuarios);
                    //Thread hilo = new Thread(bt.Start);
                    //hilo.Start();

                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }
        public void usuario(Socket c)
        {
            while (true)
            {
                byte[] msg = new byte[1024];
                int tamaño = c.Receive(msg);
                c.Send(msg, 0, tamaño, SocketFlags.None);
            }
        }        
        public void SendMessageToAllClients(string message)
        {
            if (!conectado)
                return;            

            for (int i = 0; i < usuarios.Count; i++)
            {
                if (usuarios.ElementAt(i).Connected)
                {
                    try
                    {
                        byte[] tobytes = Encoding.ASCII.GetBytes(message);
                        byte[] datas = tobytes;
                       // SendData((TcpClient)usuarios.ElementAt(i), message, 0);
                        
                    }
                    catch
                    {

                    }
                }
            }
        }
    }
}
