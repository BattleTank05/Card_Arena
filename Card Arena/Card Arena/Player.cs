using System;
using System.Collections.Generic;
using System.Text;
using Card_Arena.Decks;

namespace Card_Arena
{
    class Player
    {
        public Deck[] currentDeck = new Deck[1];
        public int money = 200;
        public Deck[] playerDecks = new Deck[5];
        public bool isPlayerDefeated = false;
        public Deck[] playerCardInventory = new Deck[12];
        public int level = 1; //default set to common (1)

        public void Check_Money()
        {
            if (money <= 0)
            {
                money = 0;
            }
        }
        //This function will not likely be used:
        public Deck[] CreateBaseDeck(Player player)
        {
            Deck[] newBaseDeck = new Deck[8];
            for (int i = 0; i < newBaseDeck.Length; i++)
            {
                int cardDamage = GetRandom(1, 4);
                Common_Card newCard = new Common_Card();
                newCard.cardDamage = cardDamage;
                newBaseDeck[i] = newCard;
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
