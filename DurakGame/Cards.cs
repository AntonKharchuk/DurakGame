using System;
using System.Collections.Generic;
using System.Text;

namespace DurakGame
{
    class Card
    {
        int num;
        int suit;
        public int Num
        {
            get => num;
            set
            {
               if (value >= 0 && value < 9)
                    {
                    num = value;
                }
            }
        }
        public int Suit
        {
            get => suit;
            set
            {
                if (value >= 0 && value < 4)
                {
                    suit = value;
                }
            }
        }
        public Card(Card card)
        {
            num = card.Num;
            suit = card.Suit;
        }
        public Card()
        {

        }
        public override string ToString()
        {
            return "|"+Num.ToString() + "/" + Suit.ToString() + "|" ;
        }
    }
}
