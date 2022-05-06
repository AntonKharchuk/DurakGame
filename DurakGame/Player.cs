using System;
using System.Collections.Generic;
using System.Text;

namespace DurakGame
{
    class Player
    {
        public List<Card> PlayerCards;

        public Player()
        {
            PlayerCards = new List<Card> { };
        }

        public void TakeCard(Card card)
        {
            PlayerCards.Add(card);
        }
     

        public override string ToString()
        {
            string res = "";
            foreach (var item in PlayerCards)
            {
                res += item + " ";
            }
            return res;
        }
    }
}
