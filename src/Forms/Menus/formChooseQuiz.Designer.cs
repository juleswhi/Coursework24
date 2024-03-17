namespace ChessMasterQuiz.Forms.Menus
{
    partial class formChooseQuiz
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
            btnPuzzles = new Button();
            btnWrittenQuestions = new Button();
            SuspendLayout();
            // 
            // btnPuzzles
            // 
            btnPuzzles.BackColor = Color.FromArgb(192, 255, 192);
            btnPuzzles.FlatStyle = FlatStyle.Flat;
            btnPuzzles.Font = new Font("JetBrains Mono", 26.2499962F, FontStyle.Regular, GraphicsUnit.Point);
            btnPuzzles.Location = new Point(127, 115);
            btnPuzzles.Name = "btnPuzzles";
            btnPuzzles.Size = new Size(264, 189);
            btnPuzzles.TabIndex = 0;
            btnPuzzles.Text = "Puzzles";
            btnPuzzles.UseVisualStyleBackColor = false;
            btnPuzzles.Click += btnPuzzles_Click;
            // 
            // btnWrittenQuestions
            // 
            btnWrittenQuestions.BackColor = Color.FromArgb(192, 255, 192);
            btnWrittenQuestions.FlatStyle = FlatStyle.Flat;
            btnWrittenQuestions.Font = new Font("JetBrains Mono", 26.2499962F, FontStyle.Regular, GraphicsUnit.Point);
            btnWrittenQuestions.Location = new Point(397, 115);
            btnWrittenQuestions.Name = "btnWrittenQuestions";
            btnWrittenQuestions.Size = new Size(264, 189);
            btnWrittenQuestions.TabIndex = 1;
            btnWrittenQuestions.Text = "Written Questions";
            btnWrittenQuestions.UseVisualStyleBackColor = false;
            btnWrittenQuestions.Click += btnWrittenQuestions_Click;
            // 
            // formChooseQuiz
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(800, 450);
            Controls.Add(btnWrittenQuestions);
            Controls.Add(btnPuzzles);
            Name = "formChooseQuiz";
            Text = "formChooseQuiz";
            ResumeLayout(false);
        }

        #endregion

        private Button btnPuzzles;
        private Button btnWrittenQuestions;
    }
}