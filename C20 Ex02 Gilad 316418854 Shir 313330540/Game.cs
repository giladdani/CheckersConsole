using System;

namespace C20_Ex02_Gilad_316418854_Shir_313330540
{
    public class Game
    {
        // Private Members
        private Player m_PlayerOne;
        private Player m_PlayerTwo;
        private Board m_Board;
        private eGameTypes m_GameType;
        private int m_TurnCount;
        private bool m_IsOver;

        // Constructors
        public Game(string i_PlayerOneName, int i_BoardSize, eGameTypes i_GameType) //todo merge the c'tors
        {
            m_PlayerOne = new Player(i_PlayerOneName);
            m_Board = new Board(i_BoardSize);
            m_GameType = i_GameType;
            m_IsOver = false;
        }

        public Game(string i_PlayerOneName, string i_PlayerTwoName, int i_BoardSize, eGameTypes i_GameType)
        {
            m_PlayerOne = new Player(i_PlayerOneName);
            m_PlayerTwo = new Player(i_PlayerTwoName);
            m_Board = new Board(i_BoardSize);
            m_GameType = i_GameType;
            m_IsOver = false;
        }

        public void PlayNextTurn()
        {


            // check if game is over- if so then m_IsOver = true
            // also calculate score
        }

        // Properties
        public Player PlayerOne
        {
            get
            {
                return m_PlayerOne;
            }
        }
        public Player PlayerTwo
        {
            get
            {
                return m_PlayerTwo; 
            }
        }
        public Player CurrentPlayer
        {
            get
            {
                Player player;
                if (m_TurnCount % 2 == 0)
                {
                    player = m_PlayerTwo;
                }
                else
                {
                    player = m_PlayerOne;
                }

                return player;
            }
        }
        public Board Board
        {
            get
            {
                return m_Board;
            }
        }
        public int TurnCount
        {
            get
            {
                return m_TurnCount;
            }
            set
            {
                if(value > 0)
                {
                    m_TurnCount = value;
                }
            }
        }
        public bool IsOver
        {
            get
            {
                return m_IsOver;
            }
        }
    }
}
