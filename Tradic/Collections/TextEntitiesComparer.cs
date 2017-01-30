using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tradic.Model.Entities;

namespace Tradic.Collections
{
    class TextEntitiesComparer : IComparer<TextEntity>
    {
        public int Compare(TextEntity x, TextEntity y)
        {
            for (int i = 0; i < x.Text.Length; i++)
            {
                if (i > y.Text.Length - 1) return -1;
                if (x.Text[i] > y.Text[i]) return 1;
                else if (x.Text[i] < y.Text[i]) return -1;
            }
            return 0;
        }
    }
}
