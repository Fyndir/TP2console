using System;
using System.Collections.Generic;

namespace TP2console.Models.EntityFramework
{
    public partial class Utilisateur
    {
        public Utilisateur()
        {
            Avis = new HashSet<Avis>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Pwd { get; set; }

        public virtual ICollection<Avis> Avis { get; set; }
    }
}
