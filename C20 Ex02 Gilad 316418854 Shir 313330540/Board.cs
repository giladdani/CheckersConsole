using System;
using System.Windows;

namespace C20_Ex02_Gilad_316418854_Shir_313330540
{

    public class Board
    {
        private int m_Size;
        private Square[,] m_Board; // @ should Piece[,] ?

        public Board(int i_Size)
        {
            m_Size = i_Size;
        }

        public void Build()
        {
            for (int i = 0; i < m_Size; i++)
            {
                for (int j = 0; j < m_Size; j++)
                {
                    m_Board[i, j].piecePointer = null;
                }
            }

            BuildBeginningStatus(Player.ePlayerSide.Up, 0, (m_Size / 2) - 1);
            BuildBeginningStatus(Player.ePlayerSide.Down, (m_Size / 2) + 1, m_Size);
        }



        private void BuildBeginningStatus(Player.ePlayerSide i_Type, int i_StartRow, int i_EndRow)
        {

            for (int i = i_StartRow; i < i_EndRow; i++)
            {
                for (int j = 0; j < m_Size; j++)
                {
                    if ((j % 2 == 1) && (i % 2 == 0))
                    {
                        Point locationPoint = new Point(i, j);
                        Piece boardPiece = new Piece(locationPoint, i_Type);
                        m_Board[i, j].piecePointer = boardPiece;

                    }

                    if ((j % 2 == 0) && (i % 2 == 1))
                    {
                        Point locationPoint = new Point(i, j);
                        Piece boardPiece = new Piece(locationPoint, i_Type);
                        m_Board[i, j].piecePointer = boardPiece;

                    }
                }
            }
        }

       
        public void makeMove(Piece i_piece, Point i_To)
        {
            m_Board[Convert.ToInt32(i_piece.Location.X), Convert.ToInt32(i_piece.Location.Y)].piecePointer = null;
            // the piece pointer that this square had will be null now
            i_piece.Location = i_To;// update piece location
            m_Board[Convert.ToInt32(i_To.X), Convert.ToInt32(i_To.Y)].piecePointer = i_piece; 
            //update the piece pointer in the new piece it have
        }
    }
}