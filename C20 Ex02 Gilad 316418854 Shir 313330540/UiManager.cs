using System;

namespace C20_Ex02_Gilad_316418854_Shir_313330540
{
    public class UiManager
    {
        // Private Members
        private Game m_Game;

        // Constructor
        public UiManager(Game i_Game)
        {
            m_Game = i_Game;      // @Eli- whats the relationship between the UI and the Game?
        }

        // Public Methods
        public void initGameSettings()
        {
            Console.WriteLine("Enter first player name: ");     // @ must we use string.Format everywhere?
            string playerOneName = Console.ReadLine();
            Console.WriteLine("enter board size");
            int boardSize = int.Parse(Console.ReadLine());
            Console.WriteLine("enter second player name: ");
            
            //board size
            //against computer?
            //if yes,finish
            //else enter second player name 
        }

        public static void SetNextTurn()
        {
            printBoard();
            if(lastMove != null)
            {
                Console.WriteLine(m_Game.CurrentPlayerName + "'s move was "+(currentGame.CurrentPlayerSymbol)+ ": " + currentGame.LastMove);   // @Eli- did you use string.Format again?
            }
            Console.WriteLine(currentGame.PlayerOneName);
            if(currentTurn %2 !=0)
                Console.WriteLine("");
        }
    }
}