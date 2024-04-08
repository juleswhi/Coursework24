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
            btnSubmit = new Button();
            lblNumber = new Label();
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
            lblQuestion.Location = new Point(491, 207);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(285, 27);
            lblQuestion.TabIndex = 1;
            lblQuestion.Text = "What opening is this?";
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.FromArgb(192, 255, 192);
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnSubmit.Location = new Point(491, 290);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(297, 45);
            btnSubmit.TabIndex = 15;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // lblNumber
            // 
            lblNumber.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblNumber.AutoSize = true;
            lblNumber.Font = new Font("JetBrains Mono", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblNumber.Location = new Point(669, 9);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(119, 39);
            lblNumber.TabIndex = 16;
            lblNumber.Text = "Number";
            // 
            // formTypeQuestion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(800, 450);
            Controls.Add(lblNumber);
            Controls.Add(btnSubmit);
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
        private Button btnSubmit;
        private Label lblNumber;
    }
}