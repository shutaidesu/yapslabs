using System.Windows;

namespace lab5
{
    public partial class SearchResultsWindow : Window
    {
        public SearchResultsWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
