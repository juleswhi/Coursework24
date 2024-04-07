namespace ChessMasterQuiz.Forms.Questions
{
    partial class formTypeQuestion
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
            txtBoxAnswer = new TextBox();
            lblQuestion = new Label();
            SuspendLayout();
            // 
            // txtBoxAnswer
            // 
            txtBoxAnswer.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxAnswer.Location = new Point(491, 249);
            txtBoxAnswer.Name = "txtBoxAnswer";
            txtBoxAnswer.PlaceholderText = "Answer..";
            txtBoxAnswer.Size = new Size(297, 35);
            txtBoxAnswer.TabIndex = 0;
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblQuestion.Location = new Point(530, 207);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(220, 27);
            lblQuestion.TabIndex = 1;
            lblQuestion.Text = "What {} is this?";
            // 
            // formTypeQuestion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(800, 450);
            Controls.Add(lblQuestion);
            Controls.Add(txtBoxAnswer);
            Name = "formTypeQuestion";
            Text = "formTypeQuestion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBoxAnswer;
        private Label lblQuestion;
    }
}