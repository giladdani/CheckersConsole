using System;
using System.Drawing;
using System.Windows;
using System.Drawing;

namespace C20_Ex02_Gilad_316418854_Shir_313330540
{
    public class Piece
    {
        private bool m_IsKing;
        private bool m_IsCaptured;
        private Point m_Location;
        private readonly ePlayerSide r_Type;

        public Piece(Point i_Location, ePlayerSide i_Type)
        {
            m_IsKing = false;
            m_IsCaptured = false;
            m_Location = i_Location;
            r_Type = i_Type;
        }

        public ePlayerSide Type
        {
            get
            {
                return r_Type;
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
                if (value == true)          // todo why this check? if we start a new round we want to reset it
                {
                    m_IsKing = true;
                }
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
                if (value == true)          // todo same question as IsKing
                {
                    m_IsCaptured = true;
                }
            }
        }
    }


}





    

