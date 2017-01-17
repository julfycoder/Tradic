using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tradic.Model;
using Tradic.Model.Entities;
using Tradic.Algorithmics;
using Tradic.Collections;

namespace Tradic.Exams
{
    class EqualExam
    {
        ITradicIterator entitiesIterator;

        IEnumerable<Description> descriptions;
        IEnumerable<Word> allWords;
        IEnumerable<Language> languages;
        IEnumerable<Word> translationWords;
        
        Word openableTranslation;
        Word examinationalWord;

        
        public EqualExam(ITradicIterator entitiesIterator)
        {
            this.entitiesIterator = entitiesIterator;
            descriptions = entitiesIterator.GetDescriptions();
            languages = entitiesIterator.GetLanguages();
            Sort();
        }
        public Word GenerateWord()
        {
            Sort();
            examinationalWord = null;
            translationWords = null;

            while (translationWords == null)
            {
                examinationalWord = allWords.ToList()[Selection.GetIndexByMRAlgo(allWords.Count())];
                translationWords = GenerateTranslationWords(examinationalWord);
            }

            return examinationalWord;
        }
        private IEnumerable<Word> GenerateTranslationWords(Word originalWord)
        {
            Word translationWord = null;
            IEnumerable<Word> translationWords = allWords.Where(w => w.TranslationId == originalWord.TranslationId && w.Id != originalWord.Id && w.LanguageId != originalWord.LanguageId);
            Language language = languages.First(l => l.Id == translationWords.ToList()[Selection.GetRandom(translationWords.Count() - 1)].LanguageId);
            translationWords = translationWords.Where(w => w.LanguageId == language.Id);

            if (translationWords != null)
            {
                translationWord = translationWords.ToList()[Selection.GetRandom(translationWords.Count() - 1)];
            }
            return translationWords;
        }

        public Word GetTranslation()
        {
            if (openableTranslation == null || translationWords.All(w => w.Id != openableTranslation.Id))
            {
                openableTranslation = translationWords.ToList()[Selection.GetRandom(translationWords.Count())];
            }
            return openableTranslation;
        }
        public Description GetDescription()
        {
            if (descriptions.Any(d => d.WordId == examinationalWord.Id))
            {
                return descriptions.First(d => d.WordId == examinationalWord.Id);
            }
            return null;
        }
        public bool IsTranslationCorrect(string text)
        {
            if (translationWords.Any(w => w.Text.ToLower() == text.ToLower()))
            {
                return true;
            }
            return false;
        }

        private void Sort()
        {
            allWords = entitiesIterator.GetWords().OrderBy(w => w, new WordsComparer());
        }
        private void SaveChangedWord()
        {
            entitiesIterator.ChangeEntity(examinationalWord);
        }
        private void DecreaseTranslationKnowledge()
        {
            examinationalWord.Priority++;
            entitiesIterator.ChangeEntity(examinationalWord);
        }
        private void IncreaseTranslationKnowledge()
        {
            examinationalWord.Priority--;
            entitiesIterator.ChangeEntity(examinationalWord);
        }
    }
}
