namespace PingPong
{
    public partial class Form1 : Form
    {
        // Velocidad de la pelota
        int ballXSpeed = 4;
        int ballYSpeed = 4;
        int Speed = 2;

        // Velocidad aleratoria de la pelota
        Random rdm = new Random();

        // Variables de control de movimiento
        bool goDown, goUp;

        // Puntaje y velocidad del jugador y de la IA
        int ComputeSpeedChange = 50;
        int Player1Score = 0;
        int PlayerSpeed = 8;
        int PCScore = 0;

        // Configuración de las velocidades de la IA
        int[] i = { 5, 6, 8, 9 };
        int[] j = { 10, 9, 8, 11, 12 };

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

        private void CheckCollision(PictureBox PicOne, PictureBox PicTwo, int offset)
        {

        }

        private void GameOver (string message)
        {

        }
    }
}
