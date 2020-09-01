using System;
using System.CodeDom;
using System.Drawing;

namespace C20_Ex02_Gilad_316418854_Shir_313330540
{
    public class Player
    {
        // Private Members
        private string m_Name;
        private ePlayerSide m_Side;
        private Piece[] m_Pieces;
        private int m_TotalPoints;
        private bool m_IsAi;
        private string m_LastTurn;
        
        // Constructors
        public Player(string i_Name, ePlayerSide i_Side, int i_NumOfPieces)
        {
            m_Name = i_Name;
            m_Side = i_Side;
            m_TotalPoints = 0;
            m_Pieces = new Piece[i_NumOfPieces];
            initPiecesArray();
            for (int i = 0; i < i_Pieces; i++)
            {
                m_Pieces[0].Location.X =
            }
        }

        // Private Methods
        private void buildPlayerPiecesArr(ePlayerSide i_Side, int i_NumOfPieces)
        {
            int numOfRows = i_NumOfPieces / 4;

            Piece[] piecesArr = buildStartArr(i_Type, i_NumOfPieces, numOfRows);
            // num of rows depends on the amount of pieces 8 pieces->2 rows, 12 pieces ->3 rows, 16 pieces ->4 rows
        }

        private Piece[] buildStartArr(ePlayerSide i_Type, int i_Pieces, int i_NumOfRows)
        {
            int k = 0;
            Piece[] piecesArr = new Piece[i_Pieces];

            while (k < i_Pieces)
            {
                for (int i = i_StartRow; i < i_EndRow; i++)
                {
                    for (int j = 0; j < m_Size; j++)
                    {
                        if ((j % 2 == 1) && (i % 2 == 0))
                        {
                            Point locationPoint = new Point(i, j);
                            Piece boardPiece = new Piece(locationPoint, i_Type);
                            m_Board[i, j].piecePointer = boardPiece;
                            piecesArr[k].Location.X = i;

                            k++;
                        }

                        if ((j % 2 == 0) && (i % 2 == 1))
                        {
                            Point locationPoint = new Point(i, j);
                            Piece boardPiece = new Piece(locationPoint, i_Type);
                            m_Board[i, j].piecePointer = boardPiece;
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
