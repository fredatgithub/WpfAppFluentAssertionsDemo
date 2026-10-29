using System.Windows;
using LibraryHelper;

namespace WpfAppFluentAssertionsDemo
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow: Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void ComputeButton_Click(object sender, RoutedEventArgs e)
    {
      for (int i =  0; i < 250; i++)
      {
        if (Helper.IsPrime(i))
        {
          ResultsListBox.Items.Add(i);
        }
      }
    }
  }
}