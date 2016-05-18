using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class LoopyCalculator
    {
        public double Average(int[] ints)
        {
            return ints[0];
        }

        public double AverageParams(params int[] paramInts)
        {
            return Average(paramInts);
        }

        public double Sum(int[] ints)
        {
            var sum = 0.0;
            foreach (var i in ints)
            {
                
            }
            return sum;
        }

        public double Max(int[] ints)
        {
            return ints.Max();
        }
    }
}
