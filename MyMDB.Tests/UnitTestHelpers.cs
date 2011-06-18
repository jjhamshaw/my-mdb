using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MyMDB.Models.Abstract;
using MyMDB.Models.Entities;
using Moq;

namespace MyMDB.Tests
{
    public static class UnitTestHelpers
    {
        public static void ShouldEqual<T>(this T actualValue, T expectedValue) 
        { 
            Assert.AreEqual(expectedValue, actualValue);
        }

        public static IFilmsRepository MockFilmsRepository(params Film[] films)
        {
            var mockFilmsRepos = new Mock<IFilmsRepository>();
            mockFilmsRepos.Setup(x => x.Films).Returns(films.AsQueryable());
            return mockFilmsRepos.Object;
        }
    }
}
