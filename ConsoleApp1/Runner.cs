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
            InitMainMenu();
        }

        public static void InitMainMenu()
        {
            BuildKatas();
            DisplayKatas();
            ReadUserInputRecursively();
        }

        private static void BuildKatas()
        {
            //Let's imagine it retrieves the dictionary from a DB via DAO
            Dictionary<int, string> kataRoster = new Dictionary<int, string>
            {
                { 1, "Isogram" },
                { 2, "Fibonacci" },
                { 3, "Exit" }
            };
            globalKataDictionary = kataRoster;
        }

        private static void DisplayKatas()
        {
            foreach (KeyValuePair<int, string> kataDictionaryEntry in globalKataDictionary)
            {
                string consoleEntry = kataDictionaryEntry.Key + ". " + kataDictionaryEntry.Value;
                Console.WriteLine(consoleEntry);
            }
            //Empty line as console formatting buffer
            Console.WriteLine();
        }

        private static void ReadUserInputRecursively()
        {
            //Read input without echoing
            char userInput = Console.ReadKey(true).KeyChar;
            ProcessUserInput(userInput);
        }

        private static void ProcessUserInput(char userInput)
        {
            if (Char.IsDigit(userInput))
            {
                HandleDigitInput(userInput);
            }
            else
            {
                //Input is not a digit
                HandleInvalidInput(INPUT_CHAR_ERR_MSG);
            }
        }

        private static void HandleDigitInput(char userInput)
        {
            int inputDigit = int.Parse(userInput.ToString());
            if (inputDigit > globalKataDictionary.Count)
            {
                //Input out of bounds
                HandleInvalidInput(INPUT_OUT_OF_BOUNDS_MSG);
            }
            else if (inputDigit == 0)
            {
                //Input is zero
                HandleInvalidInput(INPUT_ZERO_MSG);
            }
            ChooseKataToDisplay(inputDigit);
        }

        private static void HandleInvalidInput(string err_msg)
        {
            Console.WriteLine(err_msg);
            DisplayKatas();
            //Reading input via recursion
            ReadUserInputRecursively();
        }

        private static void ChooseKataToDisplay(int inputDigit)
        {
            switch (inputDigit)
            {
                case 1:
                    Console.WriteLine("Kata chosen");
                    Isogram isogram = new Isogram();    
                    isogram.Execute();
                    break;
                case 2:
                    Fibonacci fibonacci = new Fibonacci();
                    fibonacci.Execute();
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
