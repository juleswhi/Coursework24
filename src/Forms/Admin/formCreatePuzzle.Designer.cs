﻿namespace ChessMasterQuiz.Forms.Admin
{
    partial class formCreatePuzzle
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
            txtBoxLocation = new TextBox();
            btnAddPiece = new Button();
            txtBoxWinningMove = new TextBox();
            txtBoxAlternative1 = new TextBox();
            txtBoxAlternative2 = new TextBox();
            txtBoxAlternative3 = new TextBox();
            btnCreatePuzzle = new Button();
            txtBoxRating = new TextBox();
            btnBack = new Button();
            cBoxToMove = new CheckBox();
            pBoxWhitePawn = new PictureBox();
            pBoxWhiteQueen = new PictureBox();
            pBoxWhiteRook = new PictureBox();
            pBoxWhiteBishop = new PictureBox();
            pBoxWhiteKnight = new PictureBox();
            pBoxWhiteKing = new PictureBox();
            pBoxBlackKing = new PictureBox();
            pBoxBlackQueen = new PictureBox();
            pBoxBlackRook = new PictureBox();
            pBoxBlackBishop = new PictureBox();
            pBoxBlackKnight = new PictureBox();
            pBoxBlackPawn = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pBoxWhitePawn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pBoxWhiteQueen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pBoxWhiteRook).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pBoxWhiteBishop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pBoxWhiteKnight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pBoxWhiteKing).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pBoxBlackKing).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pBoxBlackQueen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pBoxBlackRook).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pBoxBlackBishop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pBoxBlackKnight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pBoxBlackPawn).BeginInit();
            SuspendLayout();
            // 
            // txtBoxLocation
            // 
            txtBoxLocation.Location = new Point(528, 416);
            txtBoxLocation.Name = "txtBoxLocation";
            txtBoxLocation.PlaceholderText = "Location..";
            txtBoxLocation.Size = new Size(100, 23);
            txtBoxLocation.TabIndex = 1;
            // 
            // btnAddPiece
            // 
            btnAddPiece.Location = new Point(623, 237);
            btnAddPiece.Name = "btnAddPiece";
            btnAddPiece.Size = new Size(75, 23);
            btnAddPiece.TabIndex = 3;
            btnAddPiece.Text = "Add";
            btnAddPiece.UseVisualStyleBackColor = true;
            btnAddPiece.Click += btnAddPiece_Click;
            // 
            // txtBoxWinningMove
            // 
            txtBoxWinningMove.Location = new Point(632, 357);
            txtBoxWinningMove.Name = "txtBoxWinningMove";
            txtBoxWinningMove.PlaceholderText = "Winning Move..";
            txtBoxWinningMove.Size = new Size(75, 23);
            txtBoxWinningMove.TabIndex = 4;
            // 
            // txtBoxAlternative1
            // 
            txtBoxAlternative1.Location = new Point(713, 357);
            txtBoxAlternative1.Name = "txtBoxAlternative1";
            txtBoxAlternative1.PlaceholderText = "Alternative Move";
            txtBoxAlternative1.Size = new Size(75, 23);
            txtBoxAlternative1.TabIndex = 5;
            // 
            // txtBoxAlternative2
            // 
            txtBoxAlternative2.Location = new Point(713, 386);
            txtBoxAlternative2.Name = "txtBoxAlternative2";
            txtBoxAlternative2.PlaceholderText = "Alternative Move";
            txtBoxAlternative2.Size = new Size(75, 23);
            txtBoxAlternative2.TabIndex = 6;
            // 
            // txtBoxAlternative3
            // 
            txtBoxAlternative3.Location = new Point(632, 386);
            txtBoxAlternative3.Name = "txtBoxAlternative3";
            txtBoxAlternative3.PlaceholderText = "Alternative Move";
            txtBoxAlternative3.Size = new Size(75, 23);
            txtBoxAlternative3.TabIndex = 7;
            // 
            // btnCreatePuzzle
            // 
            btnCreatePuzzle.Location = new Point(632, 415);
            btnCreatePuzzle.Name = "btnCreatePuzzle";
            btnCreatePuzzle.Size = new Size(75, 23);
            btnCreatePuzzle.TabIndex = 8;
            btnCreatePuzzle.Text = "Create Puzzle";
            btnCreatePuzzle.UseVisualStyleBackColor = true;
            btnCreatePuzzle.Click += btnCreatePuzzle_Click;
            // 
            // txtBoxRating
            // 
            txtBoxRating.Location = new Point(659, 295);
            txtBoxRating.Name = "txtBoxRating";
            txtBoxRating.PlaceholderText = "Rating..";
            txtBoxRating.Size = new Size(100, 23);
            txtBoxRating.TabIndex = 9;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(713, 415);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 11;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // cBoxToMove
            // 
            cBoxToMove.AutoSize = true;
            cBoxToMove.Location = new Point(659, 324);
            cBoxToMove.Name = "cBoxToMove";
            cBoxToMove.Size = new Size(105, 19);
            cBoxToMove.TabIndex = 13;
            cBoxToMove.Text = "White To Move";
            cBoxToMove.UseVisualStyleBackColor = true;
            // 
            // pBoxWhitePawn
            // 
            pBoxWhitePawn.Image = Chess.ChessPieces.WhitePawn;
            pBoxWhitePawn.Location = new Point(577, 24);
            pBoxWhitePawn.Name = "pBoxWhitePawn";
            pBoxWhitePawn.Size = new Size(51, 47);
            pBoxWhitePawn.TabIndex = 14;
            pBoxWhitePawn.TabStop = false;
            pBoxWhitePawn.Click += pBoxWhitePawn_Click;
            // 
            // pBoxWhiteQueen
            // 
            pBoxWhiteQueen.Image = Chess.ChessPieces.WhiteQueen;
            pBoxWhiteQueen.Location = new Point(689, 24);
            pBoxWhiteQueen.Name = "pBoxWhiteQueen";
            pBoxWhiteQueen.Size = new Size(51, 47);
            pBoxWhiteQueen.TabIndex = 15;
            pBoxWhiteQueen.TabStop = false;
            pBoxWhiteQueen.Click += pBoxWhiteQueen_Click;
            // 
            // pBoxWhiteRook
            // 
            pBoxWhiteRook.Image = Chess.ChessPieces.WhiteRook;
            pBoxWhiteRook.Location = new Point(634, 78);
            pBoxWhiteRook.Name = "pBoxWhiteRook";
            pBoxWhiteRook.Size = new Size(51, 47);
            pBoxWhiteRook.TabIndex = 16;
            pBoxWhiteRook.TabStop = false;
            pBoxWhiteRook.Click += pBoxWhiteRook_Click;
            // 
            // pBoxWhiteBishop
            // 
            pBoxWhiteBishop.Image = Chess.ChessPieces.WhiteBishop;
            pBoxWhiteBishop.Location = new Point(632, 24);
            pBoxWhiteBishop.Name = "pBoxWhiteBishop";
            pBoxWhiteBishop.Size = new Size(51, 47);
            pBoxWhiteBishop.TabIndex = 17;
            pBoxWhiteBishop.TabStop = false;
            pBoxWhiteBishop.Click += pBoxWhiteBishop_Click;
            // 
            // pBoxWhiteKnight
            // 
            pBoxWhiteKnight.Image = Chess.ChessPieces.WhiteKnight;
            pBoxWhiteKnight.Location = new Point(577, 78);
            pBoxWhiteKnight.Name = "pBoxWhiteKnight";
            pBoxWhiteKnight.Size = new Size(51, 47);
            pBoxWhiteKnight.TabIndex = 18;
            pBoxWhiteKnight.TabStop = false;
            pBoxWhiteKnight.Click += pBoxWhiteKnight_Click;
            // 
            // pBoxWhiteKing
            // 
            pBoxWhiteKing.Image = Chess.ChessPieces.WhiteKing;
            pBoxWhiteKing.Location = new Point(689, 77);
            pBoxWhiteKing.Name = "pBoxWhiteKing";
            pBoxWhiteKing.Size = new Size(51, 47);
            pBoxWhiteKing.TabIndex = 19;
            pBoxWhiteKing.TabStop = false;
            pBoxWhiteKing.Click += pBoxWhiteKing_Click;
            // 
            // pBoxBlackKing
            // 
            pBoxBlackKing.Image = Chess.ChessPieces.BlackKing;
            pBoxBlackKing.Location = new Point(691, 183);
            pBoxBlackKing.Name = "pBoxBlackKing";
            pBoxBlackKing.Size = new Size(51, 47);
            pBoxBlackKing.TabIndex = 20;
            pBoxBlackKing.TabStop = false;
            pBoxBlackKing.Click += pBoxBlackKing_Click;
            // 
            // pBoxBlackQueen
            // 
            pBoxBlackQueen.Image = Chess.ChessPieces.BlackQueen;
            pBoxBlackQueen.Location = new Point(634, 184);
            pBoxBlackQueen.Name = "pBoxBlackQueen";
            pBoxBlackQueen.Size = new Size(51, 47);
            pBoxBlackQueen.TabIndex = 21;
            pBoxBlackQueen.TabStop = false;
            pBoxBlackQueen.Click += pBoxBlackQueen_Click;
            // 
            // pBoxBlackRook
            // 
            pBoxBlackRook.Image = Chess.ChessPieces.BlackRook;
            pBoxBlackRook.Location = new Point(577, 184);
            pBoxBlackRook.Name = "pBoxBlackRook";
            pBoxBlackRook.Size = new Size(51, 47);
            pBoxBlackRook.TabIndex = 22;
            pBoxBlackRook.TabStop = false;
            pBoxBlackRook.Click += pBoxBlackRook_Click;
            // 
            // pBoxBlackBishop
            // 
            pBoxBlackBishop.Image = Chess.ChessPieces.BlackBishop;
            pBoxBlackBishop.Location = new Point(689, 130);
            pBoxBlackBishop.Name = "pBoxBlackBishop";
            pBoxBlackBishop.Size = new Size(51, 47);
            pBoxBlackBishop.TabIndex = 23;
            pBoxBlackBishop.TabStop = false;
            pBoxBlackBishop.Click += pBoxBlackBishop_Click;
            // 
            // pBoxBlackKnight
            // 
            pBoxBlackKnight.Image = Chess.ChessPieces.BlackKnight;
            pBoxBlackKnight.Location = new Point(634, 131);
            pBoxBlackKnight.Name = "pBoxBlackKnight";
            pBoxBlackKnight.Size = new Size(51, 47);
            pBoxBlackKnight.TabIndex = 24;
            pBoxBlackKnight.TabStop = false;
            pBoxBlackKnight.Click += pBoxBlackKnight_Click;
            // 
            // pBoxBlackPawn
            // 
            pBoxBlackPawn.Image = Chess.ChessPieces.BlackPawn;
            pBoxBlackPawn.Location = new Point(577, 131);
            pBoxBlackPawn.Name = "pBoxBlackPawn";
            pBoxBlackPawn.Size = new Size(51, 47);
            pBoxBlackPawn.TabIndex = 25;
            pBoxBlackPawn.TabStop = false;
            pBoxBlackPawn.Click += pBoxBlackPawn_Click;
            // 
            // formCreatePuzzle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pBoxBlackPawn);
            Controls.Add(pBoxBlackKnight);
            Controls.Add(pBoxBlackBishop);
            Controls.Add(pBoxBlackRook);
            Controls.Add(pBoxBlackQueen);
            Controls.Add(pBoxBlackKing);
            Controls.Add(pBoxWhiteKing);
            Controls.Add(pBoxWhiteKnight);
            Controls.Add(pBoxWhiteBishop);
            Controls.Add(pBoxWhiteRook);
            Controls.Add(pBoxWhiteQueen);
            Controls.Add(pBoxWhitePawn);
            Controls.Add(cBoxToMove);
            Controls.Add(btnBack);
            Controls.Add(txtBoxRating);
            Controls.Add(btnCreatePuzzle);
            Controls.Add(txtBoxAlternative3);
            Controls.Add(txtBoxAlternative2);
            Controls.Add(txtBoxAlternative1);
            Controls.Add(txtBoxWinningMove);
            Controls.Add(btnAddPiece);
            Controls.Add(txtBoxLocation);
            Name = "formCreatePuzzle";
            Text = "formCreatePuzzle";
            ((System.ComponentModel.ISupportInitialize)pBoxWhitePawn).EndInit();
            ((System.ComponentModel.ISupportInitialize)pBoxWhiteQueen).EndInit();
            ((System.ComponentModel.ISupportInitialize)pBoxWhiteRook).EndInit();
            ((System.ComponentModel.ISupportInitialize)pBoxWhiteBishop).EndInit();
            ((System.ComponentModel.ISupportInitialize)pBoxWhiteKnight).EndInit();
            ((System.ComponentModel.ISupportInitialize)pBoxWhiteKing).EndInit();
            ((System.ComponentModel.ISupportInitialize)pBoxBlackKing).EndInit();
            ((System.ComponentModel.ISupportInitialize)pBoxBlackQueen).EndInit();
            ((System.ComponentModel.ISupportInitialize)pBoxBlackRook).EndInit();
            ((System.ComponentModel.ISupportInitialize)pBoxBlackBishop).EndInit();
            ((System.ComponentModel.ISupportInitialize)pBoxBlackKnight).EndInit();
            ((System.ComponentModel.ISupportInitialize)pBoxBlackPawn).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtBoxLocation;
        private Button btnAddPiece;
        private TextBox txtBoxWinningMove;
        private TextBox txtBoxAlternative1;
        private TextBox txtBoxAlternative2;
        private TextBox txtBoxAlternative3;
        private Button btnCreatePuzzle;
        private TextBox txtBoxRating;
        private Button btnBack;
        private CheckBox cBoxToMove;
        private PictureBox pBoxWhitePawn;
        private PictureBox pBoxWhiteQueen;
        private PictureBox pBoxWhiteRook;
        private PictureBox pBoxWhiteBishop;
        private PictureBox pBoxWhiteKnight;
        private PictureBox pBoxWhiteKing;
        private PictureBox pBoxBlackKing;
        private PictureBox pBoxBlackQueen;
        private PictureBox pBoxBlackRook;
        private PictureBox pBoxBlackBishop;
        private PictureBox pBoxBlackKnight;
        private PictureBox pBoxBlackPawn;
    }
}