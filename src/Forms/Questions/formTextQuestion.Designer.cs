namespace ChessMasterQuiz.QuestionDir
{
    partial class formTextQuestion
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
            lblNumber = new Label();
            btnAnswer1 = new Button();
            btnAnswer2 = new Button();
            btnAnswer4 = new Button();
            btnAnswer3 = new Button();
            SuspendLayout();
            // 
            // lblQuestion
            // 
            lblQuestion.Anchor = AnchorStyles.None;
            lblQuestion.AutoSize = true;
            lblQuestion.Font = new Font("JetBrains Mono", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblQuestion.Location = new Point(341, 48);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(143, 36);
            lblQuestion.TabIndex = 0;
            lblQuestion.Text = "Question";
            // 
            // lblNumber
            // 
            lblNumber.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblNumber.AutoSize = true;
            lblNumber.Font = new Font("JetBrains Mono", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblNumber.Location = new Point(669, 9);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(119, 39);
            lblNumber.TabIndex = 0;
            lblNumber.Text = "Number";
            // 
            // btnAnswer1
            // 
            btnAnswer1.Font = new Font("JetBrains Mono", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            btnAnswer1.Location = new Point(129, 116);
            btnAnswer1.Name = "btnAnswer1";
            btnAnswer1.Size = new Size(277, 120);
            btnAnswer1.TabIndex = 1;
            btnAnswer1.Tag = "1";
            btnAnswer1.Text = "Answer 1";
            btnAnswer1.UseVisualStyleBackColor = true;
            // 
            // btnAnswer2
            // 
            btnAnswer2.Font = new Font("JetBrains Mono", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            btnAnswer2.Location = new Point(412, 116);
            btnAnswer2.Name = "btnAnswer2";
            btnAnswer2.Size = new Size(274, 120);
            btnAnswer2.TabIndex = 2;
            btnAnswer2.Tag = "1";
            btnAnswer2.Text = "Answer 2";
            btnAnswer2.UseVisualStyleBackColor = true;
            // 
            // btnAnswer4
            // 
            btnAnswer4.Font = new Font("JetBrains Mono", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            btnAnswer4.Location = new Point(412, 242);
            btnAnswer4.Name = "btnAnswer4";
            btnAnswer4.Size = new Size(274, 120);
            btnAnswer4.TabIndex = 4;
            btnAnswer4.Tag = "1";
            btnAnswer4.Text = "Answer 4";
            btnAnswer4.UseVisualStyleBackColor = true;
            // 
            // btnAnswer3
            // 
            btnAnswer3.Font = new Font("JetBrains Mono", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            btnAnswer3.Location = new Point(129, 242);
            btnAnswer3.Name = "btnAnswer3";
            btnAnswer3.Size = new Size(277, 120);
            btnAnswer3.TabIndex = 3;
            btnAnswer3.Tag = "1";
            btnAnswer3.Text = "Answer 3";
            btnAnswer3.UseVisualStyleBackColor = true;
            // 
            // formTextQuestion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAnswer4);
            Controls.Add(btnAnswer2);
            Controls.Add(btnAnswer3);
            Controls.Add(btnAnswer1);
            Controls.Add(lblNumber);
            Controls.Add(lblQuestion);
            Name = "formTextQuestion";
            Text = "formTextQuestion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblQuestion;
        private Label lblNumber;
        private Button btnAnswer1;
        private Button btnAnswer2;
        private Button btnAnswer4;
        private Button btnAnswer3;
    }
}