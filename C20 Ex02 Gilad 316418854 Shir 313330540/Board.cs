using System;
using System.Drawing;
using System.Windows;

namespace C20_Ex02_Gilad_316418854_Shir_313330540
{
    public class Board
    {
        // Private Members
        private int m_Size;
        private Square[,] m_Board;

        // Constructors
        public Board(int i_Size)
        {
            m_Size = i_Size;
        }

        // Public Methods
        public void Build()
        {
            for (int i = 0; i < m_Size; i++)
            {
                for (int j = 0; j < m_Size; j++)
                {
                    m_Board[i, j].PiecePointer = null;
                }
            }

            SetPiecesPosition(ePlayerSide.Up, 0, (m_Size / 2) - 1);
            SetPiecesPosition(ePlayerSide.Down, (m_Size / 2) + 1, m_Size);
        }

        // Update both board and piece of new given location
        public void MovePiece(Piece i_Piece, Point i_To)
        {
            // update board's locations
            m_Board[i_Piece.Location.X, i_Piece.Location.Y].PiecePointer = null;
            m_Board[i_To.X, i_To.Y].PiecePointer = i_Piece;
            // update piece's location
            i_Piece.Location = i_To;
        }

        public void SetPiecesPosition(ePlayerSide i_Side, int i_StartRow, int i_EndRow)
        {
            for (int i = i_StartRow; i < i_EndRow; i++)
            {
                for (int j = 0; j < m_Size; j++)
                {
                    if ((j % 2 == 1) && (i % 2 == 0))
                    {
                        Point location = new Point(i, j);
                        Piece boardPiece = new Piece(location, i_Side);
                        m_Board[i, j].PiecePointer = boardPiece;
                    }

                    if ((j % 2 == 0) && (i % 2 == 1))
                    {
                        Point location = new Point(i, j);
                        Piece boardPiece = new Piece(location, i_Side);
                        m_Board[i, j].PiecePointer = boardPiece;
                    }
                }
            }
        }
    }
}