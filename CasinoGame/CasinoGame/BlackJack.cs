using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoGame
{
    class BlackJack : CasinoGameBase
    {
        private Queue<Card> _deck;
        private List<Card> _cards;
        private List<Card> _playerCards;
        private List<Card> _computerCards;
        private Random _random;
        private CardSuit suit;
        private CardValue value;

        public BlackJack(int numberOfCards)
        {
            FactoryMethod();
        }

        protected override void FactoryMethod()
        {
            _deck = new Queue<Card>();
            _cards = new List<Card>();
            _playerCards = new List<Card>();
            _computerCards = new List<Card>();
            _random = new Random();

            foreach (CardValue Value in Enum.GetValues(typeof(CardValue)))
            {
                foreach (CardSuit Suit in Enum.GetValues(typeof(CardSuit)))
                {
                    Card card = new Card(suit, value);
                    _cards.Add(card);
                }
            }
        }

        public override void PlayGame()
        {
            DealCards(_playerCards, 2);
            DealCards(_computerCards, 2);

            Console.WriteLine($"Карты игрока: {string.Join(", ", _playerCards)}");
            Console.WriteLine($"Карты противника: {string.Join(", ", _computerCards)}"); ;

            DetermineWinner();
        }

        private void Shuffle()
        {
            List<Card> shuffledCards = _cards.OrderBy(card => _random.Next()).ToList();
            _deck.Clear();
            foreach (var card in shuffledCards)
            {
                _deck.Enqueue(card);
            }
        }

        private void DealCards(List<Card> hand, int numCards)
        {
            for (int i = 0; i < numCards; i++)
            {
                if (_deck.Count > 0)
                {
                    hand.Add(_deck.Dequeue());
                }
                else
                {
                    Console.WriteLine("Карт больше нет");
                    Shuffle();
                }
            }
        }

        private int CalculateScore(List<Card> hand)
        {
            int score = 0;
            int aceCount = 0;

            foreach (var card in hand)
            {
                switch (card.Value)
                {
                    case CardValue.Six:
                    case CardValue.Seven:
                    case CardValue.Eight:
                    case CardValue.Nine:
                    case CardValue.Ten:
                        score += (int)card.Value;
                        break;
                    case CardValue.Jack:
                    case CardValue.Queen:
                    case CardValue.King:
                        score += 10;
                        break;
                    case CardValue.Ace:
                        aceCount++;
                        break;
                }
            }

            for (int i = 0; i < aceCount; i++)
            {
                if (score + 11 <= 21)
                {
                    score += 11;
                }
                else
                {
                    score += 1;
                }
            }

            return score;
        }
        private void DetermineWinner()
        {
            while (true)
            {
                int playerScore = CalculateScore(_playerCards);
                int computerScore = CalculateScore(_computerCards);

                if (playerScore > computerScore && playerScore <= 21)
                {
                    Console.WriteLine($"Победил игрок со счетом {playerScore}");
                    OnWinInvoke();
                    break;
                }
                else if (computerScore > playerScore && computerScore <= 21)
                {
                    Console.WriteLine($"Победил противник со счетом {computerScore}");
                    OnLooseInvoke();
                    break;
                }
                else if (playerScore == computerScore && playerScore < 21)
                {
                    Console.WriteLine("Ничья, добавляем по одной карте на руку");
                    DealCards(_playerCards, 1);
                    DealCards(_computerCards, 1);
                }
                else if (playerScore == computerScore && playerScore >= 21)
                {
                    Console.WriteLine("Ничья, оба игрока набрали больше 21 очка");
                    OnDrawInvoke();
                    break;
                }
                else if (playerScore <= 21 && computerScore > 21)
                {
                    Console.WriteLine($"Победил противник со счетом {playerScore}. Проиграл противник со счетом {computerScore}");
                    OnWinInvoke();
                    break;
                }
                else if (computerScore <= 21 && playerScore > 21)
                {
                    Console.WriteLine($"Победил противник со счетом {computerScore}. Проиграл противник со счетом {playerScore}");
                    OnLooseInvoke();
                    break;
                }
            }
        }
    }
}
