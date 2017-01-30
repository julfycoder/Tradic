using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tradic.Model.Entities;

namespace Tradic.Collections
{
    public interface ITextEntityEnumerator
    {
        IEnumerable<TextEntity> GetTextEntitiesSortedByAlphabet(IEnumerable<TextEntity> entities);
        IEnumerable<TextEntity> GetTextEntitiesConversely(IEnumerable<TextEntity> entities);
        IEnumerable<TextEntity> GetTextEntitiesWhichContainSubstring(IEnumerable<TextEntity>entities, string substring);
    }
}
