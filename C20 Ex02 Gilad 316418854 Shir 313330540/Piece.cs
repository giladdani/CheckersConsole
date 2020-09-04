using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;

namespace C20_Ex02_Gilad_316418854_Shir_313330540
{
    public class Piece
    {
        // Private Members
        private readonly ePlayerSide r_Side;
        private bool m_IsKing;
        private bool m_IsCaptured;
        private Point m_Location;

        // Constructors
        public Piece(Point i_Location, ePlayerSide i_Side)
        {
            m_IsKing = false;
            m_IsCaptured = false;
            m_Location = i_Location;
            r_Side = i_Side;
        }

        // Public Methods
        // Returns true if the piece has any possible moves
        public bool HasPossibleMoves(Board i_CurrentBoard, Player i_Player)
        {
            return (MoveValidator.IsPieceHavePossibleMove(i_Player, i_CurrentBoard, this));
        }

        // Returns a list of the piece's possible moves
        public List<Move> GetAvailableMovesList(Player i_Player, Board i_Board)
        {
            List<Move> movesList = new List<Move>();
            if (MoveValidator.IsPieceHavePossibleMove(i_Player, i_Board, this))
            {
                //if(this.IsKing)
                //{
                //    addSimpleMovesUpside(movesList, i_Board);
                //    addCaptureMovesUpside(movesList, i_Board);
                //    addSimpleMovesDownside(movesList, i_Board);
                //    addCaptureMovesDownside(movesList, i_Board);
                //}
                //if(this.r_Side == ePlayerSide.Up)
                //{
                    
                //}
                //else
                //{
                    
                //}
                //if (this.IsKing)
                //{
                //    // check and add possible back moves
                //}
            }

            return movesList;
        }

        // Private Methods
        private void addSimpleMovesUpside(List<Move> i_MovesList, Board i_Board)
        {
            if (MoveValidator.IsInBorders(i_Board, this.Location.X + 1, this.Location.Y + 1) && i_Board.GameBoard[this.Location.X + 1, this.Location.Y + 1].PiecePointer == null)
            {
                i_MovesList.Add(new Move(this.Location.Y, this.Location.X, this.Location.Y + 1, this.Location.X + 1));
            }

            if (MoveValidator.IsInBorders(i_Board, this.Location.X + 1, this.Location.Y - 1) && i_Board.GameBoard[this.Location.X + 1, this.Location.Y - 1].PiecePointer == null)
            {
                i_MovesList.Add(new Move(this.Location.Y, this.Location.X, this.Location.Y - 1, this.Location.X + 1));
            }

            // Capture moves
            if (MoveValidator.IsInBorders(i_Board, this.Location.X + 2, this.Location.Y + 2)
               && i_Board.GameBoard[this.Location.X + 2, this.Location.Y + 2].PiecePointer == null)
            {
                if (i_Board.GameBoard[this.Location.X + 1, this.Location.Y + 1].PiecePointer != null
                   && i_Board.GameBoard[this.Location.X + 1, this.Location.Y + 1].PiecePointer.Side
                   == ePlayerSide.Down)
                {
                    i_MovesList.Add(new Move(this.Location.Y, this.Location.X, this.Location.Y + 2, this.Location.X + 2));
                }
            }

            if (MoveValidator.IsInBorders(i_Board, this.Location.X + 2, this.Location.Y - 2)
               && i_Board.GameBoard[this.Location.X + 2, this.Location.Y - 2].PiecePointer == null)
            {
                if (i_Board.GameBoard[this.Location.X + 1, this.Location.Y - 1].PiecePointer != null
                   && i_Board.GameBoard[this.Location.X + 1, this.Location.Y - 1].PiecePointer.Side
                   == ePlayerSide.Down)
                {
                    i_MovesList.Add(new Move(this.Location.Y, this.Location.X, this.Location.Y - 2, this.Location.X + 2));
                }
            }
        }

        // Properties
        public ePlayerSide Side
        {
            get
            {
                return r_Side;
            }
        }
        public Point Location
        {
            get
            {
                return m_Location;
            }
            set
            {
                m_Location = value;
            }
        }
        public bool IsKing
        {
            get
            {
                return m_IsKing;
            }
            set
            {
                
                m_IsKing = true;
                
            }
        }
        public bool IsCaptured
        {
            get
            {
                return m_IsCaptured;
            }
            set
            {
                m_IsCaptured = true;
                
            }
        }
    }
}





    

