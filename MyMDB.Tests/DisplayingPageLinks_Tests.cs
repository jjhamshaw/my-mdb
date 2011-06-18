using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Web.Mvc;
using MyMDB.Views.Models;
using MyMDB.HtmlHelpers;
using MyMDB.Models.Entities;
using MyMDB.Controllers;

namespace MyMDB.Tests
{
[TestFixture]
    class DisplayingPageLinks_Tests
    {
        [Test]
        public void Can_Generate_Links_To_Other_Pages()
        { 
            //extend the HtmlHelper class
            //doesnt matter if the variable we use is null
            HtmlHelper html = null;

            PagingInfo pagingInfo = new MyMDB.Views.Models.PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };
            Func<int, string> pageUrl = i => "Page" + i;

            MvcHtmlString result = html.PageLinks(pagingInfo, pageUrl);

            result.ToString().ShouldEqual(@"<a href=""Page1"">1</a>
<a class=""selected"" href=""Page2"">2</a>
<a href=""Page3"">3</a>
");
        }

        [Test]
        public void Film_Lists_Include_Correct_Page_Numbers()
        {
            var mockRepository = UnitTestHelpers.MockFilmsRepository(
                new Film { Title = "Film 1" },
                new Film { Title = "Film 2" },
                new Film { Title = "Film 3" },
                new Film { Title = "Film 4" },
                new Film { Title = "Film 5" }
                );
            var controller = new FilmsController(mockRepository) { PageSize = 3 };

            var result = controller.List(2);

            var ViewModel = (FilmsListViewModel)result.ViewData.Model;
            PagingInfo pagingInfo = ViewModel.PagingInfo;
            pagingInfo.CurrentPage.ShouldEqual(2);
            pagingInfo.ItemsPerPage.ShouldEqual(3);
            pagingInfo.TotalItems.ShouldEqual(5);
            pagingInfo.TotalPages.ShouldEqual(2);
        }
    }
}
