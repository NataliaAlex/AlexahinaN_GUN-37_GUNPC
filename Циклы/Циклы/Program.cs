using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Циклы
{
    class Program
    {
        static void Main(string[] args)
        {
            //С помощью цикла for (или while) выведите первые 10 чисел Фиббоначи
            Console.WriteLine("Задание 1");
            int[] array1 = new [] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55};
            for (int index = 0; index < array1.Length; index++)
            {
                Console.WriteLine(array1[index]);
            }

            //Используя цикл for, выведите все чётные числа от 2 до 20
            Console.WriteLine();
            Console.WriteLine("Задание 2");
            for (int i = 2; i <= 20; i+=2)
            {
                Console.WriteLine(i);
            }

            //С помощью вложенных циклов for выведите таблицу умножения от 1 до 5
            //Каждая строка таблицы должна быть выведена в отдельной строке
            Console.WriteLine();
            Console.WriteLine("Задание 3");
            
            for (int j = 1; j <= 5; j++)
            {
                for (int k = 0; k <= 10; k++)
                {
                    Console.WriteLine(j*k);
                }
                Console.WriteLine();
            }
          
            //Дана строка string password = “qwerty”;
            //Напишите программу для ввода пароля, которая считывает пользовательский ввод Console.ReadLine
            //Подсказка: используйте do -while
            Console.WriteLine();
            Console.WriteLine("Задание 4");
            Console.WriteLine("Enter the password (*6)");
            string password = "qwerty";
            var letters = "";
            do
            {
                letters = Console.ReadLine();
                if (letters != password)
                {
                    Console.WriteLine("Wrong password");
                }
            }
            while (letters != password);
            Console.WriteLine("Correct password");
         }
    }
}
