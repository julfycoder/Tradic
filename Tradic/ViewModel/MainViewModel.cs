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
using System.Windows;

namespace Tradic.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        IAccessible dataAccess;
        public event PropertyChangedEventHandler PropertyChanged;
        ObservableCollection<Word> Words;
        ObservableCollection<Description> Descriptions;
        Page currentPage;

        public MainViewModel(Page currentPage)
        {
            this.currentPage = currentPage;
            dataAccess = TradicAccessible.GetInstance();
            Words = new ObservableCollection<Word>(dataAccess.GetWords());
            Descriptions = new ObservableCollection<Description>(dataAccess.GetDescriptions());
            OriginalLanguages = new ObservableCollection<Language>(dataAccess.GetLanguages());
            Initialize();
            PropertyChanged += UpdateTranslations;
            PropertyChanged += UpdateOriginalDescription;
            PropertyChanged += UpdateTranslationDescription;
        }

        #region Initialization

        void Initialize()
        {
            InitializeCommands();
            InitializeProperties();
        }
        void InitializeCommands()
        {
            RemoveTranslationCommand = new Command(arg => RemoveTranslation());
            RemoveOriginalWordCommand = new Command(arg => RemoveOriginalWord());
            GoToAddWordPageCommand = new Command(arg => GoToAddWordPage(currentPage));
            AddNewTranslationCommand = new Command(arg => AddNewTranslation());
            GoToTestingPageCommand = new Command(arg => GoToTestingPage(currentPage));
            SaveOriginalWordDescriptionCommand = new Command(arg => SaveOriginalWordDescription());
            SaveTranslationWordDescriptionCommand = new Command(arg => SaveTranslationWordDescription());
        }
        void InitializeProperties()
        {
            SelectedOriginalLanguage = OriginalLanguages.ToList()[0];
            OriginalWords = new ObservableCollection<Word>(Words.Where(w => w.LanguageId == SelectedOriginalLanguage.Id));
            TranslationWords = new ObservableCollection<Word>();
        }

        #endregion

        void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        void UpdateTranslations(object sender, PropertyChangedEventArgs e)
        {
            if ((e.PropertyName == "SelectedOriginalWord" || e.PropertyName == "SelectedTranslationLanguage") && SelectedTranslationLanguage != null && SelectedOriginalWord != null)
                TranslationWords = new ObservableCollection<Word>(Words.Where(w => w.LanguageId == SelectedTranslationLanguage.Id && w.TranslationId == SelectedOriginalWord.TranslationId).ToList());
            if (e.PropertyName == "SelectedOriginalLanguage") TranslationWords.Clear();
        }
        void UpdateOriginalDescription(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedOriginalWord" && SelectedOriginalWord != null && Descriptions.ToList().Exists(d => d.WordId == SelectedOriginalWord.Id))
            {
                OriginalWordDescription = Descriptions.First(d => d.WordId == SelectedOriginalWord.Id).Text;
            }
            else if ((e.PropertyName != "SelectedOriginalWord" || SelectedOriginalWord == null || !Descriptions.ToList().Exists(d => d.WordId == SelectedOriginalWord.Id)) &&
                OriginalWordDescription != "" &&
                OriginalWordDescription != null &&
                (e.PropertyName == "SelectedOriginalLanguage" || e.PropertyName == "SelectedOriginalWord"))
            {
                OriginalWordDescription = "";
            }
        }
        void UpdateTranslationDescription(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedTranslationWord" && SelectedTranslationWord != null && Descriptions.ToList().Exists(d => d.WordId == SelectedTranslationWord.Id))
            {
                TranslationWordDescription = Descriptions.First(d => d.WordId == SelectedTranslationWord.Id).Text;
            }
            else if ((e.PropertyName != "SelectedTranslationWord" || SelectedTranslationWord == null || !Descriptions.ToList().Exists(d => d.WordId == SelectedTranslationWord.Id)) &&
                TranslationWordDescription != "" &&
                TranslationWordDescription != null &&
                e.PropertyName != "TranslationWordDescription" &&
                e.PropertyName != "OriginalWordDescription")
            {
                TranslationWordDescription = "";
            }
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
                Descriptions.Remove(Descriptions.First(d => d.WordId == SelectedTranslationWord.Id));

                Words.Remove(Words.First(w => w.Id == SelectedTranslationWord.Id));
                TranslationWords.Remove(SelectedTranslationWord);
            }
            else MessageBox.Show("You must select translation", "Selection warning", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                Descriptions.Remove(Descriptions.First(d => d.WordId == SelectedOriginalWord.Id));

                Words.Remove(Words.First(w => w.Id == SelectedOriginalWord.Id));
                OriginalWords.Remove(SelectedOriginalWord);
                TranslationWords.Clear();
            }
            else MessageBox.Show("You must select original word", "Selection warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public ICommand AddNewTranslationCommand { get; set; }
        void AddNewTranslation()
        {
            if (SelectedOriginalLanguage != null && SelectedTranslationLanguage != null && SelectedOriginalWord != null && TranslationWord != null && TranslationWord != "")
            {
                Word lastWord = dataAccess.GetWords().Last();
                Word translation = new Word { Id = lastWord.Id + 1, Text = TranslationWord, LanguageId = SelectedTranslationLanguage.Id, TranslationId = SelectedOriginalWord.TranslationId };
                dataAccess.AddEntity(translation);
                Words.Add(translation);
                TranslationWords.Add(translation);
                TranslationWord = "";
            }
            else if (SelectedOriginalLanguage == null) MessageBox.Show("You must select original language", "Language warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (SelectedTranslationLanguage == null) MessageBox.Show("You must select translation language", "Language warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (SelectedOriginalWord == null) MessageBox.Show("You must select original word", "Selection warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (TranslationWord == null || TranslationWord == "") MessageBox.Show("You must enter translation", "Translation warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public ICommand GoToTestingPageCommand { get; set; }
        void GoToTestingPage(Page currentPage)
        {
            currentPage.NavigationService.Navigate(new TestingPage());
        }

        public ICommand SaveOriginalWordDescriptionCommand { get; set; }
        public void SaveOriginalWordDescription()
        {
            if (SelectedOriginalWord != null)
            {
                Description description;
                if (dataAccess.GetDescriptions().ToList().Exists(d => d.WordId == SelectedOriginalWord.Id))
                {
                    description = dataAccess.GetDescriptions().First(d => d.WordId == SelectedOriginalWord.Id);
                    description.Text = OriginalWordDescription;
                    dataAccess.ChangeEntity(description);
                    Descriptions.First(d => d.WordId == SelectedOriginalWord.Id).Text = OriginalWordDescription;
                }
                else
                {
                    description = new Description { WordId = SelectedOriginalWord.Id, Text = OriginalWordDescription };
                    dataAccess.AddEntity(description);
                    Descriptions.Add(dataAccess.GetDescriptions().Last());
                }
            }
            else MessageBox.Show("You must choose original word", "Choose warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public ICommand SaveTranslationWordDescriptionCommand { get; set; }
        public void SaveTranslationWordDescription()
        {
            if (SelectedTranslationWord != null)
            {
                Description description;
                if (dataAccess.GetDescriptions().ToList().Exists(d => d.WordId == SelectedTranslationWord.Id))
                {
                    description = Descriptions.First(d => d.WordId == SelectedTranslationWord.Id);
                    description.Text = TranslationWordDescription;
                    dataAccess.ChangeEntity(description);
                    Descriptions.First(d => d.WordId == SelectedTranslationWord.Id).Text = TranslationWordDescription;
                }
                else
                {
                    description = new Description { WordId = SelectedTranslationWord.Id, Text = TranslationWordDescription };
                    dataAccess.AddEntity(description);
                    Descriptions.Add(dataAccess.GetDescriptions().Last());
                }
            }
            else MessageBox.Show("You must choose translation word", "Choose warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        #endregion

        #region Properties

        public ObservableCollection<Language> OriginalLanguages
        {
            get;
            set;
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
                OriginalWords = new ObservableCollection<Word>(dataAccess.GetWords().Where(w => w.LanguageId == SelectedOriginalLanguage.Id));
                TranslationLanguages = new ObservableCollection<Language>(OriginalLanguages.Where(l => l != _selected_original_language));
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

        Word _selectedTranslationWord;
        public Word SelectedTranslationWord
        {
            get
            {
                return _selectedTranslationWord;
            }
            set
            {
                _selectedTranslationWord = value;
                NotifyPropertyChanged("SelectedTranslationWord");
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
                if (_translation_word == " ") _translation_word = "";
                NotifyPropertyChanged("TranslationWord");
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
