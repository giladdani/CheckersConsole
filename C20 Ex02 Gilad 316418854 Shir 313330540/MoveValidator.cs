﻿using System;
using System.Globalization;

namespace C20_Ex02_Gilad_316418854_Shir_313330540
{
    public class MoveValidator
    {
        private static bool isCapturePossiblePerPiece(Player i_Player, Board i_Board, Piece i_Piece)
        {
            bool captureMovePossible = false;

            if (i_Player.Side == ePlayerSide.Down)
            {
                captureMovePossible = IsCaptureMovePossiblePerSide(ePlayerSide.Down, i_Board, (int)ePlayerMoves.MoveUp, i_Piece);
            }
            else
            {
                captureMovePossible = IsCaptureMovePossiblePerSide(ePlayerSide.Up, i_Board, (int)ePlayerMoves.MoveDown, i_Piece);
            }

            return captureMovePossible;
        }

        // Public Methods
        public static bool IsPlayerHasCapture(Player i_Player, Board i_Board)
        {
            bool canCapture = false;
            
            foreach(Piece piece in i_Player.Pieces)
            {
                if(piece.IsKing)
                {
                    canCapture = IsKingCapturePossible(i_Player, i_Board, piece);
                }
                else 
                {
                    canCapture = isCapturePossiblePerPiece(i_Player, i_Board, piece);
                }
            }
            
            return canCapture;
        }

        public static bool IsCaptureMovePossiblePerSide(ePlayerSide i_Side, Board i_Board, int i_Direction, Piece i_Piece)
        {
            bool captureMovePossible = false;

            if (i_Board.GameBoard[i_Piece.Location.X + i_Direction, i_Piece.Location.Y - i_Direction].PiecePointer.Side == GetOtherSide(i_Side))
            {
                if (i_Board.GameBoard[i_Piece.Location.X + 2 * i_Direction, i_Piece.Location.Y - 2 * i_Direction] == null)
                {
                    captureMovePossible = true;
                }
            }

            if (i_Board.GameBoard[i_Piece.Location.X + i_Direction, i_Piece.Location.Y + i_Direction].PiecePointer.Side == GetOtherSide(i_Side))
            {
                if (i_Board.GameBoard[i_Piece.Location.X + 2 * i_Direction, i_Piece.Location.Y + 2 * i_Direction] == null)
                {
                    captureMovePossible = true;
                }
            }

            return captureMovePossible;
        }

        public static bool IsKingCapturePossible(Player i_Player, Board i_Board, Piece i_Piece)
        { 
            bool kingCapturePossible = false;

            if (i_Player.Side == ePlayerSide.Down)
            {
                kingCapturePossible = IsCaptureMovePossiblePerSide(ePlayerSide.Down, i_Board, (int)ePlayerMoves.MoveDown, i_Piece);
            }
            else
            {
                kingCapturePossible = IsCaptureMovePossiblePerSide(ePlayerSide.Up, i_Board, (int)ePlayerMoves.MoveUp, i_Piece);
            }

            return kingCapturePossible;
        }

        // Returns true if the the move without capture is possible
        public static bool IsSimpleMove(Player i_Player, Board i_Board, Move i_Move)
        {
            bool simpleMove = false;

            // if destination is empty
            if(i_Board.GameBoard[i_Move.XTo, i_Move.YTo].PiecePointer == null)
            {
                // if row diff is 1
                if (Math.Abs(i_Move.XTo - i_Move.XFrom) == 1)
                {
                    simpleMove = (IsKingMoveDiagonalLine(i_Player, i_Move) || IsSimpleMovePossible(i_Player, i_Board, i_Move));
                }
            }

            return simpleMove;
        }

        public static bool IsSimpleMovePossible(Player i_Player, Board i_Board, Move i_Move)
        {
            bool possible = false;

            // check valid move for regular piece
            if (i_Board.GameBoard[i_Move.XFrom, i_Move.YFrom].PiecePointer.IsKing == false)
            {
                if (i_Player.Side == ePlayerSide.Down)
                {
                    possible = IsMoveDiagonalLine(ePlayerSide.Down, i_Move, (int)ePlayerMoves.MoveUp);
                }

                if (i_Player.Side == ePlayerSide.Up)
                {
                    possible = IsMoveDiagonalLine(ePlayerSide.Up, i_Move, (int)ePlayerMoves.MoveDown);
                }
            }

            // check valid move for king piece
            if (i_Board.GameBoard[i_Move.XFrom, i_Move.YFrom].PiecePointer.IsKing)
            {
                if (IsKingMoveDiagonalLine(i_Player, i_Move))
                {
                    possible = true;
                }
            }

            return possible;
        }

        public static bool IsMoveDiagonalLine(ePlayerSide i_Side, Move i_Move, int i_Direction)
        {
            bool diagonalLine = false;

            if ((i_Move.XTo == i_Move.XFrom + i_Direction) && (Math.Abs(i_Move.YFrom - i_Move.YTo) == 1))
            {
                diagonalLine = true;
            }

            return diagonalLine;
        }

