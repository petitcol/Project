using Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TP1.Models;
using TP1.View;

namespace TP1.ViewModels
{
    public class WindowConnexionVM : NotifyPropertyChangedBase
    {
        #region Champs

        public MainWindowVM MW { get; set; }
        public WindowConnexion Window { get; set; }
        public Compte CompteUser { get; set; }
        public ObservableCollection<Compte> lComptes { get; set; }
        public bool IsConnected { get; set; } = false;
        public DelegateCommand ConnexionCommand { get; set; }
        public DelegateCommand CreateAccCommand { get; set; }
        public DelegateCommand AnnulCommand { get; set; }

        #endregion

        public WindowConnexionVM(Compte c, ObservableCollection<Compte> l, MainWindowVM mw, WindowConnexion w)
        {
            CompteUser = c;
            lComptes = l;
            MW = mw;
            Window = w;
            ConnexionCommand = new DelegateCommand(ConnexionAction, CanExecuteCreateAccCo);
            CreateAccCommand = new DelegateCommand(CreateAccAction, CanExecuteCreateAccCo);
            AnnulCommand = new DelegateCommand(AnnulAction, CanExecuteCreateAccCo);
            ConnexionCommand.RaiseCanExecuteChanged();
            IsConnected = false;
        }

        #region ButtonMethodes

        public void ConnexionAction(object o)
        {
            if (CompteUser.Identifiant.Equals("") || CompteUser.Pwd.Equals("") || CompteUser.Identifiant.Equals(null) || CompteUser.Pwd.Equals(null))
            {
                MessageBox.Show("Connexion impossible : Veuillez remplir les champs", "Connexion", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            foreach (Compte c in lComptes)
            {
                if (c.Identifiant.Equals(CompteUser.Identifiant) && c.Pwd.Equals(CompteUser.Pwd))
                {
                    MessageBox.Show("Connexion Réussie", "Connexion", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    MW.CompteUser = c;
                    IsConnected = true;
                    Window.Close();
                    return;
                }
            }
            MessageBox.Show("Connexion impossible : Veuillez saisir un identifiant/mot de passe correct", "Connexion", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public void CreateAccAction(object o)
        {
            WindowEnrCompte Enr = new WindowEnrCompte(CompteUser, lComptes);
            Enr.Name = "Enregistrement";
            Enr.ShowDialog();

            IsConnected = Enr.ViewModel.isConnected;
            Window.Close();
        }

        public void AnnulAction(object o)
        {
            Window.Close();
        }

        public bool CanExecuteCreateAccCo(object o)
        {
            return true;
        }

        #endregion
    }
}
