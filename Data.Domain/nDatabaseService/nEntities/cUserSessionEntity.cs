using Base.Data.nDatabaseService.nDatabase;
using DData.Domain.nDatabaseService.nEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.nDatabaseService.nEntities
{
    public class cUserSessionEntity : cBaseEntity<cUserSessionEntity>
    {
        public string SessionHash { get; set; }
        public string IpAddress { get; set; }

        public cUserEntity User { get; set; }
    }
}
