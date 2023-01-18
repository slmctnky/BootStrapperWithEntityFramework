using Base.FileData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Base.Data.nDatabaseService;
using Data.Domain.nDatabaseService;
using Data.Domain.nDataService.nEntityServices.nSystemEntities;
using System.Security.Policy;
using Data.Domain.nDefaultValueTypes;

namespace Data.Domain.nDataService.nDataManagers
{
    public class cPageDataManager : cBaseDataManager
    {
        public cPageDataManager(cDataServiceContext _CoreServiceContext, cDataService _DataService, IFileDateService _FileDataService)
          : base(_CoreServiceContext, _DataService, _FileDataService)
        {
        }

        public cPageEntity GetPageByUrl(string _Url)
        {
            return cPageEntity.Get(__Item => __Item.Url == _Url).FirstOrDefault();
        }

        public cPageEntity AddPage(string _Name, string _Code, string _Url, string _ComponentName)
        {
            cPageEntity __PageEntity = cPageEntity.Add(new cPageEntity()
            {
                Name = _Name,
                Code = _Code,
                Url = _Url,
                ComponentName = _ComponentName
            });
            __PageEntity.Save();
            return __PageEntity;
        }
        public cPageEntity UpdatePage(cPageEntity __PageEntity, string _Name, string _Code, string _Url, string _ComponentName)
        {

            __PageEntity.Name = _Name;
            __PageEntity.Code = _Code;
            __PageEntity.Url = _Url;
            __PageEntity.ComponentName = _ComponentName;
            __PageEntity.Save();
            return __PageEntity;
        }

        public void CreatePageIfNotExists(PageIDs _PageID)
        {
            CreatePageIfNotExists(_PageID.Name, _PageID.Code, _PageID.Url, _PageID.Component);
        }

        public void CreatePageIfNotExists(string _Name, string _Code, string _Url, string _ComponentName)
        {
            cPageEntity __PageEntity = GetPageByUrl(_Url);
            if (__PageEntity == null)
            {
                AddPage(_Name, _Code, _Url, _ComponentName);
            }
#if DEBUG
            else
            {

                UpdatePage(__PageEntity, _Name, _Code, _Url, _ComponentName);

            }
#endif
        }

        public void AddPageToRole(cRoleEntity _Role, cPageEntity _Page)
        {
            if (_Page != null && !ControlRoleMenueExists(_Role, _Page))
            {
                _Role.RolePages.Add(new cRolePageMapEntity() {
                    Page = _Page,
                    Role = _Role
                });
                _Role.Save();
            }
        }

        public bool ControlRoleMenueExists(cRoleEntity _Role, cPageEntity _Page)
        {
            return cRolePageMapEntity.Get(__Item => __Item.Role == _Role && __Item.Page == _Page).Count() > 0;
        }
    }
}
