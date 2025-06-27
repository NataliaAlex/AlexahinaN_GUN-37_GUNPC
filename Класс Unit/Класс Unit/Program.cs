using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Класс_Unit;

//Класс 1.Реализовать класс Unit, обладающий следующим функционалом:
//Открытые свойства:
//Имя юнита(Name):
//1.1 Задается строкой в конструкторе;
//1.2 Свойство только для чтения
//Здоровье юнита (Health):
//2.1 Поле свойства должно быть числом типа float; поле приватное
//2.2 Свойство только для чтения, возвращает поле из п.1;
//Урон(Damage):
//3.1 Свойство только для чтения;
//3.2 Значение задаётся в конструкторе и равно 5; тип int
//Броня(Armor):
//4.1 Возвращает число типа float;
//4.2 Значение задаётся в конструкторе и равно 0.6;
//Открытые методы:
//Конструкторы:
//1.1 Без аргумента - внутри устанавливается значение по-умолчанию для имени персонажа в виде “Unknown Unit”;
//1.2 Со строковым аргументом - устанавливает значение строки в свойство Name;
//1.3 Конструктор без аргумента должен вызывать конструктор с аргументом через ключевое слово this;
//Фактическое здоровье(GetRealHealth):
//2.1 Не имеет аргументов;
//2.2 Возвращает число типа float;
//2.3 Рассчитывается, как Health * (1f + Armor);
//Получить урон(SetDamage):
//3.1 Возвращает bool: true - юнит погиб(Health <= 0f), false - юнит жив(обратное значение);
//3.2 Внутри метода происходит расчет и выставление в поле здоровья значения: Health - value * Armor;

namespace Класс_Unit
{
    class Unit
    {
        //Открытые свойства
        public string Name { get; } //Свойство только для чтения
        
        private float health; //Поле свойства; поле приватное
        public float Health { get { return health; } } //Свойство только для чтения, возвращает поле свойства "health"

        public int Damage { get; } //Свойство только для чтения

        public float Armor { get; } //Свойство только для чтения

        //Конструкторы
        public Unit() : this("Unknown Unit")
        {

        }

        public Unit(string name)
        {
            Name = name;
        }

        public Unit(int Damage)
        {
            Damage = 5;
        }

        public Unit(float Armor)
        {
            Armor = 0.6f;
        }

                //Фактическое здоровье(GetRealHealth)
        public float GetRealHealth()
        {
            return Health * (1f + Armor);
        }

        //Получить урон(SetDamage)
        public bool SetDamage()
        {
            if (Health <= 0f)
            {
                Console.WriteLine("Юнит погиб");
                return true;
            }
            else 
            {
                var newHealth = Health * Armor;
                Console.WriteLine("Юнит жив");
                return false;
            }

        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите имя бойца");
        string name = Console.ReadLine();
        
    }
}