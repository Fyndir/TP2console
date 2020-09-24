using System;
using System.Collections.Generic;

namespace TP2console.Models.EntityFramework
{
    public partial class Avis
    {
        public int Film { get; set; }
        public int Utilisateur { get; set; }
        public string Avis1 { get; set; }
        public decimal Note { get; set; }

        public virtual Film FilmNavigation { get; set; }
        public virtual Utilisateur UtilisateurNavigation { get; set; }
    }
}
