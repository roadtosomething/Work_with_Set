using System;
using System.Collections.Generic;
using Work_with_Set;

namespace Lab2
{
    //Исключение выхода за пределы массива 
    //Абстрактный класс множества
    //Класс множества наличия
    //Класс битового множества
    //Класс множественного наличия
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
                "6. Просмотреть значения множества\n" +
                "7. Посмотреть максимальный возможный элемент" +
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
                    case "7":
                        Console.WriteLine(set.GetMaxValue());
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