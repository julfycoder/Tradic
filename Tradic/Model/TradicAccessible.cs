using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tradic.Business;
using Tradic.DAL;

namespace Tradic.Model
{
    public class TradicAccessible : IAccessible
    {
        ITranslationHelper transHelper;
        IWordHelper wordHelper;
        public TradicAccessible()
        {
            TradicDataAccess access = new TradicDataAccess();
            transHelper = new TranslationHelper(access);
            wordHelper = new WordHelper(access);
        }
        public void AddEntity(Entity.Word word)
        {
            wordHelper.AddEntity(new DAL.Entity.Word { Text = word.Text, Language = word.Language, TranslationId = word.TranslationId });
        }

        public void AddEntity(Entity.Translation translation)
        {
            transHelper.AddEntity(new DAL.Entity.Translation());
        }

        public void RemoveEntity(Entity.Word word)
        {
            wordHelper.RemoveEntity(wordHelper.GetWords().First(w => w.Id == word.Id));
        }

        public void RemoveEntity(Entity.Translation translation)
        {
            transHelper.RemoveEntity(transHelper.GetTranslations().First(w => w.Id == translation.Id));
        }

        public IEnumerable<Entity.Word> GetWords()
        {
            IEnumerable<DAL.Entity.Word> DAL_Words = wordHelper.GetWords();
            List<Entity.Word> Tradic_Words = new List<Entity.Word>();
            foreach (DAL.Entity.Word dal_word in DAL_Words)
            {
                Tradic_Words.Add(new Entity.Word { Id = dal_word.Id, Text = dal_word.Text, Language = dal_word.Language, TranslationId = dal_word.TranslationId });
            }
            return Tradic_Words;
        }

        public IEnumerable<Entity.Translation> GetTranslations()
        {
            IEnumerable<DAL.Entity.Translation> DAL_Translations = transHelper.GetTranslations();
            List<Entity.Translation> Tradic_Translations = new List<Entity.Translation>();
            foreach (DAL.Entity.Translation dal_translation in DAL_Translations)
            {
                Tradic_Translations.Add(new Entity.Translation { Id = dal_translation.Id });
            }
            return Tradic_Translations;
        }
    }
}
