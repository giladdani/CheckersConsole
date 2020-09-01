using System;
using System.Runtime.Remoting.Messaging;

namespace C20_Ex02_Gilad_316418854_Shir_313330540
{
    public class Game
    {
        // Private Members
        private Player m_Player1;
        private Player m_Player2;
        private Board m_Board;
        private string m_LastMove;
        int m_TurnCount;
       

        // Constructors
        public Game(Player i_Player1, Player i_Player2, Board i_Board)
        {
            m_Player1 = i_Player1;
            m_Player1 = i_Player2;
            m_Board = i_Board;
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
