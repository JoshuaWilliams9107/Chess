using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Knight : ChessPiece
    {
        private int x;
        private int y;

        public Knight(string color)
        {
            this.color = color;
            pieceName = "Knight";
        }
        public override void Move(ChessBoard chessBoard, bool calculation)
        {
            if (chessBoard.isEmptyOrCapturable(this.color, x+1, y+2, calculation))
            {
                chessBoard.highLightSquare(x+1, y+2, x, y, calculation);
            }
            if (chessBoard.isEmptyOrCapturable(this.color, x - 1, y + 2, calculation))
            {
                chessBoard.highLightSquare(x - 1, y + 2, x, y, calculation);
            }
            if (chessBoard.isEmptyOrCapturable(this.color, x + 1, y - 2, calculation))
            {
                chessBoard.highLightSquare(x + 1, y - 2, x, y, calculation);
            }
            if (chessBoard.isEmptyOrCapturable(this.color, x - 1, y - 2, calculation))
            {
                chessBoard.highLightSquare(x - 1, y - 2, x, y, calculation);
            }
            if (chessBoard.isEmptyOrCapturable(this.color, x + 2, y + 1, calculation))
            {
                chessBoard.highLightSquare(x + 2, y + 1, x, y, calculation);
            }
            if (chessBoard.isEmptyOrCapturable(this.color, x - 2, y + 1, calculation))
            {
                chessBoard.highLightSquare(x - 2, y + 1, x, y, calculation);
            }
            if (chessBoard.isEmptyOrCapturable(this.color, x + 2, y - 1, calculation))
            {
                chessBoard.highLightSquare(x + 2, y - 1, x, y, calculation);
            }
            if (chessBoard.isEmptyOrCapturable(this.color, x - 2, y - 1, calculation))
            {
                chessBoard.highLightSquare(x - 2, y - 1, x, y, calculation);
            }
        }
        public override void UpdatePosition(String position)
        {
            int x = position[0] - 'A';
            int y = 8 - (position[1] - '0');
            this.x = x;
            this.y = y;
        }
        public override void UpdatePosition(int x, int y)
        {
            this.x = x;
            this.y = y;
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
