using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work_with_Set
{
    class SimpleSet : Set
    {
        //Поля класса
        private bool[] items;
        //
        //Конструктор
        public SimpleSet(int item)
        {
            base.maxValue= item;
            items = new bool[item + 1];
            items[item] = true;
        }
        //Метод добавления
        public override void Add(int item)
        {
            if (!isHaving(item))
            {
                items[item] = true;
            }
            else
            {
                Console.WriteLine("Элемент "+item+" присутствует во множестве");
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
            if (item <= base.maxValue&&item>0)
            {
                return items[item];
            }
            else
            {
                throw new TargetNotCorrectedValueForSet(base.maxValue);
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
                for (int i = 0; i < items.Length; i++)
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

}
