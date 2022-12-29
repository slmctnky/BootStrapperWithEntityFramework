using Base.Data.nDatabaseService.nDatabase;
using Bootstrapper.Core.nApplication;
using Data.Domain.nDatabaseService.Entities;
using DData.Domain.nDatabaseService.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.nDatabaseService
{
    public class cDatabaseContext : cBaseDatabaseContext
    {
        public DbSet<cBlogEntity> cUserEntity { get; set; }
        
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
