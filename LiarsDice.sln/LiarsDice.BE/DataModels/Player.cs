
using LiarsDice.BE.Interfaces;
using LiarsDice.FE;
using System.Collections.Generic;

namespace LiarsDice.BE.DataModels
{
    public sealed class Player : Stats
    {
        #region Constructor
        public Player() : this("genericName")
        {
        }
        public Player(string name) : this(name, 6)
        {
            Name = name;
        }
        public Player(string name, int numberOfDice) : this(name, numberOfDice, 6)
        {
            Name = name;
            DieCount = numberOfDice;
        }
        public Player(string name, int numberOfDice, int maxDie)
        {
            Dice = new List<Die>();
            Score = 0;
            StatLog = new int[maxDie];
            DieCount = numberOfDice;
            Name = name;
            MaxDie = maxDie;
        }
        public Player(PlayerFE player)
        {
            Consumes(player);
        }
        #endregion
        #region DataProps
        public int PK { get; set; }
        #endregion
        #region Props
        public List<Die> Dice { get; set; }
        public string Name { get; set; }
        public int DieCount { get; set; }
        public int Score { get; set; }
        public int MaxDie { get; set; }
        public int[] Bet = new int[2];
        public int[] StatLog;
        #endregion
        #region Functions
        public void Consumes(PlayerFE play)
        {
            Name = play.Name;
            DieCount = play.DieCount;
            Score = play.Score;
            MaxDie = play.MaxDie;
            Bet = play.Bet;
            StatLog = play.StatLog;
            Dice = new List<Die>();
            for(int n = 0; n < play.Dice.Count; n++)
            {
                Dice.Add(new Die(play.Dice[n]));
            }
        }
        public PlayerFE Produces()
        {
            PlayerFE returnable = new PlayerFE();
            returnable.Name = Name;
            returnable.DieCount = DieCount;
            returnable.Score = Score;
            returnable.MaxDie = MaxDie;
            returnable.Bet = Bet;
            returnable.StatLog = StatLog;
            for (int n = 0; n < Dice.Count; n++)
            {
                returnable.Dice.Add(Dice[n].Produces());
            }
            return returnable;
        }
        public void RollDice()
        {
            int n = 0;
            do
            {
                var die = new Die(MaxDie); 
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
