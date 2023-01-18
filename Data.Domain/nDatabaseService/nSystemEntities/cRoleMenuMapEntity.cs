using Base.Data.nDatabaseService.nDatabase;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.nDatabaseService.nSystemEntities
{
    public class cRoleMenuMapEntity : cBaseEntity<cRoleMenuMapEntity>
    {
        public cMenuEntity Menu { get; set; }
        public cRoleEntity Role { get; set; }

        public int SortValue { get; set; }
    }
}
