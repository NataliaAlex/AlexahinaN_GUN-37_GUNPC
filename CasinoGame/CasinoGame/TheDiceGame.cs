using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoGame
{
    public class DiceGame : CasinoGameBase
    {
        private readonly int _diceCount;
        private readonly int _minValue;
        private readonly int _maxValue;
        private readonly List<Dice> _dices;

        public DiceGame(int numberOfDice, int min, int max)
        {
            _diceCount = numberOfDice;
            _minValue = min;
            _maxValue = max;
            _dices = new List<Dice>();
            FactoryMethod();
        }

        public override void PlayGame()
        {
            Console.WriteLine("Игра в кости");

            int playerScore = RollDice();
            int computerScore = RollDice();

            Console.WriteLine($"Очки игрока {playerScore}");
            Console.WriteLine($"Очки противника: {computerScore}");

            if (playerScore > computerScore)
            {
                Console.WriteLine("Игрок победил");
                OnWinInvoke();
            }
            else if (playerScore < computerScore)
            {
                Console.WriteLine("Противник победил");
                OnLooseInvoke();
            }
            else
            {
                Console.WriteLine("Ничья");
                OnDrawInvoke();
            }
        }

        protected override void FactoryMethod()
        {
            for (int i = 0; i < _diceCount; i++)
            {
                _dices.Add(new Dice(_minValue, _maxValue));
            }
        }

        private int RollDice()
        {
            int totalScore = 0;
            foreach (var dice in _dices)
            {
                totalScore += dice.Number;
            }
            return totalScore;
        }
    }
}
