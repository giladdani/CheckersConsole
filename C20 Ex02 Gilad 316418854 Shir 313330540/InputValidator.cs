using System;

namespace C20_Ex02_Gilad_316418854_Shir_313330540
{
    public class InputValidator
    {
        // Returns true if the given board size is valid
        public static bool IsBoardSizeValid(string i_BoardSizeString)
        {
            bool isValidNumber = int.TryParse(i_BoardSizeString, out int size);
            return (isValidNumber && (size == 6 || size == 8 || size == 10));
        }

        // Returns true if the given name is valid
        public static bool IsNameValid(string i_Name)
        {
            return (i_Name != null && !(i_Name.Contains(" ")) && i_Name.Length <= 20);
        }

        // Returns true if the given string represents a valid game mode choice
        public static bool IsValidGameType(string i_Choice)
        {
            bool isValidNumber = Enum.TryParse(i_Choice, out eGameTypes type);
            return (isValidNumber && (type == eGameTypes.OnePlayer || type == eGameTypes.TwoPlayers));
        }

        // Returns true if the move is valid in terms of syntax (charchar>charchar)
        public static bool IsMoveSyntaxValid(string i_Move, int i_BoardSize)
        {
            bool isSeparatorValid = true;
            bool isLettersValid = true;
            bool isLengthValid = i_Move.Length == 5;        //todo change 5 to define/const

            if(isLengthValid)
            {
                isSeparatorValid = i_Move[2] == '>';
                isLettersValid = isMoveLettersValid(i_Move, i_BoardSize);
            }

            return (isLengthValid && isSeparatorValid && isLettersValid);
        }

        // Returns true if the letters of the move are in the right format
        private static bool isMoveLettersValid(string i_Move, int i_BoardSize)
        {
            bool[] isLetterValid = { true, true, true, true };

            if(i_BoardSize == 6)
            {
                isLetterValid[0] = i_Move[0] >= 'A' && i_Move[0] <= 'F';
                isLetterValid[1] = i_Move[1] >= 'a' && i_Move[1] <= 'f';
                isLetterValid[2] = i_Move[3] >= 'A' && i_Move[3] <= 'F';
                isLetterValid[3] = i_Move[4] >= 'a' && i_Move[4] <= 'f';
            }

            if(i_BoardSize == 8)
            {
                isLetterValid[0] = i_Move[0] >= 'A' && i_Move[0] <= 'H';
                isLetterValid[1] = i_Move[1] >= 'a' && i_Move[1] <= 'h';
                isLetterValid[2] = i_Move[3] >= 'A' && i_Move[3] <= 'H';
                isLetterValid[3] = i_Move[4] >= 'a' && i_Move[4] <= 'h';
            }

            if(i_BoardSize == 10)
            {
                isLetterValid[0] = i_Move[0] >= 'A' && i_Move[0] <= 'J';
                isLetterValid[1] = i_Move[1] >= 'a' && i_Move[1] <= 'j';
                isLetterValid[2] = i_Move[3] >= 'A' && i_Move[3] <= 'J';
                isLetterValid[3] = i_Move[4] >= 'a' && i_Move[4] <= 'j';
            }

            return (isLetterValid[0] && isLetterValid[1] && isLetterValid[2] && isLetterValid[3]);
        }
    }
}
