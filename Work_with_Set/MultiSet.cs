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
            base.maxValue = item;
            items = new int[item + 1];
            items[item] = 1;
        }
        public override void Add(int item)
        {
            if (!isHaving(item))
            {
                items[item] += 1;
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
            return (items[item] != 0);
        }
    }
}
