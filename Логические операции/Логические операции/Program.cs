using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Логические_операции
{
    class Program
    {
        static void Main(string[] args)
        {
            //предложить пользователю ввести первое число, затем второе(используйте вывод в консоли, язык -английский)
            //сделать проверку ввода.Вместо Parse использовать TryParse.
            //В случае ошибки - предупреждать пользователя и делать выход из программы(return)
            //предложить пользователю ввести оператор: & | или ^.Сделать проверку ввода(введён корректный символ).
            //в зависимости от ввода выводить результат побитовой операции. Используйте оператор switch-case
            //результат выводить в десятичной, двоичной и шестнадцатиричной форме

            Console.WriteLine("Enter the number");
            if (!int.TryParse(Console.ReadLine(), out int number1))
            {
                Console.WriteLine("Error: not a number");
                return;
            }

            Console.WriteLine("Enter the number");
            if (!int.TryParse(Console.ReadLine(), out int number2))
            {
                Console.WriteLine("Error: not a number");
                return;
            }

            Console.WriteLine("Enter the symbol - &, |, ^");
            var s = Console.ReadLine();
            if (s.Length != 1 || (s[0] != '&' && s[0] != '|' && s[0] != '^'))
            {
                Console.WriteLine("Wrong symbol");
                return;
            }

            switch (s[0])
            {
                case '&':
                    Console.WriteLine("В десятичной системе");
                    Console.WriteLine(number1 & number2);
                    Console.WriteLine("В двоичной системе");
                    Console.WriteLine(Convert.ToString(number1 & number2, 2));
                    Console.WriteLine("В шестнадцатиричной системе");
                    Console.WriteLine(Convert.ToString(number1 & number2, 16));
                    break;

                case '|':
                    Console.WriteLine("В десятичной системе");
                    Console.WriteLine(number1 | number2);
                    Console.WriteLine("В двоичной системе");
                    Console.WriteLine(Convert.ToString(number1 | number2, 2));
                    Console.WriteLine("В шестнадцатиричной системе");
                    Console.WriteLine(Convert.ToString(number1 | number2, 16));
                    break;

                case '^':
                    Console.WriteLine("В десятичной системе");
                    Console.WriteLine(number1 ^ number2);
                    Console.WriteLine("В двоичной системе");
                    Console.WriteLine(Convert.ToString(number1 ^ number2, 2));
                    Console.WriteLine("В шестнадцатиричной системе");
                    Console.WriteLine(Convert.ToString(number1 ^ number2, 16));
                    break;

            }
        }
    }
}
