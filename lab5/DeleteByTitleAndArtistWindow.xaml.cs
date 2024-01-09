using System.Windows;

namespace lab5
{
    public partial class DeleteByTitleAndArtistWindow : Window
    {
        public string Title { get; private set; }
        public string Artist { get; private set; }

        public DeleteByTitleAndArtistWindow()
        {
            InitializeComponent();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Artist = artistTextBox.Text;
            Title = titleTextBox.Text;
            Close();
        }
    }
}
