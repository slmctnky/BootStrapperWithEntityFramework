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
    public class cGlobalParamsDataLoader : cBaseDataLoader
    {
        public cParamsDataManager ParamsDataManager { get; set; }


        public cGlobalParamsDataLoader(cApp _App, cDataService _DataService, IFileDateService _FileDataService)
          : base(_App, LoaderIDs.GlobalParamsDataLoader, _DataService, _FileDataService)
        {
        }

        public void Init()
        {
			
        }
    }
}
