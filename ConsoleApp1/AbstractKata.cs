using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas
{
    abstract class AbstractKata
    {
        private const string EXT_QUESTION = "Are you satisfied with the result? If so, press Y to exit the program";
        private const char EXT_CHAR = 'y';
        //Abstract methods
        public abstract void performKata(string userInput);
        public abstract void displayWelcomeMessage();

        //Implemented methods
        #region
        public void execute()
        {
            bool readyToExit = false;
            while (!readyToExit)
            {
                displayWelcomeMessage();
                string userInputString = readUserInputString();
                performKata(userInputString);

                displayExitQuestion();
                char exitKey = readUserInputKeyForExit();
                readyToExit = (exitKey == EXT_CHAR) ? true : false;
            }
        }

        public string readUserInputString()
        {
            //Read input
            string userInput = Console.ReadLine();
            return userInput;
        }

        public char readUserInputKeyForExit()
        {
            //Read input without echoing
            return Console.ReadKey(true).KeyChar;
        }

        public void displayExitQuestion() {
            Console.WriteLine(EXT_QUESTION);
        }
        #endregion
    }
}
