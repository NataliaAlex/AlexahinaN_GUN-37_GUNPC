using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Реализовать класс Weapon, обладающий следующим функционалом:
        //Открытые свойства:
    //Имя оружия(Name):
//1.1 Задается строкой в конструкторе;
//1.2 Свойство только для чтения;
    //Минимальное значение урона (MinDamage):
//2.1 Свойство с приватным сеттером;
//2.2 Является числом типа int;
    //Максимальное значение урона (MaxDamage):
//3.1.Свойство с приватным сеттером;
//3.2.Является числом типа int;
    //Прочность(Durability):
//4.1 Свойство только для чтения;
//4.2 Значение задаётся в конструкторе и равно 1; тип float
    //Конструкторы:
//1.1 Со строковым аргументом - устанавливает значение строки в свойство Name;
//1.2 Со строковым аргументом и двумя числами типа int. Первое число - minDamage, второе - maxDamage;
//1.3 Конструктор с тремя аргументами должен вызывать конструктор с одним аргументом через ключевое слово this и передавать в него имя оружия;
//1.4 Конструктор с тремя аргументами должен вызывать в теле метод SetDamageParams;
    //Задать параметры урона (SetDamageParams):
//2.1 Не возвращает никаких значений;
//2.2 В качестве аргумента принимает два числа типа int. minDamage - задает минимальный урон оружия, maxDamage - задает максимальный урон оружия;
//2.3 Внутри метода должна проверяться допустимость входных значений. Если minDamage больше maxDamage - числа меняются местами, а в консоль выводится сообщение о некорректных входных данных (с указанием имени оружия);
//2.4 Если minDamage меньше 1, минимальный урон оружия задается значением f, а в консоль выводится сообщение о форсированной установки минимального значения;
//2.5 Если maxDamage меньше или равен 1, то устанавливаем значение 10;
    //Вернуть урон(GetDamage):
//3.1 Не принимает никаких аргументов;
//3.2 Возвращает число типа int, рассчитываемое, как среднее арифметическое между MinDamage и MaxDamage (вспомните, что такое среднее арифметическое из школьного курса математики);

class Weapon
{
    //Открытые свойства
    public string Name { get; } //Свойство только для чтения
    public int MinDamage { get; private set; } //Свойство с приватным сеттером
    public int MaxDamage { get; private set; } //Свойство с приватным сеттером
    public float Durability { get; } //Свойство только для чтения

    //Конструкторы
    public Weapon (string name)
    {
        Name = name;
        Durability = 1;
    }

    public Weapon(string Name, int minDamage, int maxDamage): this (Name)
    {
        SetDamageParams(minDamage, maxDamage);
    }

    //Параметры урона (SetDamageParams)
    public void SetDamageParams (int MinDamage, int MaxDamage)
    {
        if (MinDamage > MaxDamage)
        {
            Console.WriteLine("Некорректные данные " + Name);
            (MinDamage, MaxDamage) = (MaxDamage, MinDamage); //числа меняются местами
        }

        if (MinDamage < 1)
        {
            MinDamage = (int) 1f;
            Console.WriteLine("Минимальный урон 1");
        }
 
        if (MaxDamage <= 1)
        {
            MaxDamage = 10;
            Console.WriteLine("Максимальный урон 10");
        }

        this.MinDamage = MinDamage;
        this.MaxDamage = MaxDamage;
    }

    //Вернуть урон(GetDamage)
    public int GetDamage()
    {
        int GetDamagebyWeapon = (MinDamage + MaxDamage) / 2;
        return GetDamagebyWeapon;
    }

}
namespace Класс_Weapon
{
    class Program
    {
        static void Main(string[] args)
        {
            Weapon weapon = new Weapon(Name: "Sword", maxDamage: 15, minDamage: 1);
            Console.WriteLine("Weapon name " + weapon.Name);
        }
    }
}
