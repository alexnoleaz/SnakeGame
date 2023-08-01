using SnakeGame.Models;
using SnakeGame.Common;

namespace SnakeGame.Views
{
    public partial class Form1 : Form
    {
        private readonly List<Circle> _snake;
        private readonly Random _rand;
        private Circle _food;

        private int _maxWidth;
        private int _maxHeight;

        private int _score;
        private int _highScore;

        private bool _isUp;
        private bool _isDown;
        private bool _isRight;
        private bool _isLeft;

        public Form1()
        {
            InitializeComponent();
            _ = new Settings();
            _snake = new List<Circle>();
            _rand = new Random();
            _food = new Circle();
        }
        private void BtnStartClick(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void KeysIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && Settings.Directions != Directions.Right)
                _isLeft = true;

            if (e.KeyCode == Keys.Right && Settings.Directions != Directions.Left)
                _isRight = true;

            if (e.KeyCode == Keys.Up && Settings.Directions != Directions.Down)
                _isUp = true;

            if (e.KeyCode == Keys.Down && Settings.Directions != Directions.Up)
                _isDown = true;
        }

        private void KeysIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                _isLeft = false;

            if (e.KeyCode == Keys.Right)
                _isRight = false;

            if (e.KeyCode == Keys.Up)
                _isUp = false;

            if (e.KeyCode == Keys.Down)
                _isDown = false;
        }

        private void UpdateCanvasGraphics(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            Brush snakeColour;

            for (int i = 0; i < _snake.Count; i++)
            {
                snakeColour = i == 0 ? Brushes.Green : Brushes.Black;
                graphics.FillEllipse(snakeColour, new Rectangle
                {
                    X = _snake[i].X * Settings.Width,
                    Y = _snake[i].Y * Settings.Height,
                    Width = Settings.Width,
                    Height = Settings.Height
                });
            }

            graphics.FillEllipse(Brushes.Red, new Rectangle
            {
                X = _food.X * Settings.Width,
                Y = _food.Y * Settings.Height,
                Width = Settings.Width,
                Height = Settings.Height
            });
        }

        private void GameTimerTick(object sender, EventArgs e)
        {
            // Directions Configuration
            if (_isLeft) Settings.Directions = Directions.Left;
            if (_isRight) Settings.Directions = Directions.Right;
            if (_isDown) Settings.Directions = Directions.Down;
            if (_isUp) Settings.Directions = Directions.Up;

            for (int i = _snake.Count - 1; i >= 0; i--)
            {
                if (i != 0)
                {
                    _snake[i].X = _snake[i - 1].X;
                    _snake[i].Y = _snake[i - 1].Y;
                }
                else
                {
                    switch (Settings.Directions)
                    {
                        case Directions.Left:
                            _snake[i].X--;
                            break;
                        case Directions.Right:
                            _snake[i].X++;
                            break;
                        case Directions.Up:
                            _snake[i].Y--;
                            break;
                        case Directions.Down:
                            _snake[i].Y++;
                            break;
                    }

                    if (_snake[i].X < 0)
                        _snake[i].X = _maxWidth;

                    if (_snake[i].X > _maxWidth)
                        _snake[i].X = 0;

                    if (_snake[i].Y < 0)
                        _snake[i].Y = _maxHeight;

                    if (_snake[i].Y > _maxHeight)
                        _snake[i].Y = 0;

                    if (_snake[i].X == _food.X && _snake[i].Y == _food.Y)
                        EatFood();

                    for (int j = 1; j < _snake.Count; j++)
                    {
                        if (_snake[i].X == _snake[j].X && _snake[i].Y == _snake[j].Y)
                        {
                            GameOver();

                            var result = MessageBox.Show("Play Again?", "GAME OVER", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                            if (result != DialogResult.Yes)
                                Close();

                            RestartGame();
                        }
                    }
                }
            }

            canvas.Invalidate();
        }

        private void RestartGame()
        {
            // Initial Configuration
            _maxWidth = canvas.Width / Settings.Width - 1;
            _maxHeight = canvas.Height / Settings.Height - 1;
            _score = 0;

            _snake.Clear();

            btnStart.Enabled = false;
            lblScore.Text = $"Score: {_score}";
            gameTimer.Interval = 120;

            Settings.Directions = Directions.Left;
            _isUp = _isDown = _isRight = _isLeft = false;

            _snake.Add(new Circle { X = 10, Y = 5 }); // Head

            for (int i = 0; i < 6; i++) // Body
                _snake.Add(new Circle());

            CreateFood();
            gameTimer.Start();
        }

        private void EatFood()
        {
            _score++;
            lblScore.Text = $"Score: {_score}";

            var body = new Circle
            {
                X = _snake[_snake.Count - 1].X,
                Y = _snake[_snake.Count - 1].Y
            };

            _snake.Add(body);

            if (gameTimer.Interval > 60) gameTimer.Interval -= 3;
            else if (gameTimer.Interval > 40) gameTimer.Interval--;
            else gameTimer.Interval = 40;

            CreateFood();
        }

        private void CreateFood()
        {
            _food = new Circle
            {
                X = _rand.Next(2, _maxWidth),
                Y = _rand.Next(2, _maxHeight)
            };
        }

        private void GameOver()
        {
            gameTimer.Stop();
            btnStart.Enabled = true;

            if (_score > _highScore)
            {
                _highScore = _score;
                lblHighScore.Text = $"High Score: {_highScore}";
                lblHighScore.ForeColor = Color.Blue;
            }
        }
    }
}