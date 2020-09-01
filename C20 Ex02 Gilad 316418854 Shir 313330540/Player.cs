using System;
using System.Drawing;

namespace C20_Ex02_Gilad_316418854_Shir_313330540
{
    
    public class Player
    {
        private string m_Name;
        private ePlayerSide m_Side;
        private Piece[] m_PiecesArr;
        private int m_TotalPoints;
        private Boolean m_IsAI;
        public enum ePlayerSide
        {
            Up, Down
        }
        //??? moves array

        public Player(string i_Name, ePlayerSide i_Side, int i_SizeOfBoard)
        {
            m_Name = i_Name;
            m_Side = i_Side;
            m_TotalPoints = 0;

            InitializePieceArr(i_Side, i_SizeOfBoard);
           
        }

        public Piece[] PiecesArr
        {
            get
            {
                return PiecesArr;
            }
        }
        public bool IsAI
        {
            get
            {
                return (IsAI == true);
            }
            set
            {
                IsAI = value;
            }
        }
        private void InitializePieceArr(ePlayerSide i_Side, int i_SizeOfBoard)
        {
            int numOfPieces = (i_SizeOfBoard/2)*(i_SizeOfBoard-1);
            m_PiecesArr = new Piece[numOfPieces];
            int endRow, startRow, piecesIndex = 0;
            if (i_Side == ePlayerSide.Up)
            {
                startRow = 0;
                endRow = (i_SizeOfBoard / 2) - 1;
            }
            else //i_side=Down
            {
                startRow = (i_SizeOfBoard / 2) - 1;
                endRow = i_SizeOfBoard;
            }
            while (piecesIndex < numOfPieces)
            {
                for (int i = startRow; i < endRow ; i++)
                {
                    for (int j = 0; j < i_SizeOfBoard; j++)
                    {
                        if ((j % 2 == 1) && (i % 2 == 0))
                        {
                            Point locationPoint = new Point(i, j);
                            Piece boardPiece = new Piece(locationPoint, i_Side);
                            m_PiecesArr[piecesIndex] = boardPiece;
                            piecesIndex++;
                        }

                        if ((j % 2 == 0) && (i % 2 == 1))
                        {
                            Point locationPoint = new Point(i, j);
                            Piece boardPiece = new Piece(locationPoint, i_Side);
                            m_PiecesArr[piecesIndex] = boardPiece;
                            piecesIndex++;

                        }

                    }
                }
            }
        }

      
      
    }
}
