using Base.Data.nDatabaseService;
using Base.Data.nDatabaseService.nDatabase;
using Base.FileData;
using Bootstrapper.Boundary.nCore.nObjectLifeTime;
using Bootstrapper.Core.nAttributes;
using Data.Domain.nDatabaseService;
using Data.GenericWebScaffold.nDataService.nDataManagers.nLoaders;

namespace Data.GenericWebScaffold.nDataService.nDataManagers
{
    [Register(typeof(IDefaultDataLoader), false, false, false, false, LifeTime.ContainerControlledLifetimeManager)]
    public class cDefaultDataLoaderManager : cBaseDataManager, IDefaultDataLoader
    {
        public cLanguageDataLoader LanguageDataLoader { get; set; }
        public cLanguageDataManager LanguageDataManager { get; set; }

        public cGlobalParamsDataLoader GlobalParamsDataLoader { get; set; }
        public cRoleDataLoader RoleDataLoader { get; set; }

        
        public cDefaultDataLoaderManager(cDataServiceContext CoreServiceContext, cDataService _DataService, IFileDateService _FileDataService
            , cLanguageDataLoader _LanguageDataLoader
            , cGlobalParamsDataLoader _GlobalParamsDataLoader
            , cRoleDataLoader _RoleDataLoader
            , cLanguageDataManager _LanguageDataManager
            )

          : base(CoreServiceContext, _DataService, _FileDataService)
        {
            LanguageDataLoader = _LanguageDataLoader;
            LanguageDataManager = _LanguageDataManager;
            RoleDataLoader = _RoleDataLoader;
            GlobalParamsDataLoader = _GlobalParamsDataLoader;

        }

        public void Load()
        {
            cDatabaseContext __DatabaseContext = DataService.GetDatabaseContext();

            __DatabaseContext.Perform(() => { LanguageDataLoader.Init(); });
            __DatabaseContext.Perform(() => { GlobalParamsDataLoader.Init(); });
            __DatabaseContext.Perform(() => { RoleDataLoader.Init(); });
        }
    }
}

