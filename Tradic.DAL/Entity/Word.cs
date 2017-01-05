using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tradic.DAL.Entity
{
    public class Word:Entity
    {
        [ForeignKey("Translation")]
        public int TranslationId { get; set; }
        public string Text { get; set; }

        [ForeignKey("Language")]
        public int LanguageId { get; set; }

        public Language Language { get; set; }
        public Translation Translation { get; set; }

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
