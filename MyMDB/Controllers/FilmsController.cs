using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMDB.Models.Abstract;
using MyMDB.Models.Concrete;
using System.ComponentModel;
using MyMDB.Views.Models;

namespace MyMDB.Controllers
{
    public class FilmsController : Controller
    {
        public int PageSize = 4;
        
        private IFilmsRepository filmsRepository;

        public FilmsController(IFilmsRepository filmsRepository)
        {
            //STEP 1:
            ////filmsRepository = new FakeFilmsRepository();

            //STEP 2:
            // Temp hard coded connection string until we set up DI
            ////string connString = @"Server=.\SQLEXPRESS;Database=sandpit;Trusted_Connection=yes;";
            ////filmsRepository = new SqlFilmsRepository(connString);

            //STEP 3:
            this.filmsRepository = filmsRepository;
        }

        public ViewResult List(int page = 1)
        {
            var filmsToShow = filmsRepository.Films;
            var viewModel = new FilmsListViewModel
            {
                Films = filmsToShow.Skip((page - 1) * PageSize).Take(PageSize).ToList(),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = filmsToShow.Count()
                }
            };

            return View(viewModel);
        }
    }
}
