using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tradic.Model.Entities;

namespace Tradic.Collections
{
    class WordsComparer : IComparer<Word>
    {
        public int Compare(Word x, Word y)
        {
            if (x.Priority < y.Priority) return -1;
            else if (x.Priority == y.Priority) return 0;
            return 1;
        }
    }
}
