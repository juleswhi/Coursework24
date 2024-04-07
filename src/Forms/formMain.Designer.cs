namespace ChessMasterQuiz
{
    partial class formMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            panelHolder = new Panel();
            SuspendLayout();
            // 
            // panelHolder
            // 
            panelHolder.Dock = DockStyle.Fill;
            panelHolder.Location = new Point(0, 0);
            panelHolder.Name = "panelHolder";
            panelHolder.Size = new Size(800, 450);
            panelHolder.TabIndex = 0;
            // 
            // formMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelHolder);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "formMain";
            Text = "formMain";
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHolder;
    }
}