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
                    CardPair[CardPairCounter] = new CardPair(card);
                }
            }
        }
        public bool CanSetUnder(Card cc)
        {
            if (EvalubleCards == null)
            {
                return true;
            }
            else if(CardPairCounter>6)
            {
                return false;
            }
            return EvalubleCards.Contains(cc.Num);
        }
        public bool CanSetUnder(Player pp)
        {
           
            foreach (var card in pp.PlayerCards)
            {
                if (CanSetUnder(card))
                {
                    return true;
                }
            }
            return false;
        }
        public void SetUpCard(Card card)
        {
            if (CanSetUp(card))
            {
                CardPair[CardPairCounter++].UpCard = new Card(card);
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
        public bool CanBito()
        {
            if (CardPairCounter==0)
            {
                return false;
            }
            else if (CardPair[CardPairCounter]==null)
            {
                return true;
            }
           
            return false;
        }
        public void Bito()
        {
            EvalubleCards = null;
            CardPair = new CardPair[6];
            CardPairCounter = 0;
        }
        public List<Card> TakeAll()
        {
            List<Card> res = new List<Card> { };
            foreach (var pair in CardPair)
            {
                if (pair!=null)
                {
                    if (pair.UnderCard != null)
                    {
                        res.Add(pair.UnderCard);
                        if (pair.UpCard != null)
                        {
                            res.Add(pair.UpCard);
                        }

                    }

                }
            }
            EvalubleCards = null;
            CardPair = new CardPair[6];
            CardPairCounter = 0;
            return res;
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
