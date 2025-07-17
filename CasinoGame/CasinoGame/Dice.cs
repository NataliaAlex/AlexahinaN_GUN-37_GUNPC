using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CasinoGame
{
    public struct Dice
    {
        public readonly int Number;
        private readonly int _min;
        private readonly int _max;
        public Random _random;


        public Dice (int min, int max) : this()
        {
            _random = new Random();
            _random.Next(_min, _max + 1);

            if (min < 1 || min > int.MaxValue)
            {
                throw new WrongDiceNumberException(min, 1, int.MaxValue);
            }

            if (max < 1 || max > int.MaxValue)
            {
                throw new WrongDiceNumberException(max, 1, int.MaxValue);
            }

            if (min > max)
            {
                throw new Exception("Минимальное значение не может быть больше максимального");
            }

        }
    }
}
