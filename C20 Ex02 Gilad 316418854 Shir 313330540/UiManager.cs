using System;
using System.Text;

namespace C20_Ex02_Gilad_316418854_Shir_313330540
{
    public class UiManager
    {
        // Private Members
        private Game m_CurrentGame;

        // Public Methods
        public void CreateGame()
        {
            string playerOneName = getNameFromUser();
            int boardSize = getBoardSizeFromUser();
            bool aiMode = getAiModeChoice();
            string playerTwoName = aiMode ? "Computer" : getNameFromUser();

            m_CurrentGame = new Game(playerOneName, playerTwoName, boardSize, aiMode);
        }

        // Start a new round of the game
        public void StartRound()
        {
            string lastMove = string.Empty;
            m_CurrentGame.Board.Build();
            m_CurrentGame.TurnCount = 1;
            m_CurrentGame.SetPiecesStartingPositions();
            while (!m_CurrentGame.IsOver())
            {
                reprintBoard();
                if(m_CurrentGame.TurnCount > 1)
                {
                    printLastTurnMessage(lastMove);
                }

                Move currentMove = getMove(out lastMove);
                eMoveFeedback moveFeedback = m_CurrentGame.ExecuteMove(currentMove);
                while(moveFeedback != eMoveFeedback.Success && moveFeedback != eMoveFeedback.Quit)
                {
                    printFeedback(moveFeedback);
                    currentMove = getMove(out lastMove);
                    moveFeedback = m_CurrentGame.ExecuteMove(currentMove);
                }
            }

            m_CurrentGame.CalculateScores();        // TODO
            if(playAgain())
            {
                StartRound();
            }
            else
            {
                printFinalScores();
            }
        }

        // Private Methods
        // Gets a move from the user    TODO
        private Move getMove(out string o_moveString)
        {
            //if (m_CurrentGame.CurrentPlayer.IsAi)
            //{
            //    Move move = m_CurrentGame.CurrentPlayer.GenerateRandomMove(m_CurrentGame.Board);
            //}
            //else
            //{
                StringBuilder turnMessage = new StringBuilder();
                turnMessage.Append(m_CurrentGame.CurrentPlayer.Name);
                turnMessage.Append("'s Turn ");
                turnMessage.Append(m_CurrentGame.CurrentPlayer.Side == ePlayerSide.Down ? "(X): " : "(O): ");
                Console.Write(turnMessage);
                string moveString = Console.ReadLine();
                while (!InputValidator.IsMoveSyntaxValid(moveString, m_CurrentGame.Board.Size))
                {
                    Console.Write("Invalid move format, try again: ");
                    moveString = Console.ReadLine();
                }
            //}
            o_moveString = moveString;
            Move move = new Move(moveString);
            return move;
        }

        private void printFeedback(eMoveFeedback i_MoveFeedback)
        {
            switch (i_MoveFeedback)
            {
                case eMoveFeedback.FailedCouldCapture:
                    {
                        Console.WriteLine("Failed, you can capture!");
                        break;
                    }
                case eMoveFeedback.CanDoubleCapture:
                    {

                        reprintBoard();
                        Console.WriteLine("You can double capture! play another turn.");
                        break;
                    }
                case eMoveFeedback.Failed:
                    {
                        Console.WriteLine("Invalid move. try again.");
                        break;
                    }
            }
        }

        // Print final players Scores
        private void printFinalScores()
        {
            // TODO
        }

        // Returns true if the user input is another game
        private bool playAgain()
        {
            Console.WriteLine("Play again? enter 1 for YES or 2 for NO: ");
            string choiceString = Console.ReadLine();
            while (!InputValidator.IsValidGameType(choiceString))
            {
                Console.WriteLine("Invalid choice, enter 1 or 2: ");
                choiceString = Console.ReadLine();
            }

            return (bool.Parse(choiceString));
        }

