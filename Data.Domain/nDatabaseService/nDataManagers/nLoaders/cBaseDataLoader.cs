using Base.FileData;
using Base.FileData.nFileDataService;
using Bootstrapper.Core.nApplication;
using Bootstrapper.Core.nCore;
using Data.Domain.nDatabaseService;
using Data.GenericWebScaffold.nDataService.nDataManagers.nLoaders.nLoaderIDs;
using Data.GenericWebScaffold.nDefaultValueTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Data.GenericWebScaffold.nDataService.nDataManagers.nLoaders
{
    public class cBaseDataLoader : cCoreObject
    { 
		public LoaderIDs LoaderID { get; set; }
		public cDataService DataService { get; set; }
        public IFileDateService FileDataService { get; set; }

		public cBaseDataLoader(cApp _App, LoaderIDs _LoaderID, cDataService _DataService, IFileDateService _FileDataService)
          : base(_App)
        {
			LoaderID = _LoaderID;
            DataService = _DataService;
            FileDataService = _FileDataService;
        }

		public string GetTotalString<TType>(List<TType> _List)
		{
			JArray __JArray = JArray.FromObject(_List);
			return __JArray.ToString();
		}
	}
}
