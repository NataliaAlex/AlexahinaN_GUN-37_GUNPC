using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoGame
{
    public interface ISaveLoadService<T>
    {
        void SaveData(T data, string identifier);
        T LoadData(string identifier);
    }

    public class FileSystemSaveLoadService : ISaveLoadService<string>
    {
        private readonly string _basePath;

        public FileSystemSaveLoadService(string basePath)
        {
            _basePath = basePath;

            if (!Directory.Exists(_basePath))
            {
                Directory.CreateDirectory(_basePath);
            }
        }

        public void SaveData(string data, string identifier)
        {
            string filePath = Path.Combine(_basePath, $"{identifier}.txt");

            try
            {
                File.WriteAllText(filePath, data);
                Console.WriteLine($"Сохранено в {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка {ex.Message}");
            }
        }

        public string LoadData(string identifier)
        {
            string filePath = Path.Combine(_basePath, $"{identifier}.txt");

            try
            {
                if (File.Exists(filePath))
                {
                    string data = File.ReadAllText(filePath);
                    Console.WriteLine($"Сохранение загружено {filePath}");
                    return data;
                }
                else
                {
                    Console.WriteLine($"Сохранение не найдено {filePath}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Попытка открытия сохранения {ex.Message}");
                return null;
            }
        }
    }
}