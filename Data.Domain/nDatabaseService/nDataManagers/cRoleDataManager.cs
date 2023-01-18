﻿using Base.FileData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Data.Domain.nDefaultValueTypes;
using Base.Data.nDatabaseService;
using Data.Domain.nDatabaseService;
using Data.Domain.nDatabaseService.nSystemEntities;

namespace Data.Domain.nDataService.nDataManagers
{
    public class cRoleDataManager : cBaseDataManager
    {
        public cRoleDataManager(cDataServiceContext _CoreServiceContext, cDataService _DataService, IFileDateService _FileDataService)
          : base(_CoreServiceContext, _DataService, _FileDataService)
        {
        }
        
        public cRoleEntity GetRoleByCode(string _Code)
        {
            return cRoleEntity.Get(__Item => __Item.Code == _Code).FirstOrDefault();
        }


        public void CreateRuleByCodeAndNameIfNotExists(RoleIDs _RoleID)
        {
            CreateRuleByCodeAndNameIfNotExists(_RoleID.Name, _RoleID.Code);
        }
        public void CreateRuleByCodeAndNameIfNotExists(string _Name, string _Code)
        {
            cRoleEntity __RoleEntity = GetRoleByCode(_Code);
            if (__RoleEntity == null)
            {
                __RoleEntity = cRoleEntity.Add(new cRoleEntity()
                {
                    Name = _Name,
                    Code = _Code
                });
                __RoleEntity.Save();
            }
        }
        
        public void AddMenuToRole(cRoleEntity _Role, cMenuEntity _Menu)
        {
            if (!CheckIfNotExistsRoleMenu(_Role, _Menu))
            {
                _Role.RoleMenus.Add(new cRoleMenuMapEntity()
                {
                    Role = _Role,
                    Menu = _Menu,
                    SortValue = _Menu.SortValue
                });
                _Role.Save();
            }
        }

        public bool CheckIfNotExistsRoleMenu(cRoleEntity _Role, cMenuEntity _Menu)
        {
            return cRoleMenuMapEntity.Get(__Item => __Item.Role == _Role && __Item.Menu == _Menu).Count() > 0;
        }
        
        
    }
}
