namespace PingPong
{
    public partial class Form1 : Form
    {
        private int ballXSpeed = 4;
        private int ballYSpeed = 4;
        private int computerSpeedChange = 50;
        private Random random = new Random();
        private bool goDown;
        private bool goUp;
        private int player1Score = 0;
        private int playerSpeed = 8;
        private int pcScore = 0;
        private int[] i = { 5, 6, 8, 9 };
        private int[] j = { 10, 9, 8, 11, 12 };
        private int speed = 5;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            Pelota.Top += ballYSpeed;
            Pelota.Left += ballXSpeed;

            this.Text = "Score Jugador: " + player1Score + " Score IA: " + pcScore;

            if (Pelota.Top < 0 || Pelota.Bottom > this.ClientSize.Height)
                ballYSpeed = -ballYSpeed;

            if (Pelota.Left < 2)
            {
                Pelota.Left = 300;
                ballXSpeed = -ballXSpeed;
                pcScore++;
            }

            if (Pelota.Right > this.ClientSize.Width - 2)
            {
                Pelota.Left = 300;
                ballXSpeed = -ballXSpeed;
                player1Score++;
            }

            if (IA.Top < -1)
                IA.Top = 0;
            else if (IA.Bottom > this.ClientSize.Height)
                IA.Top = this.ClientSize.Height - IA.Height;

            if (Pelota.Top < IA.Top + (IA.Height / 2) && Pelota.Left > 300)
                IA.Top -= speed;

            if (Pelota.Top > IA.Top + (IA.Height / 2) && Pelota.Left > 300)
                IA.Top += speed;

            computerSpeedChange--;

            if (computerSpeedChange < 0)
            {
                speed = i[random.Next(i.Length)];
                computerSpeedChange = 50;
            }

            if (goDown && Jugador.Top + Jugador.Height < this.ClientSize.Height)
                Jugador.Top += playerSpeed;

            if (goUp && Jugador.Top > 0)
                Jugador.Top -= playerSpeed;

            CheckCollision(Pelota, Jugador, Jugador.Right + 5);
            CheckCollision(Pelota, IA, IA.Left - 35);

            if (pcScore > 5)
                GameOver("¡Has perdido!");
            else if (player1Score > 5)
                GameOver("¡Has ganado!");
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                goDown = true;

            if (e.KeyCode == Keys.Up)
                goUp = true;
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                goDown = false;

            if (e.KeyCode == Keys.Up)
                goUp = false;
        }

        private void CheckCollision(PictureBox picOne, PictureBox picTwo, int offset)
        {
            if (picOne.Bounds.IntersectsWith(picTwo.Bounds))
            {
                picOne.Left = offset;

                int x = i[random.Next(i.Length)];
                int y = j[random.Next(j.Length)];

                ballXSpeed = ballXSpeed < 0 ? x : -x;
                ballYSpeed = ballYSpeed < 0 ? -y : y;
            }
        }

        private void GameOver(string message)
        {
            Temporizador.Stop();
            MessageBox.Show(message, "Game Over");
            pcScore = 0;
            player1Score = 0;
            ballXSpeed = ballYSpeed = 4;
            computerSpeedChange = 50;
            Temporizador.Start(); // Reiniciar el juego
        }
    }
}
