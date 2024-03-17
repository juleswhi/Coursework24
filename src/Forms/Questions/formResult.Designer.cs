namespace ChessMasterQuiz.Forms.Questions
{
    partial class formResult
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
            btnHome = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblQuestion
            // 
            lblQuestion.Anchor = AnchorStyles.None;
            lblQuestion.AutoSize = true;
            lblQuestion.Font = new Font("JetBrains Mono", 35.9999962F, FontStyle.Regular, GraphicsUnit.Point);
            lblQuestion.Location = new Point(257, 183);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(288, 63);
            lblQuestion.TabIndex = 1;
            lblQuestion.Text = "Score/Max";
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.FromArgb(192, 255, 192);
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Location = new Point(658, 387);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(130, 51);
            btnHome.TabIndex = 2;
            btnHome.Text = "Back";
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("JetBrains Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(365, 158);
            label1.Name = "label1";
            label1.Size = new Size(78, 25);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // formResult
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnHome);
            Controls.Add(lblQuestion);
            Name = "formResult";
            Text = "formResult";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblQuestion;
        private Button btnHome;
        private Label label1;
    }
}