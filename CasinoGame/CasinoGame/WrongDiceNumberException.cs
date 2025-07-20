using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoGame
{
    public class WrongDiceNumberException : Exception
    {
        public WrongDiceNumberException(int number, int min, int max)
        {
            Console.WriteLine($"Некорректное число {number}. Выберите число между {min} и {max}");
        }
    }
}
