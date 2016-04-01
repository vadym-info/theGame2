using System;
using System.Collections.Generic;

namespace TheGame2
{
    public class QuessManager
    {
        private readonly int weight;
        private readonly Queue<Player> queueOfPlayers;

        public delegate void OnWin(string playerName, int totalNumberOfAttempts);
        public OnWin OnWinHandler;
        //public Action<string, int> OnWin;

        public QuessManager(int realWeight, List<Player> playerList)
        {
            this.weight = realWeight;
            this.queueOfPlayers = new Queue<Player>(playerList);
        }

        public void AddGuessRequest(Player guessRequest)
        {
            this.queueOfPlayers.Enqueue(guessRequest);
            StartProcessingTheQuesses();
        }

        public void StartTheGame()
        {
            StartProcessingTheQuesses();
        }

        private void StartProcessingTheQuesses()
        {
            Player playerToProcess = queueOfPlayers.Dequeue();
            ProcessTheGuess(playerToProcess);
        }

        private void ProcessTheGuess(Player currentPlayer)
        {
            int theGuess = currentPlayer.GetGuess();
            Console.WriteLine("guess {0}", theGuess);
            if (theGuess == weight)
            {
                OnWinHandler(currentPlayer.Name, 0);
                //OnWin(playerToProcesscurrentPlayer.Name, 0);
            }
            else
            {
                currentPlayer.SaveGuess(theGuess);
            }
        }
    }
}
