namespace ChessMasterQuiz.Forms.Admin
{
    partial class formAdminMenu
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
            btnViewPuzzles = new Button();
            btnViewQuestions = new Button();
            label1 = new Label();
            chckBoxPasswordStrong = new CheckBox();
            label2 = new Label();
            checkBoxPasswordWeak = new CheckBox();
            chckBoxPasswordMedium = new CheckBox();
            btnCreatePuzzles = new Button();
            btnCreateQuestions = new Button();
            label3 = new Label();
            btnMainMenu = new Button();
            label4 = new Label();
            txtBoxPromote = new TextBox();
            btnPromote = new Button();
            btnDemote = new Button();
            SuspendLayout();
            // 
            // btnViewPuzzles
            // 
            btnViewPuzzles.BackColor = Color.FromArgb(192, 255, 192);
            btnViewPuzzles.FlatStyle = FlatStyle.Flat;
            btnViewPuzzles.Font = new Font("JetBrains Mono", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            btnViewPuzzles.Location = new Point(17, 70);
            btnViewPuzzles.Name = "btnViewPuzzles";
            btnViewPuzzles.Size = new Size(283, 79);
            btnViewPuzzles.TabIndex = 2;
            btnViewPuzzles.Text = "View All Puzzles";
            btnViewPuzzles.UseVisualStyleBackColor = false;
            btnViewPuzzles.Click += btnViewPuzzles_Click;
            // 
            // btnViewQuestions
            // 
            btnViewQuestions.BackColor = Color.FromArgb(192, 255, 192);
            btnViewQuestions.FlatStyle = FlatStyle.Flat;
            btnViewQuestions.Font = new Font("JetBrains Mono", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            btnViewQuestions.Location = new Point(17, 155);
            btnViewQuestions.Name = "btnViewQuestions";
            btnViewQuestions.Size = new Size(283, 79);
            btnViewQuestions.TabIndex = 3;
            btnViewQuestions.Text = "View All Questions";
            btnViewQuestions.UseVisualStyleBackColor = false;
            btnViewQuestions.Click += btnViewQuestions_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("JetBrains Mono", 26.2499962F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 243);
            label1.Name = "label1";
            label1.Size = new Size(293, 47);
            label1.TabIndex = 4;
            label1.Text = "User Settings";
            // 
            // chckBoxPasswordStrong
            // 
            chckBoxPasswordStrong.AutoSize = true;
            chckBoxPasswordStrong.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            chckBoxPasswordStrong.Location = new Point(78, 320);
            chckBoxPasswordStrong.Name = "chckBoxPasswordStrong";
            chckBoxPasswordStrong.Size = new Size(109, 31);
            chckBoxPasswordStrong.TabIndex = 5;
            chckBoxPasswordStrong.Tag = "Strong";
            chckBoxPasswordStrong.Text = "Strong";
            chckBoxPasswordStrong.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(17, 290);
            label2.Name = "label2";
            label2.Size = new Size(233, 27);
            label2.TabIndex = 8;
            label2.Text = "Password Strength";
            // 
            // checkBoxPasswordWeak
            // 
            checkBoxPasswordWeak.AutoSize = true;
            checkBoxPasswordWeak.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxPasswordWeak.Location = new Point(78, 394);
            checkBoxPasswordWeak.Name = "checkBoxPasswordWeak";
            checkBoxPasswordWeak.Size = new Size(83, 31);
            checkBoxPasswordWeak.TabIndex = 9;
            checkBoxPasswordWeak.Tag = "Weak";
            checkBoxPasswordWeak.Text = "Weak";
            checkBoxPasswordWeak.UseVisualStyleBackColor = true;
            // 
            // chckBoxPasswordMedium
            // 
            chckBoxPasswordMedium.AutoSize = true;
            chckBoxPasswordMedium.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            chckBoxPasswordMedium.Location = new Point(78, 357);
            chckBoxPasswordMedium.Name = "chckBoxPasswordMedium";
            chckBoxPasswordMedium.Size = new Size(109, 31);
            chckBoxPasswordMedium.TabIndex = 10;
            chckBoxPasswordMedium.Tag = "Medium";
            chckBoxPasswordMedium.Text = "Medium";
            chckBoxPasswordMedium.UseVisualStyleBackColor = true;
            // 
            // btnCreatePuzzles
            // 
            btnCreatePuzzles.BackColor = Color.FromArgb(192, 255, 192);
            btnCreatePuzzles.FlatStyle = FlatStyle.Flat;
            btnCreatePuzzles.Font = new Font("JetBrains Mono", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            btnCreatePuzzles.Location = new Point(324, 70);
            btnCreatePuzzles.Name = "btnCreatePuzzles";
            btnCreatePuzzles.Size = new Size(283, 79);
            btnCreatePuzzles.TabIndex = 11;
            btnCreatePuzzles.Text = "Create Puzzle";
            btnCreatePuzzles.UseVisualStyleBackColor = false;
            btnCreatePuzzles.Click += btnCreatePuzzles_Click;
            // 
            // btnCreateQuestions
            // 
            btnCreateQuestions.BackColor = Color.FromArgb(192, 255, 192);
            btnCreateQuestions.FlatStyle = FlatStyle.Flat;
            btnCreateQuestions.Font = new Font("JetBrains Mono", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            btnCreateQuestions.Location = new Point(324, 155);
            btnCreateQuestions.Name = "btnCreateQuestions";
            btnCreateQuestions.Size = new Size(283, 79);
            btnCreateQuestions.TabIndex = 12;
            btnCreateQuestions.Text = "Create Question";
            btnCreateQuestions.UseVisualStyleBackColor = false;
            btnCreateQuestions.Click += btnCreateQuestions_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("JetBrains Mono", 26.2499962F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(17, 9);
            label3.Name = "label3";
            label3.Size = new Size(377, 47);
            label3.TabIndex = 13;
            label3.Text = "Question Settings";
            // 
            // btnMainMenu
            // 
            btnMainMenu.BackColor = Color.FromArgb(192, 255, 192);
            btnMainMenu.FlatStyle = FlatStyle.Flat;
            btnMainMenu.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnMainMenu.Location = new Point(642, 394);
            btnMainMenu.Name = "btnMainMenu";
            btnMainMenu.Size = new Size(146, 44);
            btnMainMenu.TabIndex = 14;
            btnMainMenu.Text = "Main Menu";
            btnMainMenu.UseVisualStyleBackColor = false;
            btnMainMenu.Click += btnMainMenu_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(324, 308);
            label4.Name = "label4";
            label4.Size = new Size(194, 27);
            label4.TabIndex = 15;
            label4.Text = "User Promotion";
            // 
            // txtBoxPromote
            // 
            txtBoxPromote.BorderStyle = BorderStyle.FixedSingle;
            txtBoxPromote.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxPromote.Location = new Point(296, 338);
            txtBoxPromote.Name = "txtBoxPromote";
            txtBoxPromote.PlaceholderText = "Username..";
            txtBoxPromote.Size = new Size(246, 35);
            txtBoxPromote.TabIndex = 16;
            // 
            // btnPromote
            // 
            btnPromote.BackColor = Color.FromArgb(192, 255, 192);
            btnPromote.FlatStyle = FlatStyle.Flat;
            btnPromote.Font = new Font("JetBrains Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnPromote.Location = new Point(296, 379);
            btnPromote.Name = "btnPromote";
            btnPromote.Size = new Size(120, 32);
            btnPromote.TabIndex = 17;
            btnPromote.Text = "Promote";
            btnPromote.UseVisualStyleBackColor = false;
            btnPromote.Click += btnPromote_Click;
            // 
            // btnDemote
            // 
            btnDemote.BackColor = Color.FromArgb(192, 255, 192);
            btnDemote.FlatStyle = FlatStyle.Flat;
            btnDemote.Font = new Font("JetBrains Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnDemote.Location = new Point(422, 379);
            btnDemote.Name = "btnDemote";
            btnDemote.Size = new Size(120, 32);
            btnDemote.TabIndex = 18;
            btnDemote.Text = "Demote";
            btnDemote.UseVisualStyleBackColor = false;
            btnDemote.Click += btnDemote_Click;
            // 
            // formAdminMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(800, 450);
            Controls.Add(btnDemote);
            Controls.Add(btnPromote);
            Controls.Add(txtBoxPromote);
            Controls.Add(label4);
            Controls.Add(btnMainMenu);
            Controls.Add(label3);
            Controls.Add(btnCreateQuestions);
            Controls.Add(btnCreatePuzzles);
            Controls.Add(chckBoxPasswordMedium);
            Controls.Add(checkBoxPasswordWeak);
            Controls.Add(label2);
            Controls.Add(chckBoxPasswordStrong);
            Controls.Add(label1);
            Controls.Add(btnViewQuestions);
            Controls.Add(btnViewPuzzles);
            Name = "formAdminMenu";
            Text = "formAdminMenu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnViewPuzzles;
        private Button btnViewQuestions;
        private Label label1;
        private CheckBox chckBoxPasswordStrong;
        private Label label2;
        private CheckBox checkBoxPasswordWeak;
        private CheckBox chckBoxPasswordMedium;
        private Button btnCreatePuzzles;
        private Button btnCreateQuestions;
        private Label label3;
        private Button btnMainMenu;
        private Label label4;
        private TextBox txtBoxPromote;
        private Button btnPromote;
        private Button btnDemote;
    }
}