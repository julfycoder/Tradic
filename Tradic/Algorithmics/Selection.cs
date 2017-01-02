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
        static Random rnd = new Random();
        /// <summary>
        /// MR - most recent. This method gives upper priority to recent words.
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public static int GetIndexByMRAlgo(int N)
        {
            int delay = 150;
            Thread.Sleep(delay);
            double r1 = (double)rnd.Next(0, N + 1);
            Thread.Sleep(delay);
            double r2 = rnd.Next(0, (int)r1);

            return (int)((N - 1) - r2);
        }
        public static int GetRandom(int max)
        {
            return rnd.Next(max);
        }
        public static int GetRandom(int min, int max)
        {
            return rnd.Next(min, max);
        }
    }
}
