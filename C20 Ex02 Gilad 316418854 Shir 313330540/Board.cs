using System;
using System.Drawing;

namespace C20_Ex02_Gilad_316418854_Shir_313330540
{
    public class Board
    {
        // Private Members
        private int m_Size;
        private Square[,] m_GameBoard;

        // Constructors
        public Board(int i_Size)
        {
            m_Size = i_Size;
            Build();
        }

        // Public Methods
        public void Build()
        {
            m_GameBoard = new Square[m_Size, m_Size];
            for (int i = 0; i < m_Size; i++)
            {
                for (int j = 0; j < m_Size; j++)
                {
                    m_GameBoard[i, j] = new Square();
                }
            }
        }

        public void SetPiecesPosition(Player i_Player)
        {
            foreach(Piece piece in i_Player.Pieces)
            {
                int x = piece.Location.X;
                int y = piece.Location.Y;
                m_GameBoard[x, y].PiecePointer = piece;
            }
        }
       
        //public void makeMove(Piece i_Piece, Point i_To)
        //{
        //    m_Board[i_Piece.Location.X, i_Piece.Location.Y].PiecePointer = null;
        //    // the piece pointer that this square had will be null now
        //    i_Piece.Location = i_To;// update piece location
        //    m_Board[i_To.X,i_To.Y].PiecePointer = i_Piece; 
        //    //update the piece pointer in the new piece it have
        //}

        //version #2
        public void makeMove(Player i_Player,int i_PieceIndex, Point i_To)
        {
            m_GameBoard[i_Player.Pieces[i_PieceIndex].Location.X, i_Player.Pieces[i_PieceIndex].Location.Y].PiecePointer = null;
            // the piece pointer that this square had will be null now
            i_Player.Pieces[i_PieceIndex].Location = i_To;// update piece location
            m_GameBoard[i_To.X, i_To.Y].PiecePointer = i_Player.Pieces[i_PieceIndex];
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
        public Square[,] GameBoard
        {
            get
            {
                return m_GameBoard;
            }
        }
    }
}