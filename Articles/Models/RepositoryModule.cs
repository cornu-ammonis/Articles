using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Articles.Models
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ApplicationDbContext>().ToMethod(c =>
           {
               ApplicationDbContext db = new ApplicationDbContext();
               return db;
           }

                );


        }

    }
}