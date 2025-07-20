using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoGame
{
    class TheDiceGame
    {
        private readonly int _diceCount;
        private readonly int _minValue;
        private readonly int _maxValue;
        private readonly List<Dice> _dices;

        public TheDiceGame(int numberOfDice, int min, int max)
        {
            _diceCount = numberOfDice;
            _minValue = min;
            _maxValue = max;
        }

        protected void FactoryMethod()
        {
            for (int i = 0; i < _diceCount; i++)
            {
                _dices.Add(new Dice(_minValue, _maxValue));
            }
        }

        public int RollOfTheDice()
        {
            int totalScore = 0;
            foreach (var dice in _dices)
            {
                totalScore += dice.Number;
            }
            return totalScore;
        }

        public void PlayDiceGame()
        {
            Console.WriteLine("Игра в кости \n Выбейте большее число очков, чем ваш соперник");

            int playerScore = RollOfTheDice();
            int computerScore = RollOfTheDice();

            if (playerScore > computerScore)
            {
                Console.WriteLine($"{playerScore}, {computerScore}") ;
                Console.WriteLine("Победил Игрок!");
                OnWinInvoke();
            }
            else

            if (playerScore < computerScore)
            {
                Console.WriteLine("Победил Соперник!");
                OnLooseInvoke();
            }
            else
            {
                Console.WriteLine("У нас ничья!");
                OnDrawInvoke();
            }
        }
    }
}
