using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work_with_Set
{

    class BDConvertor
    {
        public short[] getByteArray(uint value)
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
        public uint getIntValue(short[] array)
        {
            uint value = 0;
            for (int i = 0; i < array.Length; i++)
            {
                value += (uint)(array[i] * Math.Pow(2, i));
            }
            return value;
        }
    }
}
