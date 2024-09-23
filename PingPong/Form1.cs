namespace PingPong
{
    public partial class Form1 : Form
    {
        // Velocidad de la pelota
        private int ballXSpeed = 4;
        private int ballYSpeed = 4;

        int ComputerSpeedChange = 50;
        // Velocidad aleatoria de la pelota
        private Random rdm = new Random();

        // Variables de control de movimiento
        private bool goDown;
        private bool goUp;

        // Puntaje y velocidad del jugador y de la IA
        private int player1Score = 0;
        private int playerSpeed = 8;
        private int pcScore = 0;

        // Configuración de las velocidades de la IA
        private int[] i = { 5, 6, 8, 9 };
        private int[] j = { 10, 9, 8, 11, 12 };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void GameTimerEvent(object sender, EventArgs e)
        {

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

                int x = i[rdm.Next(i.Length)];
                int y = j[rdm.Next(j.Length)];

                if (ballXSpeed < 0)
                    ballXSpeed = x;
                else
                    ballXSpeed = -x;

                if (ballYSpeed < 0)
                    ballYSpeed = -y;
                else
                    ballYSpeed = y;
            }
        }

        private void GameOver(string message)
        {
            Temporizador.Stop();
            MessageBox.Show(message, "Game Over");
            pcScore = 0;
            player1Score = 0;
            ballXSpeed = ballYSpeed = 4;
            ComputerSpeedChange = 50;
            Temporizador.Start(); // Reiniciar el juego
        }
    }
}
