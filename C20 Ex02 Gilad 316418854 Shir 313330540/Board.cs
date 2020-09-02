using System;
using System.Drawing;

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
            Build();
        }

        // Public Methods
        public void Build()
        {
            m_Board= new Square[m_Size, m_Size];
            for (int i = 0; i < m_Size; i++)
            {
                for (int j = 0; j < m_Size; j++)
                {
                    m_Board[i, j].PiecePointer = null;
                }
            }
        }

        public void SetPiecesPosition(Player i_Player)
        {
            int x, y;
            for (int i = 0; i < (m_Size / 2) * (m_Size - 1); i++)
            {
                x = i_Player.PiecesArr[i].Location.X;
                y = i_Player.PiecesArr[i].Location.Y;
                m_Board[x,y].PiecePointer = i_Player.PiecesArr[i];
            }
        }
       
        public void makeMove(Piece i_Piece, Point i_To)
        {
            m_Board[i_Piece.Location.X, i_Piece.Location.Y].PiecePointer = null;
            // the piece pointer that this square had will be null now
            i_Piece.Location = i_To;// update piece location
            m_Board[i_To.X,i_To.Y].PiecePointer = i_Piece; 
            //update the piece pointer in the new piece it have
        }

        // Properties
        public int Size
        {
            get
            {
                return m_Size;
            }
        }
    }
}