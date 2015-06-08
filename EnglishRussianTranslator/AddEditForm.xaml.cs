using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EnglishRussianTranslator.Client.ViewModels;
using EnglishRussianTranslator.Common.Models;

namespace EnglishRussianTranslator
{
    /// <summary>
    /// Interaction logic for AddEditForm.xaml
    /// </summary>
    public partial class AddEditForm : Window
    {
        private TranslationModel _currentmodel = new TranslationModel();
        private WordModel _word = new WordModel();
        private WordModel _curentEditTrModel = new WordModel();
        private bool _isAdd;
        private int _langId = 0;
        public AddEditForm()
        {
            AddEditViewModel vm = new AddEditViewModel();
            DataContext = vm;
            InitializeComponent();
        }

        public void Init(bool isAdd, LanguageModel currentLang, WordModel word)
        {
            try
            {
                uiEndEditBtn.Visibility = Visibility.Hidden;

                _isAdd = isAdd;
                _word = word;
                ((AddEditViewModel)DataContext).LoadViewModel(_isAdd, word, currentLang);
                if (!isAdd)
                {
                    _currentmodel.MainWord = word;
                    uiMainWordTxt.Text = word.TranslationWord;
                    uiLanguageComboBox.SelectedItem = currentLang;
                    uiLanguageComboBox.IsEnabled = false;
                }

                ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Во время загрузки формы произошла ошибка", "ошибка");
            }

        }


        private void uiSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_isAdd)
                {
                    if (!string.IsNullOrEmpty(uiMainWordTxt.Text))
                    {
                        _currentmodel = new TranslationModel();
                        WordModel newMainWord = new WordModel { TranslationWord = uiMainWordTxt.Text };
                        _currentmodel.MainWord = newMainWord;
                        _currentmodel.TranslationList = ((AddEditViewModel)DataContext).TranslateVariations.ToArray();


                        using (ServiceClient s = new ServiceClient())
                        {
                            LanguageModel lang = (LanguageModel)uiLanguageComboBox.SelectedItem;
                            s.AddWord(lang.ID, _currentmodel);
                        }
                    }

                }
                else
                {
                    if (!string.IsNullOrEmpty(uiMainWordTxt.Text))
                    {
                        _currentmodel.MainWord = _word;
                        _currentmodel.TranslationList = ((AddEditViewModel) DataContext).TranslateVariations.ToArray();
                        using (ServiceClient s = new ServiceClient())
                        {

                            LanguageModel lang = (LanguageModel)uiLanguageComboBox.SelectedItem;
                            s.EditWord(lang.ID, _currentmodel);
                        }
                    }
                }
                MessageBox.Show("Сохранение перевода прошло успешно!");
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Сохранение не завершено!" + Environment.NewLine + " Во время сохранение произошла ошибка.", 
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void uiAddRowBtn_Click(object sender, RoutedEventArgs e)
        {
            //uiTranslationDataGrid.Items.Add(new WordModel());
            ((AddEditViewModel)DataContext).AddRow(uiNewTranslationTxt.Text);

            uiNewTranslationTxt.Text = string.Empty;
        }

        private void uiEditRowBtn_Click(object sender, RoutedEventArgs e)
        {
            if (uiTranslationDataGrid.SelectedItem != null)
            {
                _curentEditTrModel = (WordModel)uiTranslationDataGrid.SelectedItem;
                uiNewTranslationTxt.Text = _curentEditTrModel.TranslationWord;
                uiEndEditBtn.Visibility = Visibility.Visible;
            }

        }

        private void uiEndEditBtn_Click(object sender, RoutedEventArgs e)
        {
            uiEndEditBtn.Visibility = Visibility.Hidden;
            ((AddEditViewModel) DataContext).EditRow(_curentEditTrModel, uiNewTranslationTxt.Text);
            uiNewTranslationTxt.Text = string.Empty;
        }

        private void uiDeleteRowBtn_Click(object sender, RoutedEventArgs e)
        {
            if (uiTranslationDataGrid.SelectedItem != null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить этот вариант перевода?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    WordModel wordToDelete = (WordModel)uiTranslationDataGrid.SelectedItem;
                    ((AddEditViewModel)DataContext).DeleteRow(wordToDelete);
                }
               
            }
        }
    }
}
