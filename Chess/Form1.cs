using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Necessary to take the window frame width/height into account
            //this.chromeWidth = this.Width - this.ClientSize.Width;
            //this.chromeHeight = this.Height - this.ClientSize.Height;
            //this.ClientSize = new System.Drawing.Size(800, 800);
        }
        ChessBoard chessBoard;
        //public Dictionary<String,ChessPiece> chessBoard;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            int width = this.ClientSize.Height / 8;
            int height = this.ClientSize.Height / 8;
            if (chessBoard == null)
            {
                chessBoard = new ChessBoard();
                this.Controls.Clear();
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        char letter = (char)('A' + x);
                        Button button = new Button
                        {
                            Name = letter + "" + (8 - y),
                            Size = new Size(width, height),
                            Location = new Point(this.ClientSize.Width / 2 - (width * 4) + x * width, y * height)
                        };
                        this.Controls.Add(button);
                        if ((x + y) % 2 == 0)
                        {
                            button.BackColor = Color.White;
                        }
                        else
                        {
                            button.BackColor = Color.RoyalBlue;
                        }
                        chessBoard.Add(new ChessSquare(button, x, y,chessBoard));
                        
                    }
                }
                //Placing the white pieces
                chessBoard.generatePiece("A2", new Pawn("White"));
                chessBoard.generatePiece("B2", new Pawn("White"));
                chessBoard.generatePiece("C2", new Pawn("White"));
                chessBoard.generatePiece("D2", new Pawn("White"));
                chessBoard.generatePiece("E2", new Pawn("White"));
                chessBoard.generatePiece("F2", new Pawn("White"));
                chessBoard.generatePiece("G2", new Pawn("White"));
                chessBoard.generatePiece("H2", new Pawn("White"));
                chessBoard.generatePiece("B1", new Knight("White"));
                chessBoard.generatePiece("G1", new Knight("White"));
                chessBoard.generatePiece("A1", new Rook("White"));
                chessBoard.generatePiece("H1", new Rook("White"));
                chessBoard.generatePiece("C1", new Bishop("White"));
                chessBoard.generatePiece("F1", new Bishop("White"));
                chessBoard.generatePiece("D1", new Queen("White"));
                chessBoard.generatePiece("E1", new King("White"));
                chessBoard.whiteKing = chessBoard.getPiece("E1");
                //Placing the Black Pieces
                chessBoard.generatePiece("A7", new Pawn("Black"));
                chessBoard.generatePiece("B7", new Pawn("Black"));
                chessBoard.generatePiece("C7", new Pawn("Black"));
                chessBoard.generatePiece("D7", new Pawn("Black"));
                chessBoard.generatePiece("E7", new Pawn("Black"));
                chessBoard.generatePiece("F7", new Pawn("Black"));
                chessBoard.generatePiece("G7", new Pawn("Black"));
                chessBoard.generatePiece("H7", new Pawn("Black"));
                chessBoard.generatePiece("B8", new Knight("Black"));
                chessBoard.generatePiece("G8", new Knight("Black"));
                chessBoard.generatePiece("A8", new Rook("Black"));
                chessBoard.generatePiece("H8", new Rook("Black"));
                chessBoard.generatePiece("C8", new Bishop("Black"));
                chessBoard.generatePiece("F8", new Bishop("Black"));
                chessBoard.generatePiece("D8", new Queen("Black"));
                chessBoard.generatePiece("E8", new King("Black"));
                chessBoard.blackKing = chessBoard.getPiece("E8");
            }
            else
            {
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        chessBoard.getSquare(x, y).button.Size = new Size(width, height);
                        chessBoard.getSquare(x, y).button.Location = new Point(this.ClientSize.Width / 2 - (width * 4) + x * width, y * height);
                    }
                }
            }
        }
       
        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
            //this.Size = new Size(this.Size.Height, this.Size.Height);
            Form1_Load(sender, e);
        }
    }
}