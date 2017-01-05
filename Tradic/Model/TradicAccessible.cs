using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tradic.Business.Helper;
using Tradic.DAL;

namespace Tradic.Model
{
    public class TradicAccessible : IAccessible
    {
        static ITranslationHelper transHelper;
        static IWordHelper wordHelper;
        static ILanguageHelper languageHelper;
        static IDescriptionHelper descriptionHelper;
        static IAccessible CurrentInstance;

        protected TradicAccessible() { }

        #region AddEntity

        public void AddEntity(Entity.Word word)
        {
            wordHelper.AddEntity(new DAL.Entity.Word { Text = word.Text, LanguageId = word.LanguageId, TranslationId = word.TranslationId });
        }

        public void AddEntity(Entity.Translation translation)
        {
            transHelper.AddEntity(new DAL.Entity.Translation());
        }
        
        public void AddEntity(Entity.Language language)
        {
            languageHelper.AddEntity(new DAL.Entity.Language { Name = language.Name });
        }

        public void AddEntity(Entity.Description description)
        {
            descriptionHelper.AddEntity(new DAL.Entity.Description { Text = description.Text, WordId = description.WordId });
        }

        #endregion

        #region RemoveEntity

        public void RemoveEntity(Entity.Word word)
        {
            wordHelper.RemoveEntity(wordHelper.GetWords().First(w => w.Id == word.Id));
        }

        public void RemoveEntity(Entity.Translation translation)
        {
            transHelper.RemoveEntity(transHelper.GetTranslations().First(w => w.Id == translation.Id));
        }

        public void RemoveEntity(Entity.Language language)
        {
            languageHelper.RemoveEntity(languageHelper.GetLanguages().First(l => l.Id == language.Id));
        }

        public void RemoveEntity(Entity.Description description)
        {
            descriptionHelper.RemoveEntity(descriptionHelper.GetDescriptions().First(d => d.Id == description.Id));
        }

        #endregion

        #region GetEntities

        public IEnumerable<Entity.Word> GetWords()
        {
            IEnumerable<DAL.Entity.Word> DAL_Words = wordHelper.GetWords();
            List<Entity.Word> Tradic_Words = new List<Entity.Word>();
            foreach (DAL.Entity.Word dal_word in DAL_Words)
            {
                Tradic_Words.Add(new Entity.Word { Id = dal_word.Id, Text = dal_word.Text, LanguageId = dal_word.LanguageId, TranslationId = dal_word.TranslationId });
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

        public IEnumerable<Entity.Language> GetLanguages()
        {
            IEnumerable<DAL.Entity.Language> DAL_Languages = languageHelper.GetLanguages();
            List<Entity.Language> Tradic_Language = new List<Entity.Language>();
            foreach (DAL.Entity.Language dal_language in DAL_Languages)
            {
                Tradic_Language.Add(new Entity.Language { Id = dal_language.Id, Name = dal_language.Name });
            }
            return Tradic_Language;
        }

        public IEnumerable<Entity.Description> GetDescriptions()
        {
            IEnumerable<DAL.Entity.Description> dal_descriptions = descriptionHelper.GetDescriptions();
            List<Entity.Description> tradic_descriptions = new List<Entity.Description>();
            foreach (DAL.Entity.Description description in dal_descriptions)
            {
                tradic_descriptions.Add(new Entity.Description { Id = description.Id, Text = description.Text, WordId = description.WordId });
            }
            return tradic_descriptions;
        }

        #endregion

        public static IAccessible GetInstance()
        {
            if (CurrentInstance == null)
            {
                CurrentInstance = new TradicAccessible();
                TradicDataAccess access = TradicDataAccess.GetInstance();
                transHelper = new TranslationHelper(access);
                wordHelper = new WordHelper(access);
                languageHelper = new LanguageHelper(access);
                descriptionHelper = new DescriptionHelper(access);
            }
            return CurrentInstance;
        }
        
    }
}
