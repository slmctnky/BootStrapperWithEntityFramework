using Base.FileData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Base.Data.nDatabaseService;
using Data.Domain.nDatabaseService;

using System.Drawing;
using Data.Domain.nDefaultValueTypes;
using Data.Domain.nDatabaseService.nSystemEntities;

namespace Data.Domain.nDataService.nDataManagers
{
    public class cMenuDataManager : cBaseDataManager
    {
        public cMenuDataManager(cDataServiceContext _CoreServiceContext, cDataService _DataService, IFileDateService _FileDataService)
          : base(_CoreServiceContext, _DataService, _FileDataService)
        {
        }

        public cMenuEntity GetMenuByCode(string _Code)
        {
            return cMenuEntity.Get(__Item => __Item.Code == _Code).FirstOrDefault();
        }

        public cMenuEntity AddMenu(string _MenuTypeCode, string _Name, string _Code, string _Icon, int _SortValue, cPageEntity _PageEntity)
        {
            cMenuEntity __MenuEntity = cMenuEntity.Add(new cMenuEntity()
            {
                Name = _Name,
                Code = _Code,
                Icon = _Icon,
                MenuTypeCode = _MenuTypeCode,
                SortValue = _SortValue,
                Page = _PageEntity
            }); ;
            
            __MenuEntity.Save();

            return __MenuEntity;
        }
        public cMenuEntity UpdateMenu(cMenuEntity __MenuEntity, string _MenuTypeCode, string _Name, string _Code, string _Icon, int _SortValue)
        {
			__MenuEntity.Name = _Name;
            __MenuEntity.Code = _Code;
            __MenuEntity.Icon = _Icon;
            __MenuEntity.MenuTypeCode = _MenuTypeCode;
            __MenuEntity.SortValue = _SortValue;
            __MenuEntity.Save();
            return __MenuEntity;
        }

        public cMenuEntity CreateMenuIfNotExists(string _MenuTypeCode, string _Name, string _Code, string _Icon,
            int _SortValue, cPageEntity _PageEntity)
        {
            cMenuEntity __MenuEntity = GetMenuByCode(_Code);
            if (__MenuEntity == null)
            {
                __MenuEntity = AddMenu(_MenuTypeCode, _Name, _Code, _Icon, _SortValue, _PageEntity);
            }
#if DEBUG
            else
            {
                __MenuEntity = UpdateMenu(__MenuEntity, _MenuTypeCode, _Name, _Code, _Icon, _SortValue);
            }
#endif
            return __MenuEntity;
        }

        public cMenuEntity CreateMenuIfNotExists(MenuIDs _MenuID, cPageEntity _PageEntity = null)
        {
            return CreateMenuIfNotExists(_MenuID.MenuType.Code, _MenuID.Name, _MenuID.Code, _MenuID.Icon, _MenuID.ID, _PageEntity);
        }

        public cMenuEntity CreateSubMenuIfNotExists(MenuIDs _RootMenuID, string _MenuTypeCode, string _Name, string _Code, string _Icon, int _SortValue, cPageEntity _PageEntity)
        {
            cMenuEntity __MenuEntity = GetMenuByCode(_Code);
            if (__MenuEntity == null)
            {
                __MenuEntity = AddMenu(_MenuTypeCode, _Name, _Code, _Icon, _SortValue,  _PageEntity);
            }

            cMenuEntity __RootMenuEntity = GetMenuByCode(_RootMenuID.Code);
            __MenuEntity.RootMenu = __RootMenuEntity;
			__MenuEntity.MenuTypeCode = _MenuTypeCode;
			__MenuEntity.Save();
            return __MenuEntity;
        }

        public cMenuEntity CreateSubMenuIfNotExists(MenuIDs _RootMenuID, MenuIDs _MenuID, cPageEntity _PageEntity)
        {
            return CreateSubMenuIfNotExists(_RootMenuID, _MenuID.MenuType.Code, _MenuID.Name, _MenuID.Code, _MenuID.Icon, _MenuID.ID, _PageEntity);
        }
        

       /* public List<object> GetSubMenus(List<MenuIDs> _MenuIDsList)
        {
            List<object> __List = new List<object>();
            foreach (MenuIDs _Menu in _MenuIDsList)
            {
                cMenuEntity __MenuEntity = GetMenuByCode(_Menu.Code);
                cPageEntity __Page = __MenuEntity.Page.GetValue();
                __List.Add(new
                {
                    url = __Page.Url,
                    icon = __MenuEntity.Icon,
                    name = __MenuEntity.Name,
                    Active = false
                });
                
            }
            return __List;
        }*/
    }
}
