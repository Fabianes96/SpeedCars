using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Carro
{
    class HiloServidor: BaseThread
    {
        private Socket socket;
        private NetworkStream oss;
        private NetworkStream iss;
        private LinkedList<Socket> usuarios = new LinkedList<Socket>();
        private BinaryReader br;
        private BinaryWriter bw;
        //
        private bool turno;
        private int XO;

        public HiloServidor(Socket sc,LinkedList<Socket> us)
        {
            socket = sc;
            usuarios = us;
            

        }
        public override void RunThread()
        {
            try
            {
                iss = new NetworkStream(socket);
                oss = new NetworkStream(socket);
                ////////
                //turno = XO == 1;
                //string msg = "";
                //msg += "JUEGA: " + (turno ? "X;" : "O;");
                //msg += turno;
                //bw = new BinaryWriter(oss);
                //bw.Write(msg);                
            }
            catch (Exception)
            {
                for (int i = 0; i < usuarios.Count; i++)
                {
                    if (usuarios.ElementAt(i) == socket)
                    {
                        usuarios.Remove(usuarios.ElementAt(i));
                        break;
                    }
                }                
            }
        }
    }
}
