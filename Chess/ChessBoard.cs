using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class ChessBoard
    {
        public ChessPiece whiteKing;
        public ChessPiece blackKing;
        Dictionary<String, ChessSquare> chessBoard;
        ChessSquare[,] chessBoardArray;
        public bool isBlackTurn = true;
        public bool blackInCheck = false;
        public bool whiteInCheck = false;
        public ChessBoard()
        {
            chessBoard = new Dictionary<String, ChessSquare>();
            chessBoardArray = new ChessSquare[8, 8];
        }
        public void Add(ChessSquare sq)
        {
            string position = sq.button.Name;
            chessBoard.Add(position, sq);
            int x = position[0] - 'A';
            int y = 8 - (position[1] - '0');
            chessBoardArray[x, y] = sq;
        }
        public void highLightSquare(String position, String originPosition)
        {
            chessBoard[position].highlight(chessBoard[originPosition]);
        }
        public void highLightSquare(int x, int y, int originX, int originY,bool calculation)
        {
            int kingX = -1;
            int kingY = -1;
            if(chessBoardArray[originX, originY].piece.color == "White")
            {
                kingX = whiteKing.getX();
                kingY = whiteKing.getY();
            }
            else 
            {
                kingX = blackKing.getX();
                kingY = blackKing.getY();
            }

            if (x < 8 && x >= 0 && y < 8 && y >= 0 && calculation)
            {
                if (chessBoardArray[x, y].piece != null)
                {
                    if (chessBoardArray[x, y].piece.pieceName == "King" && chessBoardArray[originX, originY].piece.color != chessBoardArray[x, y].piece.color)
                    {
                        if (chessBoardArray[x, y].piece.color == "White")
                        {
                            whiteInCheck = true;
                        }
                        else
                        {
                            blackInCheck = true;
                        }
                    }
                }
                chessBoardArray[x, y].setCapturable();
            }
            if (x < 8 && x >= 0 && y < 8 && y >= 0 && !calculation)
            {
                if (chessBoardArray[x, y].piece != null)
                {
                    if (chessBoardArray[x, y].piece.pieceName != "King")
                    {
                        //If move and king is still in true space don't highlight
                        if ((chessBoardArray[originX, originY].piece.color == "White" && whiteInCheck) || (chessBoardArray[originX, originY].piece.color == "Black" && blackInCheck))
                        {
                            if (movesOutOfCheck(chessBoardArray[originX, originY], x, y, kingX, kingY))
                            {
                                chessBoardArray[x, y].highlight(chessBoardArray[originX, originY]);
                            }
                        }
                        else
                        {
                            if (movesOutOfCheck(chessBoardArray[originX, originY], x, y, kingX, kingY))
                            {
                                chessBoardArray[x, y].highlight(chessBoardArray[originX, originY]);
                            }
                        }
                    }
                }
                else
                {
                    //If move and king is still in true space don't highlight
                    if ((chessBoardArray[originX, originY].piece.color == "White" && whiteInCheck) || (chessBoardArray[originX, originY].piece.color == "Black" && blackInCheck))
                    {
                        if (movesOutOfCheck(chessBoardArray[originX, originY], x, y, kingX, kingY))
                        {
                            chessBoardArray[x, y].highlight(chessBoardArray[originX, originY]);
                        }
                    }
                    else
                    {
                        if (movesOutOfCheck(chessBoardArray[originX, originY], x, y, kingX, kingY))
                        {
                            chessBoardArray[x, y].highlight(chessBoardArray[originX, originY]);
                        }
                    }
                }
            }
                
        }
       public bool movesOutOfCheck(ChessSquare square, int x, int y, int kingX, int kingY)
        {
            bool output = false;
            int originX = square.x;
            int originY = square.y;
            ChessPiece tempPiece = chessBoardArray[x, y].piece;
            chessBoardArray[x, y].piece = square.piece;
            chessBoardArray[originX, originY].piece = null;
            
            calculateCapturable(chessBoardArray[x, y].piece.color);
            if (chessBoardArray[x, y].piece.pieceName == "King")
            {
                if (chessBoardArray[x, y].isCapturable() == false)
                {
                    output = true;
                }
            }
            else
            {
                if (chessBoardArray[kingX, kingY].isCapturable() == false)
                {
                    output = true;
                }
            }
            int theX = x;
            int theY = y;
            chessBoardArray[originX, originY].piece = chessBoardArray[x, y].piece;
            chessBoardArray[x, y].piece = tempPiece;
            return output;
        }
        public void unHighlight()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    chessBoardArray[x, y].unHighlight();
                    chessBoardArray[x, y].setUnCapturable();
                }
            }
        }
        public ChessSquare getSquare(String position)
        {
            return chessBoard[position];
        }
        public ChessSquare getSquare(int x, int y)
        {
            if (x < 8 && x >= 0 && y < 8 && y >= 0)
                return chessBoardArray[x, y];
            else
                return null;
        }
        public ChessPiece getPiece(int x, int y)
        {
            if (x < 8 && x >= 0 && y < 8 && y >= 0)
                return chessBoardArray[x, y].piece;
            else
                return null;
        }
        public ChessPiece getPiece(string position)
        {
            int x = position[0] - 'A';
            int y = 8 - (position[1] - '0');
            if (x < 8 && x >= 0 && y < 8 && y >= 0)
                return chessBoardArray[x, y].piece;
            else
                return null;
        }
        public void placePiece(int x, int y, ChessPiece piece)
        {
            piece.UpdatePosition(x, y);
            getSquare(x, y).placePiece(piece);
            piece.Move(this, true);
            if (piece.color == "Black")
            {
                isBlackTurn = false;
            }
            else if (piece.color == "White")
            {
                isBlackTurn = true;
            }
        }
        public void generatePiece(String position, ChessPiece piece)
        {
            int x = position[0] - 'A';
            int y = 8 - (position[1] - '0');
            piece.UpdatePosition(x, y);
            getSquare(position).placePiece(piece);
        }
        public bool isEmptyOrCapturable(String color, int x, int y,bool calculation)
        {
            if (getPiece(x, y) != null)
            {
                if(getPiece(x, y).color == color && calculation)
                {
                    getSquare(x, y).setCapturable();
                }
                if (getPiece(x, y).color != color)
                    return true;
            }
            if (getPiece(x, y) == null)
            {
                return true;
            }
            return false;
        }
        public bool isEmpty(String color, int x, int y)
        {
            if (getPiece(x, y) == null)
            {
                return true;
            }
            return false;
        }
        public void calculateCapturable(String pieceColor)
        {
            foreach (ChessSquare square in chessBoardArray)
            {
                square.setUnCapturable();
            }
            foreach (ChessSquare square in chessBoardArray)
            {
                if (square.piece != null)
                {
                    if(square.piece.color != pieceColor)
                        square.piece.Move(this,true);
                }
            }
        }
        public bool isCapturable(int x, int y)
        {
            if(getSquare(x, y) != null)
            {
                if(getSquare(x, y).isCapturable())
                    return true;
            }
            return false;
        }
    }
}
