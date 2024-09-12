namespace PingPong
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Jugador = new PictureBox();
            IA = new PictureBox();
            Pelota = new PictureBox();
            Temporizador = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)Jugador).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IA).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Pelota).BeginInit();
            SuspendLayout();
            // 
            // Jugador
            // 
            Jugador.Image = Properties.Resources.player;
            Jugador.Location = new Point(12, 160);
            Jugador.Name = "Jugador";
            Jugador.Size = new Size(30, 120);
            Jugador.SizeMode = PictureBoxSizeMode.StretchImage;
            Jugador.TabIndex = 1;
            Jugador.TabStop = false;
            // 
            // IA
            // 
            IA.Image = Properties.Resources.computer;
            IA.Location = new Point(758, 160);
            IA.Name = "IA";
            IA.Size = new Size(30, 120);
            IA.SizeMode = PictureBoxSizeMode.StretchImage;
            IA.TabIndex = 2;
            IA.TabStop = false;
            // 
            // Pelota
            // 
            Pelota.Image = Properties.Resources.ball;
            Pelota.Location = new Point(380, 160);
            Pelota.Name = "Pelota";
            Pelota.Size = new Size(30, 30);
            Pelota.SizeMode = PictureBoxSizeMode.Zoom;
            Pelota.TabIndex = 3;
            Pelota.TabStop = false;
            // 
            // Temporizador
            // 
            Temporizador.Enabled = true;
            Temporizador.Interval = 20;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 451);
            Controls.Add(Pelota);
            Controls.Add(IA);
            Controls.Add(Jugador);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Jugador: 0   IA: 0";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)Jugador).EndInit();
            ((System.ComponentModel.ISupportInitialize)IA).EndInit();
            ((System.ComponentModel.ISupportInitialize)Pelota).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox Jugador;
        private PictureBox IA;
        private PictureBox Pelota;
        private System.Windows.Forms.Timer Temporizador;
    }
}
