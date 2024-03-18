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
            lblChangePassword = new Label();
            txtBoxOldPassword = new TextBox();
            txtBoxNewPassword = new TextBox();
            btnChangePassword = new Button();
            lblOldPasswordIncorrect = new Label();
            lblNewPasswordInvalid = new Label();
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
            lblTopScoreValue.Font = new Font("JetBrains Mono", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblTopScoreValue.ForeColor = Color.FromArgb(0, 192, 0);
            lblTopScoreValue.Location = new Point(167, 86);
            lblTopScoreValue.Name = "lblTopScoreValue";
            lblTopScoreValue.Size = new Size(51, 39);
            lblTopScoreValue.TabIndex = 7;
            lblTopScoreValue.Text = "-1";
            // 
            // lblQuizCompleteValue
            // 
            lblQuizCompleteValue.AutoSize = true;
            lblQuizCompleteValue.Font = new Font("JetBrains Mono", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblQuizCompleteValue.ForeColor = Color.FromArgb(0, 192, 0);
            lblQuizCompleteValue.Location = new Point(279, 139);
            lblQuizCompleteValue.Name = "lblQuizCompleteValue";
            lblQuizCompleteValue.Size = new Size(51, 39);
            lblQuizCompleteValue.TabIndex = 7;
            lblQuizCompleteValue.Text = "-1";
            // 
            // lblAccuracyValue
            // 
            lblAccuracyValue.AutoSize = true;
            lblAccuracyValue.Font = new Font("JetBrains Mono", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblAccuracyValue.ForeColor = Color.FromArgb(0, 192, 0);
            lblAccuracyValue.Location = new Point(153, 192);
            lblAccuracyValue.Name = "lblAccuracyValue";
            lblAccuracyValue.Size = new Size(51, 39);
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
            lblRatingValue.Font = new Font("JetBrains Mono", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblRatingValue.ForeColor = Color.FromArgb(0, 192, 0);
            lblRatingValue.Location = new Point(125, 241);
            lblRatingValue.Name = "lblRatingValue";
            lblRatingValue.Size = new Size(51, 39);
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
            lblMainMenu.Location = new Point(594, 378);
            lblMainMenu.Name = "lblMainMenu";
            lblMainMenu.Size = new Size(194, 60);
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
            // lblChangePassword
            // 
            lblChangePassword.AutoSize = true;
            lblChangePassword.Font = new Font("JetBrains Mono", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            lblChangePassword.Location = new Point(21, 317);
            lblChangePassword.Name = "lblChangePassword";
            lblChangePassword.Size = new Size(238, 31);
            lblChangePassword.TabIndex = 15;
            lblChangePassword.Text = "Change Password?";
            // 
            // txtBoxOldPassword
            // 
            txtBoxOldPassword.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxOldPassword.Location = new Point(21, 351);
            txtBoxOldPassword.Name = "txtBoxOldPassword";
            txtBoxOldPassword.PlaceholderText = "Old Password..";
            txtBoxOldPassword.Size = new Size(238, 35);
            txtBoxOldPassword.TabIndex = 16;
            txtBoxOldPassword.UseSystemPasswordChar = true;
            // 
            // txtBoxNewPassword
            // 
            txtBoxNewPassword.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxNewPassword.Location = new Point(21, 392);
            txtBoxNewPassword.Name = "txtBoxNewPassword";
            txtBoxNewPassword.PlaceholderText = "New Password..";
            txtBoxNewPassword.Size = new Size(238, 35);
            txtBoxNewPassword.TabIndex = 17;
            txtBoxNewPassword.UseSystemPasswordChar = true;
            // 
            // btnChangePassword
            // 
            btnChangePassword.BackColor = Color.FromArgb(192, 255, 192);
            btnChangePassword.FlatStyle = FlatStyle.Flat;
            btnChangePassword.Font = new Font("JetBrains Mono", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnChangePassword.Location = new Point(307, 363);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(153, 49);
            btnChangePassword.TabIndex = 18;
            btnChangePassword.Text = "Change";
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // lblOldPasswordIncorrect
            // 
            lblOldPasswordIncorrect.AutoSize = true;
            lblOldPasswordIncorrect.Font = new Font("JetBrains Mono", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            lblOldPasswordIncorrect.ForeColor = Color.FromArgb(192, 0, 0);
            lblOldPasswordIncorrect.Location = new Point(265, 339);
            lblOldPasswordIncorrect.Name = "lblOldPasswordIncorrect";
            lblOldPasswordIncorrect.Size = new Size(260, 21);
            lblOldPasswordIncorrect.TabIndex = 19;
            lblOldPasswordIncorrect.Text = "Old password is incorrect";
            // 
            // lblNewPasswordInvalid
            // 
            lblNewPasswordInvalid.AutoSize = true;
            lblNewPasswordInvalid.Font = new Font("JetBrains Mono", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            lblNewPasswordInvalid.ForeColor = Color.FromArgb(192, 0, 0);
            lblNewPasswordInvalid.Location = new Point(273, 420);
            lblNewPasswordInvalid.Name = "lblNewPasswordInvalid";
            lblNewPasswordInvalid.Size = new Size(240, 21);
            lblNewPasswordInvalid.TabIndex = 20;
            lblNewPasswordInvalid.Text = "New password is invalid";
            // 
            // formUserProfile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(800, 450);
            Controls.Add(lblNewPasswordInvalid);
            Controls.Add(lblOldPasswordIncorrect);
            Controls.Add(btnChangePassword);
            Controls.Add(txtBoxNewPassword);
            Controls.Add(txtBoxOldPassword);
            Controls.Add(lblChangePassword);
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
        private Label lblChangePassword;
        private TextBox txtBoxOldPassword;
        private TextBox txtBoxNewPassword;
        private Button btnChangePassword;
        private Label lblOldPasswordIncorrect;
        private Label lblNewPasswordInvalid;
    }
}