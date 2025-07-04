﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Строки_и_символы
{
    //Напишите метод, который принимает две строки и возвращает конкатенацию этих строк.
    public class Task1
    {
        public string ConcatenateStrings()
        {
            string beginning = "My Cup of ";
            string end = "Tea";
            string.Concat(beginning + end);
            Console.WriteLine(string.Concat(beginning + end));
            return (beginning + end);
        }
    }

    //Напишите метод GreetUser, который получает имя(string) и возраст(int),
    //а затем использует строку с форматом $ для возврата сообщения вида “Hello, [Name]! You are[Age] years old.”.
    //Второе предложение должно идти с новой строки (используйте escape последовательность)
    public class Task2
    {
        public string GreetUser()
        {
            string name = "Spenser";
            string age = "30";
            string.Concat(name + age);
            Console.WriteLine($"Hello, {name}! \nYou are {age} years old");
            return (name + age);
        }
    }

    //Закончите метод, который получает строку и возвращает новую строку с информацией:
    //Количество символов в строке, Строку в верхнем регистре, Строку в нижнем регистре. Используйте методы класса string
    public class Task3
    {
        public string InfoStrings()
        {
            string Phrase = "Fight Fire With Fire";
            Console.WriteLine("Длина строки " + Phrase.Length);
            Console.WriteLine(Phrase.ToUpper());
            Console.WriteLine(Phrase.ToLower());
            return (Phrase);
        }
    }

    //Напишите метод, который возвращает первые 5 символов строки.Используйте метод Substring
    public class Task4
    {
        public string Substring()
        {
            string simbol = "Curiosity Killed The Cat";
            Console.WriteLine(simbol.Substring(0, 5));
            return (simbol);
        }
    }

    //Напишите метод, принимающий на вход массив из строк и возвращающий экземпляр StringBuilder.
    //Вам нужно создать экземпляр StringBuilder, который объединяет все элементы входного массива в одно предложение,
    //каждый элемент - через пробел.Какой метод StringBuilder вы будете использовать: Append или AppendLine?
    public class Task5
    {
        public string StringBuilder()
        {
            var StringBuilder = new StringBuilder();
            string[] idiom = { "What", "Goes", "Up", "Must", "Come", "Down" };
            for (int i = 0; i < idiom.Length; i++)
            {
                StringBuilder.Append(idiom[i]);
                StringBuilder.Append(" ");
            }
            Console.WriteLine(StringBuilder);
            return Convert.ToString(StringBuilder);
        }
    }

    //Напишите метод, который принимает строку и два слова: одно для поиска и другое для замены.
    //Затем замените все вхождения первого слова на второе слово в введенной строке и верните результат.
    public class Task6
    {
        public string ReplaceWord()
        {
            string line = "A Little Bird Told Me";
            Console.WriteLine(line);

            string forSearch = "Told";
            string forReplace = "Sang to";

            line = line.Replace(forSearch, forReplace);

            Console.WriteLine(line);
            return (line);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Task1 ConcatenateStrings = new Task1();
            ConcatenateStrings.ConcatenateStrings();
            Console.WriteLine();

            Task2 GreetUser = new Task2();
            GreetUser.GreetUser();
            Console.WriteLine();

            Task3 InfoStrings = new Task3();
            InfoStrings.InfoStrings();
            Console.WriteLine();

            Task4 Substring = new Task4();
            Substring.Substring();
            Console.WriteLine();

            Task5 StringBuilder = new Task5();
            StringBuilder.StringBuilder();
            Console.WriteLine();

            Task6 ReplaceWord = new Task6();
            ReplaceWord.ReplaceWord();
            Console.WriteLine();
        }
    }
}
