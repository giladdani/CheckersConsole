using System;


namespace C20_Ex02_Gilad_316418854_Shir_313330540
{
    class Move
    {
        private int m_XFrom;
        private int m_YFrom;
        private int m_XTo;
        private int m_YTo;
        private int m_XToDoubleCapture;
        private int m_YToDoubleCapture;

        public Move(string i_Move)
        {
            m_XFrom = i_Move[1] - 97;
            m_YFrom = i_Move[0] - 65;
            m_XTo = i_Move[3] - 97;
            m_YTo = i_Move[2] - 65;
        }

        public int XFrom
        {
            get
            {
                return m_XFrom;
            }
        }
        public int YFrom
        {
            get
            {
                return m_YFrom;
            }
        }
        public int XTo
        {
            get
            {
                return m_XTo;
            }
        }
        public int YTo
        {
            get
            {
                return m_YTo;
            }
        }


       
        public int XToDoubleCapture
        {
            get
            {
                return m_XToDoubleCapture;
            }
            set
            {
                m_XToDoubleCapture = value;
            }
        }
        public int YToDoubleCapture
        {
            get
            {
                return m_YToDoubleCapture;
            }
            set
            {
                m_YToDoubleCapture = value;
            }
        }

    }
}
