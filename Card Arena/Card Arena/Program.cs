using System;
using System.Collections.Generic;
using System.Text;

namespace Card_Arena
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to card arena!");
            Player player = new Player();
            player.CreateBaseDeck(player);
            Lobby(player);
        }
        static void Lobby(Player player) 
        {
            int userInputInt = 0;
            Console.WriteLine("(1) Create a new deck(Out of Order)/n(2) Arena");
            string userInputStr = Console.ReadLine();
            try 
            {
                userInputInt = Int32.Parse(userInputStr);
            }
            
            catch
            {
                Lobby(player);
            }
            if (userInputInt == 1)
            {
                Console.WriteLine("----Deck Builder----");
                for (int i = 0; i < player.playerCardInventory.Length; i++)
                {

                }
            }
            else if (userInputInt == 2) 
            {
                Arena fightCatalyst = new Arena();
                fightCatalyst.StartFight(player);
            }
        }
        public int MathFunctionClamp(int currentValue, int change, int MaxValue)
        {
            if (currentValue + change <= 0)
            {
                currentValue = 0;
                return currentValue;
            }
            else if (currentValue + change > MaxValue) 
            {
                currentValue = MaxValue;
                return currentValue;
            }
            return currentValue + change;
        }
    }
}
