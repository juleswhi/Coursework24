namespace ChessMasterQuiz.Forms
{
    partial class formUserProfile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblUsername = new Label();
            lblTopScore = new Label();
            pBoxProfileImage = new PictureBox();
            lblQuizCompleted = new Label();
            lblTopScoreValue = new Label();
            lblQuizCompleteValue = new Label();
            lblAccuracyValue = new Label();
            lblAccuracy = new Label();
            lblRatingValue = new Label();
            lblRating = new Label();
            lblMainMenu = new Button();
            btnNext = new Button();
            ((System.ComponentModel.ISupportInitialize)pBoxProfileImage).BeginInit();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("JetBrains Mono", 27.7499962F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsername.Location = new Point(51, 9);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(462, 49);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "{UserName}'s Profile";
            // 
            // lblTopScore
            // 
            lblTopScore.AutoSize = true;
            lblTopScore.Font = new Font("JetBrains Mono", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            lblTopScore.Location = new Point(21, 92);
            lblTopScore.Name = "lblTopScore";
            lblTopScore.Size = new Size(140, 31);
            lblTopScore.TabIndex = 3;
            lblTopScore.Text = "TOP SCORE";
            // 
            // pBoxProfileImage
            // 
            pBoxProfileImage.BackColor = Color.FromArgb(192, 255, 192);
            pBoxProfileImage.BorderStyle = BorderStyle.FixedSingle;
            pBoxProfileImage.Location = new Point(559, 24);
            pBoxProfileImage.Name = "pBoxProfileImage";
            pBoxProfileImage.Size = new Size(171, 158);
            pBoxProfileImage.TabIndex = 4;
            pBoxProfileImage.TabStop = false;
            // 
            // lblQuizCompleted
            // 
            lblQuizCompleted.AutoSize = true;
            lblQuizCompleted.Font = new Font("JetBrains Mono", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            lblQuizCompleted.Location = new Point(21, 147);
            lblQuizCompleted.Name = "lblQuizCompleted";
            lblQuizCompleted.Size = new Size(252, 31);
            lblQuizCompleted.TabIndex = 5;
            lblQuizCompleted.Text = "QUIZZES COMPLETED";
            // 
            // lblTopScoreValue
            // 
            lblTopScoreValue.AutoSize = true;
            lblTopScoreValue.Font = new Font("JetBrains Mono", 26.2499962F, FontStyle.Regular, GraphicsUnit.Point);
            lblTopScoreValue.ForeColor = Color.FromArgb(0, 192, 0);
            lblTopScoreValue.Location = new Point(167, 80);
            lblTopScoreValue.Name = "lblTopScoreValue";
            lblTopScoreValue.Size = new Size(62, 47);
            lblTopScoreValue.TabIndex = 7;
            lblTopScoreValue.Text = "-1";
            // 
            // lblQuizCompleteValue
            // 
            lblQuizCompleteValue.AutoSize = true;
            lblQuizCompleteValue.Font = new Font("JetBrains Mono", 26.2499962F, FontStyle.Regular, GraphicsUnit.Point);
            lblQuizCompleteValue.ForeColor = Color.FromArgb(0, 192, 0);
            lblQuizCompleteValue.Location = new Point(279, 135);
            lblQuizCompleteValue.Name = "lblQuizCompleteValue";
            lblQuizCompleteValue.Size = new Size(62, 47);
            lblQuizCompleteValue.TabIndex = 7;
            lblQuizCompleteValue.Text = "-1";
            // 
            // lblAccuracyValue
            // 
            lblAccuracyValue.AutoSize = true;
            lblAccuracyValue.Font = new Font("JetBrains Mono", 26.2499962F, FontStyle.Regular, GraphicsUnit.Point);
            lblAccuracyValue.ForeColor = Color.FromArgb(0, 192, 0);
            lblAccuracyValue.Location = new Point(153, 188);
            lblAccuracyValue.Name = "lblAccuracyValue";
            lblAccuracyValue.Size = new Size(62, 47);
            lblAccuracyValue.TabIndex = 9;
            lblAccuracyValue.Text = "-1";
            // 
            // lblAccuracy
            // 
            lblAccuracy.AutoSize = true;
            lblAccuracy.Font = new Font("JetBrains Mono", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            lblAccuracy.Location = new Point(21, 198);
            lblAccuracy.Name = "lblAccuracy";
            lblAccuracy.Size = new Size(126, 31);
            lblAccuracy.TabIndex = 8;
            lblAccuracy.Text = "ACCURACY";
            // 
            // lblRatingValue
            // 
            lblRatingValue.AutoSize = true;
            lblRatingValue.Font = new Font("JetBrains Mono", 26.2499962F, FontStyle.Regular, GraphicsUnit.Point);
            lblRatingValue.ForeColor = Color.FromArgb(0, 192, 0);
            lblRatingValue.Location = new Point(137, 247);
            lblRatingValue.Name = "lblRatingValue";
            lblRatingValue.Size = new Size(62, 47);
            lblRatingValue.TabIndex = 11;
            lblRatingValue.Text = "-1";
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.Font = new Font("JetBrains Mono", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            lblRating.Location = new Point(21, 247);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(98, 31);
            lblRating.TabIndex = 10;
            lblRating.Text = "RATING";
            // 
            // lblMainMenu
            // 
            lblMainMenu.BackColor = Color.FromArgb(192, 255, 192);
            lblMainMenu.FlatStyle = FlatStyle.Flat;
            lblMainMenu.Font = new Font("JetBrains Mono", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblMainMenu.Location = new Point(559, 361);
            lblMainMenu.Name = "lblMainMenu";
            lblMainMenu.Size = new Size(181, 53);
            lblMainMenu.TabIndex = 12;
            lblMainMenu.Text = "Back To Main Menu";
            lblMainMenu.UseVisualStyleBackColor = false;
            lblMainMenu.Click += lblMainMenu_Click;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.FromArgb(192, 255, 192);
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Location = new Point(559, 188);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(171, 41);
            btnNext.TabIndex = 14;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // formUserProfile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(800, 450);
            Controls.Add(btnNext);
            Controls.Add(lblMainMenu);
            Controls.Add(lblRatingValue);
            Controls.Add(lblRating);
            Controls.Add(lblAccuracyValue);
            Controls.Add(lblAccuracy);
            Controls.Add(lblQuizCompleteValue);
            Controls.Add(lblTopScoreValue);
            Controls.Add(lblQuizCompleted);
            Controls.Add(pBoxProfileImage);
            Controls.Add(lblTopScore);
            Controls.Add(lblUsername);
            Name = "formUserProfile";
            Text = "formUserProfile";
            ((System.ComponentModel.ISupportInitialize)pBoxProfileImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsername;
        private Label lblTopScore;
        private PictureBox pBoxProfileImage;
        private Label lblQuizCompleted;
        private Label lblTopScoreValue;
        private Label lblQuizCompleteValue;
        private Label lblAccuracyValue;
        private Label lblAccuracy;
        private Label lblRatingValue;
        private Label lblRating;
        private Button lblMainMenu;
        private Button btnNext;
    }
}