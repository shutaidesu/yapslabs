using System.Windows;

namespace lab5
{
    public partial class EditCompositionWindow : Window
    {
        private Composition originalComposition;

        public EditCompositionWindow(Composition composition)
        {
            InitializeComponent();
            originalComposition = composition;
            // Заполните поля данными из выбранной композиции для редактирования
            newArtistTextBox.Text = composition.Artist;
            newTitleTextBox.Text = composition.Title;
        }

        internal void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            // Сохраняем изменения в выбранной композиции
            originalComposition.Artist = newArtistTextBox.Text;
            originalComposition.Title = newTitleTextBox.Text;
            Close();
        }
    }
}
