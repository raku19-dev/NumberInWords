using System.Collections.Generic;

namespace NumberInWords
{
    public class SplitPer3Digit
    {
        private static readonly int MAX_OUTPUT_ELEMENTS = 3;//999,999,999

        public List<int> split(long number)
        {
            List<int> result = new List<int>(MAX_OUTPUT_ELEMENTS);
            do
            {
                result.Add((int) number % 1000);
                number /= 1000;
            } while (number > 0);
            return result;
        }
    }
}
