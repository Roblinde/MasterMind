using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.Game
{
    public class GameHandler
    {

        public List<GameColors> GetInitialColors()
        {
            List<GameColors> colors = new List<GameColors>();

            colors.Add(RandomEnum<GameColors>());
            colors.Add(RandomEnum<GameColors>());
            colors.Add(RandomEnum<GameColors>());
            colors.Add(RandomEnum<GameColors>());

            return colors;
        }

        private T RandomEnum<T>()
        { 
            T[] values = (T[]) Enum.GetValues(typeof(T));
            return values[new Random().Next(0,values.Length)];
        }
    }
}
