namespace ChessMasterQuiz
{
    partial class formMenu
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
            lblLogin = new Label();
            pBoxProfile = new PictureBox();
            btnLeaderboard = new Button();
            btnPlay = new Button();
            btnSettings = new Button();
            ((System.ComponentModel.ISupportInitialize)pBoxProfile).BeginInit();
            SuspendLayout();
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("JetBrains Mono", 27.7499962F, FontStyle.Regular, GraphicsUnit.Point);
            lblLogin.Location = new Point(40, 46);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(220, 49);
            lblLogin.TabIndex = 1;
            lblLogin.Text = "Main Menu";
            // 
            // pBoxProfile
            // 
            pBoxProfile.BackColor = Color.FromArgb(192, 255, 192);
            pBoxProfile.BorderStyle = BorderStyle.FixedSingle;
            pBoxProfile.Location = new Point(716, 12);
            pBoxProfile.Name = "pBoxProfile";
            pBoxProfile.Size = new Size(72, 65);
            pBoxProfile.TabIndex = 2;
            pBoxProfile.TabStop = false;
            pBoxProfile.Click += pBoxProfile_Click;
            // 
            // btnLeaderboard
            // 
            btnLeaderboard.BackColor = Color.FromArgb(192, 255, 192);
            btnLeaderboard.FlatStyle = FlatStyle.Flat;
            btnLeaderboard.Font = new Font("JetBrains Mono", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnLeaderboard.Location = new Point(24, 205);
            btnLeaderboard.Name = "btnLeaderboard";
            btnLeaderboard.Size = new Size(253, 83);
            btnLeaderboard.TabIndex = 4;
            btnLeaderboard.Text = "Leaderboard";
            btnLeaderboard.UseVisualStyleBackColor = false;
            btnLeaderboard.Click += btnLeaderboard_Click;
            // 
            // btnPlay
            // 
            btnPlay.BackColor = Color.FromArgb(192, 255, 192);
            btnPlay.FlatStyle = FlatStyle.Flat;
            btnPlay.Font = new Font("JetBrains Mono", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnPlay.Location = new Point(24, 116);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(253, 83);
            btnPlay.TabIndex = 5;
            btnPlay.Text = "Play!";
            btnPlay.UseVisualStyleBackColor = false;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.FromArgb(192, 255, 192);
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("JetBrains Mono", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnSettings.Location = new Point(24, 294);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(253, 83);
            btnSettings.TabIndex = 5;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += btnSettings_Click;
            // 
            // formMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(800, 450);
            Controls.Add(btnSettings);
            Controls.Add(btnPlay);
            Controls.Add(btnLeaderboard);
            Controls.Add(pBoxProfile);
            Controls.Add(lblLogin);
            Name = "formMenu";
            Text = "formMenu";
            ((System.ComponentModel.ISupportInitialize)pBoxProfile).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLogin;
        private PictureBox pBoxProfile;
        private Button btnLeaderboard;
        private Button btnPlay;
        private Button btnSettings;
    }
}