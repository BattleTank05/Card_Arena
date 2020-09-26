using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Card_Arena.Decks;

namespace Card_Arena
{
    class Player
    {
        public List<Card> currentDeck = new List<Card>();
        public int money = 200;
        public Deck[] playerDecks = new Deck[5];
        public bool isPlayerDefeated = false;
        public Deck[] playerCardInventory = new Deck[12];

        public List<Card> playerHand = new List<Card>();
        
        public int level = 1; //default set to common (1)
        public int xpToLevel = 100;
        public int currentXP = 0;

        public void PlayerTurn(Player player) 
        {
            int userInputInt = 0;
            Console.WriteLine("Your Turn!\n" + "1) Play a card\n" + "2) Draw a card");
            string userInputStr = Console.ReadLine();
            try
            {
                userInputInt = Int32.Parse(userInputStr);
            }
            catch 
            {
                PlayerTurn(player);
            }
            if (userInputInt == 1) 
            {
                int number = 1;
                while (number > 8) 
                {
                    Card searchedCard = FindCard(player.playerHand, number);
                    Console.WriteLine(searchedCard.cardName);
                }
            }
        }

        public Card FindCard(List<Card> deck, int number) 
        {
            return deck
                .Where(c => c.location == number)
                .Single();
        }

        public void ChangeXP(int change)
        {
            if (currentXP + change >= xpToLevel)
            {
                level += 1;
                currentXP -= xpToLevel;
                xpToLevel += 100;
            }
            else
            {
                currentXP += change;
            }
        }

        public void Check_Money()
        {
            if (money <= 0)
            {
                money = 0;
            }
        }

        //This function will not likely be used:
        public List<Card> CreateBaseDeck(Player player)
        {
            int howManyCards = 8;
            List<Card> newBaseDeck = new List<Card>();
            while (howManyCards > 0)
            {
                int cardDamage = GetRandom(1, 4);
                Common_Card newCard = new Common_Card();
                newCard.cardDamage = cardDamage;
                Console.WriteLine("New Card! - Rarity: " + newCard.rarity + " Damage: " + newCard.cardDamage);
                newCard.cardName = newCard.rarity + " " + newCard.cardDamage;
                newBaseDeck.Add(newCard);
                howManyCards -= 1;
            }
            if (player.currentDeck != null)
            {
                player.currentDeck = newBaseDeck;
            }
            return player.currentDeck;
        }
        static int GetRandom(int min, int max)
        {
            Random r = new Random();
            return r.Next(min, max);
        }
    }
}
