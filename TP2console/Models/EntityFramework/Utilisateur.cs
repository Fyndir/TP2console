﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP2console.Models.EntityFramework
{
    [Table("utilisateur")]
    public partial class Utilisateur
    {
        public Utilisateur()
        {
            Avis = new HashSet<Avis>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("login")]
        [StringLength(50)]
        public string Login { get; set; }
        [Required]
        [Column("email")]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [Column("pwd")]
        [StringLength(50)]
        public string Pwd { get; set; }

        [InverseProperty("UtilisateurNavigation")]
        public virtual ICollection<Avis> Avis { get; set; }
    }
}
