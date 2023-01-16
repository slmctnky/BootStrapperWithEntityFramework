using Base.Data.nDatabaseService.nDatabase;
using Bootstrapper.Core.nApplication;
using Data.Domain.nDatabaseService.nEntities;
using Data.Domain.nDatabaseService.nEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Domain.nDataService.nEntityServices.nEntities;
using Data.GenericWebScaffold.nDataService.nEntityServices.nEntities;

namespace Data.Domain.nDatabaseService
{
    public class cDatabaseContext : cBaseDatabaseContext
    {
        public DbSet<cUserEntity> Users { get; set; }
        public DbSet<cUserDetailEntity> UserDetails { get; set; }
        public DbSet<cUserSessionEntity> Sessions { get; set; }
        public DbSet<cRoleEntity> Roles { get; set; }
        public DbSet<cLanguageEntity> Languages { get; set; }
        public DbSet<cLanguageWordEntity> LanguageWords { get; set; }

        public DbSet<cBatchJobEntity> BatchJobs { get; set; }
        public DbSet<cBatchJobExecutionEntity> BatchJobExecutions { get; set; }


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
