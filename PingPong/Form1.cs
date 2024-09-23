namespace PingPong
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // Velocidad de la pelota
            int ballXSpeed = 4;
            int ballYSpeed = 4;
            int Speed = 2;

            // Velocidad aleratoria de la pelota
            Random rdm = new Random();

            // Variables de control de movimiento
            bool IrAbajo , IrArriba;

            // Puntaje y velocidad del jugador y de la IA
            int ComputeSpeedChange = 50;
            int Player1Score = 0;
            int PlayerSpeed = 8;
            int PCScore = 0;

            // Configuración de las velocidades de la IA
            int[] i = { 5, 6, 8, 9 };
            int[] j = { 10, 9, 8, 11, 12 };
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

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {

        }

        private void CheckCollision(PictureBox PicOne, PictureBox PicTwo, int offset)
        {

        }

        private void GameOver (string message)
        {

        }
    }
}
