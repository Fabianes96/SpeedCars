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
    class Cliente: BaseThread
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
        
     

        public Cliente(Form f1, string host)
        {
            try
            {
                form = f1;
                cliente = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint dirCliente = new IPEndPoint(IPAddress.Parse(host), puerto);
                cliente.Connect(dirCliente);
                oss = new NetworkStream(cliente);
                iss = new NetworkStream(cliente);
                br = new BinaryReader(iss);
                bw = new BinaryWriter(oss);
                form.Show();


            }
            catch (Exception)
            {                
                throw;
            }
        }
        public override void RunThread()
        {
            try
            {                
                mensaje = br.Read().ToString();
                
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }
        }

    }
}
