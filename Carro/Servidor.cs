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
        private bool turnos;
        private Form form;

        public void escuchar(string ip, Form f1)
        {
            try
            {
                form = f1;
                Socket servidor = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint direccion = new IPEndPoint(IPAddress.Parse(ip),puerto);
                servidor.Bind(direccion);
                servidor.Listen(1);//Escuchando              

                //ciclo infinito esperando jugadores...
                while (true)
                {
                    
                    Socket cliente = servidor.Accept();
                    usuarios.AddLast(cliente);
                    BaseThread bt = new HiloServidor(cliente, usuarios);
                    Thread hilo = new Thread(bt.Start);
                    hilo.Start();

                }
            }
            catch (Exception x)
            {

                MessageBox.Show(x.ToString());
            }
        }
    }
}
