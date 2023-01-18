using Base.Data.nDatabaseService.nDatabase;

namespace Data.Domain.nDataService.nEntityServices.nSystemEntities
{
    public class cDataSourceColumnEntity : cBaseEntity<cDataSourceColumnEntity>
    {
        public string ColumnName { get; set; }

        public string DataSourceCode { get; set; }

        public int DataSourceID { get; set; }

        public List<cRoleDataSourceColumnMapEntity> RoleDataSourceColumnMaps { get; set; }


    }
}
