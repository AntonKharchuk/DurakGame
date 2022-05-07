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

        public Card PutCard(int index)
        {
            if (index<PlayerCards.Count && index>=0)
            {
                Card card = PlayerCards[index];
                PlayerCards.RemoveAt(index);
                return card;
            }
            else
            {
                throw new Exception("out of range");
            }
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
