using System;
using System.Runtime.Remoting.Messaging;

namespace C20_Ex02_Gilad_316418854_Shir_313330540
{
    public class Game
    {
        // Private Members
        private readonly string r_PlayerOneName;
        private readonly string r_PlayerTwoName;
        private Board m_Board;
        private string m_LastMove;
        int m_TurnCount;
        private int m_PlayerOneTotalScore = 0;
        private int m_PlayerTwoTotalScore = 0;

        // Constructors
        public Game(string i_PlayerOneName, string i_PlayerTwoName, int i_BoardSize)
        {
            r_PlayerOneName = i_PlayerOneName;
            r_PlayerTwoName = i_PlayerTwoName;
            m_Board = new Board(i_BoardSize);
            m_LastMove = null;          // @Eli- how did you saved the last move? string?
        }

        // Public Methods
        public void StartNewRound()
        {
            m_Board.BuildBoard();
            m_TurnCount = 1;
            while (!IsRoundOver())
            {
                UiManager.SetNextTurn();
                m_TurnCount++;
            }
        }

        // Properties
        public string PlayerOneName
        {
            get
            {
                return r_PlayerOneName;
            }

        }

        public string PlayerTwoName
        {
            get
            {
                return r_PlayerTwoName; 
            }
        }

        public string LastMove
        {
            get
            {
                return m_LastMove;
            }
        }

        public string CurrentPlayerName
        {
            get
            {
                string name;
                if (m_TurnCount % 2 == 0)
                {
                    name = PlayerTwoName;
                }
                else
                {
                    name = PlayerOneName;
                }

                return name;
            }
        }

        public Board Board
        {
            get
            {
                return m_Board;
            }
        }
    }
}
