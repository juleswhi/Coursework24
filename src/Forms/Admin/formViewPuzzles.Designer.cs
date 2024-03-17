namespace ChessMasterQuiz.Forms.Admin
{
    partial class formViewPuzzles
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
            btnNextPuzzle = new Button();
            btnPreviousPuzzle = new Button();
            btnMainMenu = new Button();
            chckBoxEasyPuzzles = new CheckBox();
            chckBoxHardPuzzles = new CheckBox();
            chckBoxMediumPuzzles = new CheckBox();
            SuspendLayout();
            // 
            // btnNextPuzzle
            // 
            btnNextPuzzle.BackColor = Color.FromArgb(192, 255, 192);
            btnNextPuzzle.FlatStyle = FlatStyle.Flat;
            btnNextPuzzle.Font = new Font("JetBrains Mono", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            btnNextPuzzle.Location = new Point(549, 39);
            btnNextPuzzle.Name = "btnNextPuzzle";
            btnNextPuzzle.Size = new Size(239, 69);
            btnNextPuzzle.TabIndex = 0;
            btnNextPuzzle.Text = "Next Puzzle";
            btnNextPuzzle.UseVisualStyleBackColor = false;
            btnNextPuzzle.Click += btnNextPuzzle_Click;
            // 
            // btnPreviousPuzzle
            // 
            btnPreviousPuzzle.BackColor = Color.FromArgb(192, 255, 192);
            btnPreviousPuzzle.FlatStyle = FlatStyle.Flat;
            btnPreviousPuzzle.Font = new Font("JetBrains Mono", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            btnPreviousPuzzle.Location = new Point(549, 114);
            btnPreviousPuzzle.Name = "btnPreviousPuzzle";
            btnPreviousPuzzle.Size = new Size(239, 69);
            btnPreviousPuzzle.TabIndex = 1;
            btnPreviousPuzzle.Text = "Previous Puzzle";
            btnPreviousPuzzle.UseVisualStyleBackColor = false;
            btnPreviousPuzzle.Click += btnPreviousPuzzle_Click;
            // 
            // btnMainMenu
            // 
            btnMainMenu.BackColor = Color.FromArgb(192, 255, 192);
            btnMainMenu.FlatStyle = FlatStyle.Flat;
            btnMainMenu.Font = new Font("JetBrains Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnMainMenu.Location = new Point(647, 397);
            btnMainMenu.Name = "btnMainMenu";
            btnMainMenu.Size = new Size(141, 41);
            btnMainMenu.TabIndex = 2;
            btnMainMenu.Text = "Admin Menu";
            btnMainMenu.UseVisualStyleBackColor = false;
            btnMainMenu.Click += btnMainMenu_Click;
            // 
            // chckBoxEasyPuzzles
            // 
            chckBoxEasyPuzzles.AutoSize = true;
            chckBoxEasyPuzzles.FlatStyle = FlatStyle.Flat;
            chckBoxEasyPuzzles.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            chckBoxEasyPuzzles.Location = new Point(576, 211);
            chckBoxEasyPuzzles.Name = "chckBoxEasyPuzzles";
            chckBoxEasyPuzzles.Size = new Size(184, 31);
            chckBoxEasyPuzzles.TabIndex = 3;
            chckBoxEasyPuzzles.Text = "Easy Puzzles";
            chckBoxEasyPuzzles.UseVisualStyleBackColor = true;
            // 
            // chckBoxHardPuzzles
            // 
            chckBoxHardPuzzles.AutoSize = true;
            chckBoxHardPuzzles.FlatStyle = FlatStyle.Flat;
            chckBoxHardPuzzles.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            chckBoxHardPuzzles.Location = new Point(576, 285);
            chckBoxHardPuzzles.Name = "chckBoxHardPuzzles";
            chckBoxHardPuzzles.Size = new Size(184, 31);
            chckBoxHardPuzzles.TabIndex = 4;
            chckBoxHardPuzzles.Text = "Hard Puzzles";
            chckBoxHardPuzzles.UseVisualStyleBackColor = true;
            // 
            // chckBoxMediumPuzzles
            // 
            chckBoxMediumPuzzles.AutoSize = true;
            chckBoxMediumPuzzles.FlatStyle = FlatStyle.Flat;
            chckBoxMediumPuzzles.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            chckBoxMediumPuzzles.Location = new Point(576, 248);
            chckBoxMediumPuzzles.Name = "chckBoxMediumPuzzles";
            chckBoxMediumPuzzles.Size = new Size(210, 31);
            chckBoxMediumPuzzles.TabIndex = 5;
            chckBoxMediumPuzzles.Text = "Medium Puzzles";
            chckBoxMediumPuzzles.UseVisualStyleBackColor = true;
            // 
            // formViewPuzzles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(800, 450);
            Controls.Add(chckBoxMediumPuzzles);
            Controls.Add(chckBoxHardPuzzles);
            Controls.Add(chckBoxEasyPuzzles);
            Controls.Add(btnMainMenu);
            Controls.Add(btnPreviousPuzzle);
            Controls.Add(btnNextPuzzle);
            Name = "formViewPuzzles";
            Text = "formViewPuzzles";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnNextPuzzle;
        private Button btnPreviousPuzzle;
        private Button btnMainMenu;
        private CheckBox chckBoxEasyPuzzles;
        private CheckBox chckBoxHardPuzzles;
        private CheckBox chckBoxMediumPuzzles;
    }
}