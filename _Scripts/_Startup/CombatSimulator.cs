using System;
using RPG.Managers;
using RPG.Utils;
using RPG.UserInterface;

namespace RPG.Startup
{
    class CombatSimulator
    {
        /// <summary>
        /// Entry point of the whole program
        /// </summary>
        static void Main(string[] args)
        {
            Awake();
            Start();
        }

        /// <summary>
        /// Called at the start of the program
        /// </summary>
        private static void Awake()
        {
            Utilities.SetForegroundColor(ConsoleColor.Cyan);
            Utilities.Print("Welcome to RPG Combat Simulator v1.0" +
                "\n\t by M.E. Diamantis");
            Utilities.ResetConsoleColor();
            Utilities.PrintSeparatorLines();
        }

        /// <summary>
        /// Called after Awake to start the Main Menu Sequence
        /// </summary>
        private static void Start()
        {
            MenuManager.S.DisplayMenu();
        }
    }
}
