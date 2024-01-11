namespace FamousLakesQuiz
{
    partial class formLogin
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
            lblNewQuiz = new Label();
            lblLogin = new Label();
            txtBoxEmailRegister = new TextBox();
            btnRegister = new Button();
            txtBoxEmail = new TextBox();
            txtBoxPassword = new TextBox();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // lblNewQuiz
            // 
            lblNewQuiz.AutoSize = true;
            lblNewQuiz.Font = new Font("JetBrains Mono", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            lblNewQuiz.Location = new Point(282, 288);
            lblNewQuiz.Name = "lblNewQuiz";
            lblNewQuiz.Size = new Size(238, 31);
            lblNewQuiz.TabIndex = 3;
            lblNewQuiz.Text = "New to the Quiz?";
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("JetBrains Mono", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            lblLogin.Location = new Point(338, 20);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(84, 31);
            lblLogin.TabIndex = 4;
            lblLogin.Text = "Login";
            // 
            // txtBoxEmailRegister
            // 
            txtBoxEmailRegister.AcceptsReturn = true;
            txtBoxEmailRegister.AcceptsTab = true;
            txtBoxEmailRegister.Font = new Font("JetBrains Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxEmailRegister.Location = new Point(266, 322);
            txtBoxEmailRegister.Name = "txtBoxEmailRegister";
            txtBoxEmailRegister.PlaceholderText = "Email";
            txtBoxEmailRegister.Size = new Size(171, 33);
            txtBoxEmailRegister.TabIndex = 5;
            // 
            // btnRegister
            // 
            btnRegister.Font = new Font("JetBrains Mono", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegister.Location = new Point(443, 322);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(97, 33);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            // 
            // txtBoxEmail
            // 
            txtBoxEmail.AcceptsReturn = true;
            txtBoxEmail.AcceptsTab = true;
            txtBoxEmail.Font = new Font("JetBrains Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxEmail.Location = new Point(298, 64);
            txtBoxEmail.Name = "txtBoxEmail";
            txtBoxEmail.PlaceholderText = "Email";
            txtBoxEmail.Size = new Size(171, 33);
            txtBoxEmail.TabIndex = 8;
            // 
            // txtBoxPassword
            // 
            txtBoxPassword.AcceptsReturn = true;
            txtBoxPassword.AcceptsTab = true;
            txtBoxPassword.Font = new Font("JetBrains Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxPassword.Location = new Point(298, 103);
            txtBoxPassword.Name = "txtBoxPassword";
            txtBoxPassword.PasswordChar = '*';
            txtBoxPassword.PlaceholderText = "Password";
            txtBoxPassword.Size = new Size(171, 33);
            txtBoxPassword.TabIndex = 8;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("JetBrains Mono", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogin.Location = new Point(338, 152);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(97, 33);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            // 
            // formLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtBoxPassword);
            Controls.Add(txtBoxEmail);
            Controls.Add(btnLogin);
            Controls.Add(btnRegister);
            Controls.Add(txtBoxEmailRegister);
            Controls.Add(lblLogin);
            Controls.Add(lblNewQuiz);
            Name = "formLogin";
            Text = "formLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNewQuiz;
        private Label lblLogin;
        private TextBox txtBoxEmailRegister;
        private Button btnRegister;
        private TextBox txtBoxEmail;
        private TextBox txtBoxPassword;
        private Button btnLogin;
    }
}