using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TP2console.Models.EntityFramework;
using TP2console.Utils;

namespace TP2console
{
    class Program
    {
        static void Main(string[] args)
        {
            Exo2.Exo3Q3();
        }

        public void Tuto()
        {
            // Proto de select
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


            using (var ctx = new FilmsDBContext())
            {
                Categorie categorieAction = ctx.Categorie.First(c => c.Nom == "Action");
                Console.WriteLine("Categorie : " + categorieAction.Nom);

                //Chargement des films dans categorieAction
                ctx.Entry(categorieAction).Collection(c => c.Film).Load();
                Console.WriteLine("Films : ");
                foreach (var film in categorieAction.Film)
                {
                    Console.WriteLine(film.Nom);
                }
            }

            using (var ctx = new FilmsDBContext())
            {
                //Chargement de la catégorie Action et des films de cette catégorie
                Categorie categorieAction = ctx.Categorie.Include(c => c.Film).First(c => c.Nom == "Action");
                Console.WriteLine("Categorie : " + categorieAction.Nom);
                Console.WriteLine("Films : ");
                foreach (var film in categorieAction.Film)
                {
                    Console.WriteLine(film.Nom);
                }
            }

            using (var ctx = new FilmsDBContext())
            {
                //Chargement de la catégorie Action, des films de cette catégorie et des avis
                Categorie categorieAction = ctx.Categorie.Include(c => c.Film).ThenInclude(f => f.Avis).First(c => c.Nom == "Action");
            }

            using (var ctx = new FilmsDBContext())
            {
                //Chargement de la catégorie Action
                Categorie categorieAction = ctx.Categorie.First(c => c.Nom == "Action");
                Console.WriteLine("Categorie : " + categorieAction.Nom);
                Console.WriteLine("Films : ");
                //Chargement des films de la catégorie Action.
                foreach (var film in categorieAction.Film) // lazy loading initiated
                {
                    Console.WriteLine(film.Nom);
                }
            }
        }
    }
}
