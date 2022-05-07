using System;

namespace DurakGame
{
    class Program
    {
        static void Main(string[] args)
        {
            CardDeck Deck = new CardDeck();

            Deck.MixDeck();
         
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

            //GameTable.SetUnderCard(Player1.PutCard(3));

            //Console.WriteLine(Player1);
            //Console.WriteLine(GameTable);
            //Console.WriteLine(Player2);

            //GameTable.SetUpCard(Player2.PutCard(3));
            //Console.WriteLine(Player1);
            //Console.WriteLine(GameTable);
            //Console.WriteLine(Player2);


            bool Player1Turn = true;
            bool Player1Atack = true;
            do
            {
                Console.WriteLine("-----------------------------------------------------");

                if (Player1Atack)
                {
                    if (Player1Turn)
                    {
                        Console.WriteLine(Player2);
                        Console.WriteLine(GameTable);
                        Console.WriteLine(Player1);
                        Console.WriteLine("Wright num of card to take this card, b to bito, ");

                        bool Alldone = false;
                        do
                        {
                            Console.Write("Wthat to do? ");
                            string ansver = Console.ReadLine();
                            if (ansver == "b")
                            {
                                if (GameTable.CanBito())
                                {
                                    GameTable.Bito();
                                    CardsToSix(Player1);
                                    CardsToSix(Player2);
                                    Alldone = true;
                                    Player1Turn = false;
                                    Player1Atack = false;
                                }
                                else
                                {
                                    Alldone = false;
                                   
                                }
                            }
                            else if(!int.TryParse(ansver, out int r))
                            {
                                Alldone = false;
                            }
                            else
                            {
                                int CardIndex = int.Parse(ansver);
                                if (CardIndex<Player1.PlayerCards.Count&CardIndex>-1)
                                {
                                    if (GameTable.CanSetUnder(Player1.PlayerCards[CardIndex]))
                                    {
                                        GameTable.SetUnderCard(Player1.PutCard(CardIndex));
                                        Alldone = true;
                                        Player1Turn = false;

                                    }
                                    else
                                    {
                                        Alldone = false;
                                    }

                                }
                                else
                                {
                                    Alldone = false;
                                }
                            }
                        } while (!Alldone);
                        
                    }
                    else
                    {
                        Console.WriteLine(Player1);
                        Console.WriteLine(GameTable);
                        Console.WriteLine(Player2);
                        Console.WriteLine("Wright num of card to take this card, t to take all ");

                        bool Alldone = false;
                        do
                        {
                            Console.Write("Wthat to do? ");
                            string ansver = Console.ReadLine();
                            if (ansver == "t")
                            {
                                if (GameTable.CanSetUnder(Player1))
                                {
                                    do
                                    {
                                        Console.WriteLine("-----------------------------------------------------");
                                        Console.WriteLine(GameTable);
                                        Console.WriteLine(Player1);
                                        Console.Write("Whant add something?");
                                        ansver = Console.ReadLine();
                                        ansver = ansver.ToLower();
                                        if (ansver == "no")
                                            Alldone = true;
                                        else if (!int.TryParse(ansver, out int r))
                                        {
                                            Alldone = false;
                                        }
                                        else
                                        {
                                            int CardIndex = int.Parse(ansver);
                                            if (CardIndex < Player1.PlayerCards.Count & CardIndex > -1)
                                            {
                                                if (GameTable.CanSetUnder(Player1.PlayerCards[CardIndex]))
                                                {
                                                    GameTable.CardPairCounter++;
                                                    GameTable.SetUnderCard(Player1.PutCard(CardIndex));
                                                    if (GameTable.CanSetUnder(Player1))
                                                    {
                                                        Alldone = false;
                                                    }
                                                    else
                                                        Alldone = true;

                                                }
                                                else
                                                {
                                                    Alldone = false;
                                                }
                                            }
                                            else
                                            {
                                                Alldone = false;
                                            }
                                        }


                                    } while (!Alldone);

                                }

                                foreach (var card in GameTable.TakeAll())
                                {
                                    Player2.TakeCard(card);
                                }
                                CardsToSix(Player1);
                                Player1Turn = true;
                                Alldone = true;

                            }
                            else if (!int.TryParse(ansver, out int r))
                            {
                                Alldone = false;
                            }
                            else
                            {
                                int CardIndex = int.Parse(ansver);
                                if (CardIndex < Player2.PlayerCards.Count & CardIndex > -1)
                                {
                                    if (GameTable.CanSetUp(Player2.PlayerCards[CardIndex]))
                                    {
                                        GameTable.SetUpCard(Player2.PutCard(CardIndex));
                                        Alldone = true;
                                        Player1Turn = true;

                                    }
                                    else
                                    {
                                        Alldone = false;
                                    }

                                }
                                else
                                {
                                    Alldone = false;
                                }
                            }
                        } while (!Alldone);
                    }
                }
                else
                {
                    if (!Player1Turn)
                    {
                        Console.WriteLine(Player1);
                        Console.WriteLine(GameTable);
                        Console.WriteLine(Player2);
                        Console.WriteLine("Wright num of card to take this card, b to bito, ");

                        bool Alldone = false;
                        do
                        {
                            Console.Write("Wthat to do? ");
                            string ansver = Console.ReadLine();
                            if (ansver == "b")
                            {
                                if (GameTable.CanBito())
                                {
                                    GameTable.Bito();
                                    CardsToSix(Player2);
                                    CardsToSix(Player1);
                                    Alldone = true;
                                    Player1Turn = true;
                                    Player1Atack = true;
                                }
                                else
                                {
                                    Alldone = false;

                                }
                            }
                            else if (!int.TryParse(ansver, out int r))
                            {
                                Alldone = false;
                            }
                            else
                            {
                                int CardIndex = int.Parse(ansver);
                                if (CardIndex < Player2.PlayerCards.Count & CardIndex > -1)
                                {
                                    if (GameTable.CanSetUnder(Player2.PlayerCards[CardIndex]))
                                    {
                                        GameTable.SetUnderCard(Player2.PutCard(CardIndex));
                                        Alldone = true;
                                        Player1Turn = true;

                                    }
                                    else
                                    {
                                        Alldone = false;
                                    }

                                }
                                else
                                {
                                    Alldone = false;
                                }
                            }
                        } while (!Alldone);

                    }
                    else
                    {
                        Console.WriteLine(Player2);
                        Console.WriteLine(GameTable);
                        Console.WriteLine(Player1);
                        Console.WriteLine("Wright num of card to take this card, t to take all ");

                        bool Alldone = false;
                        do
                        {
                            Console.Write("Wthat to do? ");
                            string ansver = Console.ReadLine();
                            if (ansver == "t")
                            {
                                if (GameTable.CanSetUnder(Player2))
                                {
                                    do
                                    {
                                        Console.WriteLine("-----------------------------------------------------");
                                        Console.WriteLine(GameTable);
                                        Console.WriteLine(Player2);
                                        Console.Write("Whant add something?");
                                        ansver = Console.ReadLine();
                                        ansver = ansver.ToLower();
                                        if (ansver == "no")
                                            Alldone = true;
                                        else if (!int.TryParse(ansver, out int r))
                                        {
                                            Alldone = false;
                                        }
                                        else
                                        {
                                            int CardIndex = int.Parse(ansver);
                                            if (CardIndex < Player2.PlayerCards.Count & CardIndex > -1)
                                            {
                                                if (GameTable.CanSetUnder(Player2.PlayerCards[CardIndex]))
                                                {
                                                    GameTable.CardPairCounter++;
                                                    GameTable.SetUnderCard(Player2.PutCard(CardIndex));
                                                    if (GameTable.CanSetUnder(Player2))
                                                    {
                                                        Alldone = false;
                                                    }
                                                    else
                                                        Alldone = true;
                                                }
                                                else
                                                {
                                                    Alldone = false;
                                                }
                                            }
                                            else
                                            {
                                                Alldone = false;
                                            }
                                        }


                                    } while (!Alldone);

                                }
                                foreach (var card in GameTable.TakeAll())
                                {
                                    Player1.TakeCard(card);
                                }
                                CardsToSix(Player2);
                               
                                Player1Turn = false;
                                Alldone = true;
                            }
                            else if (!int.TryParse(ansver, out int r))
                            {
                                Alldone = false;
                            }
                            else
                            {
                                int CardIndex = int.Parse(ansver);
                                if (CardIndex < Player1.PlayerCards.Count & CardIndex > -1)
                                {
                                    if (GameTable.CanSetUp(Player1.PlayerCards[CardIndex]))
                                    {
                                        GameTable.SetUpCard(Player1.PutCard(CardIndex));
                                        Alldone = true;
                                        Player1Turn = false;

                                    }
                                    else
                                    {
                                        Alldone = false;
                                    }

                                }
                                else
                                {
                                    Alldone = false;
                                }
                            }
                        } while (!Alldone);
                    }
                }

            } while (Deck.CardCount>10);



            void CardsToSix(Player player)
            {
                if (player.PlayerCards.Count < 6)
                {
                    while (player.PlayerCards.Count != 6 & Deck.CardCount > -1)
                    {
                        player.TakeCard(Deck.GetCard());
                    }

                }

            }
        }
    }
}
