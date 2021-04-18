using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas
{
    class Isogram : AbstractKata
    {
        private const string WELCOME_MSG = "Welcome to Isogram! Type in a word and press enter to check if it's an isogram";
        private const string SUCCESS_MSG = "The word you typed is an isogram!";
        private const string FAILURE_MSG = "The word you typed is NOT an isogram :(";

        //Abstract override methods
        #region
        public override void PerformKata(string userInput)
        {
            ValidateInputAsIsogram(userInput);
        }

        public override void DisplayWelcomeMessage()
        {
            Console.WriteLine(WELCOME_MSG);
        }
        #endregion

        //Own methods
        #region
        public void ValidateInputAsIsogram(string userInput)
        {
            if (IsIsogram(userInput.Trim()))
            {
                Console.WriteLine(SUCCESS_MSG);
            }
            else
            {
                Console.WriteLine(FAILURE_MSG);
            }
        }

        public static bool IsIsogram(string word)
        {
            char[] letters = word.ToLower().ToCharArray();
            Array.Sort(letters);
            bool isIsogram = true;

            //Passing arguments as reference
            LoopOverLetters(letters, ref isIsogram);

            return isIsogram;
        }

        private static void LoopOverLetters(char[] letters, ref bool isIsogram)
        {
            int index = 0;
            while (isIsogram && index < letters.Length - 1)
            {
                if (letters[index] == letters[index + 1])
                {
                    isIsogram = false;
                    break;
                }
                index++;
            }
        }
        #endregion
    }
}
