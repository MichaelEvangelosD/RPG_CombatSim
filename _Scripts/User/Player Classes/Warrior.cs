using RPG.Utils;

namespace RPG.User
{
    sealed class Warrior : Player
    {
        public Warrior(PlayerClass playerClass, string name) : base(playerClass: playerClass, name: name) { }

        /// <summary>
        /// Calculate the damage based on the defenders DR, then apply it to his health
        /// </summary>
        /// <param name="defender"></param>
        /// <returns></returns>
        public override int Attack(Player defender)
        {
            int damage = CalculateDamage(defender.DefenceRating);

            defender.Health -= damage;

            //return the damage value for printing
            return damage;
        }

        /// <summary>
        /// <para>Generate a random damage value based on the predefined formula</para>
        /// <para>r1 and r2, random numbers in [0,1]</para>
        /// <para>a = AttackPower * r 1</para>
        /// <para>d = 1 – (DefenceRating* r 2 )</para>
        /// <para>damage = a* d</para>
        /// </summary>
        /// <param name="defenderDR">the defenders Damage Rating</param>
        /// <returns>The damage value</returns>
        protected override int CalculateDamage(double defenderDR)
        {
            float r1, r2;
            r1 = (float)Utilities.RandomGenerator(1);
            r2 = (float)Utilities.RandomGenerator(1);

            float attack, damage, defence;

            attack = this.AttackPower * r1;
            defence = 1 - ((float)defenderDR * r2);

            damage = attack * defence;

            return (int)damage;
        }
    }
}
