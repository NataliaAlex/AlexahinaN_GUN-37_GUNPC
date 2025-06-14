using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Массивы___Array
{
    class Program
    {
        static void Main(string[] args)
        {
            //Создайте массив, сожержащий первые 8 чисел Фибона́ччи
            Console.WriteLine("Задание 1");
            int[] array1 = new int[8] {0, 1, 1, 2, 3, 5, 8, 13};
            Console.WriteLine(array1[6]);

            //Создайте массив типа string, содержащий название 12 месяцев
            Console.WriteLine();
            Console.WriteLine("Задание 2");
            string[] array2 = new string[12] {"January", "February", "March", "April", "May", "June", "July",
                                              "August", "September", "October", "November", "December" };
            Console.WriteLine(array2[8]);

            //Создайте двумерный массив(матрицу) 3x3.
            //Вам нужно будет создать и проинициализировать двумерный массив типа int.
            //Элементы массива - матрицы:
            //Первая строка -числа 2, 3 и 4 в степени 1
            //Вторая строка -числа 2,3 и 4 в степени 2
            //Третья - числа 2,3 и 4 в степени 3
            Console.WriteLine();
            Console.WriteLine("Задание 3");
            int[,] array3 = new int[3,3] { {2, 3, 4}, {4, 9, 16}, {8,27, 64} };
            Console.WriteLine(array3[2,2]);

            //Вам нужно будет создать и проинициализировать jagged array(ломанный массив).
            //То есть массив, содержащий массивы разного размера.
            //Должен содержать следующие элементы(тип double)
            //Первый массив -числа от 1 до 5
            //Второй массив -константы e и pi(используйте класс math)
            //Третий массив -логарифм по основанию 10 чисел 1, 10, 100 и 1000(используя функцию log).
            //Важно! Используйте статический класс Math для констант и логарифмов
            Console.WriteLine();
            Console.WriteLine("Задание 4");
            double[][] Jarray = new double[3][];
            Jarray[0] = new double[5] { 1, 2, 3, 4, 5 };
            Jarray[1] = new double[2] { Math.E, Math.PI };
            Jarray[2] = new double[4] { Math.Log10(1), Math.Log10(10), Math.Log10(100), Math.Log10(1000)};
            Console.WriteLine(Jarray[0][3]);
            Console.WriteLine(Jarray[1][1]);
            Console.WriteLine(Jarray[2][1]);

            //Вам дано два массива int[] array = { 1, 2, 3, 4, 5 }; int[] array2 = { 7, 8, 9, 10, 11, 12, 13 };
            Console.WriteLine();
            Console.WriteLine("Задача Б");
            Console.WriteLine();
            int[] array5 = new int[] { 1, 2, 3, 4, 5 };
            int[] array6 = new int[] { 7, 8, 9, 10, 11, 12, 13 };
            
            for (int i = 0; i < array5.Length; i++)
            {
                Console.WriteLine("array5 " + i + ": " + array5[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < array6.Length; i++)
            {
                Console.WriteLine("array6 " + i + ": " + array6[i]);
            }

            //Скопируйте первые 3 элемента первого массива во второй.Воспользуйтесь классом Array.
            Console.WriteLine();
            Console.WriteLine("Задание 5");
            Array.Copy(array5, array6, 3);
            Console.WriteLine("Результат копирования");
            for (int i = 0; i < array6.Length; i++)
            {
                Console.WriteLine("array6 " + i + ": " + array6[i]);
            }

            //Измените размер первого массива так, чтобы в нём стало в два раза больше элементов
            //Воспользуйтесь классом Array, метод Resize.ВАЖНО! Массив передаётся через ref.
            //Это же ключевое слово вы будете использовать при вызове метода Resize,
            //то есть: Array.Resize(ref array, newSize);
            Console.WriteLine();
            Console.WriteLine("Задание 6");
            Console.WriteLine("Увеличение кол-ва элементов в 2 раза");
            Array.Resize(ref array5, 10 );
            for (int i = 0; i < array5.Length; i++)
            {
                Console.WriteLine("array5 " + i + ": " + array5[i]);
            }
        }
    }
}
