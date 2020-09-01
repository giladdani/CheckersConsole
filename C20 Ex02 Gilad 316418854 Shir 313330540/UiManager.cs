using System;
using System.Text;

namespace C20_Ex02_Gilad_316418854_Shir_313330540
{
    public class UiManager
    {
        // Private Members
        private Game m_CurrentGame;

        // Public Methods
        public void InitGame()
        {
            string playerOneName = getNameFromUser();
            int boardSize = getBoardSizeFromUser();
            eGameTypes gameType = getGameTypeFromUser();
            if(gameType == eGameTypes.OnePlayer)
            {
                m_CurrentGame = new Game(playerOneName, boardSize, gameType);
            }
            else
            {
                string playerTwoName = getNameFromUser();
                m_CurrentGame = new Game(playerOneName, playerTwoName, boardSize, gameType);
            }
        }

        public void StartGame()
        {
            string move;
            m_CurrentGame.Board.Build();
            m_CurrentGame.TurnCount = 1;
            while(m_CurrentGame.IsOver)
            {
                Ex02.ConsoleUtils.Screen.Clear();
                printBoard();
                move = getMove();
                m_CurrentGame.PlayNextTurn(move);
                m_CurrentGame.TurnCount++;
            }
            // get winner/tie from game
            printScoreboard();
            if(askNextGame() == true)
            {
                StartGame();
            }
            else
            {
                // announce final scores
            }
        }

        // Private Methods
        private void printCurrentPlayerTurnMessage()
        {
            StringBuilder turnMessage = new StringBuilder();
            turnMessage.Append(m_CurrentGame.CurrentPlayer.Name);
            turnMessage.Append("'s Turn ");
            turnMessage.Append(m_CurrentGame.LastPlayer.Side == ePlayerSide.Down ? "(X):" : "(O):");
        }

        // Gets a move from the user
        private string getMove()
        {
            bool isQuitting = false;
            printCurrentPlayerTurnMessage();
            string move = Console.ReadLine();
            if(move == "Q")
            {
                isQuitting = true;
            }
            else
            {

            }

            return move;
        }

        private bool askNextGame()
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

        // Returns a valid Game type from user input
        private eGameTypes getGameTypeFromUser()
        {
            Console.WriteLine("Enter 1 for versus AI or 2 for two players: ");
            string choiceString = Console.ReadLine();
            while(!InputValidator.IsValidGameType(choiceString))
            {
                Console.WriteLine("Invalid choice, enter 1 or 2: ");
                choiceString = Console.ReadLine();
            }

            return ((eGameTypes)choiceString[0]);
        }

        // Properties
        public Game Game
        {
            get
            {
                return m_CurrentGame;
            }
        }
    }
}