using System;
using System.Collections.Generic;

namespace Lab2
{
    abstract class Set
    {
        //Добавление элемента в множество
        public abstract void Add(int item);
        public abstract void Remove(int item);
        public abstract bool isHaving(int item);
        //Метод для отображения нашего множества
        public override string ToString()
        {
            return ToString();
        }
        //Конструкторы
        //Конструктор с входной строкой
        public void Fill(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!isHaving(Convert.ToInt16(Convert.ToString(str[i]))))
                {
                    Add(Convert.ToInt16(Convert.ToString(str[i])));
                }
            }
        }
        //Массив на входе
        public void Fill(int[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (!isHaving(items[i]))
                {
                    Add(items[i]);
                }
            }
        }
        //Случайные числа в а:b
        public void Fill(int min, int max)
        {
            //Проверка на доступность добавления
            bool checkFlag = true;
            for (int i = min; i <= max; i++)
            {
                if (!isHaving(i))
                {
                    checkFlag = false;
                }
            }
            if (!checkFlag)
            {
                Random rnd = new Random();
                int target = rnd.Next(min, max);
                while (isHaving(target))
                {
                    target = rnd.Next(min, max);
                }
                Console.WriteLine("Число " + target + " добавлено");
                Add(target);
            }
            else
            {
                Console.WriteLine("Все числа из диапазона включены в множество");
            }
        }
    }

    class SimpleSet : Set
    {
        //Поля класса
        public bool[] items;

        //
        //Конструктор
        public SimpleSet(int item)
        {
            items = new bool[item + 1];
            items[item] = true;
        }

        public int GetmaxValue()
        {
            //Проверка на наличие множества
            if (items.Length == 0)
            {
                Console.WriteLine("Пустое множество");
                return 0;
            }
            else
            {
                int target = 0;
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i]) { target = i; }
                }
                return target;
            }
        }

        //Метод добавления
        public override void Add(int item)
        {
            if (items.Length < item + 1)
            {
                bool[] newitems = new bool[item + 1];
                for (int i = 0; i < items.Length; i++)
                {
                    newitems[i] = items[i];
                    newitems[item] = true;
                }
                //Переопределяем массив
                items = newitems;
            }
            else
            {
                items[item] = true;
            }
        }

        //Метод удаления
        public override void Remove(int item)
        {
            //Проверка наличия
            if (isHaving(item))
            {
                //Удаление
                items[item] = false;
            }
        }

        //Метод наличия во множестве
        public override bool isHaving(int item)
        {
            if (items.Length < item + 1)
            {
                return false;
            }
            else
            {
                return items[item];
            }
        }
        //Строковый вывод множества
        public override string ToString()
        {
            string str;
            //Добавим флаг проверки значений
            bool flag = false;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == true)
                {
                flag = true;
            }
        }
            if (flag)
            {
                str = "{";
                for (int i = 0; i<items.Length; i++)
                {
                    if (items[i])
                    {
                        if (i == items.Length - 1)
                        {
                            str = str + i + "}";
                        }
                        else
                        {
                            str = str + i + ",";
                        }
                    }
                }
            }
            else
{
    str = "Пустое множество";
}
return str;
        }
        //Перегрузка оператора "+"
        public static SimpleSet operator +(SimpleSet a, SimpleSet b)
{
    SimpleSet c = new SimpleSet(1);
    c.Remove(1);
    for (int i = 0; i < a.items.Length; i++)
    {
        if (a.isHaving(i))
        {
            c.Add(i);
        }
    }
    for (int i = 0; i < b.items.Length; i++)
    {
        if (!a.isHaving(i) & (b.isHaving(i)))
        {
            c.Add(i);
        }
    }
    return c;
}
public static SimpleSet operator *(SimpleSet a, SimpleSet b)
{
    SimpleSet c = new SimpleSet(0);
    c.Remove(0);
    for (int i = 0; i < b.items.Length; i++)
    {
        if (b.isHaving(i))
        {
            if (a.isHaving(i))
            {
                c.Add(i);
            }
        }
    }
    return c;
}
    }

    /*class BitSet : Set
    {
    }*/
    class Program
    {

        static void Welcome()
        {
        Console.WriteLine("Работу выполнял студент 4-го курса ФИТ-1-2019 Кялов Юрий Викторович");
        Console.WriteLine("Авторство указано, мой личный блог: https://github.com/roadtosomething");
        Console.WriteLine("Начинаем работу со множествами!");
        }
        static void Main(string[] args)
        {
        //Welcome();
        /*Console.WriteLine("Создаем множество по п.1");
        SimpleSet test = new SimpleSet(5);
        Console.WriteLine("Заполняем множество строкой 12345678...");
        test.Fill("12345678");
        Console.WriteLine("Дополняем множество заполняя его значениями из массива {22,21,23,1,23}...");
        int[] testitems = new int[5] {22,21,23,1,23};
        test.Fill(testitems);
        Console.WriteLine("Заполняем массив (10:30) случайным числом из интервала...");
        test.Fill(10, 30);
        Console.WriteLine("Результат:");
        Console.WriteLine(test);
        Console.WriteLine("Максимальное значение множества: "+test.GetmaxValue());
        Console.WriteLine("Создаем слечайные множества для проверки объединения +");
        SimpleSet A = new SimpleSet(8);
        SimpleSet B = new SimpleSet(12);
        SimpleSet C = new SimpleSet(30);
        B.Fill("12345");
        Console.WriteLine("Сложили А:" + A + " и B:" + B + " \nПолучили: " + (A + B));
        Console.WriteLine("Умножили A:" + A + " и B:" + B + "\nПолучили:" + (A * B));
        Console.WriteLine("Попробуем с пустым множеством\n Берем А:" + A + " берем С:" + C + " \nПолучаем: "+(A*C));
        */
        }
    }
}