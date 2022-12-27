using Base.Data.nDatabaseService.nDatabase;
using Bootstrapper.Core.nApplication;
using Domain.Data.nDatabaseService.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.nDatabaseService
{
    public class cDatabaseContext : cBaseDatabaseContext
    {
        public DbSet<cBlogEntity> Blogs { get; set; }
        public DbSet<cPostEntity> Posts { get; set; }

        public cDatabaseContext()
            : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder _OptionsBuilder)
        {
            base.OnConfiguring(_OptionsBuilder);
        }
    }
}
