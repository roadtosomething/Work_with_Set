using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work_with_Set
{
    class BitSet : Set
    {
        private long value;
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
            long value = 0;
            for (int i = 0; i < array.Length; i++)
            {
                value += array[i] * (long)Math.Pow(2, i);
            }
            return value;
        }
        //Конструктор с 1 значением
        public BitSet(int userValue)
        {
            short[] array = new short[32];
            array[userValue] = 1;
            this.value = getIntValue(array);
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
        public static BitSet operator +(BitSet x, BitSet y)
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

}
