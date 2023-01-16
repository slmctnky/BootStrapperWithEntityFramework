﻿using Base.Data.nDatabaseService;
using Base.FileData;
using Core.BatchJobService.nBatchJobManager.nJobs.nTestJob;
using Core.BatchJobService.nDataService.nDataManagers;
using Core.BatchJobService.nDefaultValueTypes;
using Data.Boundary.nData;
using Data.Domain.nDatabaseService;
using Data.Domain.nDatabaseService.nEntities;
using Data.GenericWebScaffold.nDataService;
using Data.GenericWebScaffold.nDataService.nDataManagers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BatchJobService.nBatchJobManager.nJobs.nTestJob
{
    public class cTestServiceJob : cBaseJob<cTestServiceJobProps>
    {
        cUserDataManager UserDataManager { get; set; }
        public cTestServiceJob(cDataServiceContext _CoreServiceContext, cDataService _DataService, IFileDateService _FileDataService, cBatchJobDataManager _BatchJobDataManager, cUserDataManager _UserDataManager)
         : base(BatchJobIDs.TestService, _CoreServiceContext, _DataService, _FileDataService, _BatchJobDataManager)
        {
            UserDataManager = _UserDataManager;
        }

        public override cBatchJobResult Run(cTestServiceJobProps _Props)
        {
			cUserEntity __UserEntity = UserDataManager.GetUserByEmail("customer@customer.com");
            cBatchJobResult __Result = new cBatchJobResult("Başarılı : " + _Props.TestValue + " , " + __UserEntity.Name + " " + __UserEntity.Surname);
            return __Result;
        }
    }
}
