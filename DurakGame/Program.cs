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

    

            Player Player2 = new Player();

            for (int i = 0; i < 6; i++)
            {
                Player2.TakeCard(Deck.GetCard());
            }

            Table GameTable = new Table(Deck.Cards[0].Suit);

            GameTable.SetUnderCard(Player1.PutCard(3));


            Console.WriteLine(Player1);
            Console.WriteLine(GameTable);
            Console.WriteLine(Player2);

            GameTable.SetUpCard(Player2.PutCard(3));
            Console.WriteLine(Player1);
            Console.WriteLine(GameTable);
            Console.WriteLine(Player2);

        }
    }
}
