namespace ChessMasterQuiz.Forms
{
    partial class formAddQuestion
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
            txtBoxAnswerOne = new TextBox();
            txtBoxQuestion = new TextBox();
            txtBoxAnswerFour = new TextBox();
            txtBoxAnswerThree = new TextBox();
            txtBoxAnswerTwo = new TextBox();
            btnCreate = new Button();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            btnBackToMenu = new Button();
            txtBoxRating = new TextBox();
            SuspendLayout();
            // 
            // txtBoxAnswerOne
            // 
            txtBoxAnswerOne.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxAnswerOne.Location = new Point(21, 119);
            txtBoxAnswerOne.Name = "txtBoxAnswerOne";
            txtBoxAnswerOne.PlaceholderText = "Potential Answer One";
            txtBoxAnswerOne.Size = new Size(527, 35);
            txtBoxAnswerOne.TabIndex = 2;
            // 
            // txtBoxQuestion
            // 
            txtBoxQuestion.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxQuestion.Location = new Point(21, 72);
            txtBoxQuestion.Name = "txtBoxQuestion";
            txtBoxQuestion.PlaceholderText = "Question";
            txtBoxQuestion.Size = new Size(527, 35);
            txtBoxQuestion.TabIndex = 1;
            // 
            // txtBoxAnswerFour
            // 
            txtBoxAnswerFour.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxAnswerFour.Location = new Point(21, 260);
            txtBoxAnswerFour.Name = "txtBoxAnswerFour";
            txtBoxAnswerFour.PlaceholderText = "Potential Answer Four";
            txtBoxAnswerFour.Size = new Size(527, 35);
            txtBoxAnswerFour.TabIndex = 5;
            // 
            // txtBoxAnswerThree
            // 
            txtBoxAnswerThree.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxAnswerThree.Location = new Point(21, 213);
            txtBoxAnswerThree.Name = "txtBoxAnswerThree";
            txtBoxAnswerThree.PlaceholderText = "Potential Answer Three";
            txtBoxAnswerThree.Size = new Size(527, 35);
            txtBoxAnswerThree.TabIndex = 4;
            // 
            // txtBoxAnswerTwo
            // 
            txtBoxAnswerTwo.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxAnswerTwo.Location = new Point(21, 166);
            txtBoxAnswerTwo.Name = "txtBoxAnswerTwo";
            txtBoxAnswerTwo.PlaceholderText = "Potential Answer Two";
            txtBoxAnswerTwo.Size = new Size(527, 35);
            txtBoxAnswerTwo.TabIndex = 3;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.FromArgb(192, 255, 192);
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnCreate.Location = new Point(229, 336);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(200, 102);
            btnCreate.TabIndex = 6;
            btnCreate.Text = "Create Question";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("JetBrains Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox1.Location = new Point(564, 123);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(185, 29);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "Correct Answer";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Font = new Font("JetBrains Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox2.Location = new Point(564, 170);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(185, 29);
            checkBox2.TabIndex = 9;
            checkBox2.Text = "Correct Answer";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Font = new Font("JetBrains Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox3.Location = new Point(564, 217);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(185, 29);
            checkBox3.TabIndex = 9;
            checkBox3.Text = "Correct Answer";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Font = new Font("JetBrains Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox4.Location = new Point(564, 264);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(185, 29);
            checkBox4.TabIndex = 10;
            checkBox4.Text = "Correct Answer";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // btnBackToMenu
            // 
            btnBackToMenu.BackColor = Color.FromArgb(192, 255, 192);
            btnBackToMenu.FlatStyle = FlatStyle.Flat;
            btnBackToMenu.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnBackToMenu.Location = new Point(445, 336);
            btnBackToMenu.Name = "btnBackToMenu";
            btnBackToMenu.Size = new Size(200, 102);
            btnBackToMenu.TabIndex = 11;
            btnBackToMenu.Text = "Admin Menu";
            btnBackToMenu.UseVisualStyleBackColor = false;
            btnBackToMenu.Click += btnBackToMenu_Click;
            // 
            // txtBoxRating
            // 
            txtBoxRating.Font = new Font("JetBrains Mono", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxRating.Location = new Point(21, 359);
            txtBoxRating.Name = "txtBoxRating";
            txtBoxRating.PlaceholderText = "Rating";
            txtBoxRating.Size = new Size(153, 39);
            txtBoxRating.TabIndex = 12;
            // 
            // formAddQuestion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(800, 450);
            Controls.Add(txtBoxRating);
            Controls.Add(btnBackToMenu);
            Controls.Add(checkBox4);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(btnCreate);
            Controls.Add(txtBoxAnswerTwo);
            Controls.Add(txtBoxAnswerThree);
            Controls.Add(txtBoxAnswerFour);
            Controls.Add(txtBoxQuestion);
            Controls.Add(txtBoxAnswerOne);
            Name = "formAddQuestion";
            Text = "formAddQuestion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtBoxAnswerOne;
        private TextBox txtBoxQuestion;
        private TextBox txtBoxAnswerFour;
        private TextBox txtBoxAnswerThree;
        private TextBox txtBoxAnswerTwo;
        private Button btnCreate;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private Button btnBackToMenu;
        private TextBox txtBoxRating;
    }
}