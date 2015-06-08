using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnglishRussianTranslator.Common.Models;
using EnglishRussianTranslator.DataLayer;
using System.ComponentModel;
using System.Collections.ObjectModel;
using EnglishRussianTranslator.Common.Models;

namespace EnglishRussianTranslator.Client.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<WordModel> _translateVariations = new ObservableCollection<WordModel>();
        private string _searchWord = string.Empty;
        private ObservableCollection<LanguageModel> _languageType = null;
        private LanguageModel _language = null;


        public ObservableCollection<LanguageModel> LanguageType
        {
            get
            {
                return _languageType;
            }
            set
            {
                _languageType = value;
                OnPropertyChanged("LanguageType");
            }
        }
        public LanguageModel CurrentLanguage
        {
            get
            {
                return _language;
            }
            set
            {
                
                if (_language != value)
                {
                    this.ChangeLanguage(value.ID);
                }
                _language = value;
                OnPropertyChanged("CurrentLanguage");
            }
        }
        public ObservableCollection<WordModel> TranslateVariations
        {
            get
            {
                return _translateVariations;
            }
            set
            {
                _translateVariations = value;
                OnPropertyChanged("TranslateVariations");
            }
        }
        public string SearchWord
        {
            get
            { return _searchWord; }
            set
            {
                _searchWord = value;
                OnPropertyChanged("SearchWord");
            }
        }

        public void ChangeLanguage(int langId)
        {
            using (ServiceClient client = new ServiceClient())
            {
            
                var translate = client.GetWords(langId, "");
                TranslateVariations = new ObservableCollection<WordModel>(translate);
            }
        }
        public void LoadViewModel(int langID)
        {
                using (ServiceClient client = new ServiceClient())
                {
                    var langTypes = client.GetAllLanguages();
                    LanguageType = new ObservableCollection<LanguageModel>(langTypes);
                    CurrentLanguage = langTypes.FirstOrDefault(l => l.ID == langID);
                    var translate = client.GetWords(langID, "");
                    TranslateVariations = new ObservableCollection<WordModel>(translate);
                }
            
        }

        public void SearchTranslation(int langId, string searchWord)
        {
            using (ServiceClient client = new ServiceClient())
            {

                var translate = client.GetWords(langId, searchWord);
                TranslateVariations = new ObservableCollection<WordModel>(translate);
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
