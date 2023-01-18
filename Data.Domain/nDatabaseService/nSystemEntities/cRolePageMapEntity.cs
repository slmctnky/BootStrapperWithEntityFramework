using Base.Data.nDatabaseService.nDatabase;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.nDatabaseService.nSystemEntities
{
    public class cRolePageMapEntity : cBaseEntity<cRolePageMapEntity>
    {
        public cRoleEntity Role { get; set; }

        public cPageEntity Page { get; set; }
    }
}
