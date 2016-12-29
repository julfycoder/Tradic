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
        public TestingPageViewModel(Page currentPage)
        {
            this.currentPage = currentPage;
            dataAccess = TradicAccessible.GetInstance();
            Words = new ObservableCollection<Word>(dataAccess.GetWords());
            takenWord = Words[Selection.GetIndexByMRAlgo(Words.Count)];
            Initialize();
        }

        #region Initialization

        void Initialize()
        {
            InitializeCommands();
            InitializeProperties();
        }
        void InitializeCommands()
        {
            GoToMainPageCommand = new Command(arg => GoToMainPage(currentPage));
        }
        void InitializeProperties()
        {
            OriginalWord = takenWord.Text;
            TranslationLanguage=
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
                NotifyPropertyChanged("OrignalWord");
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

        string _translation_language;
        public string TranslationLanguage
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
