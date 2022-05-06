using System;

namespace DurakGame
{
    class Program
    {
        static void Main(string[] args)
        {
            CardDeck Deck = new CardDeck();

            Console.WriteLine("----------------------------");

            Deck.MixDeck();
            //foreach (var card in Deck.Cards)
            //{
            //    Console.Write(card);
            //    Card card1 = Deck.GetCard();
            //    Console.WriteLine(" "+ card1);
            //}
            //Console.WriteLine(Deck.CardCount);

            Player Player1 = new Player();

            for (int i = 0; i < 6; i++)
            {
                Player1.TakeCard(Deck.GetCard());
            }

            Console.WriteLine(Player1);

            Player Player2 = new Player();

            for (int i = 0; i < 6; i++)
            {
                Player2.TakeCard(Deck.GetCard());
            }

            Console.WriteLine(Player2);


        }
    }
}
