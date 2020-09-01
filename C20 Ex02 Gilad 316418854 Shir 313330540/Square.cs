using System;

namespace C20_Ex02_Gilad_316418854_Shir_313330540
{
    public class Square
    {
        // Private Members
        private Piece m_PiecePointer;

        // Properties
        public Piece PiecePointer
        {
            get
            {
                return m_PiecePointer;
            }
            set
            {
                m_PiecePointer = value;
            }
        }
    }
}
