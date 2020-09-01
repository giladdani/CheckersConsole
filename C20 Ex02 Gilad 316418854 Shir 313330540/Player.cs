using System;
using System.Collections.Generic;
using System.Windows;

namespace C20_Ex02_Gilad_316418854_Shir_313330540
{
    public class Player
    {
        private string m_Name;
        private ePlayerSide m_Side;
        private Piece[] m_PiecesArr;
        private int m_TotalPoints;
        public enum ePlayerSide
        {
            Up, Down
        }
        //??? moves array

        public Player(string i_Name, ePlayerSide i_Side, int i_Pieces)
        {
            m_Name = i_Name;
            m_Side = i_Side;
            m_TotalPoints = 0;
            m_PiecesArr = new Piece[i_Pieces];
            initializePieceArr();
            for (int i = 0; i < i_Pieces; i++)
            {
                m_PiecesArr[0].Location.X=

            }
        }
        private void BuildPlayerPiecesArr(Player.ePlayerSide i_Type,  int i_Pieces)
        {
            int numOfRows = i_Pieces / 4;// i_pieces is the amunt of pieces the player have

            Piece[] piecesArr = buildStartArr(i_Type, i_Pieces, numOfRows);
            // num of rows depends on the amount of pieces 8 pieces->2 rows, 12 pieces ->3 rows, 16 pieces ->4 rows
            if 
        }

        private Piece[] buildStartArr(ePlayerSide i_Type, int i_Pieces, int numOfRows)
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
    }
}
