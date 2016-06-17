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
using TP1.ViewModels;

namespace TP1
{
    /// <summary>
    /// Logique d'interaction pour WindowAddVins.xaml
    /// </summary>
    public partial class WindowAddVins :Window
    {        
        public WindowAddEditVM _viewModell { get; set; }

        public WindowAddVins()
        {
            InitializeComponent();
            
            _viewModell = new WindowAddEditVM(this);
            DataContext = _viewModell;
        }
        
        public WindowAddVins(Vins v)
        {
            InitializeComponent();

            _viewModell = new WindowAddEditVM(this,v);
            DataContext = _viewModell;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
