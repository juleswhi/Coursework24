namespace FamousLakesQuiz
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
            lblRegister = new Label();
            SuspendLayout();
            // 
            // txtBoxEmail
            // 
            txtBoxEmail.AcceptsReturn = true;
            txtBoxEmail.AcceptsTab = true;
            txtBoxEmail.Font = new Font("JetBrains Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxEmail.Location = new Point(276, 27);
            txtBoxEmail.Name = "txtBoxEmail";
            txtBoxEmail.PlaceholderText = "Email";
            txtBoxEmail.Size = new Size(171, 33);
            txtBoxEmail.TabIndex = 9;
            txtBoxEmail.Tag = "password";
            // 
            // txtBoxPassword
            // 
            txtBoxPassword.AcceptsReturn = true;
            txtBoxPassword.AcceptsTab = true;
            txtBoxPassword.Font = new Font("JetBrains Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxPassword.Location = new Point(276, 84);
            txtBoxPassword.Name = "txtBoxPassword";
            txtBoxPassword.PlaceholderText = "Password";
            txtBoxPassword.Size = new Size(171, 33);
            txtBoxPassword.TabIndex = 10;
            txtBoxPassword.Tag = "password";
            // 
            // txtBoxDisplayName
            // 
            txtBoxDisplayName.AcceptsReturn = true;
            txtBoxDisplayName.AcceptsTab = true;
            txtBoxDisplayName.Font = new Font("JetBrains Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxDisplayName.Location = new Point(276, 141);
            txtBoxDisplayName.Name = "txtBoxDisplayName";
            txtBoxDisplayName.PlaceholderText = "Display Name";
            txtBoxDisplayName.Size = new Size(171, 33);
            txtBoxDisplayName.TabIndex = 10;
            txtBoxDisplayName.Tag = "password";
            // 
            // btnRegister
            // 
            btnRegister.Font = new Font("JetBrains Mono", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegister.Location = new Point(276, 263);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(171, 33);
            btnRegister.TabIndex = 11;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            // 
            // lblRegister
            // 
            lblRegister.AutoSize = true;
            lblRegister.Font = new Font("JetBrains Mono", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            lblRegister.Location = new Point(523, 57);
            lblRegister.Name = "lblRegister";
            lblRegister.Size = new Size(126, 31);
            lblRegister.TabIndex = 12;
            lblRegister.Text = "Register";
            // 
            // formRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblRegister);
            Controls.Add(btnRegister);
            Controls.Add(txtBoxDisplayName);
            Controls.Add(txtBoxPassword);
            Controls.Add(txtBoxEmail);
            Name = "formRegister";
            Text = "formRegister";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBoxEmail;
        private TextBox txtBoxPassword;
        private TextBox txtBoxDisplayName;
        private Button btnRegister;
        private Label lblRegister;
    }
}