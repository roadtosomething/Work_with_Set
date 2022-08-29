using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work_with_Set
{
    class BitSet : Set
    {
        private uint value;
        //Конвертор Двоичная - десятичная
        BDConvertor bdc = new BDConvertor();
        //Конструктор с 1 значением
        public BitSet(int userValue)
        {
            base.maxValue= 32;
            short[] array = new short[32];
            array[userValue-1] = 1;
            value = bdc.getIntValue(array);
        }
        public override bool isHaving(int item)
        {
            return (bdc.getByteArray(value)[item-1] != 0);
        }
        //Добавление 1 бита
        public override void Add(int item)
        {
            if (!isHaving(item))
            {
                short[] array = bdc.getByteArray(value);
                array[item-1] = 1;
                value = bdc.getIntValue(array);
            }
        }
        //Удаление бита
        public override void Remove(int item)
        {
            if (isHaving(item))
            {
                short[] array = bdc.getByteArray(value);
                array[item-1] = 0;
                value = bdc.getIntValue(array);
            }
        }
        //Перегрузка вывода
        public override string ToString()
        {
            return Convert.ToString(value);
        }
        //Перегрузка сложения
        public static BitSet operator +(BitSet x, BitSet y)
        {
            for (int i = 1; i <= 32; i++)
            {
                if (x.isHaving(i) || y.isHaving(i))
                {
                    x.Add(i);
                }
            }
            return x;
        }
        //Перегрузка объединения
        public static BitSet operator *(BitSet x, BitSet y)
        {
            for (int i = 1; i <= 32; i++)
            {
                if (!x.isHaving(i) || !y.isHaving(i))
                {
                    x.Remove(i);
                }
            }
            return x;
        }
    }

}
