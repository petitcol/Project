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
using TP1.Models;
using TP1.ViewModels;

namespace TP1.View
{
    /// <summary>
    /// Logique d'interaction pour WindowConnexion.xaml
    /// </summary>
    public partial class WindowConnexion : Window
    {
        public WindowConnexionVM ViewModel { get; set; }

        public WindowConnexion(Compte c, ObservableCollection<Compte> l, MainWindowVM mw)
        {
            InitializeComponent();
            ViewModel = new WindowConnexionVM(c,l,mw,this);
            DataContext = ViewModel;
        }
    }
}
