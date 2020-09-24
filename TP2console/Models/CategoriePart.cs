using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP2console.Models.EntityFramework
{
    public partial class Categorie
    {
        public override string ToString()
        {
            return $"Nom:{this.Nom}";
        }
    }
}
