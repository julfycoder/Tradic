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

namespace Tradic.ViewModel
{
    class TestingPageViewModel:INotifyPropertyChanged
    {
        IAccessible dataAccess;
        Page currentPage;
        ObservableCollection<Word> Words;
        Word takenWord;
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
            GenerateTestWord();
        }
        void InitializeCommands()
        {
            GoToMainPageCommand = new Command(arg => GoToMainPage(currentPage));
            NextWordCommand = new Command(arg => NextWord());
        }
        void InitializeProperties()
        {
            
        }

        #endregion

        void GenerateTestWord()
        {
            TranslationLanguage = null;
            while (TranslationLanguage == null)
            {
                takenWord = Words[Selection.GetIndexByMRAlgo(Words.Count)];
                OriginalWord = takenWord.Text;

                if (Words.Where(w => w.TranslationId == takenWord.TranslationId && w.Id != takenWord.Id) != null)
                {
                    IEnumerable<Word> sameTranslationWords = Words.Where(w => w.TranslationId == takenWord.TranslationId && w.Id != takenWord.Id);
                    List<Language> sameTranslationWordsLanguages = new List<Language>();

                    foreach (Word w in sameTranslationWords)
                    {
                        if (!sameTranslationWordsLanguages.Contains(languages.First(l => l.Id == w.LanguageId)))
                            sameTranslationWordsLanguages.Add(languages.First(l => l.Id == w.LanguageId));
                    }
                    if (sameTranslationWordsLanguages.Count > 0)
                        TranslationLanguage = sameTranslationWordsLanguages[Selection.GetRandom(sameTranslationWordsLanguages.Count - 1)];
                    else TranslationLanguage = sameTranslationWordsLanguages[0];
                }
            }
        }

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
        public ICommand NextWordCommand { get; set; }
        void NextWord()
        {
            GenerateTestWord();
        }

        #endregion

        #region Properties

        string _original_word;
        public string OriginalWord
        {
            get
            {
                return _original_word;
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
