using System;

namespace C20_Ex02_Gilad_316418854_Shir_313330540
{
    public class Round
    {
        // Private Members
        private string m_PlayerOneName;
        private string m_PlayerTwoName;
        private int m_PlayerOneScore = 0;
        private int m_PlayerTwoScore = 0;

        // Constructors
        public Round(int i_BoardSize, string i_PlayerOneName, string i_PlayerTwoName)
        {
            m_PlayerOneName = i_PlayerOneName;
            m_PlayerTwoName = i_PlayerTwoName;
            // Build board
        }
        
        // Public Methods
        public void Start()
        {
            // create board
        }

        // Properties
        public int PlayerOneScore
        {
            get
            {
                return m_PlayerOneScore;
            }
            set
            {
                // @ validate score? or don't allow set?
            }
        }

        public int PlayerTwoScore
        {
            get
            {
                return m_PlayerTwoScore;
            }
            set
            {
                // @ validate score? or don't allow set?
            }
        }
    }
}
