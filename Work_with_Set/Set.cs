using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work_with_Set
{
    abstract class Set
    {
        protected int maxValue=0;
        //Добавление элемента в множество
        public abstract void Add(int item);
        public abstract void Remove(int item);
        public abstract bool isHaving(int item);
        public string GetMaxValue()
        {
            return "Максимальный элемент множества: "+maxValue;
        }
        public override string ToString()
        {
            string str = "";
            for (int i = 1; i <= maxValue; i++)
            {
                if (isHaving(i))
                {
                    str += Convert.ToString(i)+",";
                }
            }
            if (str.Length > 0)
            {
                str = str.Substring(0, str.Length - 1);
                str = "{" + str + "}";
                return str;
            }
            else
            {
                return "Пустое множество";
            }
        }
        public void Fill(string str)
        {
            string[] arrayString = str.Split(',');
            if (maxValue == 0)
            {
                int maxValueString=0;
                for (int i = 0; i < arrayString.Length; i++)
                {
                    if (maxValueString < Convert.ToInt16(arrayString[i]))
                    {
                        maxValueString = Convert.ToInt16(arrayString[i]);
                    }
                }
                maxValue = maxValueString;
            }
            else
            {
                for (int i = 0; i < arrayString.Length; i++)
                {
                    int val;
                    if (int.TryParse(arrayString[i], out val))
                    {
                        if (val <= maxValue)
                        {
                            Add(val);
                        }
                        else
                        {
                            throw new TargetNotCorrectedValueForSet(maxValue);
                        }
                    }
                }
            }
            
        }
        //Массив на входе
        public void Fill(int[] items)
        {
            if (maxValue == 0)
            {
                maxValue = items.Max();
            }
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] <= maxValue)
                {
                    Add(items[i]);
                }
                else
                {
                    throw new TargetNotCorrectedValueForSet(maxValue);
                }
            }
        }
        //Случайные числа в а:b
        public void Fill(int min, int max)
        {
            Random rnd = new Random();
            int target = rnd.Next(min, max);
            if (maxValue == 0)
            {
                maxValue=target;
            }
            else
            {
                if (maxValue >= target)
                {
                    Add(target);
                }
                else
                {
                    throw new TargetNotCorrectedValueForSet(maxValue);
                }
            }
        }
    }
}
