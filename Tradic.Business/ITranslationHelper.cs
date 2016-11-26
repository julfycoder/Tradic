using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tradic.DAL.Entity;

namespace Tradic.Business
{
    public interface ITranslationHelper:IEntityHelper
    {
        IEnumerable<Translation> GetTranslations();
    }
}
