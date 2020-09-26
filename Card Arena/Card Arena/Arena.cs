using System;
using System.Collections.Generic;
using System.Text;
using Card_Arena.Decks;

namespace Card_Arena
{
    class Arena
    {
        public void StartFight(Player player) 
        {
            AI ai = new AI();
            ai.CreateBaseDeck(ai);
            int moneyCheck = 100;
            while (player.money > moneyCheck) 
            {
                ai.money += GetRandom(0, moneyCheck);
                ai.currentXP += ai.ChangeXP(GetRandom(0, moneyCheck));
                moneyCheck += 100;
            }
            Console.WriteLine("Are you ready?\n");
            string userInputReady = Console.ReadLine();
            if (userInputReady == "y" || userInputReady == "Y" || userInputReady == "yes" || userInputReady == "Yes" || userInputReady == "1") 
            {
                Battle(player, ai);
            }
        }

        public void Battle(Player player, AI ai) 
        {
            bool isFirstRound = true;
            while (player.currentDeck != null && player.playerHand != null || ai.currentDeck != null && ai.aiHand != null) 
            {
                RoundStart(player, ai, isFirstRound);
            }
        }

        public void RoundStart(Player player, AI ai, bool isFirstRound) 
        {
            if (isFirstRound == true)
            {
                int number = 3;
                while (number > 0)
                {
                    if (player.FindCard(player.currentDeck, number) != null)
                    {
                        player.playerHand.Add(player.FindCard(player.currentDeck, number));
                        player.currentDeck.Remove(player.FindCard(player.currentDeck, number));
                        number -= 1;
                    }
                }
                for (int i = 0; i < ai.currentDeck.Length; i++)
                {
                    if (i >= 4)
                    {
                        break;
                    }
                    else
                    {
                        ai.aiHand.Add(ai.currentDeck[i]);
                    }
                }
                isFirstRound = false;
            }
            else 
            {
                int number = 1;
                while (number > 0)
                {
                    if (player.FindCard(player.currentDeck, number) != null)
                    {
                        player.playerHand.Add(player.FindCard(player.currentDeck, number));
                        player.currentDeck.Remove(player.FindCard(player.currentDeck, number));
                        number -= 1;
                    }
                }
                if (player.currentDeck == null) 
                {
                    Console.WriteLine("You are out of cards!");
                }
                for (int i = 0; i < ai.currentDeck.Length; i++)
                {
                    if (ai.currentDeck[i] != null)
                    {
                        ai.aiHand.Add(ai.currentDeck[i]);
                        break;
                    }
                }
                if (ai.currentDeck[ai.currentDeck.Length] == null) 
                {
                    Console.WriteLine("Ai(1) has run out of cards!");
                }
            }
        }

        public void RoundEnd() 
        {
            
        }

        static int GetRandom(int min, int max) 
        {
            Random r = new Random();
            return r.Next(min, max);
        }
    }
}
