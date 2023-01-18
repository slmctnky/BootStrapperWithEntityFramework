using Base.Data.nDatabaseService.nDatabase;
using Data.Domain.nDataService.nEntityServices.nSystemEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.nDataService.nEntityServices.nSystemEntities
{
    public class cRoleMenuMapEntity : cBaseEntity<cRoleMenuMapEntity>
    {
        public cMenuEntity Menu { get; set; }
        public cRoleEntity Role { get; set; }

        public int SortValue { get; set; }
    }
}
