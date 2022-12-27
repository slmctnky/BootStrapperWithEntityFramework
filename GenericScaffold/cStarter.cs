using Bootstrapper.Core.nApplication.nStarter;
using Bootstrapper.Core.nApplication;
using Bootstrapper.Core.nCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Data.nDatabaseService;
using Domain.Data.nDatabaseService.Entities;
using Microsoft.EntityFrameworkCore.Migrations.Internal;

namespace GenericScaffold
{
    public class cStarter : cCoreObject, IStarter
    {
        public cDataService DataService { get; set; }
        public cStarter(cApp _App, cDataService _DataService)
            : base(_App)
        {
            DataService = _DataService;
        }

        public void Start(cApp _App)
        {
            DataService.Migrate();

            cDatabaseContext __DatabaseContext = DataService.GetDatabaseContext();

            __DatabaseContext.Perform(() =>
            {
                var blog = new cBlogEntity
                {
                    Url = "http://sample.com",
                    Posts = new List<cPostEntity>()
                {
                    new cPostEntity(){ Content = "test", Title = "Test" },
                    new cPostEntity() { Content = "test", Title = "Test" }
                }

                };
                __DatabaseContext.Blogs.Add(blog);
                __DatabaseContext.SaveChanges();
                
            });

            Console.WriteLine("Test");
        }
    }
}
