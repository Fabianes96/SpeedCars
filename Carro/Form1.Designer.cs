namespace Carro
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblpuntos = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.carro1 = new System.Windows.Forms.PictureBox();
            this.carro2 = new System.Windows.Forms.PictureBox();
            this.lblPuntos2 = new System.Windows.Forms.Label();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.lblTiempo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPuntuacion = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblScoreFinal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.carro1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carro2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblpuntos
            // 
            this.lblpuntos.AutoSize = true;
            this.lblpuntos.Location = new System.Drawing.Point(9, 52);
            this.lblpuntos.Name = "lblpuntos";
            this.lblpuntos.Size = new System.Drawing.Size(35, 13);
            this.lblpuntos.TabIndex = 1;
            this.lblpuntos.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // carro1
            // 
            this.carro1.BackColor = System.Drawing.Color.Transparent;
            this.carro1.Image = global::Carro.Properties.Resources.Carro1;
            this.carro1.Location = new System.Drawing.Point(12, 293);
            this.carro1.Name = "carro1";
            this.carro1.Size = new System.Drawing.Size(65, 115);
            this.carro1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.carro1.TabIndex = 0;
            this.carro1.TabStop = false;
            // 
            // carro2
            // 
            this.carro2.BackColor = System.Drawing.Color.Transparent;
            this.carro2.BackgroundImage = global::Carro.Properties.Resources.Carro_2_T;
            this.carro2.Image = global::Carro.Properties.Resources.Carro_2_T;
            this.carro2.Location = new System.Drawing.Point(168, 293);
            this.carro2.Name = "carro2";
            this.carro2.Size = new System.Drawing.Size(65, 115);
            this.carro2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.carro2.TabIndex = 2;
            this.carro2.TabStop = false;
            // 
            // lblPuntos2
            // 
            this.lblPuntos2.AutoSize = true;
            this.lblPuntos2.Location = new System.Drawing.Point(261, 52);
            this.lblPuntos2.Name = "lblPuntos2";
            this.lblPuntos2.Size = new System.Drawing.Size(35, 13);
            this.lblPuntos2.TabIndex = 3;
            this.lblPuntos2.Text = "label1";
            // 
            // timer3
            // 
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Location = new System.Drawing.Point(129, 92);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(35, 13);
            this.lblTiempo.TabIndex = 4;
            this.lblTiempo.Text = "label1";
            this.lblTiempo.Visible = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(325, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 123);
            this.label2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Puntuacion:";
            // 
            // lblPuntuacion
            // 
            this.lblPuntuacion.AutoSize = true;
            this.lblPuntuacion.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuntuacion.Location = new System.Drawing.Point(115, 13);
            this.lblPuntuacion.Name = "lblPuntuacion";
            this.lblPuntuacion.Size = new System.Drawing.Size(18, 18);
            this.lblPuntuacion.TabIndex = 8;
            this.lblPuntuacion.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(315, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Usuarios Conectados";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(315, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Puntuación Final";
            this.label4.Visible = false;
            // 
            // lblScoreFinal
            // 
            this.lblScoreFinal.BackColor = System.Drawing.Color.Transparent;
            this.lblScoreFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblScoreFinal.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreFinal.ForeColor = System.Drawing.Color.Orange;
            this.lblScoreFinal.Location = new System.Drawing.Point(325, 195);
            this.lblScoreFinal.Name = "lblScoreFinal";
            this.lblScoreFinal.Size = new System.Drawing.Size(98, 123);
            this.lblScoreFinal.TabIndex = 10;
            this.lblScoreFinal.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(357, 390);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "0";
            this.label5.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Carro.Properties.Resources.carre2;
            this.ClientSize = new System.Drawing.Size(435, 420);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblScoreFinal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPuntuacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.lblPuntos2);
            this.Controls.Add(this.carro2);
            this.Controls.Add(this.lblpuntos);
            this.Controls.Add(this.carro1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.carro1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carro2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox carro1;
        private System.Windows.Forms.PictureBox carro2;
        public System.Windows.Forms.Label lblpuntos;
        public System.Windows.Forms.Label lblPuntos2;
        private System.Windows.Forms.Label lblTiempo;
        public System.Windows.Forms.Timer timer3;
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPuntuacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblScoreFinal;
        private System.Windows.Forms.Label label5;
    }
}

