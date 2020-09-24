using System;
using System.Collections.Generic;

namespace TP2console.Models.EntityFramework
{
    public partial class Film
    {
        public Film()
        {
            Avis = new HashSet<Avis>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public int Categorie { get; set; }

        public virtual Categorie CategorieNavigation { get; set; }
        public virtual ICollection<Avis> Avis { get; set; }
    }
}
