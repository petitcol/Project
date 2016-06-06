using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using System.Windows;

namespace TP1
{
    public class MainWindowVM : NotifyPropertyChangedBase
    {
        #region Champs
        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand EditCommand { get; set; }
        public DelegateCommand SuppCommand { get; set; }

        private ObservableCollection<Vins> _listeVins;
        public Vins _vins;
        private string _tsearchBar;

        public string TSearchBar
        {
            get
            {
                return _tsearchBar;
            }

            set
            {
                _tsearchBar = value;
                NotifyPropertyChanged("TSearchBar");
            }
        }

        public Vins Vins
        {
            get { return _vins; }
            set     
            { 
                _vins = value;
                NotifyPropertyChanged("Vins");
                NotifyPropertyChanged("ListeVins");
                EditCommand.RaiseCanExecuteChanged();
                SuppCommand.RaiseCanExecuteChanged();
            }
        }
        
        public ObservableCollection<Vins> ListeVins
        {
            get { return _listeVins; }
            set { _listeVins = value; }
        }
        #endregion

        public MainWindowVM()
        {
            ListeVins = new ObservableCollection<Vins>
            {
            #region ExVins
                new Vins(1987,"Blanc","Domaine de la Romanée-Conti", 11,"Bourgogne - Côte de nuits", "Chardonnay"," Ce vin blanc est à la croisée de deux excellences, celle d'un domaine et celle d'un terroir. Le premier est la Romanée-Conti, domaine mythique, à la réputation internationale et dont le moindre vin atteint des sommets de prix et affole les collectionneurs. Le second est l'un des meilleurs terroirs à vins blancs de Bourgogne, Montrachet. ","Montrachet",4465,"","Images/romanee-conti_blanc.jpg"),
                new Vins(2000,"Rouge","Château de Beaucastel", 11, "Vallée du Rhône - Sud (méridional)", " ", " "," ", 313, "Très bon avec du poisson",""),
                new Vins(1999,"Rouge","Domaine Clos de Tart",9,"Vallée du Rhône - Nord (septentrional)", " ", " ", " ", 245, "Avec de la viande","")
            #endregion
            };

            AddCommand = new DelegateCommand(AddAction, CanExecuteAdd);
            EditCommand = new DelegateCommand(EditAction, CanExecuteEditSupp);
            SuppCommand = new DelegateCommand(SuppAction, CanExecuteEditSupp);
            TSearchBar = "Rechercher...";
        }
         
        private void AddAction(object o)
        {
            WindowAddVins add = new WindowAddVins();
            add.Name = "Ajout";
            add.ShowDialog();
            if(!add._viewModell.IsCanceled)
                ListeVins.Add(add._viewModell.Vins);
        }

        private void EditAction(object o)
        {
            WindowAddVins add = new WindowAddVins(Vins);
            add.Name = "Edit";
            add.ShowDialog();
            if (!add._viewModell.IsCanceled)
            {
                ListeVins.Remove(Vins);
                ListeVins.Add(add._viewModell.Vins);
            }
        }
        
        private void SuppAction(object o)
        {
            MessageBoxResult Rep = MessageBox.Show("Etes-vous sûr de vouloir supprimer cette bouteille ?", "Supprimer", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if(Rep == MessageBoxResult.Yes)
                ListeVins.Remove(Vins);
        }

        private bool CanExecuteAdd(object o)
        {
            return true;
        }

        private bool CanExecuteEditSupp(object o)
        {
            return Vins != null;
        }
    }
}
