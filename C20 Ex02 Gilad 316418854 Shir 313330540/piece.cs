using System;
using System.Windows;

namespace C20_Ex02_Gilad_316418854_Shir_313330540
{
    public class Piece
    {
        private Boolean m_IsKing;
        private Boolean m_IsCaptured;
        private Point m_Location;
        private readonly Player.ePlayerSide m_Type;//TODO : should it be readonly?

        public Piece()
        {
            m_IsKing = false;
            m_IsCaptured = false;
           
        }
        public Piece(Point i_Location, Player.ePlayerSide i_Type)
        {
            m_IsKing = false;
            m_IsCaptured = false;
            m_Location = i_Location;
            m_Type = i_Type;
        }

        public Player.ePlayerSide Type
        {
            get
            {
                return m_Type;
            }
        }
        public Point Location
        {
            get => m_Location;
            set => m_Location = value;
        }
        public Boolean IsKing
        {
            get => m_IsKing;
            set
            {
                if (value == true)
                {
                    m_IsKing=true;
                }
            }
        }

        public Boolean IsCaptured
        {
            get => m_IsCaptured;
            set
            {
                if (value == true)
                {
                    m_IsCaptured = true;
                }
            }
        }
    }


}





    

