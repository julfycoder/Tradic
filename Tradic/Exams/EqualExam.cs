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

        bool answered = false;
        bool isTranslationGiven = false;
        bool isDescriptionGiven = false;
        public EqualExam(ITradicIterator entitiesIterator)
        {
            this.entitiesIterator = entitiesIterator;
            descriptions = entitiesIterator.GetDescriptions();
            languages = entitiesIterator.GetLanguages();
            Sort();
        }
        public Word GenerateWord()
        {
            if (examinationalWord != null)
            {
                if (!answered) DecreaseTranslationKnowledge();
                SaveChangedWord();
            }
            
            examinationalWord = null;
            translationWords = null;

            Sort();
            while (translationWords == null)
            {
                examinationalWord = allWords.ToList()[Selection.GetIndexByMRAlgo(allWords.Count())];
                translationWords = GenerateTranslationWords(examinationalWord);
            }
            GenerateTranslationWord();

            answered = false;
            isTranslationGiven = false;
            isDescriptionGiven = false;

            return examinationalWord;
        }
        private IEnumerable<Word> GenerateTranslationWords(Word originalWord)
        {
            Word translationWord = null;
            IEnumerable<Word> translationWords = allWords.Where(w => w.TranslationId == originalWord.TranslationId && w.Id != originalWord.Id && w.LanguageId != originalWord.LanguageId);
            if (translationWords.Count() == 0) return null;
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
            GenerateTranslationWord();
            if (!isTranslationGiven)
            {
                DecreaseTranslationKnowledge();
                isTranslationGiven = true;
            }
            return openableTranslation;
        }
        public Language GetTranslationLanguage()
        {
            return entitiesIterator.GetLanguages().First(l => l.Id == openableTranslation.LanguageId);
        }
        public Description GetDescription()
        {
            if (descriptions.Any(d => d.WordId == examinationalWord.Id))
            {
                if (!isDescriptionGiven)
                {
                    DecreaseTranslationKnowledge();
                    isDescriptionGiven = true;
                }
                return descriptions.First(d => d.WordId == examinationalWord.Id);
            }
            return null;
        }
        public bool IsTranslationCorrect(string text)
        {
            if (translationWords.Any(w => w.Text.ToLower() == text.ToLower()))
            {
                if (!answered)
                {
                    IncreaseTranslationKnowledge();
                    answered = true;
                }
                return true;
            }
            if (!answered)
            {
                DecreaseTranslationKnowledge();
                answered = true;
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
            examinationalWord.Priority--;
        }
        private void IncreaseTranslationKnowledge()
        {
            examinationalWord.Priority++;
        }
        private void GenerateTranslationWord()
        {
            if (openableTranslation == null || translationWords.All(w => w.Id != openableTranslation.Id))
            {
                openableTranslation = translationWords.ToList()[Selection.GetRandom(translationWords.Count())];
            }
        }
    }
}
