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
using System.Windows.Navigation;
using System.Windows.Shapes;
using EnglishRussianTranslator.Client.ViewModels;
using EnglishRussianTranslator.Common.Models;
using EnglishRussianTranslator.DataLayer;

namespace EnglishRussianTranslator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            MainWindowViewModel vm = new MainWindowViewModel();
            DataContext = vm;
            InitializeComponent();
        }

        private void uiSearchTextbox_GotFocus(object sender, RoutedEventArgs e)
        {
            uiSearchTextbox.Text = string.Empty;
        }

        private void uiSearchTextbox_LostFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int langID = (int)LanguageEnum.English;


            ((MainWindowViewModel)DataContext).LoadViewModel(langID);
        }

        private void uiSearchBtn_Click(object sender, RoutedEventArgs e)
        {
            LanguageModel language = (LanguageModel) uiLanguageCbx.SelectedItem;
            ((MainWindowViewModel)DataContext).SearchTranslation(language.ID, uiSearchTextbox.Text);
        }

        private void uiAddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddEditForm addEditForm = new AddEditForm();
                addEditForm.Init(true, (LanguageModel)uiLanguageCbx.SelectedItem,null );
              
            }
            catch (Exception ex)
            {

                MessageBox.Show(string.Format("Message:{0} , Source: {1} , InnerException:{2}", ex.Message, ex.Source, ex.InnerException));
            }
           
        }

        private void uiDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (uiWordsDataGrid.SelectedItem != null)
                {
                    WordModel word = (WordModel)uiWordsDataGrid.SelectedItem;

                    ServiceClient s = new ServiceClient();
                    s.DeleteWord(word.ID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Во время удаления произошла ошибка", "ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            
            
        }

        private void uiEditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (uiWordsDataGrid.SelectedItem != null)
                {
                    WordModel word = (WordModel) uiWordsDataGrid.SelectedItem;
                    AddEditForm addEditForm = new AddEditForm();
                    addEditForm.Init(false, (LanguageModel)uiLanguageCbx.SelectedItem, word);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Во время редактирования произошла ошибка", "ошибка", MessageBoxButton.OK, MessageBoxImage.Error); 
            }
        }

       
}
}