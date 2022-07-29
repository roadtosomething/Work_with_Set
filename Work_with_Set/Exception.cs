using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work_with_Set
{
    class TargetNotCorrectedValueForSet : Exception
    {
        public TargetNotCorrectedValueForSet() : base()
        {
            Console.WriteLine("ВЫход за границы множества");
        }
    }
}
