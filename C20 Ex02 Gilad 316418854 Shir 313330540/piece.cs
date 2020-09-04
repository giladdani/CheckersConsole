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
        public bool HasPossibleMoves(Player i_Player, Board i_CurrentBoard)
        {
            return (MoveValidator.IsPieceHavePossibleMove(i_Player, i_CurrentBoard,this));
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





    

