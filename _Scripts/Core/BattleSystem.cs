using System;
using System.Collections.Generic;
using RPG.User;
using RPG.Utils;

namespace RPG.Core
{
    class BattleSystem
    {
        private readonly int numberOfPlayers = 2; //used for future expansion
        private readonly List<Player> playerList = new List<Player>();
        private readonly RoundSystem roundManager = new RoundSystem();

        //Singleton - not threadsafe
        private static BattleSystem _s = null;
        public static BattleSystem S
        {
            get
            {
                if (_s == null)
                    _s = new BattleSystem();

                return _s;
            }
        }

        /// <summary>
        /// Called when the user types 1 in the main menu
        /// <para>Calls CreatePlayers() to create the players</para>
        /// <para>Calls PrintPlayerInfo() to print all the player info</para>
        /// <para>Calls Update() to start the battle loop</para>
        /// <para>After the battle is finished, calls ClearList() to clear the list of players</para>
        /// </summary>
        public void StartBattle()
        {
            SetBattleData();
            PrintPlayerInfo();

            Utilities.Print("Press any key to continue...");
            Console.ReadKey();

            roundManager.PlayRound(playerList);

            //After the battle has ended
            ClearList(playerList);
        }

        /// <summary>
        /// Sets the PlayersStatics to default values
        /// <para>Also, it starts the player creation sequence</para>
        /// </summary>
        private void SetBattleData()
        {
            SetPlayerStatics();
            CreatePlayers(numberOfPlayers);
        }

        /// <summary>
        /// Sets the min and max values for the whole player class
        /// </summary>
        private void SetPlayerStatics()
        {
            PlayerStatics.MIN_HEALTH = 800;
            PlayerStatics.MAX_HEALTH = 1001;

            PlayerStatics.MIN_AP = 100;
            PlayerStatics.MAX_AP = 301;

            PlayerStatics.MIN_DR = 0.25f;
            PlayerStatics.MAX_DR = 1f;
        }

        /// <summary>
        /// Creates X number of players based on numberOfPlayers
        /// First asks for the name then creates and adds the player to the list
        /// </summary>
        /// <param name="numberOfPlayers"></param>
        private void CreatePlayers(int numberOfPlayers)
        {
            string playerName;
            Utilities.SetForegroundColor(ConsoleColor.Yellow);
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Utilities.Print($"What's the name of the {i + 1} player?");
                playerName = Console.ReadLine();
                Player newPlayer = new Warrior(playerClass: PlayerClass.Warrior, name: playerName);

                playerList.Add(newPlayer);
            }

            Utilities.PrintSeparatorLines();
            Utilities.Print("\tCreating Players\n");
            Utilities.ResetConsoleColor();

            foreach (Player player in playerList)
            {
                Utilities.SetForegroundColor(ConsoleColor.Cyan);
                Utilities.Print($"Player {player.name} was created");
            }
            Utilities.ResetConsoleColor();

            Utilities.PrintSeparatorLines();
        }


        /// <summary>
        /// Prints every attribute, including the name, of the objs inside playerList
        /// </summary>
        public void PrintPlayerInfo()
        {
            string playerInfo;
            Utilities.SetForegroundColor(ConsoleColor.Yellow);
            Utilities.Print("\tPlayer Stats\n");
            Utilities.ResetConsoleColor();

            foreach (Player player in this.playerList)
            {
                playerInfo = player.ToString();
                Utilities.Print(playerInfo);
                player.PrintPlayerHealth();
            }
        }

        /// <summary>
        /// Clears the passed list
        /// </summary>
        /// <param name="list">The list of Players to clear</param>
        private static void ClearList(List<Player> list)
        {
            list.Clear();
        }
    }
}
