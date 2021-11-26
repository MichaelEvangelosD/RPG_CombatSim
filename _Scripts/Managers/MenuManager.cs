using System;
using RPG.Utils;
using RPG.Core;

namespace RPG.Managers
{
    class MenuManager
    {
        //Singleton - not threadsafe
        private static MenuManager _s = null;
        public static MenuManager S
        {
            get
            {
                if (_s == null)
                    _s = new MenuManager();

                return _s;
            }
        }

        /// <summary>
        /// Starts the Menu selection screen
        /// </summary>
        public void DisplayMenu()
        {
            string answer = "";

            while (answer != "3")
            {
                PrintMenu();

                answer = Console.ReadLine();

                SwitchOnAnswer(answer);
            }

            QuitApplication();
        }

        /// <summary>
        /// Switches on the answer the user gave and calls the corresponding methods
        /// according to the answer
        /// </summary>
        /// <param name="answer">The user input</param>
        private void SwitchOnAnswer(string answer)
        {
            switch (answer)
            {
                case "1":
                    Utilities.PrintSeparatorLines();
                    BattleSystem.S.StartBattle(); //Start the battle
                    break;
                case "2":
                    Utilities.PrintSeparatorLines();
                    PrintHelp(); //Print the info text
                    break;
                case "3":
                    //Just break the check
                    //So QuitApplication() gets called
                    break;
                default:
                    Utilities.SetForegroundColor(ConsoleColor.Red);
                    Utilities.Print("Invalid Input"); //Everything else is considered invalid
                    Utilities.ResetConsoleColor();
                    break;
            }
        }

        /// <summary>
        /// Just prints the menu in the screen
        /// </summary>
        private void PrintMenu()
        {
            Utilities.SetForegroundColor(ConsoleColor.Yellow);
            Utilities.Print("Select one of the options below\n" +
                "\t1) Start Battle\n" +
                "\t2) Help\n" +
                "\t3) Forfeit");
            Utilities.ResetConsoleColor();
        }

        /// <summary>
        /// Prints the help screen
        /// </summary>
        private static void PrintHelp()
        {
            Utilities.SetForegroundColor(ConsoleColor.Green);
            Utilities.Print("*This combat simulator project is part of the GPR4100 module of SAE Institute.\n" +
                "*You can start the game by typing 1 in the Main Menu Screen\n" +
                "*You can terminate the game by typing 3 in the Main Menu screen");
            Utilities.ResetConsoleColor();

            Utilities.PrintSeparatorLines();
        }

        /// <summary>
        /// When called, waits for user input to terminate the program
        /// </summary>
        private void QuitApplication()
        {
            Utilities.SetForegroundColor(ConsoleColor.Red);
            Utilities.Print("Press any key to terminate the program...");
            Console.ReadKey();
            Utilities.ResetConsoleColor();
            Environment.Exit(0);
        }
    }
}
