using System;
using System.Drawing;

namespace C20_Ex02_Gilad_316418854_Shir_313330540
{
    public class Game
    {
        // Private Members
        private Player m_PlayerOne;
        private Player m_PlayerTwo;
        private Player m_LastPlayer;
        private Board m_Board;
        private bool m_AiMode;
        private int m_TurnCount;
        private bool m_IsOver;

        // Constructors
        public Game(string i_PlayerOneName, string i_PlayerTwoName, int i_BoardSize, bool i_AiMode)
        {
            m_PlayerOne = new Player(i_PlayerOneName, ePlayerSide.Up, i_BoardSize, false);
            m_PlayerTwo = new Player(i_PlayerTwoName, ePlayerSide.Down, i_BoardSize, i_AiMode);
            m_Board = new Board(i_BoardSize);
            m_AiMode = i_AiMode;
        }

        // Public Methods
        // Setup each player's piece's position
        public void SetPiecesStartingPositions()
        {
            m_Board.SetPiecesPosition(m_PlayerOne);
            m_Board.SetPiecesPosition(m_PlayerTwo);
        }

        // Execute the given move
        public void ExecuteMove(string i_Move)
        {
            if(i_Move != "Q")
            {
                // original place
                int x = i_Move[1] - 97; //Ascii value of 'a'
                int y = i_Move[0] - 65; //Ascii value of 'A'

                Point moveToPoint = new Point((i_Move[3] - 97), i_Move[2] - 65);
                int numOfPiecesCurrPlayer = CurrentPlayer.Pieces.Length;
                int index=0;
                // find the piece in the location from the receiving move
                TurnCount++;
                m_LastPlayer = CurrentPlayer;
                while (numOfPiecesCurrPlayer != 0)
                {
                    if (CurrentPlayer.Pieces[index].Location.X == x && CurrentPlayer.Pieces[index].Location.Y == y)
                    {
                        CurrentPlayer.Pieces[index].Location = moveToPoint;
                        m_Board.makeMove(CurrentPlayer, index, moveToPoint);
                        return;
                    }

                    index++;
                    numOfPiecesCurrPlayer--;
                }
            }

        }

        // Returns true if the game is over
        public bool IsGameOver()
        {
            bool isOver = false;
            if (m_PlayerOne.Pieces.Length == 0 || m_PlayerTwo.Pieces.Length == 0 || m_LastPlayer.LastTurn == "Q")
            {
                isOver = true;

            }

            return isOver;
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
        public Player LastPlayer
        {
            get
            {
                return m_LastPlayer;
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
        public bool AiMode
        {
            get
            {
                return m_AiMode;
            }
            set
            {
                m_AiMode = value;
            }
        }
        public bool IsOver
        {
            get
            {
                return m_IsOver;
            }
            set
            {
                m_IsOver = value;
            }
        }
    }
}
