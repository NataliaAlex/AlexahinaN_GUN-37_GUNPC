using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сlass;

//Структура Interval, будет использоваться для определение границ интервала чисел с плавающей точкой.
//Открытые свойства:
//Минимум(Min) - возвращает значение, равное минимальной границе интервала;
//Максимум(Max) - возвращает значение, равное максимальной границе интервала;
//Получить(Get) - возвращает случайное значение между Min и Max. ВНИМАНИЕ! Вам нужно будет использовать класс Random. Создайте и проинициализируйте поле типа Random в структуре
//Конструкторы:
//Конструктор с двумя аргументами типа int.
//Первый minValue - определяет нижнюю границу интервала,второй - maxValue - определяет верхнюю границу интервала;
//Внутри конструктора должна проверяться допустимость входных значений.Если minValue больше maxValue - числа меняются местами, а в консоль выводится сообщение о некорректных входных данных;
//Оба числа должны быть больше или равны 0. Если одно из чисел отрицательное - его значение меняется на 0, а в консоль выводится сообщение о некорректных входных данных;
//Если оба числа равны, максимальное значение увеличивается на 10, а в консоль выводится сообщение о некорректных входных данных.

namespace Сlass
{
    public struct Interval
    {
        public int Min { get; }
        public int Max { get; }
        public Random RandomGet;
        public Interval(int minValue, int maxValue)
        {
            RandomGet = new Random();
            if (minValue > maxValue)
            {
                (minValue, maxValue) = (maxValue, minValue);
                Console.WriteLine("Некорректные данные, значения заменены");
            }

            if (minValue < 0)
            {
                minValue = 0;
                Console.WriteLine("Некорректные данные, minValue = 0");
            }

            if (maxValue < 0)
            {
                maxValue = 0;
                Console.WriteLine("Некорректные данные, maxValue = 0");
            }

            if (minValue == maxValue)
            {
                maxValue += 10;
                Console.WriteLine("Некорректные данные, maxValue = 10");
            }

            this.Min = minValue;
            this.Max = maxValue;
        }

        public int Get
        {
            get
            {
                return RandomGet.Next((Max - Min) + Min);
            }
        }

    }

    //Структура Room, будет хранить информацию о юните и оружии
    //Поле Unit - хранит ссылку на юнита;
    //Поле Weapon - хранит ссылку на оружие;
    //Конструктор с 2мя параметрами. Принимает на вход экземпляр Unit и экземпляр Weapon, происходит инициализация соответствующих полей (пример вызова ниже).
    struct Room
    {
        public Unit Unit { get; }
        public Weapon Weapon { get; }

        public Room(Unit unit, Weapon weapon)
        {
            Unit = unit;
            Weapon = weapon;
        }
    }

    //Класс Dungeon, инкапсулирующий логику работы подземелья
    //Внутри класса хранится массив Room в поле, т.е. должно быть поле Room[] название_поля
    //Конструктор только по-умолчанию (определить). Конструктор по-умолчанию инициализирует массив.
    //В массиве должно быть от 3 до 5 элементов.
    //Элементы должны быть проинициализированы. Инициализация - любая на усмотрение исполнителя.
    //Следовательно, должен получится массив Room у которого минимум 3 элемента, в каждом должен быть свой экземпляр Unit и Weapon.
    //Необходимо будет использовать инициализацию массива.
    //Открытый метод ShowRooms. Возвращаемый тип void. Ничего не принимает на вход. Должен с помощью цикла пройтись по массиву комнат и вывести информация.
    class Dungeon
    {
        public Room[] rooms;

        public Dungeon()
        {
            rooms = new Room[]
            {
                new Room(new Unit("Knight", 3, 7), new Weapon("Sword", 9, 15)),
                new Room(new Unit("Wizard", 1, 12), new Weapon("Wizard's staff", 4, 10)),
                new Room(new Unit("Thief", 5, 15), new Weapon("Gloves", 1, 9)),
                new Room(new Unit("Hunter", 4, 10), new Weapon("Spear", 7, 13)),
            }
            ;
        }
        public void ShowRooms()
        {
            for (int i = 0; i < rooms.Length; i++)
            {
                var room = rooms[i];
                Console.WriteLine();
                Console.WriteLine("Unit: " + room.Unit.Name + " " + room.Unit.Damage.Min + " " + room.Unit.Damage.Max);
                Console.WriteLine("Weapon: " + room.Weapon.Name + " " + room.Weapon.Damage.Min + " " + room.Weapon.Damage.Max);
                Console.WriteLine();
            }
        }
    }

    //Доработка игровой логики:
    //Структура Interval заменяет свойства MinDamage и MaxDamage у оружия. Логичным образом, т.е. оба свойства заменяются на одно, имеющее тип Interval;
    //Также добавляется вместо свойства Damage у Unit. При этом минимальное значение должно быть равно 0. Добавьте ещё один конструктор с доп. параметрами типа int для мин. и макс. значений урона.

    class Unit
    {
        public string Name { get; }
        private float health;
        public float Health { get { return health; } }
        public Interval Damage { get; }
        public float Armor { get; }

        public Unit() : this("Unknown Unit")
        {

        }

        public Unit(string name)
        {
            Name = name;
            Damage = new Interval(0, 0);
            Armor = 0.6f;
        }

        public Unit(string name, int minDamage, int maxDamage)
        {
            Name = name;
            Damage = new Interval(minDamage, maxDamage);
        }

        public float GetRealHealth()
        {
            return Health * (1f + Armor);
        }

        public bool SetDamage(float value)
        {
            health -= value * Armor;
            if (Health <= 0f)
            {
                Console.WriteLine("Юнит погиб");
                return true;
            }
            else
            {
                Console.WriteLine("Юнит жив");
                return false;
            }

        }

    }
}

class Weapon
{
    public string Name { get; }
    public float Durability { get; }
    public Interval Damage { get; private set; }

    public Weapon(string name)
    {
        Name = name;
        Durability = 1;
    }

    public Weapon(string Name, int minDamage, int maxDamage) : this(Name)
    {
        SetDamageParams(minDamage, maxDamage);
    }

    public void SetDamageParams(int MinDamage, int MaxDamage)
    {
        if (MinDamage > MaxDamage)
        {
            Console.WriteLine("Некорректные данные " + Name);
            (MinDamage, MaxDamage) = (MaxDamage, MinDamage); //числа меняются местами
        }

        if (MinDamage < 1)
        {
            MinDamage = (int)1f;
            Console.WriteLine("Минимальный урон 1");
        }

        if (MaxDamage <= 1)
        {
            MaxDamage = 10;
            Console.WriteLine("Максимальный урон 10");
        }

        Damage = new Interval(MinDamage, MaxDamage);
    }

    public int GetDamage()
    {
        int GetDamagebyWeapon = (Damage.Min + Damage.Max) / 2;
        return GetDamagebyWeapon;
    }

}

//В методе Main создаётся экземпляр Dungeon.
//У Dungeon вызывается метод ShowRooms.

class Program
{
    static void Main()
    {
        Dungeon dungeon = new Dungeon();
        dungeon.ShowRooms();

    }
}