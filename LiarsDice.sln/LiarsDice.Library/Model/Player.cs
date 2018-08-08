using System;
using System.Collections.Generic;
using System.Text;

namespace LiarsDice.Library.Model
{
    public class Player
    {
        public Player() : this("genericName")
        {  
        }
        public Player(string n) : this(n, 6)
        {
            name = n;
        }
        public Player(string n, int d)
        {
            name = n;
            DieCount = d;
            Dice = new List<Die>();
            MaxDie = 6;
        }

        private string name;
        public string Name
        {
            get { return name;}
        }
        public int DieCount;
        public int MaxDie;
        public List<Die> Dice;

        private Bet bet;
        public Bet Bet
        {
            get {return bet;}
        }

        public void RollDice() //populates dice of digits = MaxDie
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

        public void PlaceBet(int w, int d) //must have populated dice before use
        {
            if (d >= Dice[0].MaxDigit)
            {
                d = 1;
            }
            bet = new Bet(w,d);
        }
    }
}
