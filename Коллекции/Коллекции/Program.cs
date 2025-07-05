using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Коллекции
{
    class Program
    {
        //Важно! У каждого класса должен быть публичный метод TaskLoop() , внутри которого происходит выполнение программы.
        //Прерывание выполнение реализовать внутри метода TaskLoop(),
        //предварительно вывести это условие в консоли(например, пользователь должен ввести “–exit”)

        //  Задание 1
        //  Создайте список строк(List) и добавьте в него несколько элементов.
        //  Затем попросите пользователя ввести новую строку и добавьте ее в список.
        //  Выведите содержимое списка на экран.
        //  Попросите пользователя ввести ещё одну строку, и добавьте её в середину списка

        private class ListTask
        {
            private readonly List<int> _listOfInts = new List<int>() { 1, 4, 6, 12 };
            public void TaskLoop()
            {
                string end = "";
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Имеющиеся числа");
                    for (int i = 0; i < _listOfInts.Count; i++)
                    {
                        Console.WriteLine(_listOfInts[i]);
                    }

                    Console.WriteLine("Введите новое число");
                    int UserNumber = Convert.ToInt32(Console.ReadLine());
                    _listOfInts.Add(UserNumber);
                    Console.WriteLine();

                    Console.WriteLine("Все имеющиеся числа");
                    for (int i = 0; i < _listOfInts.Count; i++)
                    {
                        Console.WriteLine(_listOfInts[i]);
                    }

                    Console.WriteLine("Введите новое число для добавления в середину списка");
                    int UserNumber2 = Convert.ToInt32(Console.ReadLine());
                    int middle = _listOfInts.Count / 2;
                    _listOfInts.Insert(middle, UserNumber2);
                    Console.WriteLine();

                    Console.WriteLine("Все имеющиеся числа");
                    for (int i = 0; i < _listOfInts.Count; i++)
                    {
                        Console.WriteLine(_listOfInts[i]);
                    }
                } while (end != "=");
            }
        }
        //  Задание 2
        //  Напишите программу, которая создает словарь, связывая имена студентов с их средними оценками.
        //  Попросите пользователя ввести имя студента и его оценку.Обязательно сделайте проверку на корректность ввода оценки: она должна быть от 2 до 5.
        //  Затем попросите пользователя ввести имя студента, и выведите оценку.Если студента нет в словаре, напишите, что студента с таким именем не существует.
        private class DictionaryTask
        {
            private readonly Dictionary<string, int> _student = new Dictionary<string, int>();
            public void TaskLoop()
            {
                string end = "";
                do
                {
                    Console.WriteLine("Введите имя студента ");
                    string UserName = Console.ReadLine();
                    Console.WriteLine("Введите оценку студента по 5-ти бальной шкале ");
                    int UserGrade = Convert.ToInt32(Console.ReadLine());

                    if (UserGrade < 2 || UserGrade > 5)
                    {
                        Console.WriteLine("Неправильная оценка ");
                        return;
                    }
                    _student.Add(UserName, UserGrade);

                    Console.WriteLine("Введите имя студента для поиска его оценки");
                    string UserName2 = Console.ReadLine();

                    if (_student.TryGetValue(UserName2, out int value))
                    {
                        Console.WriteLine("{0} получил оценку {1}", UserName2, value);
                    }
                    else
                    {
                        Console.WriteLine("Такого студента нет ");
                    }
                } while (end != "=");
            }
        }


        ////  Задание 3
        //  Мы познакомились с реализацией односвязного списка.Напишите реализацию двусвязного списка.
        //  Предложите пользователю создать список, ввести от 3 до 6 элементов (можно через Write, можно через WriteLine), затем вывести список в прямом и обратном порядках.
        private class LinkedListTask
        {
            private readonly LinkedList<int> _linkedList = new LinkedList<int>();
            public void TaskLoop()
            {
                string end = "";
                do
                {
                Console.WriteLine("Добавьте на экран 4 произвольных числа");
                int numbers = 4;
                for (int i = 0; i < numbers; i++)
                {
                    int number = Convert.ToInt32(Console.ReadLine());
                    _linkedList.AddLast(number);
                }

                Console.WriteLine("Список в прямом порядке:");
                var Node1 = _linkedList.First;
                while (Node1 != null)
                {
                    Console.WriteLine(Node1.Value);
                    Node1 = Node1.Next;
                }

                Console.WriteLine("Список в обратном порядке:");
                var Node2 = _linkedList.Last;
                while (Node2 != null)
                {
                    Console.WriteLine(Node2.Value);
                    Node2 = Node2.Previous;
                }
            } while (end != "=");
        }
    }


        //  В методе Main предложить пользователю выбрать номер задачи.
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 1,2 или 3 для перехода к заданию 1,2 или 3");
            Console.WriteLine("Для выхода из программы введите =");
            int task = int.Parse(Console.ReadLine());
            switch (task)
            {
                case 1:
                    CheckTaskFirst();
                    break;
                case 2:
                    CheckTaskSecond();
                    break;
                case 3:
                    CheckTaskThird();
                    break;
            }
        }

        private static void CheckTaskFirst()
        {
            var listTask = new ListTask();
            listTask.TaskLoop();
        }

        private static void CheckTaskSecond()
        {
            var dictionaryTask = new DictionaryTask();
            dictionaryTask.TaskLoop();
        }

        private static void CheckTaskThird()
        {
            var linkedListTask = new LinkedListTask();
            linkedListTask.TaskLoop();
        }


    }
}