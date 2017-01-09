using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;

using Tradic.View.Pages;
using Tradic.Commands;
using Tradic.Model;
using Tradic.Model.Entity;
using System.Windows;


namespace Tradic.ViewModel
{
    class AddWordPageViewModel : ViewModel
    {
        IAccessible dataAccess;
        Page currentPage;
        public AddWordPageViewModel(Page currentPage)
            : base()
        {
            this.currentPage = currentPage;
        }

        #region Initialize

        protected override void InitializeFields()
        {
            dataAccess = TradicAccessible.GetInstance();
        }
        protected override void InitializeCommands()
        {
            GoToMainPageCommand = new Command(arg => GoToMainPage(currentPage));
            AddNewWordCommand = new Command(arg => AddNewWord());
        }
        protected override void InitializeProperties()
        {
            OriginalLanguages = new ObservableCollection<Language>(dataAccess.GetLanguages());
        }

        #endregion

        #region Commands

        public ICommand GoToMainPageCommand { get; set; }
        void GoToMainPage(Page currentPage)
        {
            currentPage.NavigationService.Navigate(new MainPage());
        }

        public ICommand AddNewWordCommand { get; set; }
        void AddNewWord()
        {
            if ((OriginalWordText != null && OriginalWordText != "") &&
                (TranslationWordText != null && TranslationWordText != "") &&
                (SelectedOriginalLanguage != null && SelectedTranslationLanguage != null))
            {
                dataAccess.AddEntity(new Translation());
                Translation translation = dataAccess.GetTranslations().Last();

                dataAccess.AddEntity(new Word { Text = OriginalWordText, LanguageId = SelectedOriginalLanguage.Id, TranslationId = translation.Id });
                dataAccess.AddEntity(new Description { Text = OriginalWordDescription, WordId = dataAccess.GetWords().Last().Id });
                dataAccess.AddEntity(new Word { Text = TranslationWordText, LanguageId = SelectedTranslationLanguage.Id, TranslationId = translation.Id });
                dataAccess.AddEntity(new Description { Text = TranslationWordDescription, WordId = dataAccess.GetWords().Last().Id });
                OriginalWordText = "";
                TranslationWordText = "";
                OriginalWordDescription = "";
                TranslationWordDescription = "";
            }
            else if (OriginalWordText == "" || OriginalWordText == null) MessageBox.Show("You must enter original word", "Enter warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (TranslationWordText == "" || TranslationWordText == null) MessageBox.Show("You mus enter translation word", "Enter warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        #endregion

        #region Properties

        ObservableCollection<Language> _original_languages;
        public ObservableCollection<Language> OriginalLanguages
        {
            get
            {
                return _original_languages;
            }
            set
            {
                _original_languages = value;
                SelectedOriginalLanguage = OriginalLanguages[0];
                TranslationLanguages = new ObservableCollection<Language>(OriginalLanguages.Where(l => l.Id != _selected_original_language.Id));
                SelectedTranslationLanguage = TranslationLanguages[0];//////////////////////////////////////////////////
            }
        }

        ObservableCollection<Language> _translation_languages;
        public ObservableCollection<Language> TranslationLanguages
        {
            get
            {
                return _translation_languages;
            }
            set
            {
                _translation_languages = value;
                NotifyPropertyChanged("TranslationLanguages");
            }
        }

        Language _selected_original_language;
        public Language SelectedOriginalLanguage
        {
            get
            {
                return _selected_original_language;
            }
            set
            {
                _selected_original_language = value;
                TranslationLanguages = new ObservableCollection<Language>(OriginalLanguages.Where(l => l.Id != _selected_original_language.Id));
                SelectedTranslationLanguage = TranslationLanguages[0];
                NotifyPropertyChanged("SelectedOriginalLanguage");
            }
        }

        Language _selected_translation_language;
        public Language SelectedTranslationLanguage
        {
            get
            {
                return _selected_translation_language;
            }
            set
            {
                _selected_translation_language = value;
                NotifyPropertyChanged("SelectedTranslationLanguage");
            }
        }

        string _original_word_text;
        public string OriginalWordText
        {
            get
            {
                return _original_word_text;
            }
            set
            {
                _original_word_text = value;
                if (_original_word_text == " ") _original_word_text = "";
                NotifyPropertyChanged("OriginalWordText");
            }
        }

        string _translation_word_text;
        public string TranslationWordText
        {
            get
            {
                return _translation_word_text;
            }
            set
            {
                _translation_word_text = value;
                if (_translation_word_text == " ") _translation_word_text = "";
                NotifyPropertyChanged("TranslationWordText");
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

        string _translationWordDescription;
        public string TranslationWordDescription
        {
            get
            {
                return _translationWordDescription;
            }
            set
            {
                _translationWordDescription = value;
                NotifyPropertyChanged("TranslationWordDescription");
            }
        }

        #endregion
    }
}
