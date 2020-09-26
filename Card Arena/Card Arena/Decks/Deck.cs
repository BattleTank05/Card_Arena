using System;
using System.Collections.Generic;
using System.Text;

namespace Card_Arena.Decks
{
    class Deck //Can have 16 cards in one deck
    {
        public int size = 16;

    }

    class Common_Card : Card
    {
        public Common_Card()
        {
            rarity = "Common";
        }
    }

    class Rare_Card : Card
    {
        public Rare_Card()
        {
            rarity = "Rare";
        }
    }

    class Legendary_Card : Card
    {
        public Legendary_Card()
        {
            rarity = "Legendary";
        }
    }
}
