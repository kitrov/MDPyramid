using System;
using System.Collections.Generic;

namespace Solution
{
    internal class Program
    {
        private static List<Result> findResults(List<List<int>> inputList)
        {
            List<Result> results = new List<Result>();
            // find all result combination
            for (int i = 0; i < inputList.Count; i++)
            {
                if (i == 0)
                {
                    PyramidUtils.generateFirstResults(inputList[i], results);
                }
                else
                {
                    List<Result> newResults = new List<Result>();
                    foreach (Result result in results)
                    {
                        List<Result> tempResults = PyramidUtils.findNextNumbersResults(inputList[i], result);
                        if (tempResults != null)
                        {
                            newResults.AddRange(tempResults);
                        }
                    }

                    results.Clear();

                    results.AddRange(newResults);
                }
            }

            return results;
        }

        private static Result findMaxResult(List<Result> results)
        {
            int max = 0;
            int maxIndex = -1;
            for (int i = 0; i < results.Count; i++)
            {
                if (maxIndex == -1 || max < results[i].Sum)
                {
                    max = results[i].Sum;
                    maxIndex = i;
                }
            }

            if (maxIndex != -1)
            {
                return results[maxIndex];
            }

            return null;
        }

        private static void printResult(Result result)
        {
            if (result != null)
            {
                Console.WriteLine("Max sum: " + result.Sum);
                Console.WriteLine("Path: " + result.getRoute());
            }
            else
            {
                Console.WriteLine("Neither path reached bottom of pyramid.");
            }
        }

        public static void Main(string[] args)
        {
            List<List<int>> inputList = ReadUtils.readInputFromFile(@"..\..\input.txt");
            Console.WriteLine();
            Console.WriteLine("Output:");
            printResult(findMaxResult(findResults(inputList)));
        }
    }
}