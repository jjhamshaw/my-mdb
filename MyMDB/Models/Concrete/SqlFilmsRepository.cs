using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyMDB.Models.Abstract;
using MyMDB.Models.Entities;
using System.Data.Linq;

namespace MyMDB.Models.Concrete
{
    public class SqlFilmsRepository : IFilmsRepository
    {
        private Table<Film> filmsTable;
        public SqlFilmsRepository(string connectionString)
        {
            filmsTable = (new DataContext(connectionString)).GetTable<Film>();
        }

        public IQueryable<Film> Films
        {
            get { return filmsTable; }
        }
    }
}