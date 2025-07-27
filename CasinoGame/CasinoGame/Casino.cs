using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoGame
{
    public class Casino : IGame, IBuilderSupporter
    {
        private ISaveLoadService<string> _saveLoadService;
        private CasinoGameBase _selectedGame;
        private string _playerName;
        private int _bank;
        private int _maxBank = 500;

        public void StartGame()
        {
            LoadPlayerProfile();

            while (_bank > 0)
            {
                ChooseGame();
                PlaceBets();
                _selectedGame.PlayGame();
                SavePlayerData();
            }
            ExitGame();
        }

        private void LoadPlayerProfile()
        {
            Console.WriteLine("Введите имя");
            _playerName = Console.ReadLine();

            string data = _saveLoadService.LoadData(_playerName);

            if (data != null)
            {
                var parts = data.Split(',');
                _playerName = parts[0];
                _bank = int.Parse(parts[1]);
                if (_bank <= 0)
                {
                    _bank = _maxBank;
                    Console.WriteLine($"Приветствуем, {_playerName} У вас на счету {_bank} ");
                    SavePlayerData();
                }
                else
                {
                    Console.WriteLine($"Приветствуем, {_playerName} У вас на счету {_bank}");
                }
            }

            else
            {
                _bank = _maxBank;
                Console.WriteLine($"Приветствуем, {_playerName} У вас на счету {_bank}");
                SavePlayerData();
            }
        }

        public void ChooseGame()
        {
            Console.WriteLine("Для выбора игры нажмите: 1 - Black Jack, 2 - The Dice Game");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int gameChoice))
            {
                switch (gameChoice)
                {
                    case 1:
                        BuildCustom(new BlackJack(52));
                        Console.WriteLine("Играем в Black Jack");
                        break;
                    case 2:
                        BuildCustom(new DiceGame(2, 1, 6));
                        Console.WriteLine("Играем в The Dice Game");
                        break;
                    default:
                        Console.WriteLine("Ошибка ввода, нажмите 1 - Black Jack, 2 - The Dice Game");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода, нажмите 1 - Black Jack, 2 - The Dice Game");
            }
        }

        public void BuildService<T>(T service) where T : ISaveLoadService<string>
        {
            _saveLoadService = service;
        }

        private void PlaceBets()
        {
            Console.WriteLine($"У вас на счету {_bank}");

            bool validBet = false;
            while (!validBet)
            {
                Console.WriteLine("Укажите ставку");
                if (int.TryParse(Console.ReadLine(), out int bet))
                {
                    if (bet > 0 && bet <= _bank)
                    {
                        _selectedGame.PlaceBet(bet);
                        _selectedGame.ComputerPlaceBet(bet);
                        validBet = true;
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка. Сделайте ставку в пределах 1 - {_bank}");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка. Сделайте ставку в пределах 1 -");
                }
            }
        }

        void BuildCustom<U>(U game) where U : CasinoGameBase
        {
            _selectedGame = game;

            _selectedGame.OnWin += HandleWin;
            _selectedGame.OnLoose += HandleLoose;
            _selectedGame.OnDraw += HandleDraw;
        }

        private void HandleWin(object sender, EventArgs e)
        {
            _bank += _selectedGame.PlayerBet * 2;
            Console.WriteLine($"Поздравляем! Победа {_selectedGame.PlayerBet * 2}! На вашем счету {_bank}");
        }

        private void HandleLoose(object sender, EventArgs e)
        {
            _bank -= _selectedGame.PlayerBet;
            Console.WriteLine($"Вы проиграли {_selectedGame.PlayerBet}. У вас осталось {_bank}");

            if (_bank == _maxBank / 2)
            {
                Console.WriteLine("You wasted half of your bank money in casino’s bar");
            }
            else if (_bank <= 0)
            {
                Console.WriteLine("No money ? Kicked!");
                ExitGame();
            }
        }

        private void HandleDraw(object sender, EventArgs e)
        {
            Console.WriteLine("Ничья");
        }

        private void SavePlayerData()
        {
            string data = $"{_playerName},{_bank}";
            _saveLoadService.SaveData(data, _playerName);
        }

        private void ExitGame()
        {
            Console.WriteLine("До новых встреч");
            SavePlayerData();
        }

        void IBuilderSupporter.BuildCustom<U>(U games)
        {
            throw new NotImplementedException();
        }
    }
}
