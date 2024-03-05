namespace ChessMasterQuiz.Forms.Menus
{
    partial class formLeaderboard
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
            flpEntries = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flpEntries
            // 
            flpEntries.BackColor = Color.Silver;
            flpEntries.Location = new Point(165, 68);
            flpEntries.Name = "flpEntries";
            flpEntries.Size = new Size(450, 300);
            flpEntries.TabIndex = 0;
            // 
            // formLeaderboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(flpEntries);
            Name = "formLeaderboard";
            Text = "formLeaderboard";
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpEntries;
    }
}