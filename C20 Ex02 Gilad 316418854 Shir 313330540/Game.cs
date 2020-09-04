﻿using System;
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

        // Execute the given move, returns true if it was executed successfully
        public eMoveFeedback ExecuteMove(Move i_Move)
        {
            eMoveFeedback moveFeedback = eMoveFeedback.Failed;

            if (!i_Move.IsQuit)
            {
                // simple move
                if (MoveValidator.IsSimpleMove(CurrentPlayer, m_Board, i_Move))
                {
                    if (MoveValidator.IsPlayerHasCapture(CurrentPlayer, m_Board))
                    {
                        moveFeedback = eMoveFeedback.FailedCouldCapture;
                    }
                    else //Execute
                    {
                        m_Board.makeMove(CurrentPlayer, m_Board.GameBoard[i_Move.XFrom,i_Move.YFrom].PiecePointer, new Point(i_Move.XTo, i_Move.YTo));
                        moveFeedback = eMoveFeedback.Success;
                        m_LastPlayer = CurrentPlayer;
                        m_TurnCount++;
                    }
                }
                // capture move
                else if (MoveValidator.IsCaptureMovePossible(CurrentPlayer, m_Board, i_Move))
                {
                    m_Board.makeCaptureMove(CurrentPlayer, m_Board.GameBoard[i_Move.XFrom, i_Move.YFrom].PiecePointer, new Point(i_Move.XTo, i_Move.YTo));
                    moveFeedback = eMoveFeedback.Success;
                    m_LastPlayer = CurrentPlayer;
                    m_TurnCount++;
                    if (MoveValidator.IsDoubleCaptureMove(CurrentPlayer, m_Board, i_Move))
                    {
                        TurnCount--;
                        moveFeedback = eMoveFeedback.CanDoubleCapture;
                    }
                }
            }
            else  // move is "Q"
            {
                moveFeedback = eMoveFeedback.Quit;
            }
                
            return moveFeedback;
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
            if(!CurrentPlayer.HasPossibleMoves(m_Board))
            {
                isOver = true;
            }

            return isOver;
        }

        // Calculate current score of players based of pieces left difference
        public eRoundResult CalculateScores()
        {
            eRoundResult roundResult;
            int piecesDifference = Math.Abs(m_PlayerOne.PiecesLeft - m_PlayerTwo.PiecesLeft);
            
            if(m_PlayerOne.PiecesLeft > m_PlayerTwo.PiecesLeft)
            {
                roundResult = eRoundResult.playerOneVictory;
                m_PlayerOne.TotalScore += piecesDifference;
            }
            else if(m_PlayerOne.PiecesLeft < m_PlayerTwo.PiecesLeft)
            {
                roundResult = eRoundResult.playerTwoVictroy;
                m_PlayerTwo.TotalScore += piecesDifference;
            }
            else
            {
                roundResult = eRoundResult.Tie;
            }

            return roundResult;
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
