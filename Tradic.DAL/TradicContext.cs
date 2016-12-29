using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Tradic.DAL.Entity;

namespace Tradic.DAL
{
    public class TradicContext : DbContext
    {
        public TradicContext()
            : base("name=TradicDatabaseConnection")
        { }
        public DbSet<Translation> Translations { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Language> Languages { get; set; }
    }
}
