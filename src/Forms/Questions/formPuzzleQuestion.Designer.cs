namespace ChessMasterQuiz.Forms.Questions
{
    partial class formPuzzleQuestion
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
            btnAnswer1 = new Button();
            btnAnswer2 = new Button();
            btnAnswer3 = new Button();
            btnAnswer4 = new Button();
            lblWinningMove = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnAnswer1
            // 
            btnAnswer1.BackColor = Color.FromArgb(192, 255, 192);
            btnAnswer1.FlatStyle = FlatStyle.Flat;
            btnAnswer1.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnAnswer1.Location = new Point(442, 118);
            btnAnswer1.Name = "btnAnswer1";
            btnAnswer1.Size = new Size(170, 131);
            btnAnswer1.TabIndex = 0;
            btnAnswer1.Text = "button1";
            btnAnswer1.UseVisualStyleBackColor = false;
            // 
            // btnAnswer2
            // 
            btnAnswer2.BackColor = Color.FromArgb(192, 255, 192);
            btnAnswer2.FlatStyle = FlatStyle.Flat;
            btnAnswer2.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnAnswer2.Location = new Point(618, 118);
            btnAnswer2.Name = "btnAnswer2";
            btnAnswer2.Size = new Size(170, 131);
            btnAnswer2.TabIndex = 1;
            btnAnswer2.Text = "button2";
            btnAnswer2.UseVisualStyleBackColor = false;
            // 
            // btnAnswer3
            // 
            btnAnswer3.BackColor = Color.FromArgb(192, 255, 192);
            btnAnswer3.FlatStyle = FlatStyle.Flat;
            btnAnswer3.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnAnswer3.Location = new Point(442, 255);
            btnAnswer3.Name = "btnAnswer3";
            btnAnswer3.Size = new Size(170, 131);
            btnAnswer3.TabIndex = 2;
            btnAnswer3.Text = "button3";
            btnAnswer3.UseVisualStyleBackColor = false;
            // 
            // btnAnswer4
            // 
            btnAnswer4.BackColor = Color.FromArgb(192, 255, 192);
            btnAnswer4.FlatStyle = FlatStyle.Flat;
            btnAnswer4.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnAnswer4.Location = new Point(618, 255);
            btnAnswer4.Name = "btnAnswer4";
            btnAnswer4.Size = new Size(170, 131);
            btnAnswer4.TabIndex = 3;
            btnAnswer4.Text = "button4";
            btnAnswer4.UseVisualStyleBackColor = false;
            // 
            // lblWinningMove
            // 
            lblWinningMove.AutoSize = true;
            lblWinningMove.Font = new Font("JetBrains Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblWinningMove.Location = new Point(473, 59);
            lblWinningMove.Name = "lblWinningMove";
            lblWinningMove.Size = new Size(276, 25);
            lblWinningMove.TabIndex = 4;
            lblWinningMove.Text = "What is the winning move";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(698, 9);
            label1.Name = "label1";
            label1.Size = new Size(90, 27);
            label1.TabIndex = 5;
            label1.Text = "label1";
            // 
            // formPuzzleQuestion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(lblWinningMove);
            Controls.Add(btnAnswer4);
            Controls.Add(btnAnswer3);
            Controls.Add(btnAnswer2);
            Controls.Add(btnAnswer1);
            Name = "formPuzzleQuestion";
            Text = "formPuzzleQuestion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAnswer1;
        private Button btnAnswer2;
        private Button btnAnswer3;
        private Button btnAnswer4;
        private Label lblWinningMove;
        private Label label1;
    }
}