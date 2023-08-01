namespace SnakeGame.Views
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
            lblHighScore = new Label();
            lblScore = new Label();
            canvas = new PictureBox();
            btnStart = new Button();
            gameTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            SuspendLayout();
            // 
            // lblHighScore
            // 
            lblHighScore.AutoSize = true;
            lblHighScore.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblHighScore.Location = new Point(137, 13);
            lblHighScore.Name = "lblHighScore";
            lblHighScore.Size = new Size(103, 23);
            lblHighScore.TabIndex = 7;
            lblHighScore.Text = "High Score:";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblScore.Location = new Point(12, 13);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(74, 23);
            lblScore.TabIndex = 6;
            lblScore.Text = "Score: 0";
            // 
            // canvas
            // 
            canvas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            canvas.Location = new Point(12, 47);
            canvas.Name = "canvas";
            canvas.Size = new Size(567, 582);
            canvas.TabIndex = 5;
            canvas.TabStop = false;
            canvas.Paint += UpdateCanvasGraphics;
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStart.BackColor = Color.Green;
            btnStart.Cursor = Cursors.Hand;
            btnStart.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnStart.ForeColor = SystemColors.ControlLightLight;
            btnStart.Location = new Point(473, 8);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(106, 33);
            btnStart.TabIndex = 4;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += BtnStartClick;
            // 
            // gameTimer
            // 
            gameTimer.Interval = 120;
            gameTimer.Tick += GameTimerTick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(591, 637);
            Controls.Add(lblHighScore);
            Controls.Add(lblScore);
            Controls.Add(canvas);
            Controls.Add(btnStart);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            KeyDown += KeysIsDown;
            KeyUp += KeysIsUp;
            ((System.ComponentModel.ISupportInitialize)canvas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHighScore;
        private Label lblScore;
        private PictureBox canvas;
        private Button btnStart;
        private System.Windows.Forms.Timer gameTimer;
    }
}