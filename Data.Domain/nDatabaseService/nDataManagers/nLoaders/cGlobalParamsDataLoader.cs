using Base.FileData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Data.Domain.nDataService.nDataManagers;
using Data.Domain.nDefaultValueTypes;
using Data.Domain.nDataService.nDataManagers.nLoaders.nLoaderIDs;
using Bootstrapper.Core.nApplication;
using Data.Domain.nDatabaseService;

namespace Data.Domain.nDataService.nDataManagers.nLoaders
{
    public class cGlobalParamsDataLoader : cBaseDataLoader
    {
        public cParamsDataManager ParamsDataManager { get; set; }


        public cGlobalParamsDataLoader(cApp _App, cDataService _DataService, IFileDateService _FileDataService, cChecksumDataManager _ChecksumDataManager)
          : base(_App, LoaderIDs.GlobalParamsDataLoader, _DataService, _FileDataService, _ChecksumDataManager)
        {
        }

        public override void Init()
        {
			
        }
    }
}
