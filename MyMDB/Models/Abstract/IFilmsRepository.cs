using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyMDB.Models.Entities;

namespace MyMDB.Models.Abstract
{
    public interface IFilmsRepository
    {
        IQueryable<Film> Films {get;}
    }
}