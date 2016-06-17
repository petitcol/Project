using Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TP1.Models;

namespace TP1.ViewModels
{
    public class WindowConnexionVM : NotifyPropertyChangedBase
    {
        #region Champs

        public Compte CompteUser { get; set; }
        public ObservableCollection<Compte> lComptes { get; set; }
        public bool IsConnected { get; set; } = false;
        public DelegateCommand ConnexionCommand { get; set; }
        public DelegateCommand CreateAccCommand { get; set; }

        #endregion

        public WindowConnexionVM(Compte c, ObservableCollection<Compte> l)
        {
            CompteUser = c;
            lComptes = l;
            ConnexionCommand = new DelegateCommand(ConnexionAction, CanExecuteCreateAccCo);
            CreateAccCommand = new DelegateCommand(CreateAccAction, CanExecuteCreateAccCo);
            IsConnected = false;
        }

        #region ButtonMethodes

        public void ConnexionAction(object o)
        {
            if(CompteUser.Identifiant.Equals("") || CompteUser.Pwd.Equals(""))
            {
                MessageBox.Show("Connexion impossible : Veuillez remplir les champs", "Connexion", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            foreach (Compte c in lComptes)
            {
                if (c.Identifiant.Equals(CompteUser.Identifiant) && c.Pwd.Equals(CompteUser.Pwd))
                {
                    MessageBox.Show("Connexion Réussie", "Connexion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    CompteUser = c;
                    IsConnected = true;
                }
                else
                    MessageBox.Show("Connexion impossible : Veuillez saisir un identifiant/mot de passe correct", "Connexion", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void CreateAccAction(object o)
        {
            
        }

        public bool CanExecuteCreateAccCo(object o)
        {
            return true;
        }

        #endregion
    }
}
