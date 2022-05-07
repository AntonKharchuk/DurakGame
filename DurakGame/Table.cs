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
                if(CanSetUnder(card))
                {
                    CardPair[CardPairCounter].UnderCard = new Card(card);
                }
            }
        }
        public bool CanSetUnder(Card cc)
        {
            if (EvalubleCards == null)
            {
                return true;
            }
            return EvalubleCards.Contains(cc.Num);
        }
        public void SetUpCard(Card card)
        {
            if (CanSetUp(card))
            {
                CardPair[CardPairCounter].UpCard = new Card(card);
                EvalubleCards.Add(card.Num);
            }
            else
            {
                throw new Exception("False card to set");
            }
           
        }
        public bool CanSetUp(Card cc)
        {
            if (CardPair[CardPairCounter].UnderCard == null)
            {
                return false;
            }
            else if ((cc.Suit == CardPair[CardPairCounter].UnderCard.Suit & cc.Num > CardPair[CardPairCounter].UnderCard.Num) || (cc.Suit == Trump & CardPair[CardPairCounter].UnderCard.Suit == Trump & cc.Num > CardPair[CardPairCounter].UnderCard.Num) || (cc.Suit == Trump & CardPair[CardPairCounter].UnderCard.Suit != Trump))
            {
                return true;
            }

            return false;
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
