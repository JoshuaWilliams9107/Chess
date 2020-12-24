using Chess.Properties;
using Svg;
using Svg.Transforms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Chess icons from
namespace Chess
{
    public class ChessSquare
    {
        public int x;
        public int y;
        public Button button;
        public ChessBoard chessBoard;
        public ChessPiece piece;
        private Color color;
        private ChessSquare movingSquare;
        private bool capturable = false;
        public PictureBox picturePiece;
        public ChessSquare(Button button, int x, int y, ChessBoard chessBoard)
        {
            this.button = button;
            color = button.BackColor;
            this.x = x;
            this.y = y;
            button.Click += new EventHandler(this.Tile_Clicked);
            this.chessBoard = chessBoard;
        }

        public void GeneratePictureBoxPiece(int clientWidth,string name, string filePath,int x, int y,int width,int height)
        {
            PictureBox svgImage = new PictureBox
            {
                Name = name,
                Size = new Size(width, height),
                Location = new Point(clientWidth / 2 - (width * 4) + x * width, y * height)
            };
            
            //picturePiece = svgImage;
        }
        public void placePiece(ChessPiece piece)
        {
            this.piece = piece;
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream;
            SvgDocument svgDoc;
            string currentDir = Environment.CurrentDirectory;
            Console.Write(currentDir);
            if (piece.color == "White")
            {
                svgDoc = SvgDocument.Open(currentDir + "/Images/w_" + piece.pieceName.ToLower() + "_svg_withShadow.svg");
            }
            else
            {
                svgDoc = SvgDocument.Open(currentDir + "/Images/b_" + piece.pieceName.ToLower() + "_svg_withShadow.svg");
            }
            svgDoc.Transforms = new SvgTransformCollection();
            svgDoc.Transforms.Add(new SvgScale(2, 2));
            svgDoc.Width = new SvgUnit(svgDoc.Width.Type, 50);
            svgDoc.Height = new SvgUnit(svgDoc.Height.Type, 50);
            //svgImage.Image = svgDoc.Draw();
            //Bitmap bmp = new Bitmap(myStream);
            button.BackgroundImage = svgDoc.Draw();
            button.BackgroundImageLayout = ImageLayout.Stretch;
        }
        public void removePiece()
        {
            this.piece = null;
            button.BackgroundImage = null;
        }
        public void highlight(ChessSquare movingPiece)
        {
            this.movingSquare = movingPiece;
            this.button.BackColor = Color.GreenYellow;
        }
        public void unHighlight()
        {
            this.movingSquare = null;
            this.button.BackColor = color;
        }
        void Tile_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (this.button.BackColor == Color.GreenYellow)
            {
                chessBoard.placePiece(x, y, movingSquare.piece);
                movingSquare.removePiece();

                chessBoard.unHighlight();
            }else if (piece != null)
            {
                chessBoard.unHighlight();

                if ((piece.color == "Black" && chessBoard.isBlackTurn) || (piece.color == "White" && !chessBoard.isBlackTurn))
                {
                    piece.Move(chessBoard, false);
                    /*if(piece.color == "Black" && chessBoard.blackInCheck == true)
                    {
                        
                    }
                    else if(piece.color == "Black")
                    {
                        piece.Move(chessBoard, false);
                    }
                    if (piece.color == "White" && chessBoard.whiteInCheck == true)
                    {

                    }
                    else if (piece.color == "White")
                    {
                        piece.Move(chessBoard, false);
                    }*/

                }
            }
            else
            {
                chessBoard.unHighlight();
            }
            
            //btn.Text = chessBoard.getSquare(btn.Name).button.Name;
        }
        public void setCapturable()
        {
            this.capturable = true;
            /*if (capturable) {
                button.Text = "True";
            }
            else
            {
                button.Text = "False";
            }*/
        }
        public void setUnCapturable()
        {
            this.capturable = false;
            /*if (capturable)
            {
                button.Text = "True";
            }
            else
            {
                button.Text = "False";
            }*/
        }
        public bool isCapturable()
        {
            return this.capturable;
        }
    }
}
