using Base.Data.nDatabaseService.nDatabase;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.nDatabaseService.nSystemEntities
{
    public class cRoleDataSourcePermissionMapEntity : cBaseEntity<cRoleDataSourcePermissionMapEntity>
    {
        public cDataSourcePermissionEntity DataSourcePermissionEntity { get; set; }

        public cRoleEntity Role { get; set; }
    }
}
