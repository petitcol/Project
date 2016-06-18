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
    /// Logique d'interaction pour WindowEnrCompte.xaml
    /// </summary>
    public partial class WindowEnrCompte : Window
    {

        WindowEnrCompteVM ViewModel { get; set; }  

        public WindowEnrCompte(Compte c, ObservableCollection<Compte> l)
        {
            InitializeComponent();
            ViewModel = new WindowEnrCompteVM(c, l,this);
            DataContext = ViewModel;
        }
    }
}
