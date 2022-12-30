using Base.FileData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Data.GenericWebScaffold.nDataService.nDataManagers;
using Data.GenericWebScaffold.nDefaultValueTypes;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using Data.GenericWebScaffold.nDataService.nDataManagers.nLoaders.nLoaderIDs;
using Bootstrapper.Core.nApplication;
using Data.Domain.nDatabaseService;

namespace Data.GenericWebScaffold.nDataService.nDataManagers.nLoaders
{
    public class cLanguageDataLoader : cBaseDataLoader
    {
        public cLanguageDataManager LanguageDataManager { get; set; }


        public cLanguageDataLoader(cApp _App, LoaderIDs _LoaderID, cDataService _DataService, IFileDateService _FileDataService
            , cLanguageDataManager _LanguageDataManager
         )
          : base(_App, LoaderIDs.LanguageDataLoader, _DataService, _FileDataService)
        {
            LanguageDataManager = _LanguageDataManager;
        }

        public void Init()
        {
        }
    }
}
