using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Ninject.Modules;
using System.Web.Routing;
using MyMDB.Models.Abstract;
using MyMDB.Models.Concrete;
using System.Configuration;

namespace MyMDB.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        // A Ninject "kernal" is the thing that can supply object instances
        private IKernel kernel = new StandardKernel(new MyMDBServices());

        // ASP.NET MVC calls this to get the controller for each request
        protected override IController GetControllerInstance(RequestContext context, Type controllerType)
        {
            if (controllerType == null)
                return null;
            return (IController)kernel.Get(controllerType);
        }

        //Configures how abstract service types are mapped to concrete implementations
        private class MyMDBServices : NinjectModule
        {
            public override void Load()
            {
                Bind<IFilmsRepository>().To<SqlFilmsRepository>().WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["AppDb"].ConnectionString);
            }
        }
    }
}