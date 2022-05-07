using System;
using System.Collections.Generic;
using System.Text;

namespace DurakGame
{
    class Table
    {
        public CardPair[] CardPair;
        public int CardPairCounter;
         List<int> EvalubleCards;
         public int Trump { get; set; }

        public Table(int trump)
        {
            CardPair = new CardPair[6];
            CardPairCounter = 0;
    
            Trump = trump;
        }
        public void SetUnderCard(Card card)
        {
            if (EvalubleCards == null)
            {
                EvalubleCards = new List<int> {card.Num};
                CardPair[CardPairCounter] =  new CardPair(card);
                
            }
            else
            {
                if(EvalubleCards.Contains(card.Num))
                {
                    CardPair[CardPairCounter].UnderCard = new Card(card);
                }
            }
        }
        public void SetUpCard(Card card)
        {
            if (CanSet(card))
            {
                CardPair[CardPairCounter].UpCard = new Card(card);
                EvalubleCards.Add(card.Num);
            }
            else
            {
                throw new Exception("False card to set");
            }
            bool CanSet(Card cc)
            {
                if (CardPair[CardPairCounter].UnderCard == null)
                {
                    return false;
                }
                else if((card.Suit ==CardPair[CardPairCounter].UnderCard.Suit & card.Num> CardPair[CardPairCounter].UnderCard.Num)|| (card.Suit == Trump & CardPair[CardPairCounter].UnderCard.Suit == Trump & card.Num > CardPair[CardPairCounter].UnderCard.Num)||(card.Suit == Trump & CardPair[CardPairCounter].UnderCard.Suit != Trump))
                {
                    return true;
                }

                return false;
            }
        }
        public bool TurnIsOver()
        {
            if (CardPair[CardPairCounter].UpCard != null)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string res = "$"+ Trump+ "$";
            foreach (var pair in CardPair)
            {
                if (pair != null)
                {
                    res += "#"+ pair;
                }
            }
            return res;
        }

    }
}
