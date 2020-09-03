using System;
using System.Globalization;

namespace C20_Ex02_Gilad_316418854_Shir_313330540
{
    public class MoveValidator
    {
       
        //Returns true if the the move without capture is possible
        public static bool IsSimpleMove(Player i_Player, Board i_Board, Move i_Move)
        {
            bool simpleMove = false;
            if(i_Board.GameBoard[i_Move.XTo, i_Move.YTo] ==null)
            {
                if (Math.Abs(i_Move.XTo - i_Move.XFrom) == 1)
                {
                    simpleMove = (isKingMoveDiagonalLine(i_Player, i_Move) || isSimpleMovePossible(i_Player, i_Board, i_Move));
                }
            }
            return simpleMove;
        }

        public static bool IsSimpleMovePossible(Player i_Player, Board i_Board, Move i_Move)
        {
            bool possible = false;

            //check valid move for regular piece
            if (i_Board.GameBoard[i_Move.XFrom, i_Move.YFrom].PiecePointer.IsKing == false)
            {
                if (isMoveDiagonalLine(i_Player, i_Move))
                {
                    possible = true;
                }
            }

            //check valid move for king piece
            if (i_Board.GameBoard[i_Move.XFrom, i_Move.YFrom].PiecePointer.IsKing == true)
            {
                if (isKingMoveDiagonalLine(i_Player, i_Move))
                {
                    possible = true;
                }
            }


            return possible;
        }

        public static bool IsKingMoveDiagonalLine(Player i_Player, Move i_Move)
        {
            bool diagonalLine = ((i_Move.XTo == i_Move.XFrom - 1) || (i_Move.XTo == i_Move.XFrom + 1)) &&
                                ((i_Move.YFrom == i_Move.YFrom + 1) || (i_Move.YTo == i_Move.YTo - 1));

            return diagonalLine;
        }

        // check if move is diagonal, only if there is no capture and the piece is not a king
        public static bool IsMoveDiagonalLine(Player i_Player, Move i_Move)
        {
            bool diagonalLine = false;
            if (i_Player.Side == ePlayerSide.Down)
            {
                if ((i_Move.XTo == i_Move.XFrom - 1) && (Math.Abs(i_Move.YFrom - i_Move.YTo) == 1))
                {
                    diagonalLine = true;
                }
            }
            else
            {
                if ((i_Move.XTo == i_Move.XFrom + 1) && (Math.Abs(i_Move.YFrom - i_Move.YTo) == 1))
                {
                    diagonalLine = true;
                }
            }

            return diagonalLine;
        }

        //Returns true if the the move with capture is possible
        public static bool IsCaptureMove(Player i_Player, Board i_Board, Move i_Move)
        {
            bool captureMove = false;
            if (i_Board.GameBoard[i_Move.XTo, i_Move.YTo] == null)
            { 
                if (Math.Abs(i_Move.XTo - i_Move.XFrom) == 2)
                {
                    captureMove = (IsKingCapturePossible(i_Player, i_Board, i_Move) || IsCaptureMovePossible(i_Player, i_Board, i_Move));
                }
            }
            return captureMove;
        }

        public static bool IsCaptureMovePossible(Player i_Player, Board i_Board, Move i_Move)
        {
            bool captureMovePossible = false;


            if (i_Player.Side == ePlayerSide.Down)
            {
                captureMovePossible = IsCaptureMovePossiblePerSide(ePlayerSide.Down, i_Board, (int)ePlayerMoves.MoveUp, i_Move);
            }
            else
            {
                captureMovePossible = IsCaptureMovePossiblePerSide(ePlayerSide.Up, i_Board, (int)ePlayerMoves.MoveDown, i_Move);
            }
           
            
            return captureMovePossible;
        }

        public static bool IsCaptureMovePossiblePerSide(ePlayerSide i_Side, Board i_Board, int i_Direction, Move i_Move)
        {
           
            bool captureMovePossible = false;
            if ( i_Move.XFrom + 2*i_Direction == i_Move.XTo)
            {
                if (i_Move.YFrom -2*i_Direction == i_Move.YTo)
                {
                    if (i_Board.GameBoard[i_Move.XTo + i_Direction, i_Move.YTo - i_Direction].PiecePointer.Side == GetOtherSide(i_Side))
                    {
                        captureMovePossible = true;

                    }
                }
                if (i_Move.YFrom + 2 * i_Direction == i_Move.YTo)
                {
                    if (i_Board.GameBoard[i_Move.XTo + i_Direction, i_Move.YTo + i_Direction].PiecePointer.Side == GetOtherSide(i_Side))
                    {
                        captureMovePossible = true;

                    }
                }
            }
            return captureMovePossible;
        }

