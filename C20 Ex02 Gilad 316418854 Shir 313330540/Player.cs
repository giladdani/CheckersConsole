using System;

namespace C20_Ex02_Gilad_316418854_Shir_313330540
{
    public class Player
    {
        // Private Members
        private readonly string r_Name;
        private int m_TotalScore;
        private string m_LastMove;
        // Piece[] pieces;

        // Constructors
        public Player(string i_Name)
        {
            r_Name = i_Name;
            m_TotalScore = 0;
        }

        // Properties
        public string Name
        {
            get
            {
                return m_Name;
            }
        }
        public int TotalScore
        {
            get
            {
                return m_TotalScore;
            }
        }
        public string LastMove
        {
            get
            {
                return m_LastMove;
            }
            set
            {
                m_LastMove = value;
            }
        }
    }
}
