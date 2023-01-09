using Base.FileData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Data.GenericWebScaffold.nDataService.nDataManagers;
using Data.GenericWebScaffold.nDefaultValueTypes;
using Data.GenericWebScaffold.nDataService.nDataManagers.nLoaders.nLoaderIDs;
using Bootstrapper.Core.nApplication;
using Data.Domain.nDatabaseService;

namespace Data.GenericWebScaffold.nDataService.nDataManagers.nLoaders
{
    public class cRoleDataLoader : cBaseDataLoader
    {
        public cRoleDataManager RoleDataManager { get; set; }
        public cRoleDataLoader(cApp _App, cDataService _DataService, IFileDateService _FileDataService
            , cRoleDataManager _RoleDataManager)
          : base(_App, LoaderIDs.RoleDataLoader, _DataService, _FileDataService)
        {
            RoleDataManager = _RoleDataManager;
        }

        public void Init()
        {
        }
    }
}
