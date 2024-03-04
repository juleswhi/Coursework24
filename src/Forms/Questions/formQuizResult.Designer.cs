namespace ChessMasterQuiz.QuestionDir
{
    partial class formQuizResult
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
            label1 = new Label();
            lblMainMenu = new Button();
            SuspendLayout();
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Font = new Font("JetBrains Mono", 27.7499962F, FontStyle.Regular, GraphicsUnit.Point);
            lblQuestion.Location = new Point(305, 19);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(198, 49);
            lblQuestion.TabIndex = 1;
            lblQuestion.Text = "Results!";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("JetBrains Mono", 35.9999962F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.SpringGreen;
            label1.Location = new Point(285, 174);
            label1.Name = "label1";
            label1.Size = new Size(172, 63);
            label1.TabIndex = 2;
            label1.Text = "-1/-1";
            // 
            // lblMainMenu
            // 
            lblMainMenu.Font = new Font("JetBrains Mono", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblMainMenu.Location = new Point(607, 385);
            lblMainMenu.Name = "lblMainMenu";
            lblMainMenu.Size = new Size(181, 53);
            lblMainMenu.TabIndex = 13;
            lblMainMenu.Text = "Back To Main Menu";
            lblMainMenu.UseVisualStyleBackColor = true;
            lblMainMenu.Click += lblMainMenu_Click;
            // 
            // formQuizResult
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblMainMenu);
            Controls.Add(label1);
            Controls.Add(lblQuestion);
            Name = "formQuizResult";
            Text = "formQuizResult";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblQuestion;
        private Label label1;
        private Button lblMainMenu;
    }
}