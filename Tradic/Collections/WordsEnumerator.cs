using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tradic.Model.Entities;

namespace Tradic.Collections
{
    class WordsEnumerator
    {
        ITextEntityEnumerator enumerator;
        public WordsEnumerator()
        {
            enumerator = new TextEntityEnumerator();
        }
        public IEnumerable<Word> GetWordsSortedByAlphabet(IEnumerable<Word> words)
        {
            List<Word> sortedWords = new List<Word>();
            List<TextEntity> textEntities = new List<TextEntity>();
            foreach (Word w in words) textEntities.Add(w);

            foreach (TextEntity entity in enumerator.GetTextEntitiesSortedByAlphabet(textEntities))
                sortedWords.Add(words.First(w => w.Id == entity.Id));

            return sortedWords;
        }
        public IEnumerable<Word> GetWordsConversely(IEnumerable<Word> words)
        {
            return words.Reverse();
        }
        public IEnumerable<Word> GetWordsWhichContainSubstring(IEnumerable<Word> words, string substring)
        {
            List<Word> currentWords = new List<Word>();
            List<TextEntity> textEntities = new List<TextEntity>();
            foreach (Word w in words) textEntities.Add(w);

            foreach (TextEntity entity in enumerator.GetTextEntitiesWhichContainSubstring(textEntities, substring))
                currentWords.Add(words.First(w => w.Id == entity.Id));

            return currentWords;
        }
        public IEnumerable<Word> GetWordsSortedByKnowledge(IEnumerable<Word> words)
        {
            return words.OrderBy(w => w, new WordsComparer());
        }
    }
}
