using LiarsDice.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiarsDice.Library.Model
{
    public class Player : Stats, SaveHelper
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
        public string Name;
        public int DieCount;
        public int Score;
        public int MaxDie;
        public List<Die> Dice;
        public int[] StatLog;
        private Bet bet;
        public Bet Bet
        {
            get {return bet;}
        }
        public int PrimeKey { get; set; }
        public int CaseID { get { return 3; } }
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
            }
            bet = new Bet(w,d);
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
