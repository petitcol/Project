using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using System.Windows;

namespace TP1.ViewModels
{
    public class WindowAddEditVM : NotifyPropertyChangedBase
    {
        public string CommandName { get; set; }
        public string WindowName { get; set; }
        public DelegateCommand Command { get; set; }
        public DelegateCommand AnnulCommand { get; set; }
        public Vins Vins { get; set; }
        public WindowAddVins Window { get; set; }
        public Boolean IsCanceled { get; set; }

        public WindowAddEditVM(WindowAddVins w)
        {
            Vins = new Vins();
            Window = w;
            CommandName = "Ajouter";
            WindowName = "Ajout d'une bouteille";
            Command = new DelegateCommand(CommandAction, CanExecuteCommand);
            AnnulCommand = new DelegateCommand(AnnulAction, CanExecuteAnnul);
            IsCanceled = false;
        }

        public WindowAddEditVM(WindowAddVins w, Vins v)
        {
            Vins = new Vins(v.Annee, v.Type, v.Domaine, v.Pourcentage, v.Region, v.Cepage,v.Description, v.Appellation, v.Prix, v.EnCuisine,v.PathImage);
            Window = w;
            CommandName = "Modifier";
            WindowName = "Modification d'une bouteille";
            Command = new DelegateCommand(CommandAction, CanExecuteCommand);
            AnnulCommand = new DelegateCommand(AnnulAction, CanExecuteAnnul);
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

        private bool CanExecuteCommand(object o)
        {
            return true;
        }

        private bool CanExecuteAnnul(object o)
        {
            return true;
        }
    }
}
