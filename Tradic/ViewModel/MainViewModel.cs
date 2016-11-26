using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Tradic.Model;
using Tradic.Model.Entity;
using System.Windows.Controls;
using Tradic.Commands;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Tradic.View.Pages;

namespace Tradic.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        IAccessible dataAccess;
        public event PropertyChangedEventHandler PropertyChanged;
        ObservableCollection<Word> Words;

        public MainViewModel(Page currentPage)
        {
            dataAccess = new TradicAccessible();
            Words = new ObservableCollection<Word>(dataAccess.GetWords().ToList());

            OriginalLanguages = new ObservableCollection<string> { "English", "Russian" };
            SelectedOriginalLanguage = OriginalLanguages.ToList()[0];
            OriginalWords = new ObservableCollection<Word>(Words.Where(w => w.Language == SelectedOriginalLanguage));
            PropertyChanged += UpdateTranslations;

            RemoveTranslationCommand = new Command(arg=>RemoveTranslation());
            RemoveOriginalWordCommand = new Command(arg => RemoveOriginalWord());
            GoToAddWordPageCommand = new Command(arg => GoToAddWordPage(currentPage));
            AddNewTranslationCommand = new Command(arg => AddNewTranslation());
            TranslationWords = new ObservableCollection<Word>();
        }

        void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        void UpdateTranslations(object sender, PropertyChangedEventArgs e)
        {
            if ((e.PropertyName == "SelectedOriginalWord" || e.PropertyName == "SelectedTranslationLanguage") && SelectedTranslationLanguage != null && SelectedOriginalWord != null)
                TranslationWords = new ObservableCollection<Word>(Words.Where(w => w.Language == SelectedTranslationLanguage && w.TranslationId == SelectedOriginalWord.TranslationId).ToList());
            if (e.PropertyName == "SelectedOriginalLanguage") TranslationWords.Clear();
        }

        #region Commands
        public ICommand GoToAddWordPageCommand { get; set; }
        void GoToAddWordPage(Page currentPage)
        {
            currentPage.NavigationService.Navigate(new AddWordPage());
        }

        public ICommand RemoveTranslationCommand { get; set; }
        void RemoveTranslation()
        {
            if (SelectedTranslationWord != null)
            {
                if (dataAccess.GetWords().Where(w => w.TranslationId == SelectedTranslationWord.TranslationId).Count() > 1)
                    dataAccess.RemoveEntity(SelectedTranslationWord);
                else
                {
                    dataAccess.RemoveEntity(SelectedTranslationWord);
                    dataAccess.RemoveEntity(dataAccess.GetTranslations().Where(t => t.Id == SelectedTranslationWord.TranslationId).Last());
                }

                Words.Remove(Words.First(w => w.Id == SelectedTranslationWord.Id));
                TranslationWords.Remove(SelectedTranslationWord);
            }
        }

        public ICommand RemoveOriginalWordCommand { get; set; }
        void RemoveOriginalWord()
        {
            if (SelectedOriginalWord != null)
            {
                if (dataAccess.GetWords().Where(w => w.TranslationId == SelectedOriginalWord.TranslationId).Count() > 1)
                    dataAccess.RemoveEntity(SelectedOriginalWord);
                else
                {
                    dataAccess.RemoveEntity(SelectedOriginalWord);
                    dataAccess.RemoveEntity(dataAccess.GetTranslations().Where(t => t.Id == SelectedOriginalWord.TranslationId).Last());
                }

                Words.Remove(Words.First(w => w.Id == SelectedOriginalWord.Id));
                OriginalWords.Remove(SelectedOriginalWord);
                TranslationWords.Clear();
            }
        }

        public ICommand AddNewTranslationCommand { get; set; }
        void AddNewTranslation()
        {
            if (SelectedOriginalLanguage != null && SelectedTranslationLanguage != null && SelectedOriginalWord != null&&TranslationWord!=null)
            {
                Word translation = new Word { Text = TranslationWord, Language = SelectedTranslationLanguage, TranslationId = SelectedOriginalWord.TranslationId };
                dataAccess.AddEntity(translation);
                Words.Add(translation);
                TranslationWords.Add(translation);
            }
        }

        #endregion

        #region Properties

        public ObservableCollection<string> OriginalLanguages
        {
            get;
            set;
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

        ObservableCollection<Word> _original_words;
        public ObservableCollection<Word> OriginalWords
        {
            get
            {
                return _original_words;
            }
            set
            {
                _original_words = value;
                NotifyPropertyChanged("OriginalWords");
            }
        }

        ObservableCollection<Word> _translation_words;
        public ObservableCollection<Word> TranslationWords
        {
            get
            {
                return _translation_words;
            }
            set 
            {
                _translation_words = value;
                NotifyPropertyChanged("TranslationWords");
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
                OriginalWords = new ObservableCollection<Word>(dataAccess.GetWords().Where(w => w.Language == SelectedOriginalLanguage));
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

        Word _selected_original_word;
        public Word SelectedOriginalWord
        {
            get
            {
                return _selected_original_word;
            }
            set
            {
                _selected_original_word = value;
                NotifyPropertyChanged("SelectedOriginalWord");
            }
        }

        public Word SelectedTranslationWord
        {
            get;
            set;
        }

        public string TranslationWord
        {
            get;
            set;
        }

        #endregion
    }
}
