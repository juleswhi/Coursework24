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
            txtBoxAnswerOne.Location = new Point(155, 131);
            txtBoxAnswerOne.Name = "txtBoxAnswerOne";
            txtBoxAnswerOne.PlaceholderText = "Potential Answer One";
            txtBoxAnswerOne.Size = new Size(527, 23);
            txtBoxAnswerOne.TabIndex = 2;
            // 
            // txtBoxQuestion
            // 
            txtBoxQuestion.Location = new Point(155, 102);
            txtBoxQuestion.Name = "txtBoxQuestion";
            txtBoxQuestion.PlaceholderText = "Question";
            txtBoxQuestion.Size = new Size(527, 23);
            txtBoxQuestion.TabIndex = 1;
            // 
            // txtBoxAnswerFour
            // 
            txtBoxAnswerFour.Location = new Point(155, 218);
            txtBoxAnswerFour.Name = "txtBoxAnswerFour";
            txtBoxAnswerFour.PlaceholderText = "Potential Answer Four";
            txtBoxAnswerFour.Size = new Size(527, 23);
            txtBoxAnswerFour.TabIndex = 5;
            // 
            // txtBoxAnswerThree
            // 
            txtBoxAnswerThree.Location = new Point(155, 189);
            txtBoxAnswerThree.Name = "txtBoxAnswerThree";
            txtBoxAnswerThree.PlaceholderText = "Potential Answer Three";
            txtBoxAnswerThree.Size = new Size(527, 23);
            txtBoxAnswerThree.TabIndex = 4;
            // 
            // txtBoxAnswerTwo
            // 
            txtBoxAnswerTwo.Location = new Point(155, 160);
            txtBoxAnswerTwo.Name = "txtBoxAnswerTwo";
            txtBoxAnswerTwo.PlaceholderText = "Potential Answer Two";
            txtBoxAnswerTwo.Size = new Size(527, 23);
            txtBoxAnswerTwo.TabIndex = 3;
            // 
            // btnCreate
            // 
            btnCreate.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnCreate.Location = new Point(305, 268);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(200, 102);
            btnCreate.TabIndex = 6;
            btnCreate.Text = "CREATE QUESTION";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(688, 135);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(83, 19);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(688, 160);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(83, 19);
            checkBox2.TabIndex = 9;
            checkBox2.Text = "checkBox2";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(688, 189);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(83, 19);
            checkBox3.TabIndex = 9;
            checkBox3.Text = "checkBox3";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(688, 220);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(83, 19);
            checkBox4.TabIndex = 10;
            checkBox4.Text = "checkBox4";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // btnBackToMenu
            // 
            btnBackToMenu.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnBackToMenu.Location = new Point(523, 268);
            btnBackToMenu.Name = "btnBackToMenu";
            btnBackToMenu.Size = new Size(200, 102);
            btnBackToMenu.TabIndex = 11;
            btnBackToMenu.Text = "Back To Menu";
            btnBackToMenu.UseVisualStyleBackColor = true;
            btnBackToMenu.Click += btnBackToMenu_Click;
            // 
            // txtBoxRating
            // 
            txtBoxRating.Location = new Point(167, 265);
            txtBoxRating.Name = "txtBoxRating";
            txtBoxRating.PlaceholderText = "Rating";
            txtBoxRating.Size = new Size(100, 23);
            txtBoxRating.TabIndex = 12;
            txtBoxRating.TextChanged += txtBoxRating_TextChanged;
            // 
            // formAddQuestion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
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