using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using System.Windows;
using Microsoft.Win32;
using System.IO;
using System.Windows.Input;

namespace TP1.ViewModels
{
    public class WindowAddEditVM : NotifyPropertyChangedBase
    {
        public string CommandName { get; set; }
        public string WindowName { get; set; }
        public DelegateCommand Command { get; set; }
        public DelegateCommand AnnulCommand { get; set; }
        public DelegateCommand ParcourirCommand { get; set; }
        public Vins Vins { get; set; }
        public WindowAddVins Window { get; set; }
        public Boolean IsCanceled { get; set; }


        public WindowAddEditVM(WindowAddVins w)
        {
            Vins = new Vins();
            Window = w;
            CommandName = "Ajouter";
            WindowName = "Ajout d'une bouteille";
            Command = new DelegateCommand(CommandAction, CanExecuteParAnnulComm);
            AnnulCommand = new DelegateCommand(AnnulAction, CanExecuteParAnnulComm);
            ParcourirCommand = new DelegateCommand(ParcourirAction, CanExecuteParAnnulComm);
            IsCanceled = false;
        }

        public WindowAddEditVM(WindowAddVins w, Vins v)
        {
            Vins = new Vins(v.Annee, v.Type, v.Domaine, v.Pourcentage, v.Region, v.Cepage,v.Description, v.Appellation, v.Prix, v.EnCuisine,v.PathImage,v.ImageName);
            Window = w;
            CommandName = "Modifier";
            WindowName = "Modification d'une bouteille";
            Command = new DelegateCommand(CommandAction, CanExecuteParAnnulComm);
            AnnulCommand = new DelegateCommand(AnnulAction, CanExecuteParAnnulComm);
            ParcourirCommand = new DelegateCommand(ParcourirAction, CanExecuteParAnnulComm);
            IsCanceled = false;
            
        }        

        private void CommandAction(object o)
        {                     
            Window.Close();            
        }

        private void AnnulAction(object o)
        {
            IsCanceled = true;
            Window.Close();
        }

        private void ParcourirAction(object o)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            Vins.ImageName = file.FileName;

            if (File.Exists(Vins.ImageName))
            {
                string[] aux = Vins.ImageName.Split('\\');
                string newPath = string.Format(@"G:\Cours\IHM\606\ProjIHM\TP1\Images\{0}", aux[aux.Length - 1]);
                if (!File.Exists(newPath))
                {
                    File.Copy(Vins.ImageName, newPath);
                }
                Vins.ImageName = file.SafeFileName;
                Vins.PathImage = newPath;

                //Vins.PathImage = "Images/" + file.SafeFileName;
                NotifyPropertyChanged("Vins");
            }            
        }

        private bool CanExecuteParAnnulComm(object o)
        {
            return true;
        }
    }
}
