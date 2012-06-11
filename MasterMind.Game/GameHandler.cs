using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MasterMind.Game
{
    public class GameHandler
    {
        private List<GameColors> _colors;
        private Random _random;

        public List<GameColors> GetInitialColors()
        {
            _random = new Random();
            _colors = new List<GameColors>();

            _colors.Add(RandomEnum<GameColors>());
            _colors.Add(RandomEnum<GameColors>());
            _colors.Add(RandomEnum<GameColors>());
            _colors.Add(RandomEnum<GameColors>());

            return _colors;
        }

        private T RandomEnum<T>()
        { 
            T[] values = (T[]) Enum.GetValues(typeof(T));
            return values[_random.Next(0,values.Length)];
        }

        public bool Guess(List<GameColors> correctGuess)
        {
            if (correctGuess.Count != 4)
                throw new Exception("Malformed guess, does not contain 4 colors");

            if (_colors == null)
                throw new Exception("Colors has not been initialized. Call .GetInitialColors() before .Guess");

            return _colors.SequenceEqual(correctGuess);
        }
    }
}
