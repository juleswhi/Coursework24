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
            btnAnswer1.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnAnswer1.Location = new Point(442, 118);
            btnAnswer1.Name = "btnAnswer1";
            btnAnswer1.Size = new Size(170, 131);
            btnAnswer1.TabIndex = 0;
            btnAnswer1.Text = "button1";
            btnAnswer1.UseVisualStyleBackColor = true;
            // 
            // btnAnswer2
            // 
            btnAnswer2.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnAnswer2.Location = new Point(618, 118);
            btnAnswer2.Name = "btnAnswer2";
            btnAnswer2.Size = new Size(170, 131);
            btnAnswer2.TabIndex = 1;
            btnAnswer2.Text = "button2";
            btnAnswer2.UseVisualStyleBackColor = true;
            // 
            // btnAnswer3
            // 
            btnAnswer3.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnAnswer3.Location = new Point(442, 255);
            btnAnswer3.Name = "btnAnswer3";
            btnAnswer3.Size = new Size(170, 131);
            btnAnswer3.TabIndex = 2;
            btnAnswer3.Text = "button3";
            btnAnswer3.UseVisualStyleBackColor = true;
            // 
            // btnAnswer4
            // 
            btnAnswer4.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnAnswer4.Location = new Point(618, 255);
            btnAnswer4.Name = "btnAnswer4";
            btnAnswer4.Size = new Size(170, 131);
            btnAnswer4.TabIndex = 3;
            btnAnswer4.Text = "button4";
            btnAnswer4.UseVisualStyleBackColor = true;
            // 
            // lblWinningMove
            // 
            lblWinningMove.AutoSize = true;
            lblWinningMove.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblWinningMove.Location = new Point(451, 77);
            lblWinningMove.Name = "lblWinningMove";
            lblWinningMove.Size = new Size(337, 27);
            lblWinningMove.TabIndex = 4;
            lblWinningMove.Text = "What is the winning move?";
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