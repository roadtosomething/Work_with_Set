using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work_with_Set
{
    class TargetNotCorrectedValueForSet : Exception
    {
        public TargetNotCorrectedValueForSet(int maxValue) : base()
        {
            Console.WriteLine("Выход за границы множества. Максимальный элемент множества: "+maxValue);
        }
    }
}
