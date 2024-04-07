namespace ChessMasterQuiz.Forms.Admin
{
    partial class formViewQuestions
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
            lblQuestion = new Label();
            lblQuestionText = new Label();
            lblAnswers = new Label();
            lblAnswerOne = new Label();
            lblAnswerFour = new Label();
            lblAnswerThree = new Label();
            lblAnswerTwo = new Label();
            btnPreviousQuestion = new Button();
            btnNextPuzzle = new Button();
            btnMainMenu = new Button();
            SuspendLayout();
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Font = new Font("JetBrains Mono", 26.2499962F, FontStyle.Regular, GraphicsUnit.Point);
            lblQuestion.Location = new Point(28, 26);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(209, 47);
            lblQuestion.TabIndex = 0;
            lblQuestion.Text = "Question:";
            // 
            // lblQuestionText
            // 
            lblQuestionText.AutoSize = true;
            lblQuestionText.Font = new Font("JetBrains Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblQuestionText.Location = new Point(38, 73);
            lblQuestionText.Name = "lblQuestionText";
            lblQuestionText.Size = new Size(111, 25);
            lblQuestionText.TabIndex = 1;
            lblQuestionText.Text = "Text Here";
            // 
            // lblAnswers
            // 
            lblAnswers.AutoSize = true;
            lblAnswers.Font = new Font("JetBrains Mono", 26.2499962F, FontStyle.Regular, GraphicsUnit.Point);
            lblAnswers.Location = new Point(28, 131);
            lblAnswers.Name = "lblAnswers";
            lblAnswers.Size = new Size(188, 47);
            lblAnswers.TabIndex = 2;
            lblAnswers.Text = "Answers:";
            // 
            // lblAnswerOne
            // 
            lblAnswerOne.AutoSize = true;
            lblAnswerOne.Font = new Font("JetBrains Mono", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblAnswerOne.Location = new Point(38, 178);
            lblAnswerOne.Name = "lblAnswerOne";
            lblAnswerOne.Size = new Size(63, 36);
            lblAnswerOne.TabIndex = 3;
            lblAnswerOne.Tag = "1.";
            lblAnswerOne.Text = "1. ";
            // 
            // lblAnswerFour
            // 
            lblAnswerFour.AutoSize = true;
            lblAnswerFour.Font = new Font("JetBrains Mono", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblAnswerFour.Location = new Point(38, 343);
            lblAnswerFour.Name = "lblAnswerFour";
            lblAnswerFour.Size = new Size(47, 36);
            lblAnswerFour.TabIndex = 4;
            lblAnswerFour.Tag = "4.";
            lblAnswerFour.Text = "4.";
            // 
            // lblAnswerThree
            // 
            lblAnswerThree.AutoSize = true;
            lblAnswerThree.Font = new Font("JetBrains Mono", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblAnswerThree.Location = new Point(38, 288);
            lblAnswerThree.Name = "lblAnswerThree";
            lblAnswerThree.Size = new Size(47, 36);
            lblAnswerThree.TabIndex = 5;
            lblAnswerThree.Tag = "3.";
            lblAnswerThree.Text = "3.";
            // 
            // lblAnswerTwo
            // 
            lblAnswerTwo.AutoSize = true;
            lblAnswerTwo.Font = new Font("JetBrains Mono", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblAnswerTwo.Location = new Point(38, 233);
            lblAnswerTwo.Name = "lblAnswerTwo";
            lblAnswerTwo.Size = new Size(47, 36);
            lblAnswerTwo.TabIndex = 6;
            lblAnswerTwo.Tag = "2.";
            lblAnswerTwo.Text = "2.";
            // 
            // btnPreviousQuestion
            // 
            btnPreviousQuestion.BackColor = Color.FromArgb(192, 255, 192);
            btnPreviousQuestion.FlatStyle = FlatStyle.Flat;
            btnPreviousQuestion.Font = new Font("JetBrains Mono", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            btnPreviousQuestion.Location = new Point(537, 101);
            btnPreviousQuestion.Name = "btnPreviousQuestion";
            btnPreviousQuestion.Size = new Size(239, 77);
            btnPreviousQuestion.TabIndex = 8;
            btnPreviousQuestion.Text = "Previous Question";
            btnPreviousQuestion.UseVisualStyleBackColor = false;
            btnPreviousQuestion.Click += btnPreviousQuestion_Click;
            // 
            // btnNextPuzzle
            // 
            btnNextPuzzle.BackColor = Color.FromArgb(192, 255, 192);
            btnNextPuzzle.FlatStyle = FlatStyle.Flat;
            btnNextPuzzle.Font = new Font("JetBrains Mono", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            btnNextPuzzle.Location = new Point(537, 26);
            btnNextPuzzle.Name = "btnNextPuzzle";
            btnNextPuzzle.Size = new Size(239, 69);
            btnNextPuzzle.TabIndex = 7;
            btnNextPuzzle.Text = "Next Question";
            btnNextPuzzle.UseVisualStyleBackColor = false;
            btnNextPuzzle.Click += btnNextPuzzle_Click;
            // 
            // btnMainMenu
            // 
            btnMainMenu.BackColor = Color.FromArgb(192, 255, 192);
            btnMainMenu.FlatStyle = FlatStyle.Flat;
            btnMainMenu.Font = new Font("JetBrains Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnMainMenu.Location = new Point(647, 397);
            btnMainMenu.Name = "btnMainMenu";
            btnMainMenu.Size = new Size(141, 41);
            btnMainMenu.TabIndex = 9;
            btnMainMenu.Text = "Admin Menu";
            btnMainMenu.UseVisualStyleBackColor = false;
            btnMainMenu.Click += btnMainMenu_Click;
            // 
            // formViewQuestions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnMainMenu);
            Controls.Add(btnPreviousQuestion);
            Controls.Add(btnNextPuzzle);
            Controls.Add(lblAnswerTwo);
            Controls.Add(lblAnswerThree);
            Controls.Add(lblAnswerFour);
            Controls.Add(lblAnswerOne);
            Controls.Add(lblAnswers);
            Controls.Add(lblQuestionText);
            Controls.Add(lblQuestion);
            Name = "formViewQuestions";
            Text = "formViewQuestions";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblQuestion;
        private Label lblQuestionText;
        private Label lblAnswers;
        private Label lblAnswerOne;
        private Label lblAnswerFour;
        private Label lblAnswerThree;
        private Label lblAnswerTwo;
        private Button btnPreviousQuestion;
        private Button btnNextPuzzle;
        private Button btnMainMenu;
    }
}