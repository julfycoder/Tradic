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


namespace Tradic.ViewModel
{
    class AddWordPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        IAccessible dataAccess;
        public AddWordPageViewModel(Page currentPage)
        {
            dataAccess = TradicAccessible.GetInstance();
            OriginalLanguages = new ObservableCollection<string> { "English", "Russian" };
            SelectedOriginalLanguage = OriginalLanguages[0];
            GoToMainPageCommand = new Command(arg => GoToMainPage(currentPage));
            AddNewWordCommand = new Command(arg => AddNewWord());
        }

        void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Commands

        public ICommand GoToMainPageCommand { get; set; }
        void GoToMainPage(Page currentPage)
        {
            currentPage.NavigationService.Navigate(new MainPage());
        }

        public ICommand AddNewWordCommand { get; set; }
        void AddNewWord()
        {
            if (OriginalWordText != null && TranslationWordText != null&&(SelectedOriginalLanguage!=null&&SelectedTranslationLanguage!=null))
            {
                dataAccess.AddEntity(new Translation());
                Translation translation = dataAccess.GetTranslations().Last();

                dataAccess.AddEntity(new Word { Text = OriginalWordText, Language = SelectedOriginalLanguage, TranslationId = translation.Id });
                dataAccess.AddEntity(new Word { Text = TranslationWordText, Language = SelectedTranslationLanguage, TranslationId = translation.Id });
                OriginalWordText = "";
                TranslationWordText = "";
            }
        }

        #endregion

        #region Properties

        ObservableCollection<string> _original_languages;
        public ObservableCollection<string> OriginalLanguages
        {
            get
            {
                return _original_languages;
            }
            set
            {
                _original_languages = value;
                TranslationLanguages = new ObservableCollection<string>(OriginalLanguages.Where(l => l != _selected_original_language));
                SelectedTranslationLanguage = TranslationLanguages[0];//////////////////////////////////////////////////
            }
        }

        ObservableCollection<string> _translation_languages;
        public ObservableCollection<string> TranslationLanguages
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

        string _selected_original_language;
        public string SelectedOriginalLanguage
        {
            get
            {
                return _selected_original_language;
            }
            set
            {
                _selected_original_language = value;
                TranslationLanguages = new ObservableCollection<string>(OriginalLanguages.Where(l => l != _selected_original_language));
                NotifyPropertyChanged("SelectedOriginalLanguage");
            }
        }

        string _selected_translation_language;
        public string SelectedTranslationLanguage
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
                NotifyPropertyChanged("TranslationWordText");
            }
        }

        #endregion
    }
}
