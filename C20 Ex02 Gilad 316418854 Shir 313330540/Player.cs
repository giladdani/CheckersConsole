using System;
using System.Drawing;

namespace C20_Ex02_Gilad_316418854_Shir_313330540
{
    public class Player
    {
        // Private Members
        private string m_Name;
        private ePlayerSide m_Side;
        private Piece[] m_Pieces;
        private int m_TotalScore;
        private bool m_IsAi;
        private string m_LastTurn;
        
        // Constructors
        public Player(string i_Name, ePlayerSide i_Side, int i_BoardSize, bool i_IsAi)
        {
            m_Name = i_Name;
            m_Side = i_Side;
            m_IsAi = i_IsAi;
            m_TotalScore = 0;
            initPieceArr(i_Side, i_BoardSize);
        }

        // Private Methods
        // Initialize array of pieces
        private void initPieceArr(ePlayerSide i_Side, int i_BoardSize)
        {
            int numOfPieces = (i_BoardSize / 2) * (i_BoardSize - 1);
            m_Pieces = new Piece[numOfPieces];
            int endRow, startRow, piecesIndex = 0;
            if(i_Side == ePlayerSide.Up)
            {
                startRow = 0;
                endRow = (i_BoardSize / 2) - 1;
            }
            else //i_Side=Down
            {
                startRow = (i_BoardSize / 2) - 1;
                endRow = i_BoardSize;
            }

            while(piecesIndex < numOfPieces)
            {
                for(int i = startRow; i < endRow; i++)
                {
                    for(int j = 0; j < i_BoardSize; j++)
                    {
                        if((j % 2 == 1) && (i % 2 == 0))
                        {
                            Point locationPoint = new Point(i, j);
                            Piece boardPiece = new Piece(locationPoint, i_Side);
                            m_Pieces[piecesIndex] = boardPiece;
                            piecesIndex++;
                        }

                        if((j % 2 == 0) && (i % 2 == 1))
                        {
                            Point locationPoint = new Point(i, j);
                            Piece boardPiece = new Piece(locationPoint, i_Side);
                            m_Pieces[piecesIndex] = boardPiece;
                            piecesIndex++;
                        }
                    }
                }
            }
        }

        // Properties
        public string Name
        {
            get
            {
                return m_Name;
            }
        }
        public ePlayerSide Side
        {
            get
            {
                return m_Side;
            }
        }
        public Piece[] Pieces
        {
            get
            {
                return m_Pieces;
            }
        }
        public int TotalScore
        {
            get
            {
                return m_TotalScore;
            }
            set
            {
                if(value >= 0)
                {
                    m_TotalScore = value;
                }
            }
        }
        public bool IsAi
        {
            get
            {
                return m_IsAi;
            }
            set
            {
                m_IsAi = value;
            }
        }
        public string LastTurn
        {
            get
            {
                return m_LastTurn;
            }
            set
            {
                m_LastTurn = value;
            }
        }
    }
}
