using System;

namespace RPG.Utils
{
    class Utilities
    {
        /// <summary>
        /// Prints the message in the console
        /// </summary>
        /// <param name="message">The message to print</param>
        public static void Print(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Continuously prompt the user to press ENTER, the loop breaks ONLY when the user presses ENTER
        /// </summary>
        /// <returns>True is ENTER was pressed, false if any other key was pressed</returns>
        public static bool WaitForEnter()
        {
            ConsoleKeyInfo ckInfo;
            while (true)
            {
                Console.WriteLine("Press ENTER to continue.");
                ckInfo = Console.ReadKey(false);

                if (ckInfo.Key == ConsoleKey.Enter)
                {
                    //Continue to the next round
                    Utilities.PrintSeparatorLines();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// rounds the value to a 0-100 range
        /// </summary>
        /// <param name="value"></param>
        /// <returns>an int value around 0-100 range</returns>
        public static int GetPercentage(int value)
        {
            float tempFl = value / 10;
            return (int)tempFl;
        }

        public static int RandomGenerator(int min, int max)
        {
            Random randomizer = new Random((int)DateTime.Now.Ticks); //create the randomizer with DateTime to always have a new seed
            int randomValue = randomizer.Next(min, max);

            return randomValue;
        }

        public static double RandomGenerator(float max)
        {
            Random randomizer = new Random((int)DateTime.Now.Ticks);
            double randomValue = randomizer.NextDouble() * max;

            return randomValue;
        }

        public static void SetForegroundColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public static void SetBackgroundColor(ConsoleColor color)
        {
            Console.BackgroundColor = color;
        }

        public static void ResetConsoleColor()
        {
            Console.ResetColor();
        }

        /// <summary>
        /// STYLE POINTS
        /// </summary>
        public static void PrintSeparatorLines()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }
    }
}
