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

namespace TP1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowVM _viewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new MainWindowVM();
            DataContext = _viewModel;
        }

        private void SearchBar_GotFocus (object sender, RoutedEventArgs e)
        {
            _viewModel.TSearchBar = "";
            SearchBar.FontStyle = FontStyles.Normal;
            SearchBar.Foreground = Brushes.Black;
        }

        private void SearchBar_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchBar.Text))
            {
                _viewModel.TSearchBar = "Rechercher...";
                SearchBar.FontStyle = FontStyles.Italic;
                SearchBar.Foreground = Brushes.SlateGray;
            }
        }
    }
}
