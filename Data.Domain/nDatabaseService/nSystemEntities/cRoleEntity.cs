using Base.Data.nDatabaseService.nDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.nDataService.nEntityServices.nSystemEntities
{
    public class cRoleEntity : cBaseEntity<cRoleEntity>
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public List<cRoleMenuMapEntity> RoleMenus { get; set; }
        
        public List<cRolePageMapEntity> RolePages { get; set; }

        public List<cUserRoleMapEntity> UserRoleMaps { get; set; }

        public List<cRoleDataSourcePermissionMapEntity> RoleDataSourcePermissionMaps { get; set; }

        public List<cRoleDataSourceColumnMapEntity> RoleDataSourceColumnMaps { get; set; }
    }

}
