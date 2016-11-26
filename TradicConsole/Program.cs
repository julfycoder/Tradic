using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tradic.Business;
using Tradic.DAL;
using Tradic.DAL.Entity;

namespace TradicConsole
{
    class Program
    {
        public enum Languages
        {
            English,
            Russian,
            German,
            Spanish
        }
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.GetEncoding(1251);
            Console.OutputEncoding = Encoding.GetEncoding(1251);
            TradicDataAccess access = new TradicDataAccess();
            WordHelper helper = new WordHelper(access);
            TranslationHelper transHelper = new TranslationHelper(access);

            while (true)
            {
                Console.WriteLine("Add new word 'A', Add translation word 'B', Watch translations 'C', Remove translation 'D':");
                string inputOption = Console.ReadLine();
                switch (inputOption)
                {
                    case "A":
                        {
                            AddNewWord(transHelper, helper);
                        } break;
                    case "B":
                        {
                            AddTranslationWord(transHelper, helper);
                        } break;
                    case "C":
                        {
                            WatchTranslations(transHelper, helper);
                        } break;
                    case "D":
                        {
                            RemoveTranslation(transHelper, helper);
                        }break;
                    default: Console.WriteLine("Unrecognized command"); break;
                }
            }

            Console.ReadLine();
        }
        static Translation AddNewTranslation(TranslationHelper helper)
        {
            helper.AddEntity(new Translation());
            return (Translation)helper.GetTranslations().Last();
        }
        static void AddWord(WordHelper helper, Word word)
        {
            helper.AddEntity(word);
        }
        static IEnumerable<Word> GetWordsOfLanguage(WordHelper helper, string language)
        {
            return from g in helper.GetWords() where g.Language == language select g;
        }
        #region Clauses
        static void AddNewWord(TranslationHelper transHelper, WordHelper helper)
        {
            Console.WriteLine("Choose language:");
            foreach (Languages l in Enum.GetValues(typeof(Languages))) Console.Write(l + ", ");
            Console.WriteLine();
            string language = Console.ReadLine();

            Console.WriteLine("Enter word:");
            string word = Console.ReadLine();

            Console.WriteLine("Choose translation language:");
            foreach (Languages l in Enum.GetValues(typeof(Languages))) Console.Write(l + ", ");
            Console.WriteLine();
            string translationLanguage = Console.ReadLine();

            Console.WriteLine("Enter translation word:");
            string translationWord = Console.ReadLine();

            Translation trans = AddNewTranslation(transHelper);
            AddWord(helper, new Word { Text = word, Language = language, TranslationId = trans.Id });
            AddWord(helper, new Word { Text = translationWord, Language = translationLanguage, TranslationId = trans.Id });
        }
        static void AddTranslationWord(TranslationHelper transHelper, WordHelper helper)
        {
            Console.WriteLine("Choose language:");
            foreach (Languages l in Enum.GetValues(typeof(Languages))) Console.Write(l + ", ");
            Console.WriteLine();
            string language = Console.ReadLine();

            IEnumerable<Word> words = GetWordsOfLanguage(helper, language);
            Console.WriteLine("Choose original word:");
            for (int i = 0; i < words.Count(); i++)
            {
                Console.WriteLine(words.ToList()[i].Text + ": " + i);
            }

            Word originalWord = words.ToList()[int.Parse(Console.ReadLine())];

            Console.WriteLine("Choose translation language:");
            foreach (Languages l in Enum.GetValues(typeof(Languages))) Console.Write(l + ", ");
            Console.WriteLine();
            string translationLanguage = Console.ReadLine();

            Console.WriteLine("Enter translation word:");
            string translationWord = Console.ReadLine();

            AddWord(helper, new Word { Text = translationWord, Language = translationLanguage, TranslationId = originalWord.TranslationId });
        }
        static void WatchTranslations(TranslationHelper transHelper, WordHelper helper)
        {
            Console.WriteLine("Choose language:");
            foreach (Languages l in Enum.GetValues(typeof(Languages))) Console.Write(l + ", ");
            Console.WriteLine();
            string language = Console.ReadLine();

            IEnumerable<Word> words = GetWordsOfLanguage(helper, language);
            Console.WriteLine("Choose original word:");
            for (int i = 0; i < words.Count(); i++)
            {
                Console.WriteLine(words.ToList()[i].Text + ": " + i);
            }

            Word originalWord = words.ToList()[int.Parse(Console.ReadLine())];

            Console.WriteLine("Choose translation language:");
            foreach (Languages l in Enum.GetValues(typeof(Languages))) Console.Write(l + ", ");
            Console.WriteLine();
            string translationLanguage = Console.ReadLine();

            IEnumerable<Word> translations = from t in GetWordsOfLanguage(helper, translationLanguage) where t.TranslationId==originalWord.TranslationId select t;

            foreach (Word translation in translations) Console.WriteLine(translation.Text);
        }
        static void RemoveTranslation(TranslationHelper transHelper, WordHelper helper)
        {
            Console.WriteLine("Choose language:");
            foreach (Languages l in Enum.GetValues(typeof(Languages))) Console.Write(l + ", ");
            Console.WriteLine();
            string language = Console.ReadLine();

            IEnumerable<Word> words = GetWordsOfLanguage(helper, language);
            Console.WriteLine("Choose removable word:");
            for (int i = 0; i < words.Count(); i++)
            {
                Console.WriteLine(words.ToList()[i].Text + ": " + i);
            }

            Word originalWord = words.ToList()[int.Parse(Console.ReadLine())];

            if (helper.GetWords().Where(w => w.TranslationId == originalWord.TranslationId).Count() > 1)
            {
                helper.RemoveEntity(originalWord);
            }
            else
            {
                helper.RemoveEntity(originalWord);
                transHelper.RemoveEntity(transHelper.GetTranslations().Where(t => t.Id == originalWord.TranslationId).Last());
            }
        }
        #endregion
    }
}
