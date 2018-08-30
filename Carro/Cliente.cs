using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;

namespace Carro
{
    class Cliente
    {
        private Socket cliente;
        private NetworkStream oss;
        private NetworkStream iss;
        private BinaryReader br;
        private BinaryWriter bw;
        private int puerto = 2027;
        //"localhost";
        private Form form;
        private string mensaje;
        public Cliente(Form f1, string host, string m )
        {
            try
            {
                mensaje = m;
                form = f1;                
                cliente = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint dirCliente = new IPEndPoint(IPAddress.Parse(host), puerto);
                cliente.Connect(dirCliente);
                //oss = new NetworkStream(cliente);
                //iss = new NetworkStream(cliente);
                //br = new BinaryReader(iss);
                //bw = new BinaryWriter(oss);
                //form.Show();
            }
            catch (Exception e)
            {                
                MessageBox.Show(e.ToString());
            }
        }

        public void enviar(string men)
        {
            while (true)
            {
                cliente.Send(Encoding.ASCII.GetBytes(men), 0, men.Length, SocketFlags.None);
                byte[] mensajeServidor = new byte[1024];
                int size =cliente.Receive(mensajeServidor);

            }
        }
       

    }
}
