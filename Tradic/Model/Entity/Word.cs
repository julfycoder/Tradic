using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tradic.Model.Entity
{
    public class Word:Entity
    {
        public string Text { get; set; }
        public string Language { get; set; }
        public int TranslationId { get; set; }
    }
}
