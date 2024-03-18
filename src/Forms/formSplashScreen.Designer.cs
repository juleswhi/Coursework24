namespace ChessMasterQuiz.Forms
{
    partial class formSplashScreen
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
            pnlProgressBar = new Panel();
            SuspendLayout();
            // 
            // pnlProgressBar
            // 
            pnlProgressBar.BorderStyle = BorderStyle.FixedSingle;
            pnlProgressBar.Location = new Point(36, 405);
            pnlProgressBar.Name = "pnlProgressBar";
            pnlProgressBar.Size = new Size(731, 33);
            pnlProgressBar.TabIndex = 0;
            // 
            // formSplashScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(800, 450);
            Controls.Add(pnlProgressBar);
            Name = "formSplashScreen";
            Text = "formSplashScreen";
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlProgressBar;
    }
}