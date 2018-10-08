using LiarsDice.FE;

namespace LiarsDice.BE.DataModels
{
    public sealed class Player : PlayerFE
    {
        #region Constructor

        #endregion
        #region DataProps
        public int PK { get; set; }
        #endregion
        #region Functions
        public void RollDice()
        {
            int n = 0;
            do
            {
                var die = new Die(MaxDie);/////////////////////////////////////////////////////////////////
                die.Roll();
                Dice.Add(die);
                n++;
            } while (n < DieCount);
        }
        public void PlaceBet(int w, int d)
        {
            if (d >= Dice[0].MaxDigit)
            {
                d = 1;
            }
            Bet[0] = w;
            Bet[1] = d;
        }
        public Player DeepCopy()
        {
            Player copy = (Player)this.MemberwiseClone();
            copy.Bet = Bet; //-help
            copy.Dice = Dice; //-help
            copy.StatLog = StatLog; //-help
            return copy;
        }
        #region Stats
        public string ReturnInfo()
        {
            CalculateStats();
            string returnable = Name + " has: ";
            int value = 1;
            foreach (int n in StatLog)
            {
                returnable = returnable + n + " " + value + "'s,  ";
                value++;
            }
            return returnable;
        }
        public void CalculateStats()
        {
            ZeroStat();
            foreach (Die die in Dice)
            {
                StatLog[die.Value - 1] += 1;
            }
        }
        public void ZeroStat()
        {
            for (int n = 0; n < StatLog.Length; n++)
            {
                StatLog[n] = 0;
            }
        }
        #endregion
        #endregion
    }
}
