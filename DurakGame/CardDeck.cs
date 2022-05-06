using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace DurakGame
{
    class CardDeck
    {
        public int CardCount { get; set; } = 35;

        public Card[] Cards;

        public CardDeck()
        {
            Cards = new Card[36];
            int CardCount = 0;
            for (int j = 0; j < 4; j++)
            {
                for (int k = 0; k < 9; k++)
                {
                    Cards[CardCount++] = new Card()
                    {
                        Num = k,
                        Suit = j
                    };
                }

            }
        }
        public void MixDeck()
        {
            Random random = new Random();
            for (int i = Cards.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                // обменять значения data[j] и data[i]
                var temp = Cards[j];
                Cards[j] = Cards[i];
                Cards[i] = temp;
            }
        }
        public Card GetCard()
        {
            if (CardCount>=0)
            {
                return Cards[CardCount--];
            }
            else
            {
                return new Card();
            }
        }


    }
}
