using System;
using System.Collections.Generic;

namespace Lab2
{
    //Абстрактный класс множества
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
            string[] arrayString = str.Split(',');
            for (int i = 0; i < arrayString.Length; i++)
            {
                Add(Convert.ToInt16(Convert.ToString(arrayString[i])));
            }
        }
        //Массив на входе
        public void Fill(int[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                Add(items[i]);
            }
        }
        //Случайные числа в а:b
        public void Fill(int min, int max)
        {
            Random rnd = new Random();
            int target = rnd.Next(min, max);
            Console.WriteLine("Число " + target + " добавлено");
            Add(target);
        }
    }
    //Класс множества наличия
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
    //Класс битового множества
    class BitSet : Set
    {
        private long value;

        private string arrayShow(short[] array)
        {
            string str = "";
            bool check = false;
            for (int i = 0; i < array.Length; i++)
            { 
                str = array[i] +str;
            }
            return str;
        }
        //Конвертор Десятичная - двоичная
        private short[] getByteArray()
        {
            short[] byteArray = new short[32];
            int count = 0;
            while (value > 0)
            {
                byteArray[count] = (short)(value % 2);
                count++;
                value /= 2;
            }
            return byteArray;
        }
        private short[] getByteArray(long target)
        {
            short[] byteArray = new short[32];
            int count = 0;
            while (target > 0)
            {
                byteArray[count] = (short)(target % 2);
                count++;
                target /= 2;
            }
            return byteArray;
        }
        //Конвертор Двоичная - десятичная
        private long getIntValue(short[] array)
        {
            long value=0;
            for (int i = 0; i < array.Length; i++)
            {
                value += array[i] * (long)Math.Pow(2, i);
            }
            return value;
        }
        //Конструктор с 1 значением
        public BitSet(int value)
        {
            this.value = getIntValue(getByteArray(value));
        }
        //Конструктор копирования
        public BitSet(BitSet a)
        {
            this.value = getIntValue(a.getByteArray());
        }
        //Конструктор пустого значения
        public BitSet()
        {
            this.value = 0;
        }

        public override bool isHaving(int item)
        {
            if ((item > 32) || (item<1))
            {
                return false;
            }
            else
            {
                if (getByteArray(value)[item - 1] == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //Добавление 1 бита
        public override void Add(int item)
        {
            short[] newArray = getByteArray(value);
            newArray[item - 1] = 1;
            value = getIntValue(newArray);
        }
        //Удаление бита
        public override void Remove(int item)
        {
            short[] newArray = getByteArray(value);
            newArray[item - 1] = 0;
            value = getIntValue(newArray);
        }
        //Перегрузка вывода
        public override string ToString()
        {
            return "Значение: " + value + "\nЗначение в бит: " + arrayShow(getByteArray(value));
        }
        //Перегрузка сложения
        public static BitSet operator +(BitSet x,BitSet y)
        {
            BitSet c = new BitSet();
            for (int i = 1; i <= 32; i++)
            {
                if (x.isHaving(i) || y.isHaving(i))
                {
                    c.Add(i);
                }
            }
            return c;
        }
        //Перегрузка объединения
        public static BitSet operator *(BitSet x, BitSet y)
        {
            BitSet c = new BitSet();
            for (int i = 1; i <= 32; i++)
            {
                if (x.isHaving(i) & y.isHaving(i))
                {
                    c.Add(i);
                }

            }
            return c;
        }
    }
    //Класс множественного наличия
    class MultiSet : Set
    {
        private int[] items;

        public MultiSet (int item)
        {
            items = new int[item+1];
            items[item] = 1;
        }
        public override void Add(int item)
        {
            if (item<items.Length)
            {
                items[item] += 1;
            }
            else
            {
                int[] newItens = new int[item+1];
                for (int i =0; i<items.Length;i++)
                {
                    newItens[i] = items[i];
                }
                newItens[item] += 1;
                items = newItens;
            }
        }

        public override void Remove(int item)
        {
            if (isHaving(item))
            {
                items[item] -= 1;
            };
        }

        public override bool isHaving(int item)
        {
            if (item < items.Length)
            {
                return (items[item] != 0);
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < items.Length; i++)
            {
                if (isHaving(i))
                str += i +",";
            }
            str = str.Remove(str.Length-1);
            if (str.Length > 0)
            {
                return "Значения множества: " + str;
            }
            else
            {
                return "Пустое множество";
            }
        }
    }

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
            BitSet test = new BitSet(5);
            test.Fill("1,2,3,4,5,6,7,8,9,10,11,12,13");
            BitSet A = new BitSet(test);
            BitSet B = new BitSet(300000);
            Console.WriteLine("А: "+A+"\nB: "+B+"\nСкладываем: "+(A+B)+"\nОбъединяем: "+(A*B));
            MultiSet test = new MultiSet(5);
            Console.WriteLine(test);
            test.Fill("1,2,8,10,101,101,23,32,44");
            test.Remove(101);
            Console.WriteLine(test);
            test.Fill(25, 30);
            Console.WriteLine(test);
            */
        }
    }
}