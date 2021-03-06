﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tradic.Business.Helper;
using Tradic.DAL;

namespace Tradic.Model
{
    public class TradicIterator : ITradicIterator
    {
        static ITranslationHelper transHelper;
        static IWordHelper wordHelper;
        static ILanguageHelper languageHelper;
        static IDescriptionHelper descriptionHelper;
        static ITradicIterator CurrentInstance;

        protected TradicIterator() { }

        #region AddEntity

        public void AddEntity(Entities.Word word)
        {
            wordHelper.AddEntity(new DAL.Entity.Word { Text = word.Text, LanguageId = word.LanguageId, TranslationId = word.TranslationId });
        }

        public void AddEntity(Entities.Translation translation)
        {
            transHelper.AddEntity(new DAL.Entity.Translation());
        }

        public void AddEntity(Entities.Language language)
        {
            languageHelper.AddEntity(new DAL.Entity.Language { Name = language.Name });
        }

        public void AddEntity(Entities.Description description)
        {
            descriptionHelper.AddEntity(new DAL.Entity.Description { Text = description.Text, WordId = description.WordId });
        }

        #endregion

        #region ChangeEntity

        public void ChangeEntity(Entities.Description description)
        {
            DAL.Entity.Description desc = descriptionHelper.GetDescriptions().First(d => d.Id == description.Id);
            desc.Text = description.Text;
            desc.WordId = description.WordId;
            desc.Word = wordHelper.GetWords().First(w => w.Id == description.WordId);
            descriptionHelper.ChangeEntity(desc);
        }

        public void ChangeEntity(Entities.Word word)
        {
            DAL.Entity.Word w = wordHelper.GetWords().First(target => target.Id == word.Id);
            w.Text = word.Text;
            w.LanguageId = word.LanguageId;
            w.TranslationId = word.TranslationId;
            w.Priority = word.Priority;
            w.Language = languageHelper.GetLanguages().First(l => l.Id == word.LanguageId);
            w.Translation = transHelper.GetTranslations().First(t => t.Id == word.TranslationId);
            wordHelper.ChangeEntity(w);
        }

        #endregion

        #region RemoveEntity

        public void RemoveEntity(Entities.Word word)
        {
            wordHelper.RemoveEntity(wordHelper.GetWords().First(w => w.Id == word.Id));
        }

        public void RemoveEntity(Entities.Translation translation)
        {
            transHelper.RemoveEntity(transHelper.GetTranslations().First(w => w.Id == translation.Id));
        }

        public void RemoveEntity(Entities.Language language)
        {
            languageHelper.RemoveEntity(languageHelper.GetLanguages().First(l => l.Id == language.Id));
        }

        public void RemoveEntity(Entities.Description description)
        {
            descriptionHelper.RemoveEntity(descriptionHelper.GetDescriptions().First(d => d.Id == description.Id));
        }

        #endregion

        #region GetEntities

        public IEnumerable<Entities.Word> GetWords()
        {
            IEnumerable<DAL.Entity.Word> DAL_Words = wordHelper.GetWords();
            List<Entities.Word> Tradic_Words = new List<Entities.Word>();
            foreach (DAL.Entity.Word dal_word in DAL_Words)
            {
                Tradic_Words.Add(new Entities.Word { Id = dal_word.Id, Text = dal_word.Text, LanguageId = dal_word.LanguageId, TranslationId = dal_word.TranslationId, Priority = dal_word.Priority });
            }
            return Tradic_Words;
        }

        public IEnumerable<Entities.Translation> GetTranslations()
        {
            IEnumerable<DAL.Entity.Translation> DAL_Translations = transHelper.GetTranslations();
            List<Entities.Translation> Tradic_Translations = new List<Entities.Translation>();
            foreach (DAL.Entity.Translation dal_translation in DAL_Translations)
            {
                Tradic_Translations.Add(new Entities.Translation { Id = dal_translation.Id });
            }
            return Tradic_Translations;
        }

        public IEnumerable<Entities.Language> GetLanguages()
        {
            IEnumerable<DAL.Entity.Language> DAL_Languages = languageHelper.GetLanguages();
            List<Entities.Language> Tradic_Language = new List<Entities.Language>();
            foreach (DAL.Entity.Language dal_language in DAL_Languages)
            {
                Tradic_Language.Add(new Entities.Language { Id = dal_language.Id, Name = dal_language.Name });
            }
            return Tradic_Language;
        }

        public IEnumerable<Entities.Description> GetDescriptions()
        {
            IEnumerable<DAL.Entity.Description> dal_descriptions = descriptionHelper.GetDescriptions();
            List<Entities.Description> tradic_descriptions = new List<Entities.Description>();
            foreach (DAL.Entity.Description description in dal_descriptions)
            {
                tradic_descriptions.Add(new Entities.Description { Id = description.Id, Text = description.Text, WordId = description.WordId });
            }
            return tradic_descriptions;
        }

        #endregion

        public static ITradicIterator GetInstance()
        {
            if (CurrentInstance == null)
            {
                CurrentInstance = new TradicIterator();
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
