namespace PingPong
{
    public partial class Form1 : Form
    {
        // Velocidad inicial de la pelota
        private int ballXSpeed = 4;
        private int ballYSpeed = 4;

        // Velocidad del cambio del ordenador (IA)
        private int computerSpeedChange = 50;

        // Generador de números aleatorios para la velocidad
        private Random random = new Random();

        // Variables de movimiento del jugador
        private bool goDown;
        private bool goUp;

        // Puntuaciones de los jugadores
        private int player1Score = 0;
        private int pcScore = 0;

        // Velocidad del jugador
        private int playerSpeed = 8;

        // Velocidades aleatorias para la pelota
        private int[] ballSpeedOptionsX = { 5, 6, 8, 9 };
        private int[] ballSpeedOptionsY = { 10, 9, 8, 11, 12 };

        // Velocidad inicial de la IA
        private int computerSpeed = 5;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            // Mover la pelota en la dirección actual
            Pelota.Top += ballYSpeed;
            Pelota.Left += ballXSpeed;

            // Actualizar el título de la ventana con las puntuaciones
            this.Text = $"Score Jugador: {player1Score} Score IA: {pcScore}";

            // Verificar colisiones con los bordes superior e inferior
            if (Pelota.Top < 0 || Pelota.Bottom > this.ClientSize.Height)
                ballYSpeed = -ballYSpeed;

            // Verificar si la pelota sale por el lado izquierdo (punto para la IA)
            if (Pelota.Left < 2)
            {
                ResetBallPosition();
                pcScore++;
            }

            // Verificar si la pelota sale por el lado derecho (punto para el jugador)
            if (Pelota.Right > this.ClientSize.Width - 2)
            {
                ResetBallPosition();
                player1Score++;
            }

            // Controlar los límites de movimiento de la IA
            if (IA.Top < 0)
                IA.Top = 0;
            else if (IA.Bottom > this.ClientSize.Height)
                IA.Top = this.ClientSize.Height - IA.Height;

            // Movimiento automático de la IA en dirección a la pelota
            if (Pelota.Top < IA.Top + (IA.Height / 2) && Pelota.Left > 300)
                IA.Top -= computerSpeed;
            else if (Pelota.Top > IA.Top + (IA.Height / 2) && Pelota.Left > 300)
                IA.Top += computerSpeed;

            // Cambiar la velocidad de la IA periódicamente
            computerSpeedChange--;
            if (computerSpeedChange < 0)
            {
                computerSpeed = ballSpeedOptionsX[random.Next(ballSpeedOptionsX.Length)];
                computerSpeedChange = 50;
            }

            // Movimiento del jugador controlado por teclas
            if (goDown && Jugador.Top + Jugador.Height < this.ClientSize.Height)
                Jugador.Top += playerSpeed;

            if (goUp && Jugador.Top > 0)
                Jugador.Top -= playerSpeed;

            // Verificar colisiones entre la pelota y los jugadores
            CheckCollision(Pelota, Jugador, Jugador.Right + 5);
            CheckCollision(Pelota, IA, IA.Left - 35);

            // Verificar si alguien ganó
            if (pcScore > 5)
                GameOver("¡Has perdido!");
            else if (player1Score > 5)
                GameOver("¡Has ganado!");
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            // Detectar si se presiona la tecla de movimiento hacia abajo o arriba
            if (e.KeyCode == Keys.Down)
                goDown = true;
            if (e.KeyCode == Keys.Up)
                goUp = true;
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            // Detectar si se suelta la tecla de movimiento hacia abajo o arriba
            if (e.KeyCode == Keys.Down)
                goDown = false;
            if (e.KeyCode == Keys.Up)
                goUp = false;
        }

        private void CheckCollision(PictureBox ball, PictureBox paddle, int offset)
        {
            // Verificar colisión entre la pelota y una paleta
            if (ball.Bounds.IntersectsWith(paddle.Bounds))
            {
                ball.Left = offset; // Reposicionar la pelota

                // Cambiar aleatoriamente la velocidad de la pelota tras el rebote
                ballXSpeed = ballXSpeed < 0 ? ballSpeedOptionsX[random.Next(ballSpeedOptionsX.Length)] : -ballSpeedOptionsX[random.Next(ballSpeedOptionsX.Length)];
                ballYSpeed = ballYSpeed < 0 ? -ballSpeedOptionsY[random.Next(ballSpeedOptionsY.Length)] : ballSpeedOptionsY[random.Next(ballSpeedOptionsY.Length)];
            }
        }

        private void GameOver(string message)
        {
            // Detener el juego y mostrar el mensaje de fin
            Temporizador.Stop();
            MessageBox.Show(message, "Resultado");

            // Reiniciar valores del juego
            pcScore = 0;
            player1Score = 0;
            ballXSpeed = ballYSpeed = 4;
            computerSpeedChange = 50;

            Temporizador.Start(); // Reiniciar el temporizador
        }

        private void ResetBallPosition()
        {
            // Reposicionar la pelota al centro
            Pelota.Left = this.ClientSize.Width / 2;
            Pelota.Top = this.ClientSize.Height / 2;

            // Cambiar la dirección de la pelota
            ballXSpeed = -ballXSpeed;
        }
    }
}
