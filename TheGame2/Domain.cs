using System;
using System.Collections.Generic;
using System.Threading;

namespace TheGame2
{
    public abstract class Player
    {
        static public int MinRealWeight = 40;
        static public int MaxRealWeight = 140;
        
        public readonly string Name;

        protected List<int> listOfQuesses = new List<int>();
        
        public Player(string playerName)
        {
            this.Name = playerName;
        }

        public void SaveGuess(int guess)
        {
            this.listOfQuesses.Add(guess);
        }

        public void Wait(int milliseconds)
        {
            var t = new Timer(TimerCallback, null, milliseconds, Timeout.Infinite);
        }

        private void TimerCallback(object state)
        {
            throw new NotImplementedException();
        }

        public abstract int GetGuess();
    }

    public class ThoroughPlayer : Player
    {
        private int currentQuess;

        public ThoroughPlayer(string playerName) : base(playerName)
        {
            this.currentQuess = Player.MinRealWeight;
        }

        public override int GetGuess()
        {
            return ++this.currentQuess;
        }
    }

    public static class PlayerFactory
    {
        // replace with dictionary
        public static Player Create(PlayerType playerType, string playerName)
        {
            switch (playerType)
            {
                case PlayerType.Thorough: return new ThoroughPlayer(playerName);
                default: throw new ArgumentException("Unknown player type");
            }
        }
    }

    public enum PlayerType
    {
        Random = 1,
        Memory,
        Thorough,
        Cheater,
        ThoroughCheater
    }
}
