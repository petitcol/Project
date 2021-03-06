﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Models
{
    public class Compte
    {

        #region Champs
        public string Prenom { get; set; }
        private string _nom;
        public string Nom
        {
            get
            {
                return _nom;
            }

            set
            {
                _nom = value;
               
            }
        }
        private string _identifiant;
        public string Identifiant
        {
            get
            {
                return _identifiant;
            }

            set
            {
                _identifiant = value;
            }
        }
        private string _pwd;
        public string Pwd
        {
            get
            {
                return _pwd;
            }

            set
            {
                _pwd = value;
            }
        }
        public int Age { get; set; }


        #endregion

        public Compte(int age, string nom, string prenom, string id,string pwd)
        {
            Age = age;
            Nom = nom;
            Prenom = prenom;
            Identifiant = id;
            Pwd = pwd;
        }

        public Compte() { }

        public override string ToString()
        {
            if(Age != 0)
                return Nom + " " + Prenom + ", " + Age;
            return "Non connecté";
        }
    }
}
