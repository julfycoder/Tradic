using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tradic.Model.Entities;

namespace Tradic.Model
{
    public interface ITradicIterator
    {
        void AddEntity(Word word);
        void AddEntity(Translation translation);
        void AddEntity(Language language);
        void AddEntity(Description description);

        void ChangeEntity(Description description);
        void ChangeEntity(Word word);

        void RemoveEntity(Word word);
        void RemoveEntity(Translation translation);
        void RemoveEntity(Language language);
        void RemoveEntity(Description description);

        IEnumerable<Word> GetWords();
        IEnumerable<Translation> GetTranslations();
        IEnumerable<Language> GetLanguages();
        IEnumerable<Description> GetDescriptions();
    }
}
