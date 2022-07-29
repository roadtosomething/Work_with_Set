using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work_with_Set
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
            return "Значения множества: " + ToString();
        }
        //Конструкторы
        //Конструктор с входной строкой
        public void Fill(string str)
        {
            string[] arrayString = str.Split(',');
            for (int i = 0; i < arrayString.Length; i++)
            {
                int val;
                if (int.TryParse(arrayString[i], out val)) 
                { 
                    Add(val); 
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
}
