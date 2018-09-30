using LiarsDice.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiarsDice.Library.Model
{
    public class Game : Stats
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
            safeNumber = 0.00F;
            competitors = new List<Player>();
            numberOfDicePerPlayerAtStart = nod;
        }
        #endregion

        #region Props
        private List<Player> competitors;
        public List<Player> Competitors { get {
                return competitors;
            }}
        private int activeDie;
        public int ActiveDie { get { return activeDie; }}
        readonly int maxDieValue;
        readonly int numberOfDicePerPlayerAtStart;
        private int[] StatLog;
        private float safeNumber;
        public float SafeNumber {get{ return safeNumber; }}
       
        #endregion

        #region Functions
        public void AddPlayer(Player player)
        {
            this.competitors.Add(player);
        }
        public void RemovePlayer(Player player)
        {
            this.competitors.Remove(player);
        }
        public void CalcSafeNum()
        {
            if(maxDieValue == 2)
            {
                safeNumber = activeDie / (float)2;
            } else
            {
                safeNumber = activeDie * ((float)2 / (float)maxDieValue);
            }
        }
        public void RollSequence()
        {
            foreach(Player player in competitors)
            {
                player.RollDice();
            }
        }
        public Player CreatePlayer(string name)
        {
            Player player = new Player(name, numberOfDicePerPlayerAtStart, maxDieValue);
            return player;
        }

        #region Stats
        public void CalculateStats()
        {
            ZeroStat();
            int numOfDieInPlay = 0;
            foreach (Player player in competitors)
            {
                foreach (Die die in player.Dice)
                {
                    StatLog[die.Value - 1] += 1;
                    numOfDieInPlay++;
                }
            }
            activeDie = numOfDieInPlay;
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
            foreach (Player P in competitors)
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
