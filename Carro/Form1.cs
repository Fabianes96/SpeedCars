using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carro
{
    public partial class Form1 : Form
    {
        List<PictureBox> ListaObstaculos = new List<PictureBox>();
        List<PictureBox> ListaObstaculos2 = new List<PictureBox>();
        Random RnTipoObstaculo = new Random();
        int velocidad1 = 5;
        int velocidad2 = 5;       
        int totalPuntos1;
        int totalPuntos2;

        
        public Form1()
        {
            InitializeComponent();
            lblpuntos.Text = "0";
            lblPuntos2.Text = "0";
            CrearObstaculo(ListaObstaculos, this, 10, 80);
            CrearObstaculo(ListaObstaculos2, this, 180, 250);

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
                            ListaObstaculos2.Remove(ListaObstaculos2[i]);
                        }
                        else
                        {
                            Controls.Remove(ListaObstaculos2[i]);
                            ListaObstaculos2.Remove(ListaObstaculos2[i]);
                            velocidad2 = 5;
                            int totalPuntos2 = int.Parse(lblPuntos2.Text) - 1;
                            lblPuntos2.Text = totalPuntos2.ToString();
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
                            ListaObstaculos.Remove(ListaObstaculos[i]);
                        }
                        else
                        {
                            Controls.Remove(ListaObstaculos[i]);
                            ListaObstaculos.Remove(ListaObstaculos[i]);
                            velocidad1 = 5;
                            totalPuntos1 = int.Parse(lblpuntos.Text) - 1;
                            lblpuntos.Text = totalPuntos1.ToString();
                        }
                    }              
                }
            }
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
