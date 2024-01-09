using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace lab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static Catalog catalog;

        public MainWindow()
        {
            InitializeComponent();
            catalog = new Catalog();
            compositionListView.ItemsSource = catalog.Compositions;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddCompositionWindow addWindow = new AddCompositionWindow();
            addWindow.Owner = this; // Устанавливаем владельца для центрирования окна
            addWindow.ShowDialog();

            // Получаем данные из окна
            string artist = addWindow.Artist;
            string title = addWindow.Title;

            // Проверка на null предотвращает добавление пустой композиции
            if (!string.IsNullOrEmpty(artist) && !string.IsNullOrEmpty(title))
            {
                Composition newComposition = new Composition { Artist = artist, Title = title };
                catalog.AddComposition(newComposition);
                compositionListView.ItemsSource = catalog.GetCompositions(); // Обновляем список
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteByTitleAndArtistWindow deleteWindow = new DeleteByTitleAndArtistWindow();
            deleteWindow.Owner = this;
            deleteWindow.ShowDialog();

            string title = deleteWindow.Title;
            string artist = deleteWindow.Artist;

            // Вызываем метод Search для поиска композиции
            ObservableCollection<Composition> searchResults = catalog.Search(artist, title);

            if (searchResults.Count > 0)
            {
                foreach (var result in searchResults)
                {
                    catalog.RemoveComposition(result);
                }

                compositionListView.ItemsSource = catalog.Compositions; // Обновляем список
            }
            else
            {
                MessageBox.Show("Композиции с указанным названием и автором не найдены.");
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверка, выбрана ли композиция для редактирования
            if (compositionListView.SelectedItem != null)
            {
                // Создаем окно редактирования и передаем ему выбранную композицию
                EditCompositionWindow editWindow = new EditCompositionWindow((Composition)compositionListView.SelectedItem);
                editWindow.Owner = this;
                editWindow.ShowDialog();

                // Обновляем ListView после редактирования
                compositionListView.ItemsSource = catalog.Compositions;
            }
            else
            {
                MessageBox.Show("Выберите композицию для редактирования.");
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string criteria = searchTextBox.Text;

            if (searchCriteriaComboBox.SelectedItem != null)
            {
                string selectedCriteria = ((ComboBoxItem)searchCriteriaComboBox.SelectedItem).Content.ToString();
                ObservableCollection<Composition> searchResults;

                if (selectedCriteria == "Исполнитель")
                {
                    searchResults = catalog.Search(criteria);
                }
                else
                {
                    searchResults = catalog.Search(criteria, criteria);
                }

                DisplaySearchResultsInWindow(searchResults);
            }
        }

        private void DisplaySearchResultsInWindow(ObservableCollection<Composition> searchResults)
        {
            // Создайте и отобразите новое окно с результатами поиска
            var resultsWindow = new SearchResultsWindow();

            // Очистите предыдущие результаты из TextBox
            resultsWindow.searchResultsTextBox.Clear();

            if (searchResults.Count > 0)
            {
                // Выведите новые результаты в TextBox
                resultsWindow.searchResultsTextBox.Text = string.Join(Environment.NewLine, searchResults.Select(c => c.ToString()));
                resultsWindow.ShowDialog();
            }
            else
            {
                resultsWindow.searchResultsTextBox.Text = "Ничего не найдено.";
                resultsWindow.ShowDialog();
            }
        }




        private void searchCriteriaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
