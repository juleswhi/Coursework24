namespace ChessMasterQuiz
{
    partial class formRegister
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
            txtBoxEmail = new TextBox();
            txtBoxPassword = new TextBox();
            txtBoxDisplayName = new TextBox();
            btnRegister = new Button();
            txtBoxGender = new TextBox();
            txtBoxDob = new TextBox();
            progressPassword = new ProgressBar();
            pBoxLogo = new PictureBox();
            pBarUsername = new ProgressBar();
            pBarDisplayName = new ProgressBar();
            pBarGender = new ProgressBar();
            pBarDob = new ProgressBar();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)pBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // txtBoxEmail
            // 
            txtBoxEmail.AcceptsReturn = true;
            txtBoxEmail.AcceptsTab = true;
            txtBoxEmail.BackColor = Color.White;
            txtBoxEmail.Font = new Font("JetBrains Mono", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxEmail.Location = new Point(47, 13);
            txtBoxEmail.Name = "txtBoxEmail";
            txtBoxEmail.PlaceholderText = "Username";
            txtBoxEmail.Size = new Size(281, 43);
            txtBoxEmail.TabIndex = 1;
            txtBoxEmail.Tag = "username";
            txtBoxEmail.TextChanged += txtBoxEmail_TextChanged;
            // 
            // txtBoxPassword
            // 
            txtBoxPassword.AcceptsReturn = true;
            txtBoxPassword.AcceptsTab = true;
            txtBoxPassword.BackColor = Color.White;
            txtBoxPassword.Font = new Font("JetBrains Mono", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxPassword.Location = new Point(47, 78);
            txtBoxPassword.Name = "txtBoxPassword";
            txtBoxPassword.PlaceholderText = "Password";
            txtBoxPassword.Size = new Size(281, 43);
            txtBoxPassword.TabIndex = 2;
            txtBoxPassword.Tag = "password";
            // 
            // txtBoxDisplayName
            // 
            txtBoxDisplayName.AcceptsReturn = true;
            txtBoxDisplayName.AcceptsTab = true;
            txtBoxDisplayName.BackColor = Color.White;
            txtBoxDisplayName.Font = new Font("JetBrains Mono", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxDisplayName.Location = new Point(47, 143);
            txtBoxDisplayName.Name = "txtBoxDisplayName";
            txtBoxDisplayName.PlaceholderText = "Confirm Password";
            txtBoxDisplayName.Size = new Size(281, 43);
            txtBoxDisplayName.TabIndex = 3;
            txtBoxDisplayName.Tag = "password_confirm";
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(192, 255, 192);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("JetBrains Mono", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegister.Location = new Point(168, 357);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(160, 63);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Register!";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // txtBoxGender
            // 
            txtBoxGender.AcceptsReturn = true;
            txtBoxGender.AcceptsTab = true;
            txtBoxGender.BackColor = Color.White;
            txtBoxGender.Font = new Font("JetBrains Mono", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxGender.Location = new Point(47, 208);
            txtBoxGender.Name = "txtBoxGender";
            txtBoxGender.PlaceholderText = "Email";
            txtBoxGender.Size = new Size(281, 43);
            txtBoxGender.TabIndex = 4;
            txtBoxGender.Tag = "email";
            txtBoxGender.TextChanged += txtBoxGender_TextChanged;
            // 
            // txtBoxDob
            // 
            txtBoxDob.AcceptsReturn = true;
            txtBoxDob.AcceptsTab = true;
            txtBoxDob.BackColor = Color.White;
            txtBoxDob.Font = new Font("JetBrains Mono", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxDob.Location = new Point(47, 273);
            txtBoxDob.Name = "txtBoxDob";
            txtBoxDob.PlaceholderText = "DOB D/M/Y";
            txtBoxDob.Size = new Size(281, 43);
            txtBoxDob.TabIndex = 5;
            txtBoxDob.Tag = "dob";
            // 
            // progressPassword
            // 
            progressPassword.BackColor = Color.FromArgb(192, 255, 192);
            progressPassword.ForeColor = Color.FromArgb(192, 255, 192);
            progressPassword.Location = new Point(47, 127);
            progressPassword.Name = "progressPassword";
            progressPassword.Size = new Size(281, 10);
            progressPassword.TabIndex = 12;
            // 
            // pBoxLogo
            // 
            pBoxLogo.Location = new Point(360, 20);
            pBoxLogo.Name = "pBoxLogo";
            pBoxLogo.Size = new Size(400, 400);
            pBoxLogo.TabIndex = 13;
            pBoxLogo.TabStop = false;
            // 
            // pBarUsername
            // 
            pBarUsername.BackColor = Color.FromArgb(192, 255, 192);
            pBarUsername.ForeColor = Color.FromArgb(192, 255, 192);
            pBarUsername.Location = new Point(47, 62);
            pBarUsername.Name = "pBarUsername";
            pBarUsername.Size = new Size(281, 10);
            pBarUsername.TabIndex = 14;
            // 
            // pBarDisplayName
            // 
            pBarDisplayName.BackColor = Color.FromArgb(192, 255, 192);
            pBarDisplayName.ForeColor = Color.FromArgb(192, 255, 192);
            pBarDisplayName.Location = new Point(47, 192);
            pBarDisplayName.Name = "pBarDisplayName";
            pBarDisplayName.Size = new Size(281, 10);
            pBarDisplayName.TabIndex = 15;
            // 
            // pBarGender
            // 
            pBarGender.BackColor = Color.FromArgb(192, 255, 192);
            pBarGender.ForeColor = Color.FromArgb(192, 255, 192);
            pBarGender.Location = new Point(47, 257);
            pBarGender.Name = "pBarGender";
            pBarGender.Size = new Size(281, 10);
            pBarGender.TabIndex = 16;
            // 
            // pBarDob
            // 
            pBarDob.BackColor = Color.FromArgb(192, 255, 192);
            pBarDob.ForeColor = Color.FromArgb(192, 255, 192);
            pBarDob.Location = new Point(47, 322);
            pBarDob.Name = "pBarDob";
            pBarDob.Size = new Size(281, 10);
            pBarDob.TabIndex = 17;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(192, 255, 192);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("JetBrains Mono", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            btnBack.Location = new Point(47, 357);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(115, 63);
            btnBack.TabIndex = 7;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // formRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(pBarDob);
            Controls.Add(pBarGender);
            Controls.Add(pBarDisplayName);
            Controls.Add(pBarUsername);
            Controls.Add(pBoxLogo);
            Controls.Add(progressPassword);
            Controls.Add(btnRegister);
            Controls.Add(txtBoxDob);
            Controls.Add(txtBoxGender);
            Controls.Add(txtBoxDisplayName);
            Controls.Add(txtBoxPassword);
            Controls.Add(txtBoxEmail);
            Name = "formRegister";
            Text = "formRegister";
            ((System.ComponentModel.ISupportInitialize)pBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBoxEmail;
        private TextBox txtBoxPassword;
        private TextBox txtBoxDisplayName;
        private Button btnRegister;
        private TextBox txtBoxGender;
        private TextBox txtBoxDob;
        private ProgressBar progressPassword;
        private PictureBox pBoxLogo;
        private ProgressBar pBarUsername;
        private ProgressBar pBarDisplayName;
        private ProgressBar pBarGender;
        private ProgressBar pBarDob;
        private Button btnBack;
    }
}