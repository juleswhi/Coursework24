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
            txtBoxGender = new TextBox();
            txtBoxDob = new TextBox();
            SuspendLayout();
            // 
            // txtBoxEmail
            // 
            txtBoxEmail.AcceptsReturn = true;
            txtBoxEmail.AcceptsTab = true;
            txtBoxEmail.Font = new Font("JetBrains Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxEmail.Location = new Point(276, 12);
            txtBoxEmail.Name = "txtBoxEmail";
            txtBoxEmail.PlaceholderText = "Email";
            txtBoxEmail.Size = new Size(171, 33);
            txtBoxEmail.TabIndex = 9;
            txtBoxEmail.Tag = "email";
            // 
            // txtBoxPassword
            // 
            txtBoxPassword.AcceptsReturn = true;
            txtBoxPassword.AcceptsTab = true;
            txtBoxPassword.Font = new Font("JetBrains Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxPassword.Location = new Point(276, 72);
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
            txtBoxDisplayName.Location = new Point(276, 132);
            txtBoxDisplayName.Name = "txtBoxDisplayName";
            txtBoxDisplayName.PlaceholderText = "Display Name";
            txtBoxDisplayName.Size = new Size(171, 33);
            txtBoxDisplayName.TabIndex = 10;
            txtBoxDisplayName.Tag = "display";
            // 
            // btnRegister
            // 
            btnRegister.Font = new Font("JetBrains Mono", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegister.Location = new Point(276, 339);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(171, 33);
            btnRegister.TabIndex = 11;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // txtBoxGender
            // 
            txtBoxGender.AcceptsReturn = true;
            txtBoxGender.AcceptsTab = true;
            txtBoxGender.Font = new Font("JetBrains Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxGender.Location = new Point(276, 192);
            txtBoxGender.Name = "txtBoxGender";
            txtBoxGender.PlaceholderText = "Gender";
            txtBoxGender.Size = new Size(171, 33);
            txtBoxGender.TabIndex = 10;
            txtBoxGender.Tag = "gender";
            // 
            // txtBoxDob
            // 
            txtBoxDob.AcceptsReturn = true;
            txtBoxDob.AcceptsTab = true;
            txtBoxDob.Font = new Font("JetBrains Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxDob.Location = new Point(276, 252);
            txtBoxDob.Name = "txtBoxDob";
            txtBoxDob.PlaceholderText = "DOB D/M/Y";
            txtBoxDob.Size = new Size(171, 33);
            txtBoxDob.TabIndex = 10;
            txtBoxDob.Tag = "dob";
            // 
            // formRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRegister);
            Controls.Add(txtBoxDob);
            Controls.Add(txtBoxGender);
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
        private TextBox txtBoxGender;
        private TextBox txtBoxDob;
    }
}