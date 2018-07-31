using System.Collections.Generic;

namespace Solution
{
    public class PyramidUtils
    {
        private PyramidUtils()
        {
            // utils class
        }

        public static bool isIndexAvailable(int index, int arraySize)
        {
            if (index >= arraySize)
            {
                return false;
            }

            return true;
        }

        public static bool isEven(int number)
        {
            return number % 2 == 0;
        }

        public static List<Result> findNextNumbersResults(List<int> array, Result result)
        {
            List<Result> results = new List<Result>();
            addToResultsIfCan(array, result.FatherIndex, result, results);
            addToResultsIfCan(array, result.FatherIndex + 1, result, results);
            if (results.Count == 0)
            {
                return null;
            }

            return results;
        }

        public static void generateFirstResults(List<int> array, List<Result> results)
        {
            for (int i = 0; i < array.Count; i++)
            {
                Result result = new Result();
                result.FatherIndex = i;
                result.addPoint(array[i]);
                results.Add(result);
            }
        }

        private static void addToResultsIfCan(List<int> array, int index, Result result, List<Result> results)
        {
            if (isIndexAvailable(index, array.Count))
            {
                if (isEven(array[index]) != result.isLastPointEven())
                {
                    Result newResult = result.clone();
                    newResult.FatherIndex = index;
                    newResult.addPoint(array[index]);
                    results.Add(newResult);
                }
            }
        }
    }
}