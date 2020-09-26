using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Card_Arena.Decks;

namespace Card_Arena
{
    class AI
    {
        public Deck[] currentDeck = new Deck[1];
        public int money = 200;
        public bool isPlayerDefeated = false;

        public List<Deck> aiHand = new List<Deck>();

        public int level = 1; //default set to common (1)
        public int xpToLevel = 100;
        public int currentXP = 0;

        public int ChangeXP(int change)
        {
            if (currentXP + change >= xpToLevel)
            {
                level += 1;
                currentXP -= xpToLevel;
                xpToLevel += 100;
            }
            return currentXP + change;
        }

        public void Check_Money()
        {
            if (money <= 0)
            {
                money = 0;
            }
        }
        //This function will not likely be used:
        public Deck[] CreateBaseDeck(AI ai)
        {
            Deck[] newBaseDeck = new Deck[8];
            for (int i = 0; i < newBaseDeck.Length; i++)
            {
                int cardDamage = GetRandom(1, 4);
                Common_Card newCard = new Common_Card();
                newCard.cardDamage = cardDamage;
                newCard.cardName = newCard.rarity + " " + newCard.cardDamage;
                newBaseDeck[i] = newCard;
            }
            if (ai.currentDeck != null)
            {
                ai.currentDeck = newBaseDeck;
            }
            return ai.currentDeck;
        }
        static int GetRandom(int min, int max)
        {
            Random r = new Random();
            return r.Next(min, max);
        }

    }
}
