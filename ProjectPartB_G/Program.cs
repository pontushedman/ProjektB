using System;

namespace ProjectPartB_B1
{
    class Program
    {
        static void Main(string[] args)
        {
            DeckOfCards myDeck = new DeckOfCards();
            myDeck.CreateFreshDeck();
            Console.WriteLine($"\nA freshly created deck with {myDeck.Count} cards:");
            Console.WriteLine(myDeck);

            Console.WriteLine($"\nA sorted deck with {myDeck.Count} cards:");
            myDeck.Sort();
            Console.WriteLine(myDeck);

            Console.WriteLine($"\nA shuffled deck with {myDeck.Count} cards:");
            myDeck.Shuffle();
            Console.WriteLine(myDeck);

            bool running = true;
            while (running)
            {
                Console.WriteLine("Lets play a game of highest card with two players.");
                bool amtOfCardsLoop = true;
                bool amtOfRoundsLoop = true;
                while (amtOfCardsLoop)
                {
                    Console.WriteLine("\nHow many cards to deal to each player? (1-5 or Q to Quit)");
                    var amtOfCardsInput = Console.ReadLine();
                    var amtOfCardsCheck = TryReadNrOfCards(amtOfCardsInput, out int amtOfCardsConv);
                    if (amtOfCardsCheck == true)
                    {
                        Console.WriteLine(amtOfCardsConv + " Cards will be dealt");
                        amtOfCardsLoop = false;
                        
                        Console.WriteLine("\nHow many rounds do you want to play?");
                        while (amtOfRoundsLoop)
                        {
                            var amtOfRoundsInput = Console.ReadLine();
                            var amtOfRoundsCheck = TryReadNrOfRounds(amtOfRoundsInput, out int amtOfRoundsConv);
                            
                            if ((amtOfCardsConv*2)*amtOfRoundsConv > myDeck.Count)
                            {
                                Console.WriteLine("Not enough cards for wanted round count, please try again");
                            } else
                            {
                                if (amtOfRoundsCheck == true)
                                {
                                    Console.WriteLine("\n" + amtOfRoundsConv + " rounds will be played\n-------------------------------\n");
                                    for (int i = 0; i < amtOfRoundsConv; i++)
                                    {
                                        Console.WriteLine("Round #" + (i + 1));
                                        HandOfCards player1 = new HandOfCards();
                                        HandOfCards player2 = new HandOfCards();

                                        //Your code to play the game comes here
                                        int NrOfCardsToPlayer = amtOfCardsConv;

                                        Deal(myDeck, NrOfCardsToPlayer, player1, player2);
                                        //Console.WriteLine(player1.Highest + "" + player1.Lowest);
                                        //Console.WriteLine(player2.Highest + "" +  player2.Lowest);
                                        Console.WriteLine("\n");

                                        DetermineWinner(player1, player2);
                                        amtOfRoundsLoop = false;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid round number");
                                }
                            }      
                        }
                    } else
                    {
                        Console.WriteLine("Please enter a number between 1-5");
                    }                
                }
            }
        }

        /// <summary>
        /// Asking a user to give how many cards should be given to players.
        /// User enters an integer value between 1 and 5. 
        /// </summary>
        /// <param name="NrOfCards">Number of cards given by user</param>
        /// <returns>true - if value could be read and converted. Otherwise false</returns>
        private static bool TryReadNrOfCards(string y, out int NrOfCards)
        {
            NrOfCards = 0;
            if (Int32.TryParse(y, out int nytt))
            {
                if (nytt > 0 && nytt < 6)
                {
                    NrOfCards = nytt;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Asking a user to give how many round should be played.
        /// User enters an integer value between 1 and 5. 
        /// </summary>
        /// <param name="NrOfRounds">Number of rounds given by user</param>
        /// <returns>true - if value could be read and converted. Otherwise false</returns>
        private static bool TryReadNrOfRounds(string y, out int NrOfRounds)
        {
            NrOfRounds = 0;
            if (Int32.TryParse(y, out int nytt))
            {
                NrOfRounds = nytt;
                return true;
            }
            return false;  
        }


        /// <summary>
        /// Removes from myDeck one card at the time and gives it to player1 and player2. 
        /// Repeated until players have recieved nrCardsToPlayer 
        /// </summary>
        /// <param name="myDeck">Deck to remove cards from</param>
        /// <param name="nrCardsToPlayer">Number of cards each player should recieve</param>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        /// 

        private static void Deal(DeckOfCards myDeck, int nrCardsToPlayer, HandOfCards player1, HandOfCards player2)
        {
            PlayingCard[] p1hand = new PlayingCard[nrCardsToPlayer];
            PlayingCard[] p2hand = new PlayingCard[nrCardsToPlayer];
            for (int i = 0; i < nrCardsToPlayer; i++)
            {
                var p1card = myDeck.RemoveTopCard();
                var p2card = myDeck.RemoveTopCard();
                player1.Add(p1card);
                player2.Add(p2card);
                p1hand[i] = p1card;
                p2hand[i] = p2card;
            }
            Console.WriteLine("Player 1 Cards");
            foreach (var item in p1hand)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");
            Console.WriteLine("Player 2 Cards");
            foreach (var item in p2hand)
            {
                Console.Write(item + " ");
            }
        }
        
        /// <summary>
        /// Determines and writes to Console the winner of player1 and player2. 
        /// Player with higest card wins. If both cards have equal value it is a tie.
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        private static void DetermineWinner(HandOfCards player1, HandOfCards player2)
        {
            if (player1.Highest.Value > player2.Highest.Value)
            {
                Console.WriteLine("Player 1 Wins!\n-----------------------\n");
            } else if(player2.Highest.Value > player1.Highest.Value) 
            {
                Console.WriteLine("Player 2 Wins!\n-------------------------------\n");
            }
            else if (player2.Highest.Value == player1.Highest.Value)
            {
                Console.WriteLine("Draw!\n-------------------------------\n");
            }
        }
    }
}
