using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tradic.Model.Entities
{
    public class Word:TextEntity
    {
        public int LanguageId { get; set; }
        public int TranslationId { get; set; }

        int _priority;
        public int Priority
        {
            get
            {
                return _priority;
            }
            set
            {
                if (value >= 0) _priority = value;
            }
        }
    }
}
