﻿using Base.Data.nDatabaseService.nDatabase;
using Bootstrapper.Boundary.nCore.nObjectLifeTime;
using Bootstrapper.Core.nAttributes;
using Bootstrapper.Core.nCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Data.nDatabaseService
{
    [Register(null, false, true, true, true, LifeTime.TransientLifetimeManager)]
    public abstract class cBaseDataService<TDatabaseContext> : cCoreService<cDataServiceContext>
        where TDatabaseContext : cBaseDatabaseContext
    {
        public bool IsMigrated { get; set; }
        public cBaseDataService(cDataServiceContext _ServiceContext)
          : base(_ServiceContext)
        {
            ServiceContext = _ServiceContext;
            IsMigrated = false;
        }

        public override void Init()
        {
            App.Factories.ObjectFactory.RegisterType(typeof(TDatabaseContext), typeof(TDatabaseContext), LifeTime.PerThreadLifetimeManager);
        }

        public void Migrate()
        {
            TDatabaseContext __DatabaseContext = GetDatabaseContext();
            if (!IsMigrated)
            {
                lock (this)
                {
                    if (!IsMigrated)
                    {
                        lock (this)
                        {
                            __DatabaseContext.Database.Migrate();
                            IsMigrated = true;
                        }
                        
                    }
                }
            }
        }

        public TDatabaseContext GetDatabaseContext()
        {
            return ServiceContext.App.Factories.ObjectFactory.ResolveInstance<TDatabaseContext>();
        }
    }
}