        // Prints the last players name with it's last move
        private void printLastTurnMessage(string i_LastMove)
        {
            StringBuilder lastTurnMessage = new StringBuilder(m_CurrentGame.LastPlayer.Name);
            lastTurnMessage.Append("'s move was ");
            lastTurnMessage.Append(m_CurrentGame.LastPlayer.Side == ePlayerSide.Down ? "(X):" : "(O):");
            lastTurnMessage.Append(i_LastMove);
            Console.WriteLine(lastTurnMessage);
        }

        private void reprintBoard()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            printBoard();
        }

        // Returns a valid name from user input
        private string getNameFromUser()
        {
            Console.WriteLine("Enter player name: ");
            string name = Console.ReadLine();
            while (!InputValidator.IsNameValid(name))
            {
                Console.WriteLine("Name must be up to 20 chars and without spaces.");
                Console.Write("Enter player name: ");
                name = Console.ReadLine();
            }

            return name;
        }
        
        // Returns a valid size for board from user input
        private int getBoardSizeFromUser()
        {
            Console.WriteLine("Enter board size (6, 8 or 10): ");
            string sizeString = Console.ReadLine();
            while (!InputValidator.IsBoardSizeValid(sizeString))
            {
                Console.Write("Invalid size, enter a 6 or 8 or 10: ");
                sizeString = Console.ReadLine();
            }

            return (int.Parse(sizeString));
        }

        // Returns true if the user chose to play against AI
        private bool getAiModeChoice()
        {
            bool choice = false;
            Console.WriteLine("Enter 1 for versus AI or 2 for two players: ");
            string choiceString = Console.ReadLine();
            while(!InputValidator.IsValidGameType(choiceString))
            {
                Console.Write("Invalid choice, enter 1 or 2: ");
                choiceString = Console.ReadLine();
            }

            if(choiceString == "1")
            {
                choice = true;
            }

            return choice;
        }
        
        // Prints the current board
        private void printBoard()
        {
            printColumnNames();
            Console.WriteLine();
            printRowSeparator();
            for(int i = 0, rowChar = 'a'; i < m_CurrentGame.Board.Size; i++, rowChar++)
            {
                Console.Write((char)rowChar);
                Console.Write(" | ");
                for (int j = 0; j < m_CurrentGame.Board.Size; j++)
                {
                    if(m_CurrentGame.Board.GameBoard[i, j].PiecePointer == null)
                    {
                        Console.Write(" ");
                        Console.Write(" | ");
                    }
                    else
                    {
                        if(m_CurrentGame.Board.GameBoard[i, j].PiecePointer.Side == ePlayerSide.Down)
                        {
                            Console.Write(m_CurrentGame.Board.GameBoard[i, j].PiecePointer.IsKing ? "K" : "X");
                            Console.Write(" | ");
                        }

                        if (m_CurrentGame.Board.GameBoard[i, j].PiecePointer.Side == ePlayerSide.Up)
                        {
                            Console.Write(m_CurrentGame.Board.GameBoard[i, j].PiecePointer.IsKing ? "U" : "O");
                            Console.Write(" | ");
                        }
                    }
                }

                Console.WriteLine();
                printRowSeparator();
            }
        }

        /// print the rows column names
        private void printColumnNames()
        {
            Console.Write("   ");
            for (int i = 0, columnChar = 'A'; i < m_CurrentGame.Board.Size; i++, columnChar++)
            {
                Console.Write(" ");
                Console.Write((char)columnChar);
                Console.Write("  ");
            }
        }

        // Prints a line of equal signs to separate the rows
        private void printRowSeparator()
        {
            int numOfSigns = (m_CurrentGame.Board.Size * 5) - (m_CurrentGame.Board.Size - 1);
            Console.Write("  ");
            for(int i = 0; i < numOfSigns; i++)
            {
                Console.Write("=");
            }

            Console.WriteLine();
        }

        // Properties
        public Game CurrentGame
        {
            get
            {
                return m_CurrentGame;
            }
        }
    }
}