using LiarsDice.Data.DataModels;
using LiarsDice.Library.Interfaces;
using System.Collections.Generic;

namespace LiarsDice.Library.Model
{
    public class Player : PlayerDB, Stats
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
        #endregion

        #region Props
        new public List<Die> Dice;
        protected int[] StatLog;

        #endregion

        #region Functions
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
                //should be an error tossed here
            }
            Bet[0] = w;
            Bet[1] = d;
           
        }
        public Player DeepCopy()
        {
            Player copy = new Player();
            copy.Bet = this.Bet;
            copy.Dice = this.Dice; 
            copy.DieCount = this.DieCount;
            copy.MaxDie = this.MaxDie;
            copy.Name = this.Name;
            //copy.PK = this.PK;
            copy.Score = this.Score;
            copy.StatLog = this.StatLog;
            return copy;
        }

        #region Stats
        public string ReturnInfo()
        {
            CalculateStats();
            string returnable =  Name + " has: ";
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
