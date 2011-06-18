using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyMDB.Models.Abstract;
using MyMDB.Models.Entities;

namespace MyMDB.Models.Concrete
{
    public class FakeFilmsRepository : IFilmsRepository
    {
        // a hard coded list of products
        private static IQueryable<Film> fakeFilms = new List<Film> {
            new Film {ID = 1, Title = "Nobby's Big Day Out", Director = "Chris Evans", Genre="Action", Rating = 4, ReleaseDate = new DateTime(2005, 1, 10)},
            new Film {ID = 2, Title = "Nobby Returns", Director = "Dave Davish", Genre="Comedy", Rating = 3, ReleaseDate = new DateTime(2011, 1, 10)},
            new Film {ID = 3, Title = "Nobs Attacks", Director = "Steven Spillberg", Genre="Sci-Fi", Rating = 1, ReleaseDate = new DateTime(2010, 10, 31)}
        }.AsQueryable();
        
        public IQueryable<Film> Films
        {
            get { return fakeFilms; }
        }
    }
}