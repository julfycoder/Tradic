using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tradic.Model.Entity;

namespace Tradic.Model
{
    public interface IAccessible
    {
        void AddEntity(Word word);
        void AddEntity(Translation translation);
        void AddEntity(Language language);

        void RemoveEntity(Word word);
        void RemoveEntity(Translation translation);
        void RemoveEntity(Language language);

        IEnumerable<Word> GetWords();
        IEnumerable<Translation> GetTranslations();
        IEnumerable<Language> GetLanguages();
    }
}
