using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Exercises
{
    public class HashTableExercises
    {
        public static int MostFrequent(int[] numbers)
        {
            Dictionary<int, int> mapper = new Dictionary<int, int>();

            foreach (var number in numbers)
            {
                if (mapper.ContainsKey(number))
                    mapper[number] = mapper[number] + 1;
                else
                    mapper[number] = 1;
            }


            int result = numbers[0];
            int max = -1;
            foreach (KeyValuePair<int, int> pair in mapper)
            {
                if (pair.Value > max)
                {
                    result = pair.Key;
                    max = pair.Value;
                }
            }

            return result;
        }

        public static int CountPairsWithDiff(int[] numbers, int k)
        {
            HashSet<int> unique = new HashSet<int>();
            foreach (var n in numbers)
                unique.Add(n);


            var count = 0;
            foreach (var n in numbers)
            {
                if (unique.Contains(n - k))
                    count++;

                if (unique.Contains(n + k))
                    count++;

                unique.Remove(n);
            }

            return count;
        }

        public static int[] TwoSum(int[] numbers, int target)
        {
            Dictionary<int, int> mapper = new Dictionary<int, int>();

            for (var i = 0; i < numbers.Length; i++)
            {
                int key = target - numbers[i];

                if (mapper.ContainsKey(key))
                    return new int[] { mapper[key], i };

                mapper[numbers[i]] = i;
            }


            return null;
        }
    }
}
