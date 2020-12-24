using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public abstract class ChessPiece
    {
        
        public string color;
        public string pieceName;
        //Calculates the possible spaces that the piece can move to
        public abstract void Move(ChessBoard chessBoard, bool calculation);
        public abstract void UpdatePosition(int x, int y);
        public abstract void UpdatePosition(String position);
        public abstract int getX();
        public abstract int getY();
    }
}
