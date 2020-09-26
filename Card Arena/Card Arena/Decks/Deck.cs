using System;
using System.Collections.Generic;
using System.Text;

namespace Card_Arena.Decks
{
    class Deck //Can have 16 cards in one deck
    {
        public int size = 16;

    }

    class Common_Card : Deck
    {
        public string rarity = "Common";
        public int cardDamage;
    }

    class Rare_Card : Deck
    {
        public string rarity = "Rare";
    }

    class Legendary_Card : Deck
    {
        public string rarity = "Legendary";
    }
}
