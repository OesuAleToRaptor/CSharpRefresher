using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas
{
    class Runner
    {
        //Constants
        private const string WELCOME_MSG = "Welcome to KATA Chooser!";
        private const string INPUT_CHAR_ERR_MSG = "Please use numeric input to choose the kata";
        private const string INPUT_OUT_OF_BOUNDS_MSG = "Number too high, please choose one of the displayed numbers";
        private const string INPUT_ZERO_MSG = "Wow, you're so funny. Try again.";

        //Fields
        private static Dictionary<int, string> globalKataDictionary { get; set; }

        //Methods
        #region
        static void Main(string[] args)
        {
            Console.WriteLine(WELCOME_MSG);
            buildKatas();
            displayKatas();

            readUserInputRecursively();
        }

        private static void buildKatas()
        {
            //Let's imagine it retrieves the dictionary from a DB via DAO
            Dictionary<int, string> kataRoster = new Dictionary<int, string>();
            kataRoster.Add(1, "Isogram");
            kataRoster.Add(2, "Fibonacci");
            kataRoster.Add(3, "Exit");
            globalKataDictionary = kataRoster;
        }

        private static void displayKatas()
        {
            foreach (KeyValuePair<int, string> kataDictionaryEntry in globalKataDictionary)
            {
                string consoleEntry = kataDictionaryEntry.Key + ". " + kataDictionaryEntry.Value;
                Console.WriteLine(consoleEntry);
            }
            //Empty line as console formatting buffer
            Console.WriteLine();
        }

        private static void readUserInputRecursively()
        {
            //Read input without echoing
            char userInput = Console.ReadKey(true).KeyChar;
            processUserInput(userInput);
        }

        private static void processUserInput(char userInput)
        {
            if (Char.IsDigit(userInput))
            {
                handleDigitInput(userInput);
            }
            else
            {
                //Input is not a digit
                handleInvalidInput(INPUT_CHAR_ERR_MSG);
            }
        }

        private static void handleDigitInput(char userInput)
        {
            int inputDigit = int.Parse(userInput.ToString());
            if (inputDigit > globalKataDictionary.Count)
            {
                //Input out of bounds
                handleInvalidInput(INPUT_OUT_OF_BOUNDS_MSG);
            }
            else if (inputDigit == 0)
            {
                //Input is zero
                handleInvalidInput(INPUT_ZERO_MSG);
            }
            chooseKataToDisplay(inputDigit);
        }

        private static void handleInvalidInput(string err_msg)
        {
            Console.WriteLine(err_msg);
            displayKatas();
            //Reading input via recursion
            readUserInputRecursively();
        }

        private static void chooseKataToDisplay(int inputDigit)
        {
            switch (inputDigit)
            {
                case 1:
                    Console.WriteLine("Kata chosen");
                    Isogram isogram = new Isogram();    
                    isogram.execute();
                    break;
                case 2:
                    //executeFibonacci();
                    break;
                case 3:
                    //Exit application
                    return;
                default:
                    //Protected from happening in input processing
                    break;
            }
        }
        #endregion
    }
}
