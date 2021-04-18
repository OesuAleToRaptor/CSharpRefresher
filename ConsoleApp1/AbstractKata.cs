using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Katas.Runner;

namespace Katas
{
    abstract class AbstractKata
    {
        private const string EXIT_QUESTION = "Are you satisfied with the result? Press Y to exit the program. Press N to return to the menu." 
            + "\nPress any other key to restart the kata";
        private const string RETURN_MSG = "\nReturning to main menu";
        private const char EXIT_CHAR = 'y';
        private const char RETURN_CHAR = 'n';
        //Abstract methods
        public abstract void PerformKata(string userInput);
        public abstract void DisplayWelcomeMessage();

        //Implemented methods
        #region
        public void Execute()
        {
            bool readyToExit = false;
            while (!readyToExit)
            {
                DisplayWelcomeMessage();
                string userInputString = ReadUserInputString();
                PerformKata(userInputString);

                //Kata finished
                DisplayExitQuestion();
                char exitKey = ReadUserInputKeyForExit();
                if (exitKey == RETURN_CHAR) ReturnToMainMenu();
                readyToExit = (exitKey == EXIT_CHAR) ? true : false;
            }
            
        }

        private static void ReturnToMainMenu()
        {
            Console.WriteLine(RETURN_MSG);
            InitMainMenu();
        }

        public string ReadUserInputString()
        {
            //Read input
            string userInput = Console.ReadLine();
            return userInput;
        }

        public char ReadUserInputKeyForExit()
        {
            //Read input without echoing
            return Char.ToLower(Console.ReadKey(true).KeyChar);
        }

        public void DisplayExitQuestion() {
            Console.WriteLine(EXIT_QUESTION);
        }
        #endregion
    }
}
