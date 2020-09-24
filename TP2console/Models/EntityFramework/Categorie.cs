using System;
using System.Collections.Generic;

namespace TP2console.Models.EntityFramework
{
    public partial class Categorie
    {
        public Categorie()
        {
            Film = new HashSet<Film>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Film> Film { get; set; }
    }
}
