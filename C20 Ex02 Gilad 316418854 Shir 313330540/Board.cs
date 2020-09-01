using System;

namespace C20_Ex02_Gilad_316418854_Shir_313330540
{
    //public enum eSquareStatus         // todo move to separate class
    //{
    //    Empty,
    //    Player1,
    //    Player2,
    //    KingPlayer1,
    //    KingPlayer2
    //}
    public class Board
    {
        private int m_Size;
        private Piece[,] m_Board;

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
                        m_Board[i, j] = eSquareStatus.Empty;
                }
            }

            for (int i = 0; i < (m_Size/2)-1; i++)
            {
                for(int j = 0; j < m_Size; j++)
                {
                    if((j % 2 == 1) && (i % 2 == 0))
                    {
                        m_Board[i, j] = eSquareStatus.Player1;
                    }
                    if ((j % 2 == 0) && (i % 2 == 1))
                    {
                        m_Board[i, j] = eSquareStatus.Player1;
                    }
                }
            }

            for (int i = (m_Size / 2) + 1; i < m_Size; i++)
            {
                for (int j = 0; j < m_Size; j++)
                {
                    if ((j % 2 == 1) && (i % 2 == 0))
                    {
                        m_Board[i, j] = eSquareStatus.Player2;
                    }
                    if ((j % 2 == 0) && (i % 2 == 1))
                    {
                        m_Board[i, j] = eSquareStatus.Player2;
                    }
                }
            }
        }
    }
}
