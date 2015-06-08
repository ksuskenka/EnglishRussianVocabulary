using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using EnglishRussianTranslator.Common.Models;
using EnglishRussianTranslator.DataLayer;

namespace EnglishRussianTranslator.Client.ViewModels
{
    public class AddEditViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<LanguageModel> _languageType = new ObservableCollection<LanguageModel>();
        private LanguageModel _language = null;
        private ObservableCollection<WordModel> _translateVariations = new ObservableCollection<WordModel>();
        private string _mainWord = string.Empty;


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
        public string MainWord
        {
            get
            { return _mainWord; }
            set
            {
                _mainWord = value;
                OnPropertyChanged("MainWord");
            }
        }

        public void LoadViewModel(bool isAdd, WordModel wordModel, LanguageModel lang)
        {
            using (ServiceClient s = new ServiceClient())
            {
                var langTypes = s.GetAllLanguages();
                LanguageType = new ObservableCollection<LanguageModel>(langTypes);


                if (isAdd)
                {
                    CurrentLanguage = langTypes.FirstOrDefault();
                    TranslateVariations = new ObservableCollection<WordModel>();
                }
                else
                {
                    var model = s.GetModel(lang.ID, wordModel);
                    TranslateVariations =
                        new ObservableCollection<WordModel>(model.TranslationList.ToList().OrderBy(t => t.TranslationWord));
                }

            }

        }

        public void AddRow(string word)
        {
            if (!string.IsNullOrEmpty(word))
            {
                WordModel newModel = new WordModel { TranslationWord = word };
                TranslateVariations.Add(newModel);
            }
        }

        public void EditRow(WordModel model, string newWordValue)
        {
            if (model != null && !string.IsNullOrEmpty(newWordValue) && model.TranslationWord != newWordValue)
            {
                var update = TranslateVariations.FirstOrDefault(t => t.TranslationWord == model.TranslationWord);
                TranslateVariations.Remove(update);
                model.TranslationWord = newWordValue;
                TranslateVariations.Add(model);

                TranslateVariations = new ObservableCollection<WordModel>(TranslateVariations.ToList().OrderBy(t => t.TranslationWord));

            }
        }

        public void DeleteRow(WordModel model)
        {
            if (model != null)
            {
                var deleteTr = TranslateVariations.FirstOrDefault(t => t.TranslationWord == model.TranslationWord);
                TranslateVariations.Remove(deleteTr);
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
