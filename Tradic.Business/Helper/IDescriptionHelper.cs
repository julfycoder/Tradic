using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tradic.DAL.Entity;

namespace Tradic.Business.Helper
{
    public interface IDescriptionHelper:IEntityHelper
    {
        IEnumerable<Description> GetDescriptions();
    }
}
