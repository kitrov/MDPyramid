using System;
using System.Collections.Generic;

namespace Solution
{
    public class ReadUtils
    {
        private ReadUtils()
        {
            // utils class
        }

        public static List<int> inputToArray(string[] input)
        {
            List<int> array = new List<int>();
            foreach (var entry in input)
            {
                int number;
                if (int.TryParse(entry, out number))
                {
                    array.Add(number);
                }
            }

            if (array.Count != null)
            {
                return array;
            }

            return null;
        }

        public static List<List<int>> readInputFromConsole()
        {
            List<List<int>> inputList = new List<List<int>>();
            List<int> array = inputToArray(Console.ReadLine().Split(' '));
            while (array.Count != 0)
            {
                inputList.Add(array);
                array = inputToArray(Console.ReadLine().Split(' '));
            }

            return inputList;
        }

        public static List<List<int>> readInputFromFile(string path)
        {
            Console.WriteLine("Input:");
            string[] lines = System.IO.File.ReadAllLines(path);
            List<List<int>> inputList = new List<List<int>>();
            foreach (string line in lines)
            {
                Console.WriteLine(line);
                var array = inputToArray(line.Split(' '));
                if (array.Count != 0)
                {
                    inputList.Add(array);
                }
                else
                {
                    break;
                }
            }

            return inputList;
        }
    }
}