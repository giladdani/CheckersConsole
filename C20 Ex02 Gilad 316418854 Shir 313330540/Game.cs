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
        public void ExecuteMove(Move i_Move)
        {
            TurnCount++;
            m_LastPlayer = CurrentPlayer;
            if (!i_Move.IsQuit)
            {
                if (MoveValidator.IsSimpleMove(CurrentPlayer, m_Board, i_Move))
                {
                    if (MoveValidator.IsPlayerHasCapture(CurrentPlayer, m_Board))
                    {

                        //user choose simple move, but he can choose Capture, ask for new move.
                    }
                    else //Execute simple move
                    {
                        for (int i = 0; i < CurrentPlayer.Pieces.Count; i++)
                        {
                            if (CurrentPlayer.Pieces[i].Location.X == i_Move.XFrom && CurrentPlayer.Pieces[i].Location.Y == i_Move.YFrom)
                            {
                                m_Board.makeMove(CurrentPlayer, i, new Point(i_Move.XTo, i_Move.YTo));
                            }
                        }
                    }
                }
                // capture move
                else if (MoveValidator.IsCaptureMovePossible(CurrentPlayer, m_Board, i_Move))
                {
                    for (int i = 0; i < CurrentPlayer.Pieces.Count; i++)
                    {
                        if (CurrentPlayer.Pieces[i].Location.X == i_Move.XFrom && CurrentPlayer.Pieces[i].Location.Y == i_Move.YFrom)
                        {
                            m_Board.makeMove(CurrentPlayer, i, new Point(i_Move.XTo, i_Move.YTo));
                            //TODO: 1. update other player pieces list, 
                            //      2. delete from board
                            if (MoveValidator.IsDoubleCaptureMove(CurrentPlayer, m_Board, i_Move))
                            {
                                TurnCount--;
                                // ask for another turn
                            }
                        }
                    }
                }
            }
        }

        // Returns true if the game is over
        public bool IsOver()
        {
            bool isOver = false;

            // If a player has no pieces left
            if ((m_PlayerOne.PiecesLeft == 0 || m_PlayerTwo.PiecesLeft == 0) && m_TurnCount > 1)
            {
                isOver = true;
            }

            // If current player has no moves to play
            //if(!CurrentPlayer.HasPossibleMoves(m_Board))   TODO
            //{
            //    isOver = true;
            //}

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
    }
}
