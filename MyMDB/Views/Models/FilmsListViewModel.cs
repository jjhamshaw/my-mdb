using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyMDB.Models.Entities;

namespace MyMDB.Views.Models
{
    public class FilmsListViewModel
    {
        public IList<Film> Films { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}