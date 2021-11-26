using System;
using System.Collections.Generic;
using RPG.User;
using RPG.Utils;

namespace RPG.Core
{
    class RoundSystem
    {
        /// <summary>
        /// The battle loop of the game
        /// <para>Keeps track of the round number</para>
        /// <para>In every round it determines a random attacker based on index</para>
        /// <para>When one of the players dies, the loop breaks and goes back to the main menu screen</para>
        /// </summary>
        public void PlayRound(List<Player> playerList)
        {
            Utilities.PrintSeparatorLines();
            Utilities.Print("\tBattle started!");
            Utilities.PrintSeparatorLines();

            float diceValue;
            int damage, roundNum = 1;

            while (true)
            {
                Utilities.SetForegroundColor(ConsoleColor.Magenta);
                Utilities.Print($"\tRound {roundNum}\n");
                Utilities.ResetConsoleColor();

                diceValue = RollDice();

                if (diceValue < 0.45f)
                {
                    damage = playerList[0].Attack(playerList[1]);
                    Utilities.SetForegroundColor(ConsoleColor.Cyan);
                    Utilities.Print($"Player {playerList[0].name} attacked {playerList[1].name} for {damage} points.\n");
                    Utilities.ResetConsoleColor();

                    BattleSystem.S.PrintPlayerInfo();

                    if (playerList[1].IsDead()) //Checks if the defender is dead AFTER the attack
                    {
                        Console.Beep();
                        break;
                    }
                }
                else
                {
                    damage = playerList[1].Attack(playerList[0]);
                    Utilities.SetForegroundColor(ConsoleColor.Cyan);
                    Utilities.Print($"Player {playerList[1].name} attacked {playerList[0].name} for {damage} points.\n");
                    Utilities.ResetConsoleColor();

                    BattleSystem.S.PrintPlayerInfo();

                    if (playerList[0].IsDead())
                    {
                        Console.Beep();
                        break;
                    }
                }

                //Waits for Enter to be pressed
                while (!Utilities.WaitForEnter()) ;

                Utilities.PrintSeparatorLines();

                roundNum++;
            }
        }

        /// <summary>
        /// Randomly generates a value between 0f-1f
        /// </summary>
        /// <returns>A random value between 0f-1f</returns>
        private float RollDice()
        {
            float dice = (float)Utilities.RandomGenerator(1);
            return dice;
        }
    }
}
