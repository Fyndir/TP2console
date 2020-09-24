using System;
using System.Linq;
using TP2console.Models.EntityFramework;

namespace TP2console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new FilmsDBContext())
            {
                // pas de changement en bdd utile pr le test
                ctx.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;

                // Select
                Film titanic = ctx.Film.First(f => f.Nom.Contains("Titanic"));

                // Modif en local
                titanic.Description = $"Un bateau échoué. Date : {DateTime.Now}";

                //Commit
                int nbChange = ctx.SaveChanges();

                Console.WriteLine($"Nb de modification dans la bdd : {nbChange}");
            };

            Console.ReadKey();
        }
    }
}
