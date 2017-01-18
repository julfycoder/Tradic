using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;

using Tradic.Model.Entities;
using Tradic.Model;
using Tradic.Commands;
using Tradic.View.Pages;
using Tradic.Algorithmics;
using System.Windows;
using Tradic.Exams;

namespace Tradic.ViewModel
{
    class TestingPageViewModel : ViewModel
    {
        ITradicIterator entitiesIterator;
        Page currentPage;
        IEnumerable<Language> languages;
        EqualExam equalExam;

        public TestingPageViewModel(Page currentPage)
            : base()
        {
            this.currentPage = currentPage;
        }

        #region Initialization

        protected override void InitializeFields()
        {
            entitiesIterator = TradicIterator.GetInstance();
            languages = entitiesIterator.GetLanguages();
            equalExam = new EqualExam(entitiesIterator);

            GenerateTest();
            TranslationLanguage = languages.First(l => l.Id == equalExam.GetTranslation().LanguageId);
        }
        protected override void InitializeCommands()
        {
            GoToMainPageCommand = new Command(arg => GoToMainPage(currentPage));
            GenerateTestCommand = new Command(arg => GenerateTest());
            ApplyCommand = new Command(arg => Apply());
            ShowOriginalWordDescriptionCommand = new Command(arg => ShowOriginalWordDescription());
            ShowNextLetterCommand = new Command(arg => ShowNextLetter());
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
            OriginalWord = equalExam.GenerateWord().Text;
            TranslationWord = "";
            OriginalWordDescription = null;
            TranslationLanguage = equalExam.GetTranslationLanguage();
        }

        public ICommand ApplyCommand { get; set; }
        void Apply()
        {
            if(equalExam.IsTranslationCorrect(TranslationWord))
            {
                GenerateTest();
            }
            else MessageBox.Show("Your translation is incorrect!", "Incorrect translation", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public ICommand ShowOriginalWordDescriptionCommand { get; set; }
        void ShowOriginalWordDescription()
        {
            if (equalExam.GetDescription() != null)
            {
                OriginalWordDescription = equalExam.GetDescription().Text;
            }
        }

        public ICommand ShowNextLetterCommand { get; set; }
        void ShowNextLetter()
        {
            Word openableTranslation = equalExam.GetTranslation();
            if (TranslationWord == null || TranslationWord == "")
            {
                TranslationWord = openableTranslation.Text[0].ToString();
            }
            else
            {
                if (TranslationWord.Length < openableTranslation.Text.Length &&
                    openableTranslation.Text.Substring(0, TranslationWord.Length) == TranslationWord)
                {
                    TranslationWord += openableTranslation.Text[TranslationWord.Length];
                }
                else
                {
                    for (int i = 0; i < TranslationWord.Length; i++)
                    {
                        if (TranslationWord[i] != openableTranslation.Text[i])
                        {
                            TranslationWord = openableTranslation.Text.Substring(0, i + 1);
                            break;
                        }
                    }
                }
            }
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
                if (value != " ") _translation_word = value;
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

        string _originalWordDescription;
        public string OriginalWordDescription
        {
            get
            {
                return _originalWordDescription;
            }
            set
            {
                _originalWordDescription = value;
                NotifyPropertyChanged("OriginalWordDescription");
            }
        }

        #endregion
    }
}
