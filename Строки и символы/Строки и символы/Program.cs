using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Строки_и_символы
{
    //Задание 1
    //Напишите метод, который принимает две строки и возвращает конкатенацию этих строк.
    public class Task1
    {
        public string ConcatenateStrings(string beginning, string end)
        {
            return string.Concat(beginning + end);
        }
    }

    //Задание 2
    //Напишите метод GreetUser, который получает имя(string) и возраст(int),
    //а затем использует строку с форматом $ для возврата сообщения вида “Hello, [Name]! You are[Age] years old.”.
    //Второе предложение должно идти с новой строки (используйте escape последовательность)
    public class Task2
    {
        public string GreetUser(string name, string age)
        {
            return ($"Hello, {name}! \nYou are {age} years old");
        }
    }

    //Задание 3
    //Закончите метод, который получает строку и возвращает новую строку с информацией:
    //Количество символов в строке, Строку в верхнем регистре, Строку в нижнем регистре. Используйте методы класса string
    public class Task3
    {
        public string InfoStrings(string phrase)
        {
            return ("Длина строки " + phrase.Length + " " + phrase.ToUpper() + " " + phrase.ToLower());
        }
    }

    //Задание 4
    //Напишите метод, который возвращает первые 5 символов строки.Используйте метод Substring
    public class Task4
    {
        public string Substring(string simbol)
        {
            if (simbol.Length < 5)
            {
                Console.WriteLine("Символов меньше 5");
            }
            return (simbol.Substring(0, 5));
        }
    }

    //Задание 5
    //Напишите метод, принимающий на вход массив из строк и возвращающий экземпляр StringBuilder.
    //Вам нужно создать экземпляр StringBuilder, который объединяет все элементы входного массива в одно предложение,
    //каждый элемент - через пробел.Какой метод StringBuilder вы будете использовать: Append или AppendLine?
    public class Task5
    {
        public string Builder(string[] idiom)
        {
            var StringBuilder = new StringBuilder();
            for (int i = 0; i < idiom.Length; i++)
            {
                StringBuilder.Append(idiom[i]);
                StringBuilder.Append(" ");
            }
            Console.WriteLine(StringBuilder);
            return Convert.ToString(StringBuilder);
        }
    }

    //Задание 6
    //Напишите метод, который принимает строку и два слова: одно для поиска и другое для замены.
    //Затем замените все вхождения первого слова на второе слово в введенной строке и верните результат.
    public class Task6
    {
        public string ReplaceWord(string line, string forSearch, string forReplace)
        {
            return (line.Replace(forSearch, forReplace));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Task1 Concat = new Task1();
            Concat.ConcatenateStrings("My Cup of ", "Tea");
            Console.WriteLine(Concat.ConcatenateStrings("My Cup of ", "Tea"));
            Console.WriteLine();

            Task2 GreetUser = new Task2();
            GreetUser.GreetUser("Spenser", "30");
            Console.WriteLine(GreetUser.GreetUser("Spenser", "30"));
            Console.WriteLine();

            Task3 InfoStrings = new Task3();
            InfoStrings.InfoStrings("Fight Fire With Fire");
            Console.WriteLine(InfoStrings.InfoStrings("Fight Fire With Fire"));
            Console.WriteLine();

            Task4 Substring = new Task4();
            Substring.Substring("Curiosity Killed The Cat");
            Console.WriteLine(Substring.Substring("Curiosity Killed The Cat"));
            Console.WriteLine();

            Task5 Builder = new Task5();
            string[] idiom = { "What", "Goes", "Up", "Must", "Come", "Down" };
            Builder.Builder(idiom);
            Console.WriteLine();

            Task6 ReplaceWord = new Task6();
            ReplaceWord.ReplaceWord("A Little Bird Told Me", "Told", "Sang to");
            Console.WriteLine("A Little Bird Told Me");
            Console.WriteLine(ReplaceWord.ReplaceWord("A Little Bird Told Me", "Told", "Sang to"));
            Console.WriteLine();
        }
    }
}
