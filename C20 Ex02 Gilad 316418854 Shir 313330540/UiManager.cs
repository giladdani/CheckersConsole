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
            m_CurrentGame.Board.Build();
            m_CurrentGame.TurnCount = 1;
            while(!m_CurrentGame.IsOver())
            {
                Ex02.ConsoleUtils.Screen.Clear();
                printBoard();
                string currentMove = getMove();
                m_CurrentGame.ExecuteMove(currentMove);
            }
            // TODO calculate score and sum it to total score
            printRoundScores();         // TODO
            if(playAgain())
            {
                StartRound();
            }
            else
            {
                printFinalScores();     // TODO
            }
        }

        // Private Methods
        // Gets a move from the user
        private string getMove()
        {
            StringBuilder turnMessage = new StringBuilder();
            turnMessage.Append(m_CurrentGame.CurrentPlayer.Name);
            turnMessage.Append("'s Turn ");
            turnMessage.Append(m_CurrentGame.LastPlayer.Side == ePlayerSide.Down ? "(X):" : "(O):");
            string move = Console.ReadLine();
            while(!InputValidator.IsMoveSyntaxValid(move, m_CurrentGame.Board.Size))
            {
                Console.WriteLine("Invalid move format, try again: ");
                move = Console.ReadLine();
            }


            return move;
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

        // Prints the game's board in it's current state
        private void printBoard()
        {
            // TODO
        }

        public void printLastTurnMessage()
        {
            StringBuilder lastTurnMessage = new StringBuilder(m_CurrentGame.LastPlayer);
            lastTurnMessage.Append("'s move was ");
            lastTurnMessage.Append(m_CurrentGame.LastPlayer.Side == ePlayerSide.Down ? "(X):" : "(O):");
            lastTurnMessage.Append(m_CurrentGame.LastPlayer.LastTurn);
            Console.WriteLine(lastTurnMessage);
        }

        // Private Methods
        // Returns a valid name from user input
        private string getNameFromUser()
        {
            Console.WriteLine("Enter player name: ");
            string name = Console.ReadLine();
            while (!InputValidator.IsNameValid(name))
            {
                Console.WriteLine("Name must be up to 20 chars and without spaces.");
                Console.WriteLine("Enter player name: ");
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
                Console.WriteLine("Invalid size, enter a 6 or 8 or 10: ");
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
                Console.WriteLine("Invalid choice, enter 1 or 2: ");
                choiceString = Console.ReadLine();
            }

            if(choiceString == "1")
            {
                choice = true;
            }

            return choice;
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