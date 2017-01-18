using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tradic.Business.Helper;
using Tradic.DAL;
using Tradic.DAL.Entity;
using System.Threading;

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
            TradicDataAccess access = TradicDataAccess.GetInstance();
            WordHelper wordHelper = new WordHelper(access);
            TranslationHelper transHelper = new TranslationHelper(access);
            LanguageHelper langHelper = new LanguageHelper(access);

            //Interview(transHelper, wordHelper,langHelper);
            //langHelper.AddEntity(new Language { Name = "English" });

            GetRandomWords(wordHelper,langHelper);

            //TradicContext con = new TradicContext();

            //con.Set<Language>().Add(new Language { Name = "Russian" });
            //con.SaveChanges();

            //IEnumerable<Language> languages = con.Languages;
            //foreach (Language l in languages)
            //{
            //    Console.WriteLine(l.Id + ": " + l.Name);
            //}

            Console.ReadLine();
        }
        //static void GetRandomWords2(WordHelper wordHelper)
        //{
        //    int x = 0;
        //    double amount;
        //    List<Word> Words = wordHelper.GetWords().ToList();
        //    amount = Words.Count;
        //    Random rnd = new Random();

        //    int[] counts = new int[(int)amount];
        //    foreach (Word w in Words)
        //    {
        //        Console.WriteLine(w.Text);
        //    }
        //    Console.WriteLine();
        //    while (true)
        //    {
        //        x = 0;
        //        amount = Words.Count;
        //        Thread.Sleep(rnd.Next(10));
        //        while (amount > 0.5)
        //        {
        //            int half = rnd.Next(2);
        //            half = rnd.Next(half + 1);
        //            amount -= ((int)amount) / (double)2;
        //            x += (int)(amount * half);
        //        }
        //        counts[x]++;
        //        Console.CursorLeft = 0;
        //        Console.CursorTop = Words.Count + 1;
        //        for (int i = 0; i < Words.Count; i++) Console.WriteLine(counts[i]);
        //    }
        //}
        static void GetRandomWords(WordHelper wordHelper,LanguageHelper langHelper)
        {
            //List<Word> Words = wordHelper.GetWords().Where(w => w.LanguageId == langHelper.GetLanguages().First(l => l.Name == "English").Id).ToList();
            List<Word> allWords = wordHelper.GetWords().ToList();
            List<Word> Words = new List<Word>();
            for (int i = 0; i < 12; i++)
            {
                Words.Add(allWords[i]);
            }
            

            int N = Words.Count;
            int delay = 150;
            int[] counts = new int[N];
            Random rnd = new Random();

            foreach (Word w in Words)
            {
                Console.WriteLine(w.Text);
            }
            Console.WriteLine();
            while (true)
            {
                Thread.Sleep(GetRandom(2, delay));
                double r1 = (double)rnd.Next(0, N + 1);
                Thread.Sleep(GetRandom(2, delay));
                double r2 = rnd.Next(0, (int)r1);

                double y = r2;
                counts[(int)y]++;

                Console.CursorLeft = 0;
                Console.CursorTop = N+1;
                for (int i = 0; i < N; i++)
                {
                    Console.WriteLine(counts[i]);
                }

                //Word bingo=Words[(int)y];
                //Console.Write(bingo.Text);

                //Console.ReadLine();
            }
        }
        static int GetRandom(int deep, int value)
        {
            Random rnd = new Random();
            if (deep > 0)
            {
                value = rnd.Next(GetRandom(deep - 1, value));
            }
            return value;
        }
        static void Interview(TranslationHelper transHelper, WordHelper wordHelper,LanguageHelper langHelper)
        {
            while (true)
            {
                Console.WriteLine("Add new word 'A', Add translation word 'B', Watch translations 'C', Remove translation 'D':");
                string inputOption = Console.ReadLine();
                switch (inputOption)
                {
                    case "A":
                        {
                            AddNewWord(transHelper, wordHelper,langHelper);
                        } break;
                    case "B":
                        {
                            AddTranslationWord(transHelper, wordHelper,langHelper);
                        } break;
                    case "C":
                        {
                            WatchTranslations(transHelper, wordHelper,langHelper);
                        } break;
                    case "D":
                        {
                            RemoveTranslation(transHelper, wordHelper,langHelper);
                        } break;
                    default: Console.WriteLine("Unrecognized command"); break;
                }
            }
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
        static IEnumerable<Word> GetWordsOfLanguage(WordHelper helper, Language language)
        {
            return from g in helper.GetWords() where g.LanguageId == language.Id select g;
        }
        #region Clauses
        static void AddNewWord(TranslationHelper transHelper, WordHelper helper,LanguageHelper langHelper)
        {
            Console.WriteLine("Choose language:");
            foreach (Languages l in Enum.GetValues(typeof(Languages))) Console.Write(l + ", ");
            Console.WriteLine();
            Language language = langHelper.GetLanguages().First(l=>l.Name==Console.ReadLine());

            Console.WriteLine("Enter word:");
            string word = Console.ReadLine();

            Console.WriteLine("Choose translation language:");
            foreach (Languages l in Enum.GetValues(typeof(Languages))) Console.Write(l + ", ");
            Console.WriteLine();
            Language translationLanguage = langHelper.GetLanguages().First(l => l.Name == Console.ReadLine());

            Console.WriteLine("Enter translation word:");
            string translationWord = Console.ReadLine();

            Translation trans = AddNewTranslation(transHelper);
            AddWord(helper, new Word { Text = word, LanguageId = language.Id, TranslationId = trans.Id });
            AddWord(helper, new Word { Text = translationWord, LanguageId = translationLanguage.Id, TranslationId = trans.Id });
        }
        static void AddTranslationWord(TranslationHelper transHelper, WordHelper helper,LanguageHelper langHelper)
        {
            Console.WriteLine("Choose language:");
            foreach (Languages l in Enum.GetValues(typeof(Languages))) Console.Write(l + ", ");
            Console.WriteLine();
            Language language = langHelper.GetLanguages().First(l => l.Name == Console.ReadLine());

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
            Language translationLanguage = langHelper.GetLanguages().First(l => l.Name == Console.ReadLine());


            Console.WriteLine("Enter translation word:");
            string translationWord = Console.ReadLine();

            AddWord(helper, new Word { Text = translationWord, Language = translationLanguage, TranslationId = originalWord.TranslationId });
        }
        static void WatchTranslations(TranslationHelper transHelper, WordHelper helper, LanguageHelper langHelper)
        {
            Console.WriteLine("Choose language:");
            foreach (Languages l in Enum.GetValues(typeof(Languages))) Console.Write(l + ", ");
            Console.WriteLine();
            Language language = langHelper.GetLanguages().First(l => l.Name == Console.ReadLine());

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
            Language translationLanguage = langHelper.GetLanguages().First(l => l.Name == Console.ReadLine());


            IEnumerable<Word> translations = from t in GetWordsOfLanguage(helper, translationLanguage) where t.TranslationId==originalWord.TranslationId select t;

            foreach (Word translation in translations) Console.WriteLine(translation.Text);
        }
        static void RemoveTranslation(TranslationHelper transHelper, WordHelper helper, LanguageHelper langHelper)
        {
            Console.WriteLine("Choose language:");
            foreach (Languages l in Enum.GetValues(typeof(Languages))) Console.Write(l + ", ");
            Console.WriteLine();
            Language language = langHelper.GetLanguages().First(l => l.Name == Console.ReadLine());

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
