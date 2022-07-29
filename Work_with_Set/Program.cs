using System;
using System.Collections.Generic;

namespace Lab2
{
    //Исключение выхода за пределы массива 
    class TargetNotCorrectedValueForSet : Exception
    {
        public TargetNotCorrectedValueForSet() :base() 
        {
            Console.WriteLine("ВЫход за границы множества");
        }
    }
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
            return "Значения множества: "+ToString();
        }
        //Конструкторы
        //Конструктор с входной строкой
        public void Fill(string str)
        {
            string[] arrayString = str.Split(',');
            for (int i = 0; i < arrayString.Length; i++)
            {
                try
                {
                    Add(Convert.ToInt16(Convert.ToString(arrayString[i])));
                }
                catch (Exception e)
                {
                    Console.WriteLine(arrayString[i] + "- не число");
                }
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
        public BitSet(int userValue)
        {
            this.value = getIntValue(getByteArray(userValue));
        }
        //Конструктор копирования
        private BitSet(BitSet a)
        {
            this.value = getIntValue(a.getByteArray());
        }
        //Конструктор генерации
        private BitSet()
        {
            this.value = 0;
        }

        public override bool isHaving(int item)
        {
            if (getByteArray(value)[item - 1] == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new TargetNotCorrectedValueForSet();
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
            return Convert.ToString(value);
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
            if (str.Length > 0)
            {
                str = str.Remove(str.Length-1);
                return str;
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
        static void Dialog()
        {
            bool _process = true;
            while (_process)
            {
                Console.WriteLine("Выберите один из вариантов взаимодействия, в случае выхода из программы введите \"++exit\"");
                Console.WriteLine("1. Перечисление элементов\n2. Битовый массив\n3. Логический массив");
                string userWord = Console.ReadLine();
                if (userWord == "++exit")
                {
                    Console.WriteLine("До встречи!");
                    _process = false;
                }
                else
                {
                    try
                    {
                        int target = Convert.ToInt16(userWord);
                        switch (target)
                        {
                            case 1:
                                Console.WriteLine("Выбран модуль работы с перечислением элементов");
                                Console.WriteLine("Ограничения в данном модуле на количество элементов множества нет. \n" +
                                    "Кадый элемент множества может быть включен в перечисление несколько раз.\n" +
                                    "Если вы добавили элемент 5 раз в данное множество, то необходимо удалить его равное количество раз\n" +
                                    "Вывод не учитывает количество одного элемента во множестве");
                                WorkWithSet(target);
                                break;
                            case 2:
                                Console.WriteLine("Выбран модуль работы с массивом бит");
                                Console.WriteLine("Ограничения в данном модуле на количество элементов множества:\n" +
                                    "Элемент должен соответствовать условия принадлежности отрезку [1;32] (так как работа ведется с битовым массивом данных). \n" +
                                    "Кадый элемент множества может быть включен в перечисление несколько раз.\n" +
                                    "Вывод показывает число в десятичной системе и битовое представление");
                                WorkWithSet(target);
                                break;
                            case 3:
                                Console.WriteLine("Выбран модуль работы с логическим массивом");
                                Console.WriteLine("Ограничения в данном модуле на количество элементов множества нет. \n" +
                                    "Каждый элемент имеет свойство есть или нет во множестве.\n" +
                                    "Вывод показывает на экран множество элементов принадлежащих данному");
                                WorkWithSet(target);
                                break;
                            default:
                                Console.WriteLine("Неизвестная команда");
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Неизвестная команда. Повторите попытку...");
                    }
                }
            }
        }
        static void WorkWithSet(int setNum)
        {
            //Дублирвоание взаимодействия для разных методов --------------------------------------------------------------------
            switch (setNum)
            {
                case 1:
                    Console.WriteLine("Создайте множество указав его максимальный элемент. Элемент должен быть натуральным числом.");
                    try
                    { 
                        int target = Convert.ToInt16(Console.ReadLine());
                        MultiSet set = new MultiSet(target);
                        Console.WriteLine("Множество создано. Значения множества: "+set);
                        MultiSetWorking(set);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Введите число!");
                        WorkWithSet(setNum);
                    }
                    break;
                case 2:
                    Console.WriteLine("Создайте множество указав его максимальный элемент. Элемент должен быть натуральным числом." +
                        "\nНЕ ПРЕВЫШАТЬ 32, так как работа с битовым массивом.");
                    try
                    {
                        int target = Convert.ToInt16(Console.ReadLine());
                        BitSet set = new BitSet(target);
                        Console.WriteLine("Множество создано. Значения множества: " + set);
                        MultiSetWorking(set);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Введите число!");
                        WorkWithSet(setNum);
                    }
                    break;
                case 3:
                    Console.WriteLine("Создайте множество указав его максимальный элемент. Элемент должен быть натуральным числом.");
                    try
                    {
                        int target = Convert.ToInt16(Console.ReadLine());
                        SimpleSet set = new SimpleSet(target);
                        Console.WriteLine("Множество создано. Значения множества: " + set);
                        MultiSetWorking(set);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Введите число!");
                        WorkWithSet(setNum);
                    }
                    break;
            }
        }
        static void MultiSetWorking(Set set)
        {
            Console.WriteLine("Выберите метод взаимодействия с множеством:\n" +
                "1. Добавить элемент\n" +
                "2. Удалить элемент\n" +
                "3. Заполнить строкой\n" +
                "4. Заполнить из массива (из файла)\n" +
                "5. Заполнить случайным числом из диапазона (min,max)\n" +
                "6. Просмотреть значения множества" +
                "\nДля возврата введите ++back");
            bool _working = true;
            while (_working)
            {
                Console.Write("Какую команду выполнить? ");
                string userWord = Console.ReadLine();
                int item;
                switch (userWord)
                {
                    case "1":
                        Console.WriteLine("Введите элемент: ");
                        item = Convert.ToInt32(Console.ReadLine());
                        set.Add(item);
                        break;
                    case "2":
                        Console.WriteLine("Введите элемент: ");
                        item = Convert.ToInt32(Console.ReadLine());
                        set.Remove(item);
                        break;
                    case "3":
                        Console.WriteLine("Введите строку перечилсяйте элементы через \",\"");
                        set.Fill(Console.ReadLine());
                        break;
                    case "4":
                        //
                        break;
                    case "5":
                        Console.WriteLine("Введите значения максимального и минимального значения интервала min max\n");
                        Console.Write("min=");
                        int min = Convert.ToInt32(Console.ReadLine());
                        Console.Write("max=");
                        int max = Convert.ToInt32(Console.ReadLine());
                        set.Fill(min, max);
                        break;
                    case "6":
                        Console.WriteLine(set);
                        break;
                    case "++back":
                        Console.WriteLine("Возврат к меню");
                        _working = false;
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда, попробуйте еще раз...");
                        MultiSetWorking(set);
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            Welcome();
            Dialog();
        }
    }
}