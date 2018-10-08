using LiarsDice.Data.DataModels;
using LiarsDice.Library.Interfaces;
using System;
using System.Collections.Generic;

namespace LiarsDice.Library.Model
{
    public class Game : GameDB, Stats
    {
        #region Constructor
        public Game() : this(6)
        {
        }
        public Game(int nod) :this(nod, 6)
        {
            numberOfDicePerPlayerAtStart = nod;
        }
        public Game(int nod, int mdv)
        {
            maxDieValue = mdv;
            StatLog = new int[mdv];
            SafeNumber = 0.00F;
            Competitors = new List<Player>();
            numberOfDicePerPlayerAtStart = nod;
        }
        #endregion

        #region Props
        new public List<Player> Competitors;
        #endregion

        #region Functions
        public void AddPlayer(Player player)
        {
            this.Competitors.Add(player);
        }
        public void RemovePlayer(Player player)
        {
            this.Competitors.Remove(player);
        }
        public void CalcSafeNum()
        {
            if(maxDieValue == 2)
            {
                SafeNumber = ActiveDie / (float)2;
            } else
            {
                SafeNumber = ActiveDie * ((float)2 / (float)maxDieValue);
            }
        }
        public void RollSequence()
        {
            foreach(Player player in Competitors)
            {
                player.RollDice();
            }
        }
        public Player CreatePlayer(string name)
        {
            Player player = new Player(name, numberOfDicePerPlayerAtStart, maxDieValue);
            return player;
        }
        public Game DeepCopy()
        {
            var copy = new Game();
            copy.ActiveDie = this.ActiveDie;
            copy.Competitors = this.Competitors;
            copy.maxDieValue = this.maxDieValue;
            copy.numberOfDicePerPlayerAtStart = this.numberOfDicePerPlayerAtStart;
            copy.SafeNumber = this.SafeNumber;
            copy.StatLog = this.StatLog;
            return copy;
        }
     
        #region Stats
        public void CalculateStats()
        {
            ZeroStat();
            int numOfDieInPlay = 0;
            foreach (Player player in Competitors)
            {
                foreach (Die die in player.Dice)
                {
                    StatLog[die.Value - 1] += 1;
                    numOfDieInPlay++;
                }
            }
            ActiveDie = numOfDieInPlay;
            CalcSafeNum();
        }
        public void ZeroStat()
        {
            for (int n = 0; n < StatLog.Length; n++)
            {
                StatLog[n] = 0;
            }
        }
        public string ReturnInfo()
        {
            string returnable = "All Dice: ";
            int value = 1;
            foreach (int n in StatLog)
            {
                returnable = returnable + n + " " + value + "'s,  ";
                value++;
            }
            return returnable;
        }
        public string ReturnInfo(String ProbablyTheMostMemeTrollEver)
        {
            string returnable = "";
            foreach (Player P in Competitors)
            {
                returnable = returnable + P.ReturnInfo();
                returnable = returnable + "\r\n";
            }
            return returnable;
        }
        #endregion

        #endregion
    }
}
