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
        }

        private string name;
        public string Name
        {
            get { return name;}
        }
        public int DieCount;
        public List<Die> Dice;

        public void RollDice()
        {
            int n = 0;
            do
            {
                var die = new Die();
                die.Roll();
                Dice.Add(die);
                n++;
            } while (n < DieCount);
        }
    }
}
