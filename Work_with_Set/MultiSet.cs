using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work_with_Set
{
    class MultiSet : Set
    {
        private int[] items;

        public MultiSet(int item)
        {
            items = new int[item + 1];
            items[item] = 1;
        }
        public override void Add(int item)
        {
            if (item < items.Length)
            {
                items[item] += 1;
            }
            else
            {
                int[] newItens = new int[item + 1];
                for (int i = 0; i < items.Length; i++)
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
                    str += i + ",";
            }
            if (str.Length > 0)
            {
                str = str.Remove(str.Length - 1);
                return str;
            }
            else
            {
                return "Пустое множество";
            }
        }
    }
}
