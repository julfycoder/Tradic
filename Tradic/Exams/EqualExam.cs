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

        IEnumerable<Word> allWords; 
        IEnumerable<Word> translationWords; 
        IEnumerable<Description> descriptions;
        IEnumerable<Language> languages;

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
            SortAllWords();
        }
        public Word GenerateWord()
        {
            FinishExamination();

            SortAllWords();
            translationWords = null;
            while (translationWords == null)
            {
                examinationalWord = allWords.ToList()[Selection.GetIndexByMRAlgo(allWords.Count())];
                translationWords = GenerateTranslationWords(examinationalWord);
            }
            GenerateTranslationWord();

            InitializeExaminaion();

            return examinationalWord;
        }
        private IEnumerable<Word> GenerateTranslationWords(Word originalWord)
        {
            Word translationWord = null;
            IEnumerable<Word> translationWords = allWords.Where(w => w.TranslationId == originalWord.TranslationId && w.Id != originalWord.Id && w.LanguageId != originalWord.LanguageId);//Getting exam word translations
            if (translationWords.Count() == 0) return null;                                                                                                                               //If they're not exist return null
            Language translationLanguage = languages.First(l => l.Id == translationWords.ToList()[Selection.GetRandom(translationWords.Count() - 1)].LanguageId);                         //Getting translation language
            translationWords = translationWords.Where(w => w.LanguageId == translationLanguage.Id);                                                                                       //Getting translation words that has obtained language

            if (translationWords != null)
            {
                translationWord = translationWords.ToList()[Selection.GetRandom(translationWords.Count() - 1)];                                                                           //Getting translation word from available
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
            if (translationWords.Any(w => w.Text.ToLower() == text.ToLower()))  //If correct
            {
                if (!answered) IncreaseTranslationKnowledge();
                return true;
            }
            if (!answered) DecreaseTranslationKnowledge();                      //If not correct
            answered = true;
            return false;
        }

        private void SortAllWords()
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

        private void InitializeExaminaion()
        {
            answered = false;
            isTranslationGiven = false;
            isDescriptionGiven = false;
        }
        private void FinishExamination()
        {
            if (examinationalWord != null)
            {
                if (!answered) DecreaseTranslationKnowledge();
                SaveChangedWord();
            }
        }
    }
}
