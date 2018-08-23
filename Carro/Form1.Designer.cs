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
            ((System.ComponentModel.ISupportInitialize)(this.carro1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carro2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblpuntos
            // 
            this.lblpuntos.AutoSize = true;
            this.lblpuntos.Location = new System.Drawing.Point(31, 30);
            this.lblpuntos.Name = "lblpuntos";
            this.lblpuntos.Size = new System.Drawing.Size(35, 13);
            this.lblpuntos.TabIndex = 1;
            this.lblpuntos.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
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
            this.lblPuntos2.Location = new System.Drawing.Point(261, 30);
            this.lblPuntos2.Name = "lblPuntos2";
            this.lblPuntos2.Size = new System.Drawing.Size(35, 13);
            this.lblPuntos2.TabIndex = 3;
            this.lblPuntos2.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Carro.Properties.Resources.carre2;
            this.ClientSize = new System.Drawing.Size(308, 420);
            this.Controls.Add(this.lblPuntos2);
            this.Controls.Add(this.carro2);
            this.Controls.Add(this.lblpuntos);
            this.Controls.Add(this.carro1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.carro1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carro2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox carro1;
        private System.Windows.Forms.Label lblpuntos;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox carro2;
        private System.Windows.Forms.Label lblPuntos2;
    }
}

