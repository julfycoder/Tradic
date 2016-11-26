using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tradic.DAL.Entity
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
