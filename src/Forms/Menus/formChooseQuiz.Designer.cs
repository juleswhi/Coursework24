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
            btnMainMenu = new Button();
            btnMixed = new Button();
            SuspendLayout();
            // 
            // btnPuzzles
            // 
            btnPuzzles.BackColor = Color.FromArgb(192, 255, 192);
            btnPuzzles.FlatStyle = FlatStyle.Flat;
            btnPuzzles.Font = new Font("JetBrains Mono", 26.2499962F, FontStyle.Regular, GraphicsUnit.Point);
            btnPuzzles.Location = new Point(127, 227);
            btnPuzzles.Name = "btnPuzzles";
            btnPuzzles.Size = new Size(264, 122);
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
            btnWrittenQuestions.Location = new Point(397, 227);
            btnWrittenQuestions.Name = "btnWrittenQuestions";
            btnWrittenQuestions.Size = new Size(264, 122);
            btnWrittenQuestions.TabIndex = 1;
            btnWrittenQuestions.Text = "Written Questions";
            btnWrittenQuestions.UseVisualStyleBackColor = false;
            btnWrittenQuestions.Click += btnWrittenQuestions_Click;
            // 
            // btnMainMenu
            // 
            btnMainMenu.BackColor = Color.FromArgb(192, 255, 192);
            btnMainMenu.FlatStyle = FlatStyle.Flat;
            btnMainMenu.Font = new Font("JetBrains Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnMainMenu.Location = new Point(658, 393);
            btnMainMenu.Name = "btnMainMenu";
            btnMainMenu.Size = new Size(130, 45);
            btnMainMenu.TabIndex = 2;
            btnMainMenu.Text = "Main Menu";
            btnMainMenu.UseVisualStyleBackColor = false;
            btnMainMenu.Click += btnMainMenu_Click;
            // 
            // btnMixed
            // 
            btnMixed.BackColor = Color.FromArgb(192, 255, 192);
            btnMixed.FlatStyle = FlatStyle.Flat;
            btnMixed.Font = new Font("JetBrains Mono", 35.9999962F, FontStyle.Regular, GraphicsUnit.Point);
            btnMixed.Location = new Point(127, 99);
            btnMixed.Name = "btnMixed";
            btnMixed.Size = new Size(534, 122);
            btnMixed.TabIndex = 3;
            btnMixed.Text = "Mixed";
            btnMixed.UseVisualStyleBackColor = false;
            btnMixed.Click += btnMixed_Click;
            // 
            // formChooseQuiz
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(800, 450);
            Controls.Add(btnMixed);
            Controls.Add(btnMainMenu);
            Controls.Add(btnWrittenQuestions);
            Controls.Add(btnPuzzles);
            Name = "formChooseQuiz";
            Text = "formChooseQuiz";
            ResumeLayout(false);
        }

        #endregion

        private Button btnPuzzles;
        private Button btnWrittenQuestions;
        private Button btnMainMenu;
        private Button btnMixed;
    }
}