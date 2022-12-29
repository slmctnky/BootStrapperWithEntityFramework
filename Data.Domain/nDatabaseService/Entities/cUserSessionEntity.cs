using Base.Data.nDatabaseService.nDatabase;
using Data.Domain.nDatabaseService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DData.Domain.nDatabaseService.Entities
{
    public class cUserSessionEntity : cBaseEntity
    {
        public string SessionHash { get; set; }
        public string IpAddress { get; set; }

        public cUserEntity User { get; set; }
    }
}
