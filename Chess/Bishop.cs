using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Bishop : ChessPiece
    {
        private int x;
        private int y;

        public Bishop(string color)
        {
            this.color = color;
            pieceName = "Bishop";
        }
        public override void Move(ChessBoard chessBoard, bool calculation)
        {
            int x = this.x + 1;
            int y = this.y + 1;
            while (y < 8 && x < 8)
            {
                if (chessBoard.isEmptyOrCapturable(this.color, x, y, calculation))
                {
                    chessBoard.highLightSquare(x, y, this.x, this.y, calculation);
                }
                if (!chessBoard.isEmpty(this.color, x, y))
                {
                    break;
                }
                y++;
                x++;
            }
            x = this.x - 1;
            y = this.y - 1;
            while (y >= 0 && x>=0)
            {
                if (chessBoard.isEmptyOrCapturable(this.color, x, y, calculation))
                {
                    chessBoard.highLightSquare(x, y, this.x, this.y, calculation);
                }
                if (!chessBoard.isEmpty(this.color, x, y))
                {
                    break;
                }
                y--;
                x--;
            }
            x = this.x - 1;
            y = this.y+1;
            while (x >= 0 && y < 8)
            {
                if (chessBoard.isEmptyOrCapturable(this.color, x, y, calculation))
                {
                    chessBoard.highLightSquare(x, y, this.x, this.y, calculation);
                }
                if (!chessBoard.isEmpty(this.color, x, y))
                {
                    break;
                }
                x--;
                y++;
            }
            x = this.x + 1;
            y = this.y - 1;
            while (x < 8 && y >= 0)
            {
                if (chessBoard.isEmptyOrCapturable(this.color, x, y, calculation))
                {
                    chessBoard.highLightSquare(x, y, this.x, this.y, calculation);
                }
                if (!chessBoard.isEmpty(this.color, x, y))
                {
                    break;
                }
                x++;
                y--;
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
