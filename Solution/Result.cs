using System.Collections.Generic;

namespace Solution
{
    public class Result
    {
        private int sum;
        private List<int> path;
        private int fatherIndex = -1;

        public Result()
        {
            sum = 0;
            path = new List<int>();
        }

        public void addPoint(int point)
        {
            path.Add(point);
            sum += point;
        }

        public int Sum
        {
            get { return sum; }
        }

        public string getRoute()
        {
            string route = "";
            foreach (int point in path)
            {
                route = route + point + ", ";
            }

            return route.Remove(route.Length - 2, 2);
        }

        public int FatherIndex
        {
            get { return fatherIndex; }
            set { fatherIndex = value; }
        }

        public bool isLastPointEven()
        {
            return PyramidUtils.isEven(path[path.Count - 1]);
        }

        public Result clone()
        {
            Result result = new Result();
            result.FatherIndex = FatherIndex;
            foreach (int point in path)
            {
                result.addPoint(point);
            }

            return result;
        }

    }
}