using Base.FileData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Base.Data.nDatabaseService;
using Data.Domain.nDatabaseService;

using Data.Domain.nDefaultValueTypes;
using System.Data.Entity;
using Data.Domain.nDatabaseService.nSystemEntities;

namespace Data.Domain.nDataService.nDataManagers
{
    public class cDataSourceDataManager : cBaseDataManager
    {
        public cDataSourceDataManager(cDataServiceContext _CoreServiceContext, cDataService _DataService, IFileDateService _FileDataService)
          : base(_CoreServiceContext, _DataService, _FileDataService)
        {
        }

        public List<cDataSourceColumnEntity> GetDataSourceColumnsByRoleAndDataSourceID(List<cRoleEntity> _RoleList, DataSourceIDs _DataSourceID)
        {
            IQueryable<cRoleDataSourceColumnMapEntity> __Query = null;
            foreach (cRoleEntity __RoleEntity in _RoleList)
            {
                if (__Query == null)
                {
                    __Query = cRoleDataSourceColumnMapEntity.Get(__Item => __Item.DataSourceColumn.DataSourceCode == _DataSourceID.Code)
                    .Intersect(__RoleEntity.RoleDataSourceColumnMaps);
                }
                else
                {
                    __Query = cRoleDataSourceColumnMapEntity.Get(__Item => __Item.DataSourceColumn.DataSourceCode == _DataSourceID.Code)
                    .Intersect(__RoleEntity.RoleDataSourceColumnMaps)
                    .Intersect(__Query);
                }
            }


            List<cDataSourceColumnEntity> __Result = cDataSourceColumnEntity.Get(__Item => __Item.DataSourceCode == _DataSourceID.Code)
                .Intersect(__Query.Select(__Item => __Item.DataSourceColumn)).ToList();

            return __Result;
        }

        public List<cDataSourceColumnEntity> GetDataSourceColumns(DataSourceIDs _DataSourceID)
        {
            return  cDataSourceColumnEntity.Get(__Item => __Item.DataSourceCode == _DataSourceID.Code).ToList();
        }

        public cDataSourceColumnEntity GetDataSourceColumnsByRoleAndDataSourceID(cRoleEntity _Role, DataSourceIDs _DataSourceID, cDataSourceColumnEntity _Column)
        {
            return _Role.RoleDataSourceColumnMaps.Where(__Item => __Item.DataSourceColumn.DataSourceCode == _DataSourceID.Code && __Item.DataSourceColumn.ColumnName == _Column.ColumnName).FirstOrDefault()?.DataSourceColumn;
        }

        public bool IsDataSourceColumnExistsInRole(cRoleEntity _Role, DataSourceIDs _DataSourceID, cDataSourceColumnEntity _Column)
        {
            return GetDataSourceColumnsByRoleAndDataSourceID(_Role, _DataSourceID, _Column) != null;
        }

        public cDataSourceColumnEntity GetColumnByColumnNameInDataSource(DataSourceIDs _DataSourceID, string _ColumnName)
        {
            return cDataSourceColumnEntity.Get(__Item => __Item.ColumnName == _ColumnName && __Item.DataSourceCode == _DataSourceID.Code).First();
        }

        public void AddColumnToDataSource(DataSourceIDs _DataSourceID, string _ColumnName)
        {
            if (GetColumnByColumnNameInDataSource(_DataSourceID, _ColumnName) == null)
            {
                cDataSourceColumnEntity __DataSourceColumnEntity = cDataSourceColumnEntity.Add(new cDataSourceColumnEntity()
                {
                    ColumnName = _ColumnName,
                    DataSourceCode = _DataSourceID.Code,
                    DataSourceID = _DataSourceID.ID
                });
                
                __DataSourceColumnEntity.Save();
            }
        }

        public void DeleteColumnFromDataSourceAndRoles(List<cDataSourceColumnEntity> _Columns)
        {
            foreach (cDataSourceColumnEntity __Column in _Columns)
            {
                DeleteColumnFromDataSourceAndRoles(__Column);
            }
        }

        public void DeleteColumnFromDataSourceAndRoles(cDataSourceColumnEntity _Column)
        {
            cRoleDataSourceColumnMapEntity.RemoveRange(_Column.RoleDataSourceColumnMaps);
            _Column.Delete();
        }

