using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;

using Tradic.Model.Entity;
using Tradic.Model;
using Tradic.Commands;
using Tradic.View.Pages;
using Tradic.Algorithmics;
using System.Windows;

namespace Tradic.ViewModel
{
    class TestingPageViewModel:INotifyPropertyChanged
    {
        IAccessible dataAccess;
        Page currentPage;
        ObservableCollection<Word> Words;
        Word originalWord;
        IEnumerable<Word> translationWords;
        IEnumerable<Language> languages;
        public TestingPageViewModel(Page currentPage)
        {
            this.currentPage = currentPage;
            dataAccess = TradicAccessible.GetInstance();
            Words = new ObservableCollection<Word>(dataAccess.GetWords());
            languages = dataAccess.GetLanguages();
            Initialize();
        }

        #region Initialization

        void Initialize()
        {
            InitializeCommands();
            InitializeProperties();
            GenerateTestPair();
        }
        void InitializeCommands()
        {
            GoToMainPageCommand = new Command(arg => GoToMainPage(currentPage));
            GenerateTestCommand = new Command(arg => GenerateTest());
            ApplyCommand = new Command(arg => Apply());
        }
        void InitializeProperties()
        {
            
        }

        #endregion

        #region TestGenerating

        void GenerateTestPair()
        {
            originalWord = null;
            translationWords = null;
            
            while (translationWords == null)
            {
                originalWord = GenerateOriginalWord();
                translationWords = GenerateTranslationWords(originalWord);
            }

            OriginalWord = originalWord.Text;
            TranslationLanguage = languages.First(l => l.Id == translationWords.ToList()[0].LanguageId);
        }
        Word GenerateOriginalWord()
        {
            return Words[Selection.GetIndexByMRAlgo(Words.Count)];
        }
        IEnumerable<Word> GenerateTranslationWords(Word originalWord)
        {
            Word translationWord = null;
            IEnumerable<Word> translationWords = Words.Where(w => w.TranslationId == originalWord.TranslationId && w.Id != originalWord.Id && w.LanguageId != originalWord.LanguageId);
            Language language = languages.First(l => l.Id == translationWords.ToList()[Selection.GetRandom(translationWords.Count() - 1)].LanguageId);
            translationWords = translationWords.Where(w => w.LanguageId == language.Id);

            if (translationWords != null)
            {
                translationWord = translationWords.ToList()[Selection.GetRandom(translationWords.Count() - 1)];
            }
            return translationWords;
        }

        #endregion

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Commands

        public ICommand GoToMainPageCommand { get; set; }
        void GoToMainPage(Page currentPage)
        {
            currentPage.NavigationService.Navigate(new MainPage());
        }
        public ICommand GenerateTestCommand { get; set; }
        void GenerateTest()
        {
            GenerateTestPair();
            TranslationWord = "";
        }
        public ICommand ApplyCommand { get; set; }
        void Apply()
        {
            if (translationWords.Any(w => w.Text.ToLower() == TranslationWord.ToLower()))
            {
                GenerateTest();
            }
            else MessageBox.Show("Your translation is incorrect!", "Incorrect translation", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        #endregion

        #region Properties

        string _original_word;
        public string OriginalWord
        {
            get
            {
                return _original_word.ToUpperInvariant();
            }
            set
            {
                _original_word = value;
                NotifyPropertyChanged("OriginalWord");
            }
        }

        string _translation_word;
        public string TranslationWord
        {
            get
            {
                return _translation_word;
            }
            set
            {
                _translation_word = value;
                NotifyPropertyChanged("TranslationWord");
            }
        }

        Language _translation_language;
        public Language TranslationLanguage
        {
            get
            {
                return _translation_language;
            }
            set 
            {
                _translation_language = value;
                NotifyPropertyChanged("TranslationLanguage");
            }
        }

        #endregion
    }
}
