using Base.Data.nDatabaseService.nDatabase;
using Data.Domain.nDatabaseService.nEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.nDatabaseService.nEntities
{
    public class cRoleEntity : cBaseEntity<cRoleEntity>
    {
        public string Name { get; set; }

        public string Code { get; set; }

    }
}
