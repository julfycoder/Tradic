using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Tradic.DAL.Entity
{
    public class Description:Entity
    {
        [ForeignKey("Word")]
        public int WordId { get; set; }
        public string Text { get; set; }

        public Word Word { get; set; }
    }
}
