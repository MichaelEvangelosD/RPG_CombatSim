using System;
using RPG.Utils;
using RPG.UserInterface;

namespace RPG.User
{
    public enum PlayerClass
    {
        Warrior,
        Mage,
        Rogue,
    }

    public enum PlayerState
    {
        Dead,
        Alive,
    }

    public abstract class Player
    {
        public string name;
        private int health;
        private int attackPower;
        private double defenceRating;

        private PlayerClass playerClass;
        private PlayerState playerState;

        public int Health
        {
            get { return this.health; }
            set
            {
                this.health = value;

                if (this.health <= 0)
                {
                    this.playerState = PlayerState.Dead;

                    this.health = 0; //Zero the value so it is not printed as a negative
                }
            }
        }

        public int AttackPower { get { return this.attackPower; } set { this.attackPower = value; } }

        public double DefenceRating { get { return this.defenceRating; } set { this.defenceRating = value; } }

        public Player(PlayerClass playerClass, string name)
        {
            this.name = name;
            this.playerClass = playerClass;
            this.playerState = PlayerState.Alive;

            InitializeAttributes();
        }

        /// <summary>
        /// Initializes the player stats with randomized values
        /// </summary>
        private void InitializeAttributes()
        {
            RandomizeHealth();
            RandomizeAttackPower();
            RandomizeDefenceRating();
        }

        private void RandomizeHealth()
        {
            this.health = Utilities.RandomGenerator(PlayerStatics.MIN_HEALTH, PlayerStatics.MAX_HEALTH);
        }

        private void RandomizeAttackPower()
        {
            this.attackPower = Utilities.RandomGenerator(PlayerStatics.MIN_AP, PlayerStatics.MAX_AP);
        }

        private void RandomizeDefenceRating()
        {
            double tempValue = Utilities.RandomGenerator(PlayerStatics.MAX_DR);

            if (tempValue < PlayerStatics.MIN_DR)
            {
                tempValue = PlayerStatics.MIN_DR;
            }

            this.defenceRating = tempValue;
        }

        public abstract int Attack(Player defender);

        protected abstract int CalculateDamage(double defenderDR);

        public bool IsDead()
        {
            if (this.playerState == PlayerState.Dead)
            {
                Utilities.SetForegroundColor(ConsoleColor.Red);
                Utilities.Print($"Player {this.name} fell in battle\n");
                Utilities.ResetConsoleColor();

                return true;
            }
            else
            {
                return false;
            }
        }

        public void PrintPlayerHealth()
        {
            int tempInt;
            string tempStr = UI.UI_GetPlayerHealth(this.health, out tempInt);

            if (tempInt >= 75)
            {
                Utilities.Print("Health: ");
                Utilities.SetForegroundColor(ConsoleColor.DarkGreen);
                Utilities.SetBackgroundColor(ConsoleColor.DarkGreen);
                Utilities.Print(tempStr + "\n");
                Utilities.ResetConsoleColor();
            }
            else if (tempInt <= 74 && tempInt > 30)
            {
                Utilities.Print("Health: ");
                Utilities.SetForegroundColor(ConsoleColor.DarkYellow);
                Utilities.SetBackgroundColor(ConsoleColor.DarkYellow);
                Utilities.Print(tempStr + "\n");
                Utilities.ResetConsoleColor();
            }
            else
            {
                Utilities.Print("Health: ");
                Utilities.SetForegroundColor(ConsoleColor.DarkRed);
                Utilities.SetBackgroundColor(ConsoleColor.DarkRed);
                Utilities.Print(tempStr + "\n");
                Utilities.ResetConsoleColor();
            }
        }

        /// <summary>
        /// Returns all the info of the current player object
        /// </summary>
        public override string ToString()
        {
            string tempDR = string.Format("{0:00}", (this.defenceRating * 100));

            string playerInfo = $"Player name:{this.name} Player state:{this.playerState}\n" +
                $"\tArmor: {tempDR}\tAttack Power: {this.attackPower}\n" +
                $"\tPlayer class: {this.playerClass}";

            return playerInfo;
        }
    }
}
