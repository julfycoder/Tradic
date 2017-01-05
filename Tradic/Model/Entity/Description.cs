using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tradic.Model.Entity
{
    public class Description : Entity
    {
        public int WordId { get; set; }
        public string Text { get; set; }
    }
}
