using System;
using System.Collections.Generic;

namespace TheGame2
{
    class Program
    {
        static void Main(string[] args)
        {
            // input number of players
            const int minPlayers = 1;
            const int maxPlayers = 8;
            Console.Write("Input number of players ({0} through {1}):", minPlayers, maxPlayers);
            string inputPlayers = Console.ReadLine();
            int numberOfPlayers;
            if (!int.TryParse(inputPlayers, out numberOfPlayers))
            {
                Console.WriteLine("Bad input");
                return;
            }
            if (numberOfPlayers < minPlayers || maxPlayers < numberOfPlayers)
            {
                Console.WriteLine("Number of players should be {0} through {1}", minPlayers, maxPlayers);
                //return;
            }

            // input players
            List<Player> playerList = new List<Player>(numberOfPlayers);
            for (int currentPlayer = 0; currentPlayer < numberOfPlayers; currentPlayer++)
            {
                Console.WriteLine();
                Console.WriteLine("Input {0} player information", currentPlayer);
                Console.Write("name:");
                string playerName = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine("Choose one of the player type");
                Console.WriteLine("1 - Random player");
                Console.WriteLine("2 - Memory player");
                Console.WriteLine("3 - Thorough player");
                Console.WriteLine("4 - Cheater player");
                Console.WriteLine("5 - Thorough Cheater player");
                Console.Write("player type:");
                string stringType = Console.ReadLine();
                int intType;
                if (!int.TryParse(stringType, out intType))
                {
                    Console.WriteLine("Bad input");
                    return;
                }
                bool isDefined = Enum.IsDefined(typeof(PlayerType), intType);
                if (!isDefined)
                {
                    Console.WriteLine("Unknown player type");
                    return;
                }
                PlayerType playerType = (PlayerType)intType;

                Player player = PlayerFactory.Create(playerType, playerName);
                playerList.Add(player);
            }

            int realWeight = (new Random()).Next(Player.MinRealWeight, Player.MaxRealWeight + 1);
            Console.WriteLine();
            Console.WriteLine("real weight of the basket - {0}", realWeight);

            // create quess manager
            QuessManager quessManager = new QuessManager(realWeight, playerList);
            quessManager.OnWinHandler = OutputWin;
            //quessManager.OnWin = OutputWin;
            quessManager.StartTheGame();
        }

        private static void OutputWin(string playerName, int totalNumberOfAttempts)
        {
            Console.WriteLine("Win!");
        }
    }
}
