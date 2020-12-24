using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class King : ChessPiece
    {
        private int x;
        private int y;

        public King(string color)
        {
            this.color = color;
            pieceName = "King";
        }
        public override void Move(ChessBoard chessBoard, bool calculation)
        {
            if (calculation == false)
            {
                chessBoard.calculateCapturable(color);
            }
            if (chessBoard.isEmptyOrCapturable(this.color, x + 1, y + 1, calculation) && !chessBoard.isCapturable(x+1,y+1))
            {
                chessBoard.highLightSquare(x + 1, y + 1, x, y, calculation);
            }
            if (chessBoard.isEmptyOrCapturable(this.color, x - 1, y + 1, calculation) && !chessBoard.isCapturable(x - 1, y + 1))
            {
                chessBoard.highLightSquare(x - 1, y + 1, x, y, calculation);
            }
            if (chessBoard.isEmptyOrCapturable(this.color, x + 1, y - 1, calculation) && !chessBoard.isCapturable(x + 1, y - 1))
            {
                chessBoard.highLightSquare(x + 1, y - 1, x, y, calculation);
            }
            if (chessBoard.isEmptyOrCapturable(this.color, x - 1, y - 1, calculation) && !chessBoard.isCapturable(x - 1, y - 1))
            {
                chessBoard.highLightSquare(x - 1, y - 1, x, y, calculation);
            }
            if (chessBoard.isEmptyOrCapturable(this.color, x + 1, y, calculation) && !chessBoard.isCapturable(x + 1, y))
            {
                chessBoard.highLightSquare(x + 1, y, x, y, calculation);
            }
            if (chessBoard.isEmptyOrCapturable(this.color, x - 1, y, calculation) && !chessBoard.isCapturable(x - 1, y))
            {
                chessBoard.highLightSquare(x - 1, y, x, y, calculation);
            }
            if (chessBoard.isEmptyOrCapturable(this.color, x, y - 1, calculation) && !chessBoard.isCapturable(x, y - 1))
            {
                chessBoard.highLightSquare(x, y - 1, x, y, calculation);
            }
            if (chessBoard.isEmptyOrCapturable(this.color, x, y + 1, calculation) && !chessBoard.isCapturable(x, y + 1))
            {
                chessBoard.highLightSquare(x, y + 1, x, y, calculation);
            }
            //chessBoard.unHighlight();
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
