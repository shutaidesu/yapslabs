using System.Windows;

namespace lab5;

public partial class AddCompositionWindow : Window
{
    public string Artist { get; private set; }
    public string Title { get; private set; }

    public AddCompositionWindow()
    {
        InitializeComponent();
    }

    private void AddCompositionButton_Click(object sender, RoutedEventArgs e)
    {
        Artist = artistTextBox.Text;
        Title = titleTextBox.Text;
        Close(); // Закрываем окно после добавления композиции
    }
}