        public static bool IsKingMoveDiagonalLine(Player i_Player, Move i_Move)
        {
            bool diagonalLine = (Math.Abs(i_Move.XTo - i_Move.XFrom) == 1) &&
                                (Math.Abs(i_Move.YTo - i_Move.YFrom) == 1);

            return diagonalLine;
        }

        // check if move is diagonal, only if there is no capture and the piece is not a king
       

        // Returns true if the the move with capture is possible
        public static bool IsCaptureMovePossible(Player i_Player, Board i_Board, Move i_Move)
        {
            bool captureMove = false;

            if (i_Board.GameBoard[i_Move.XTo, i_Move.YTo] == null)
            {
                if (i_Player.Side == ePlayerSide.Down)
                {
                    if (i_Move.XFrom - 1 == i_Move.YTo + 1)
                    {
                        if (((i_Move.YFrom + 1) == (i_Move.YTo - 1)) || ((i_Move.YFrom - 1) == (i_Move.YTo + 1)))
                        {
                            captureMove = true;
                        }
                    }
                }
                else
                {
                    if (i_Move.XFrom + 1 == i_Move.YTo - 1)
                    {
                        if (((i_Move.YFrom + 1) == (i_Move.YTo - 1)) || ((i_Move.YFrom - 1) == (i_Move.YTo + 1)))
                        {
                            captureMove = true;
                        }
                    }
                }
            }

            return captureMove;
        }
       
        public static bool IsDoubleCaptureMove(Player i_Player, Board i_Board, Move i_Move)
        {
            bool doubleCaptureMove = false;

            doubleCaptureMove = (IsDoubleCaptureSimpleMove(i_Player, i_Board, i_Move) || IsKingDoubleCaptureSimpleMove(i_Player, i_Board, i_Move));
                
            return doubleCaptureMove;
        }

        public static bool IsDoubleCaptureSimpleMove(Player i_Player, Board i_Board, Move i_Move)
        {
            bool doubleCaptureMove = false;

            if (i_Player.Side == ePlayerSide.Down)
            {
                doubleCaptureMove = IsDoubleCaptureMovePossiblePerSide(ePlayerSide.Down, i_Board, (int)ePlayerMoves.MoveUp, i_Move);
            }
            else
            {
                doubleCaptureMove = IsDoubleCaptureMovePossiblePerSide(ePlayerSide.Up, i_Board, (int)ePlayerMoves.MoveDown, i_Move);
            }

            return doubleCaptureMove;
        }

        public static bool IsKingDoubleCaptureSimpleMove(Player i_Player, Board i_Board, Move i_Move)
        {
            bool doubleCaptureMove = false;

            if (i_Player.Side == ePlayerSide.Down)
            {
                doubleCaptureMove = IsDoubleCaptureMovePossiblePerSide(ePlayerSide.Down, i_Board, (int)ePlayerMoves.MoveDown, i_Move);
            }
            else
            {
                doubleCaptureMove = IsDoubleCaptureMovePossiblePerSide(ePlayerSide.Up, i_Board, (int)ePlayerMoves.MoveUp, i_Move);
            }

            return doubleCaptureMove;
        }

        public static bool IsDoubleCaptureMovePossiblePerSide(ePlayerSide i_Side, Board i_Board, int i_Direction, Move i_Move)
        {
            bool doubleCaptureMove = false;
          
            if (IsInBorders(i_Board, i_Move.XTo + i_Direction, i_Move.YTo - i_Direction))
            {
                if (i_Board.GameBoard[i_Move.XTo + i_Direction, i_Move.YTo - i_Direction].PiecePointer.Side == GetOtherSide(i_Side))
                {
                    if (IsInBorders(i_Board, i_Move.XTo + 2 * i_Direction, i_Move.YTo - 2 * i_Direction))
                    {
                        if (i_Board.GameBoard[i_Move.XTo + 2 * i_Direction, i_Move.YTo - 2 * i_Direction] == null)
                        {
                            doubleCaptureMove = true;
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
                            doubleCaptureMove = true;
                        }
                    }
                }
            }

            return doubleCaptureMove;
        }
 
        public static ePlayerSide GetOtherSide(ePlayerSide i_Side)
        {
            ePlayerSide side = (i_Side==ePlayerSide.Down) ? ePlayerSide.Up : ePlayerSide.Down;

            return side;
        }

        //public static bool IsKingCapturePossible(Player i_Player, Board i_Board, Move i_Move)
        //{
        //    bool KingCapturePossible = false;

        //    if (i_Player.Side == ePlayerSide.Down)
        //    {
        //        KingCapturePossible = IsCaptureMovePossiblePerSide(ePlayerSide.Down, i_Board, (int)ePlayerMoves.MoveDown, i_Move);
        //    }
        //    else
        //    {
        //        KingCapturePossible = IsCaptureMovePossiblePerSide(ePlayerSide.Up, i_Board, (int)ePlayerMoves.MoveUp, i_Move);
        //    }

        //    return KingCapturePossible;
        //}

        public static bool IsInBorders(Board i_Board, int i_X, int i_Y)
        {
            bool inBorders = false;
            if (i_X < i_Board.Size && i_Y < i_Board.Size)
            {
                inBorders = true;
            }

            return inBorders;
        }
    }
}
