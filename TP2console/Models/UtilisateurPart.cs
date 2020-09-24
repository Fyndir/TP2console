using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP2console.Models.EntityFramework
{
    public partial class Utilisateur
    {
        public override string ToString()
        {
            return $"Login : {this.Login}";
        }
    }
}
