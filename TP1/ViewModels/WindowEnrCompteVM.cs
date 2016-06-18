using Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1.Models;
using TP1.View;
using TP1.ViewModels;

namespace TP1.ViewModels
{
    public class WindowEnrCompteVM : NotifyPropertyChangedBase
    {

        #region Champs

        public Compte CompteUser { get; set; }
        public ObservableCollection<Compte> lComptes { get; set; }
        public DelegateCommand EnrCommand { get; set; }
        public DelegateCommand AnnulCommand { get; set; }
        public WindowEnrCompte Window { get; set; }
        public bool isConnected { get; set; } = false;


        #endregion

        public WindowEnrCompteVM(Compte c, ObservableCollection<Compte> l, WindowEnrCompte w)
        {
            CompteUser = c;
            lComptes = l;
            Window = w;
            EnrCommand = new DelegateCommand(EnrAction, CanExecuteEnrAnnul);
            AnnulCommand = new DelegateCommand(AnnulAction, CanExecuteEnrAnnul);
        }

        public void EnrAction(object o)
        {
            lComptes.Add(CompteUser);
            EcrireFichierCompte();
            isConnected = true;

            Window.Close();
        }

        public void AnnulAction(object o)
        {
            Window.Close();
        }

        public bool CanExecuteEnrAnnul(object o)
        {
            return true;
        }

        public void EcrireFichierCompte()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("Comptes.txt");
            foreach (Compte Compte in lComptes)
            {
                int Age = Compte.Age;


                String Ligne = Compte.Identifiant + "|" + Compte.Pwd + "|" + Compte.Nom + "|" + Compte.Prenom + "|" + Age + "|";
                file.WriteLine(Ligne);
            }
            file.Close();

        }



    }
}
