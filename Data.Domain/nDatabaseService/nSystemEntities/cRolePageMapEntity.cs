using Base.Data.nDatabaseService.nDatabase;
using Data.Domain.nDataService.nEntityServices.nSystemEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.nDataService.nEntityServices.nSystemEntities
{
    public class cRolePageMapEntity : cBaseEntity<cRolePageMapEntity>
    {
        public cRoleEntity Role { get; set; }

        public cPageEntity Page { get; set; }
    }
}
