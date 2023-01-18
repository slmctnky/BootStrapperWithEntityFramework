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
    public class cRoleDataSourceColumnMapEntity : cBaseEntity<cRoleDataSourceColumnMapEntity>
    {
        public cDataSourceColumnEntity DataSourceColumn { get; set; }

        public cRoleEntity Role { get; set; }
    }
}