        public bool IsDataSourceExistsInRole(cRoleEntity _Role, DataSourceIDs _DataSourceID)
        {
            return GetDataSourceInRoleByDataSourceID(_Role, _DataSourceID) != null;
        }

        public List<cDataSourcePermissionEntity> GetDataSourceInRoleByDataSourceID(List<cRoleEntity> _RoleList, DataSourceIDs _DataSourceIDs)
        {
            List<cDataSourcePermissionEntity> __Result = new List<cDataSourcePermissionEntity>();
            foreach (cRoleEntity __Item in _RoleList)
            {
                cDataSourcePermissionEntity __Permission = GetDataSourceInRoleByDataSourceID(__Item, _DataSourceIDs);
                if (__Permission != null)
                {
                    __Result.Add(__Permission);
                }
            }
            return __Result;
        }

        public cDataSourcePermissionEntity GetDataSourceInRoleByDataSourceID(cRoleEntity _Role, DataSourceIDs _DataSourceIDs)
        {
            return _Role.RoleDataSourcePermissionMaps.Where(__Item => __Item.DataSourcePermissionEntity.DataSourceID == _DataSourceIDs.ID).FirstOrDefault()?.DataSourcePermissionEntity;
        }

        public void AddDataSourceColumnToRole(cRoleEntity _Role, DataSourceIDs _DataSourceID, cDataSourceColumnEntity _Column)
        {
            if (!IsDataSourceColumnExistsInRole(_Role, _DataSourceID, _Column))
            {
                _Role.RoleDataSourceColumnMaps.Add(new cRoleDataSourceColumnMapEntity()
                {
                    Role = _Role,
                    DataSourceColumn = _Column
                });
                _Role.Save();
            }
        }



        public void AddDataSourceColumnToRole(cRoleEntity _Role, DataSourceIDs _DataSourceID, List<cDataSourceColumnEntity> _Columns)
        {
            foreach (var _Column in _Columns)
            {
                AddDataSourceColumnToRole(_Role, _DataSourceID, _Column);
            }
        }

        public void AddAllDatasourceColumnToRole(cRoleEntity _Role, DataSourceIDs _DataSourceID)
        {
            List<cDataSourceColumnEntity> __Columns = GetDataSourceColumns(_DataSourceID);
            AddDataSourceColumnToRole(_Role, _DataSourceID, __Columns);
        }

        public void AddDataSourceToRole(cRoleEntity _Role, DataSourceIDs _DataSourceID, bool _CanCreate, bool _CanRead, bool _CanUpdate, bool _CanDelete)
        {
            if (!IsDataSourceExistsInRole(_Role, _DataSourceID))
            {

                cDataSourcePermissionEntity __DataSourcePermissionEntity = cDataSourcePermissionEntity.Add(new cDataSourcePermissionEntity()
                {
                    CanCreate = _CanCreate,
                    CanRead = _CanRead,
                    CanUpdate = _CanUpdate,
                    CanDelete = _CanDelete,
                    DataSourceID = _DataSourceID.ID,
                    DataSourceCode = _DataSourceID.Code
                });
                
                __DataSourcePermissionEntity.Save();

                _Role.RoleDataSourcePermissionMaps.Add(new cRoleDataSourcePermissionMapEntity()
                {
                    Role = _Role,
                    DataSourcePermissionEntity = __DataSourcePermissionEntity
                });

                _Role.Save();
            }
            else
            {
                cDataSourcePermissionEntity __DataSourcePermissionEntity = GetDataSourceInRoleByDataSourceID(_Role, _DataSourceID);

                __DataSourcePermissionEntity.CanCreate = _CanCreate;
                __DataSourcePermissionEntity.CanRead = _CanRead;
                __DataSourcePermissionEntity.CanUpdate = _CanUpdate;
                __DataSourcePermissionEntity.CanDelete = _CanDelete;
                __DataSourcePermissionEntity.DataSourceID = _DataSourceID.ID;
                __DataSourcePermissionEntity.DataSourceCode = _DataSourceID.Code;
                __DataSourcePermissionEntity.Save();
            }
        }
    }
}
