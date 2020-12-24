using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Pawn : ChessPiece
    {
        private int x;
        private int y;
        int colormult = 1;
        int counter = 0;
        public Pawn(string color)
        {
            this.color = color;
            if(color == "White")
            {
                colormult = -1;
            }
            pieceName = "Pawn";
        }
        private bool hasMoved = false;
        public override void Move(ChessBoard chessBoard, bool calculation)
        {
            if(counter == 2)
            {
                hasMoved = true;
            }

            if (hasMoved && y-1 < 8)
            {
                if(chessBoard.getPiece(x, y + (1 * colormult)) == null && !calculation)
                    chessBoard.highLightSquare(x, y + (1*colormult),x,y,false);
            }
            else
            {
                if (chessBoard.getPiece(x, y + (1 * colormult)) == null && !calculation)
                {
                    chessBoard.highLightSquare(x, y + (1 * colormult), x, y,false);
                    if (chessBoard.getPiece(x, y + (2 * colormult)) == null)
                    {
                        chessBoard.highLightSquare(x, y + (2 * colormult), x, y,false);
                    }
                }
            }
            if (calculation)
            {
                chessBoard.highLightSquare(x + (1), y + (1 * colormult), x, y, calculation);
            }
            else if(chessBoard.getPiece(x + (1), y + (1 * colormult)) != null )
            {
                if (chessBoard.getPiece(x + (1), y + (1 * colormult)).color != this.color)
                    chessBoard.highLightSquare(x + (1), y + (1 * colormult), x, y, calculation);
            }
            if (calculation)
            {
                chessBoard.highLightSquare(x - (1), y + (1 * colormult), x, y, calculation);
            }
            else if (chessBoard.getPiece(x - (1), y + (1 * colormult)) != null || calculation)
            {
                if (chessBoard.getPiece(x - (1), y + (1 * colormult)).color != this.color)
                    chessBoard.highLightSquare(x - (1), y + (1 * colormult), x, y, calculation);
            }
        }
        public override void UpdatePosition(String position)
        {
            int x = position[0] - 'A';
            int y = 8 - (position[1] - '0');
            this.x = x;
            this.y = y;
            counter++;
        }
        public override void UpdatePosition(int x, int y)
        {
            this.x = x;
            this.y = y;
            counter++;
        }
        public override int getX()
        {
            return x;
        }
        public override int getY()
        {
            return y;
        }
    }
}
