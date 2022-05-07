using System;
using System.Collections.Generic;
using System.Text;

namespace DurakGame
{
    class CardPair
    {
        public Card UnderCard;
        public Card UpCard;

        public CardPair()
        {
            UnderCard = null;
            UpCard = null;
        }
        public CardPair(Card c1)
        {
            UnderCard = c1;
            UpCard = null;
        }
        public CardPair(Card c1, Card c2)
        {
            UnderCard = c1;
            UpCard = c2;
        }
        public override string ToString()
        {
            if (UpCard == null)
            {
                return UnderCard.ToString();
            }
            return $"{UnderCard}<{UpCard}";
        }
    }
}
