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
{
    public partial class Form2 : Form
    {
        Form1 f1 = new Form1();
        
        public Form2()
        {            
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Servidor ser = new Servidor();
            ser.escuchar(textBox1.Text,f1);
            //label1.Text = "conectado";
            //f1.Show();       
            //Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cliente cli = new Cliente(f1,textBox2.Text);
            label2.Text = "conectado";
            
            //f1.Show();
        //    Hide();
        }
    }
}
