using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2console.Models.EntityFramework;

namespace TP2console.Utils
{
    public static class Exo2
    {
        public static void Exo2Q1()
        {
            var ctx = new FilmsDBContext();
            foreach (var film in ctx.Film)
            {
                Console.WriteLine(film.ToString());
            }
        }
        public static void Exo2Q2()
        {
            var ctx = new FilmsDBContext();
            foreach (var user in ctx.Utilisateur)
            {
                Console.WriteLine(user.Email);
            }
        }

        public static void Exo2Q3()
        {
            var ctx = new FilmsDBContext();
            foreach (var user in ctx.Utilisateur.OrderBy(c=>c.Login))
            {
                Console.WriteLine(user);
            }
        }

        public static void Exo2Q4()
        {
            var ctx = new FilmsDBContext();
            foreach (var film in ctx.Film.Where(f => f.CategorieNavigation.Nom == "Action"))
            {
                Console.WriteLine($"id:{film.Id} Nom:{film.Nom} ");
            }
        }

        public static void Exo2Q5()
        {
            var ctx = new FilmsDBContext();

            Console.WriteLine($"Nombre de categorie : {ctx.Categorie.Count()}");
        }

        public static void Exo2Q6()
        {
            var ctx = new FilmsDBContext();

            Console.WriteLine($"Note la plus basse : {ctx.Avis.OrderByDescending(a => a.Note).FirstOrDefault().Note}");
        }

        public static void Exo2Q7()
        {
            var ctx = new FilmsDBContext();
            foreach (var film in ctx.Film.Where(f => f.Nom.ToUpper().StartsWith("LE")))
            {
                Console.WriteLine(film.Nom);
            }
            
        }

        public static void Exo2Q8()
        {
            var ctx = new FilmsDBContext();
            decimal note = ctx.Avis.Where(a => a.FilmNavigation.Nom.ToUpper() == "PULP FICTION").Average(a => a.Note);
            Console.WriteLine($"Note moyenne de PULP FICTION : {note}");

        }

        public static void Exo2Q9()
        {
            var ctx = new FilmsDBContext();
            Console.WriteLine($"User qui a mis la best note : {ctx.Avis.Include(a => a.UtilisateurNavigation).OrderByDescending(n => n.Note).FirstOrDefault().UtilisateurNavigation.Login}");

        }

        public static void Exo3Q1()
        {
            var ctx = new FilmsDBContext();
            var user = new Utilisateur()
            {
                Login = "Fynn",
                Pwd = "zae",
                Email = "antoine.gamain@cpe.fr"
            };
            ctx.Utilisateur.Add(user);
            ctx.SaveChanges();
        }

        public static void Exo3Q2()
        {
            var ctx = new FilmsDBContext();
            var film = ctx.Film.Where(f => f.Nom.ToUpper() == "L'ARMEE DES DOUZE SINGES").FirstOrDefault();
            film.Description = "bruce willis va chez le psy";
            var categorie = ctx.Categorie.Where(c => c.Nom.ToUpper() == "DRAME").FirstOrDefault();
            film.CategorieNavigation = categorie;
            ctx.SaveChanges();
        }
        public static void Exo3Q3()
        {
            var ctx = new FilmsDBContext();
            var film = ctx.Film.Include(a=>a.Avis).Where(f => f.Nom.ToUpper() == "L'ARMEE DES DOUZE SINGES").FirstOrDefault();
            ctx.Avis.Remove(film.Avis);
            ctx.Film.Remove(film);
            ctx.SaveChanges();
        }
    }
}
