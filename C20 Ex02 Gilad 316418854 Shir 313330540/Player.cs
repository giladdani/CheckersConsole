using System;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Collections.Generic;


namespace C20_Ex02_Gilad_316418854_Shir_313330540
{
    public class Player
    {
        // Private Members
        private string m_Name;
        private ePlayerSide m_Side;
        private List<Piece> m_Pieces;
        private int m_TotalScore;
        private bool m_IsAi;
        private int m_PiecesLeft;
        
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
            int numOfPieces = (i_BoardSize / 2) * ((i_BoardSize / 2) - 1);
            m_Pieces = new List<Piece>();
            m_PiecesLeft = numOfPieces;
            int endRow, startRow, piecesIndex = 0;
            if(i_Side == ePlayerSide.Up)
            {
                startRow = 0;
                endRow = (i_BoardSize / 2) - 1;
            }
            else //i_Side=Down
            {
                startRow = (i_BoardSize / 2) + 1;
                endRow = i_BoardSize;
            }

            for(int i = startRow; i < endRow; i++)
            {
                for(int j = 0; j < i_BoardSize; j++)
                {
                    if(piecesIndex < numOfPieces)
                    {
                        if((j % 2 == 1) && (i % 2 == 0))
                        {
                            Point locationPoint = new Point(i, j);
                            Piece boardPiece = new Piece(locationPoint, i_Side);
                            m_Pieces.Add(boardPiece);
                        }

                        if((j % 2 == 0) && (i % 2 == 1))
                        {
                            Point locationPoint = new Point(i, j);
                            Piece boardPiece = new Piece(locationPoint, i_Side);
                            m_Pieces.Add(boardPiece);
                        }
                    }
                }
            }
        }

        // Public Methods
        // Returns true if the player has any possible move to play
        public bool HasPossibleMoves(Board i_CurrentBoard)
        {
            bool hasMove = false;

            foreach(Piece piece in m_Pieces)
            {
                // if piece can move/capture
                if(piece.HasPossibleMoves(i_CurrentBoard, this))
                {
                    hasMove = true;
                }
}
            return hasMove;
        }

        // Returns a random generated move for the player
        public Move GenerateRandomMove(Board i_CurrentBoard)
        {
            foreach(Piece piece in m_Pieces)
            {
                if(piece.IsKing)
                {
                    if(MoveValidator.IsKingCapturePossible(this, i_CurrentBoard, piece))
                    {
                        move = piece.GetPossibleMove();
                    }
                  
                }
                else
                {
                    if(MoveValidator.IsCapturePossible(this, i_CurrentBoard, piece))
                    {

                    }
                    //else if( piece can do simple move)
                }

                Move move = piece.GetPossibleMove(i_CurrentBoard);
            }
          
            return move;
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
        public List<Piece> Pieces
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
        public int PiecesLeft
        {
            get
            {
                return m_PiecesLeft;
            }
            set
            {
                m_PiecesLeft = value;
            }
        }
    }
}
