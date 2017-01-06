using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tradic.Model.Entity;

namespace Tradic.Collections
{
    class WordsComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            Word word1 = x as Word;
            Word word2 = y as Word;

            if (word1.Priority < word2.Priority) return -1;
            else if (word1.Priority == word2.Priority) return 0;
            return 1;
        }
    }
}
