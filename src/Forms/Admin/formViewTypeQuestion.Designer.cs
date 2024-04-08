namespace ChessMasterQuiz.Forms.Admin;

partial class formViewTypeQuestion
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
        lblOpeningName = new Label();
        lblName = new Label();
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
        // lblOpeningName
        // 
        lblOpeningName.AutoSize = true;
        lblOpeningName.Font = new Font("JetBrains Mono", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
        lblOpeningName.Location = new Point(565, 186);
        lblOpeningName.Name = "lblOpeningName";
        lblOpeningName.Size = new Size(223, 36);
        lblOpeningName.TabIndex = 3;
        lblOpeningName.Text = "Opening Name:";
        // 
        // lblName
        // 
        lblName.AutoSize = true;
        lblName.Font = new Font("JetBrains Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
        lblName.Location = new Point(604, 222);
        lblName.Name = "lblName";
        lblName.Size = new Size(56, 25);
        lblName.TabIndex = 4;
        lblName.Text = "name";
        // 
        // formViewTypeQuestion
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(224, 224, 224);
        ClientSize = new Size(800, 450);
        Controls.Add(lblName);
        Controls.Add(lblOpeningName);
        Controls.Add(btnMainMenu);
        Controls.Add(btnPreviousPuzzle);
        Controls.Add(btnNextPuzzle);
        Name = "formViewTypeQuestion";
        Text = "formViewPuzzles";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button btnNextPuzzle;
    private Button btnPreviousPuzzle;
    private Button btnMainMenu;
    private Label lblOpeningName;
    private Label lblName;
}