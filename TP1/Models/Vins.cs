using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Vins
    {
        #region Champs
        public enum TYPE { ROUGE, ROSE, BLANC }
        public TYPE EType;
        public string Type
        {
            get
            {
                switch (EType)
                {
                    case TYPE.ROUGE: return "Rouge";
                    case TYPE.ROSE: return "Rosé";
                    case TYPE.BLANC: return "Blanc";
                    default: return "";
                }
            }
            set
            {
                switch (value)
                {
                    case "Rouge":
                        EType = TYPE.ROUGE;
                        break;
                    case "Rose":
                        EType = TYPE.ROSE;
                        break;
                    case "Blanc":
                        EType = TYPE.BLANC;
                        break;
                    default: return;
                }
            }
        }

        public string EPrix { get; set; }

        public int _prix;
        public int Prix
        {
            get
            {
                return _prix;
            }

            set
            {
                _prix = value;
                EPrix = _prix + " €";
            }
        }
        private string pathimage;
        public string PathImage
        {
            get
            {
                return pathimage;
            }

            set
            {
                pathimage = value;
            }
        }
        public int? Annee { get; set; }
        public string Domaine { get; set; }
        public string Region { get; set; }
        public string Appellation { get; set; }
        public string Cepage { get; set; }
        public string Description { get; set; }
        public float? Pourcentage { get; set; }
        public string EnCuisine { get; set; }
        

        
        #endregion

        public override string ToString()
        {
            return Domaine + " - " + Annee;
        }

        public Vins() { }

        public Vins(int? annee, string type, string domaine,  float? pourcentage, string region, string cepage, string description, string appellation, int prix, string encuisine, string pathImage)
        {
            Annee = annee;
            Type = type;
            Domaine = domaine;
            Pourcentage = pourcentage;
            Region = region;
            Cepage = cepage;
            Description = description;
            Appellation = appellation;
            Prix = prix;
            EnCuisine = encuisine;
            PathImage = pathImage;  
        }
    }
}
