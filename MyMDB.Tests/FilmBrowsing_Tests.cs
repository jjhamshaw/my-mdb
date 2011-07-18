using NUnit.Framework;
using MyMDB.Models.Abstract;
using MyMDB.Models.Entities;
using MyMDB.Controllers;
using MyMDB.Views.Models;

namespace MyMDB.Tests
{
    [TestFixture]
    internal class FilmBrowsing_Tests
    {
        [Test]
        public void Can_View_A_Single_Page_Of_Films()
        {
            // Arrange: If there are 5 products in the repository...
            IFilmsRepository repository = UnitTestHelpers.MockFilmsRepository(
                new Film {Title = "Film1"},
                new Film {Title = "Film2"},
                new Film {Title = "Film3"},
                new Film {Title = "Film4"},
                new Film {Title = "Film5"}
                );
            var controller = new FilmsController(repository);
            controller.PageSize = 3;

            // Act: when the user asks for the second page...
            var result = controller.List(2);

            // Assert: they'll just see the last 2 products
            var viewModel = (FilmsListViewModel) result.ViewData.Model;
            var displayedFilms = viewModel.Films;
            displayedFilms.Count.ShouldEqual(2);
            displayedFilms[0].Title.ShouldEqual("Film4");
            displayedFilms[1].Title.ShouldEqual("Film5");
        }

        [Test]
        public void Can_Search_For_Films_By_Title()
        {
            IFilmsRepository filmRepo = UnitTestHelpers.MockFilmsRepository(
                new Film {Title = "Film1"},
                new Film {Title = "Film2"},
                new Film {Title = "Film3"},
                new Film {Title = "Film4"},
                new Film {Title = "Film5"}
                );

            var controller = new SearchController(new SearchQueryData());

            //Assert
            var viewModel = (FilmsListViewModel) result.ViewData.Model;
            var displayedFilms = viewModel.
        }
    }
}