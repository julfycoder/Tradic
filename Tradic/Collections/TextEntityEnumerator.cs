using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tradic.Model.Entities;

namespace Tradic.Collections
{
    public class TextEntityEnumerator : ITextEntityEnumerator
    {
        public IEnumerable<TextEntity> GetTextEntitiesSortedByAlphabet(IEnumerable<TextEntity> entities)
        {
            return entities.OrderBy(e => e, new TextEntitiesComparer());
        }

        public IEnumerable<TextEntity> GetTextEntitiesConversely(IEnumerable<TextEntity> entities)
        {
            return entities.Reverse();
        }

        public IEnumerable<TextEntity> GetTextEntitiesWhichContainSubstring(IEnumerable<TextEntity> entities, string substring)
        {
            List<TextEntity> currentEntities = new List<TextEntity>();
            foreach (TextEntity entity in entities)
                if (entity.Text.ToLower().Contains(substring)) currentEntities.Add(entity);
            return currentEntities;
        }
    }
}
