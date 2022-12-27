using Bootstrapper.Core.nCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.Data.nDatabaseService;

namespace Domain.Data.nDatabaseService
{
    public class cDataService : cBaseDataService<cDatabaseContext> 
    {
        public cDataService(cDataServiceContext _ServiceContext)
          : base(_ServiceContext)
        {
        }
    }
}
