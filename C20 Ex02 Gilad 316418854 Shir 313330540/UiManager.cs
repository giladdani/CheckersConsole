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
            m_CurrentGame.Board.Build();
            m_CurrentGame.TurnCount = 1;
            while(m_CurrentGame.IsOver)
            {
                Ex02.ConsoleUtils.Screen.Clear();
                printBoard();
                m_CurrentGame.PlayNextTurn();
                m_CurrentGame.TurnCount++;
            }
            // get winner/tie from game
            printScoreboard();
            // ask for new round- if yes then call StartGame()
        }

        // Prints the game's board in it's current state
        private void printBoard()
        {
            
        }

        public void printLastTurn()
        {
            StringBuilder lastTurnMessage = new StringBuilder(m_CurrentGame.LastPlayer);
            lastTurnMessage.Append("'s move was ");
            if(m_CurrentGame.LastPlayer.Side == 1)      // todo fix this forsaken garbage of code
            {
                lastTurnMessage.Append("(X):");
            }
            else
            {
                lastTurnMessage.Append("(O):");
            }
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