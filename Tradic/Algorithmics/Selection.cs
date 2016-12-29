using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tradic.Algorithmics
{
    static class Selection
    {
        public static int GetIndexByMRAlgo(int N)
        {
            Random rnd = new Random();
            int delay = 150;
            Thread.Sleep(delay);
            double r1 = (double)rnd.Next(0, N + 1);
            Thread.Sleep(delay);
            double r2 = rnd.Next(0, (int)r1);

            return (int)((N - 1) - r2);
        }
        public static int GetRandom(int max)
        {
            Random rnd = new Random();
            return rnd.Next(max);
        }
        public static int GetRandom(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }
    }
}
