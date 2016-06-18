using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using System.Windows;
using TP1.Models;
using TP1.View;
using System.Windows.Input;

namespace TP1
{
    public class MainWindowVM : NotifyPropertyChangedBase
    {
        #region Champs

        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand EditCommand { get; set; }
        public DelegateCommand SuppCommand { get; set; }
        public DelegateCommand ConnexionCommand { get; set; }
        private ObservableCollection<Compte> ListeComptes { get; set; }
        private ObservableCollection<Vins> _listeVins;
        private Vins _vins;
        private string _tsearchBar;
        private string _connexionetat;
        private Compte _compteUser;



        public string TSearchBar
        {
            get { return _tsearchBar; }
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

        public string ConnexionEtat
        {
            get { return _connexionetat; }
            set
            {
                _connexionetat = value;
                NotifyPropertyChanged("ConnexionEtat");
            }
        }

        public Compte CompteUser
        {
            get { return _compteUser; }
            set
            {
                _compteUser = value;
                NotifyPropertyChanged("CompteUser");
            }
        }

        #endregion

        public MainWindowVM()
        {


            LireFichierChargement();

            LireFichierComptes();

            AddCommand = new DelegateCommand(AddAction, CanExecuteAddCo);
            EditCommand = new DelegateCommand(EditAction, CanExecuteEditSupp);
            SuppCommand = new DelegateCommand(SuppAction, CanExecuteEditSupp);
            ConnexionCommand = new DelegateCommand(ConnexionAction, CanExecuteAddCo);
            CompteUser = new Compte();
            TSearchBar = "Rechercher...";
            ConnexionEtat = "Connexion";
        }

        #region ButtonMethodes

        private void AddAction(object o)
        {
            WindowAddVins add = new WindowAddVins();
            add.Name = "Ajout";
            add.ShowDialog();
            if (!add._viewModell.IsCanceled)
                ListeVins.Add(add._viewModell.Vins);
            EcrireFichierChargement();
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
            EcrireFichierChargement();
        }

        private void SuppAction(object o)
        {
            MessageBoxResult Rep = MessageBox.Show("Etes-vous sûr de vouloir supprimer cette bouteille ?", "Supprimer", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (Rep == MessageBoxResult.Yes)
                ListeVins.Remove(Vins);
            EcrireFichierChargement();
        }

        private void ConnexionAction(object o)
        {
            if (ConnexionEtat == "Connexion")
            {
                WindowConnexion co = new WindowConnexion(CompteUser, ListeComptes, this);
                co.Name = "Connexion";
                co.ShowDialog();

                if (co.ViewModel.IsConnected)
                {
                    ConnexionEtat = "Deconnexion";
                    NotifyPropertyChanged("ConnexionEtat");
                }
                NotifyPropertyChanged("CompteUser");
                NotifyPropertyChanged("Compte.Nom");
            }

            else if (ConnexionEtat == "Deconnexion")
            {
                MessageBoxResult Rep = MessageBox.Show("Etes-vous sûr de vouloir vous déconnecter ?", "Deconnexion", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (Rep == MessageBoxResult.Yes)
                {
                    CompteUser = new Compte();
                    ConnexionEtat = "Connexion";
                }
            }
        }

        private bool CanExecuteAddCo(object o)
        {
            return true;
        }

        private bool CanExecuteEditSupp(object o)
        {
            return Vins != null;
        }

        #endregion

        private void LireFichierChargement()
        {
            ListeVins = new ObservableCollection<Vins>()
            { };

            String ligne;
            System.IO.StreamReader file = new System.IO.StreamReader("fichier.txt");

            while ((ligne = file.ReadLine()) != null)
            {
                String[] TElements;

                TElements = ligne.Split(new[] { '|' });

                String Annee = TElements[0];
                String Type = TElements[1];
                String Domaine = TElements[2];
                String Pourcentage = TElements[3];
                String Region = TElements[4];
                String Cepage = TElements[5];
                String Description = TElements[6];
                String Appelation = TElements[7];
                String Prix = TElements[8];
                String EnCuisine = TElements[9];
                String PathImage = TElements[10];
                String ImageName = TElements[11];

                int fAnnee = 0;
                try
                {
                    fAnnee = int.Parse(TElements[0]); ;
                }
                catch (Exception) { }

                float fPourcentage = 0;

                try
                {
                    fPourcentage = Single.Parse(Pourcentage);
                }
                catch (Exception) { }

                int fPrix = int.Parse(Prix);

                ListeVins.Add(new Vins(fAnnee, Type, Domaine, fPourcentage, Region, Cepage, Description, Appelation, fPrix, EnCuisine, PathImage, ImageName));
            }

            file.Close();

        }

        private void EcrireFichierChargement()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("fichier.txt");
            foreach (Vins Vins in ListeVins)
            {
                int? Annee = Vins.Annee;
                float? Pourcentage = Vins.Pourcentage;
                int Prix = Vins.Prix;
                String Ligne = Annee + "|" + Vins.Type + "|" + Vins.Domaine + "|" + Pourcentage + "|" + Vins.Region + "|" + Vins.Cepage + "|" + Vins.Description + "|" + Vins.Appellation + "|" + Prix + "|" + Vins.EnCuisine + "|" + Vins.PathImage + "|" + Vins.ImageName + "|";

                file.WriteLine(Ligne);
            }
            file.Close();
        }


        private void LireFichierComptes()
        {
            ListeComptes = new ObservableCollection<Compte> { };

            String ligne;
            System.IO.StreamReader file = new System.IO.StreamReader("Comptes.txt");

            while ((ligne = file.ReadLine()) != null)
            {
                String[] TElements;

                TElements = ligne.Split(new[] { '|' });

                String Identifiant = TElements[0];
                String MotDePasse = TElements[1];
                String Nom = TElements[2];
                String Prenom = TElements[3];
                String Age = TElements[4];

                int fAge = 0;
                try
                {
                    fAge = int.Parse(Age);
                }
                catch (Exception) { }

                ListeComptes.Add(new Compte(fAge, Nom, Prenom, Identifiant, MotDePasse));

            }

            file.Close();
        }



    }
}