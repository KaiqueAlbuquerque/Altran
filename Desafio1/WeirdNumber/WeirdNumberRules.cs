using System.Collections.Generic;

namespace WeirdNumber
{
    public static class WeirdNumberRules
    {
        public static List<int> GenerateWeirdNumber(int number)
        {
            List<int> weirdNumbers = new List<int>();
            int increment = 1;

            do
            {
                if (Dividers(increment))
                    weirdNumbers.Add(increment);

                increment++;
            }
            while (weirdNumbers.Count < number);

            return weirdNumbers;
        }

        private static bool Dividers(int dividend)
        {
            int total = 0;

            for (int i = 1; i < dividend; i++)
                if (dividend % i == 0)
                    total += i;

            if (total > dividend)
                return true;

            return false;
        }
    }
}