        public static bool IsDoubleCaptureMove(Player i_Player, Board i_Board, Move i_Move)
        {
            bool doubleCaptureMove = false;

            doubleCaptureMove = (isDoubleCaptureSimpleMove(i_Player, i_Board, i_Move) || isKingDoubleCaptureSimpleMove(i_Player, i_Board, i_Move));
                
            
            return doubleCaptureMove;
        }

        public static bool IsDoubleCaptureSimpleMove(Player i_Player, Board i_Board, Move i_Move)
        {
            bool DoublecaptureMove = false;
            if (i_Player.Side == ePlayerSide.Down)
            {
                DoublecaptureMove = IsDoubleCaptureMovePossiblePerSide(ePlayerSide.Down, i_Board, (int)ePlayerMoves.MoveUp, i_Move);
            }
            else
            {
                DoublecaptureMove = IsDoubleCaptureMovePossiblePerSide(ePlayerSide.Up, i_Board, (int)ePlayerMoves.MoveDown, i_Move);
            }

            return DoublecaptureMove;
        }

        public static bool IsKingDoubleCaptureSimpleMove(Player i_Player, Board i_Board, Move i_Move)
        {
            bool DoublecaptureMove = false;
            if (i_Player.Side == ePlayerSide.Down)
            {
                DoublecaptureMove = IsDoubleCaptureMovePossiblePerSide(ePlayerSide.Down, i_Board, (int)ePlayerMoves.MoveDown, i_Move);
            }
            else
            {
                DoublecaptureMove = IsDoubleCaptureMovePossiblePerSide(ePlayerSide.Up, i_Board, (int)ePlayerMoves.MoveUp, i_Move);
            }

            return DoublecaptureMove;
        }

        public static bool IsDoubleCaptureMovePossiblePerSide(ePlayerSide i_Side, Board i_Board, int i_Direction, Move i_Move)
        {

            bool DoublecaptureMove = false;
          
            if (IsInBorders(i_Board, i_Move.XTo + i_Direction, i_Move.YTo - i_Direction))
            {
                if (i_Board.GameBoard[i_Move.XTo + i_Direction, i_Move.YTo - i_Direction].PiecePointer.Side == GetOtherSide(i_Side))
                {
                    if (IsInBorders(i_Board, i_Move.XTo + 2 * i_Direction, i_Move.YTo - 2 * i_Direction))
                    {
                        if (i_Board.GameBoard[i_Move.XTo + 2 * i_Direction, i_Move.YTo - 2 * i_Direction] == null)
                        {
                            DoublecaptureMove = true;
                        }
                    }
                }
            }
                
            if (IsInBorders(i_Board, i_Move.XTo + i_Direction, i_Move.YTo + i_Direction)) 
            {
                if (i_Board.GameBoard[i_Move.XTo + i_Direction, i_Move.YTo + i_Direction].PiecePointer.Side == GetOtherSide(i_Side))
                {
                    if (IsInBorders(i_Board, i_Move.XTo + 2 * i_Direction, i_Move.YTo + 2 * i_Direction))
                    {
                        if (i_Board.GameBoard[i_Move.XTo + 2 * i_Direction, i_Move.YTo + 2 * i_Direction] == null)
                        {
                            DoublecaptureMove = true;
                        }
                    }
                }
            }
            return DoublecaptureMove;

        }
 
        public static ePlayerSide GetOtherSide(ePlayerSide i_Side)
        {
            ePlayerSide side;
           if(i_Side==ePlayerSide.Down)
           {
               side = ePlayerSide.Up;
           }
           else
           {
               side = ePlayerSide.Down;
           }
            return side;
        }

        public static bool IsKingCapturePossible(Player i_Player, Board i_Board, Move i_Move)
        {
            bool KingcapturePossible = false;


            if (i_Player.Side == ePlayerSide.Down)
            {
                KingcapturePossible = IsCaptureMovePossiblePerSide(ePlayerSide.Down, i_Board, (int)ePlayerMoves.MoveDown, i_Move);
            }
            else
            {
                KingcapturePossible = IsCaptureMovePossiblePerSide(ePlayerSide.Up, i_Board, (int)ePlayerMoves.MoveUp, i_Move);
            }


            return KingcapturePossible;
        }

        public static bool IsInBorders( Board i_Board, int i_X, int i_Y)
        {
            bool inBorders=false;
            if (i_X< i_Board.Size && i_Y < i_Board.Size)
            {
                inBorders = true;
            }

            return inBorders;
        }

    }
}
