using Base.FileData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Data.GenericWebScaffold.nDefaultValueTypes;
using Data.Boundary.nData;
using Data.GenericWebScaffold.nDataService.nDataManagers;
using Data.GenericWebScaffold.nDataService;
using Core.BatchJobService.nDefaultValueTypes;
using Base.Data.nDatabaseService;
using Data.Domain.nDatabaseService;
using Data.GenericWebScaffold.nDataService.nEntityServices.nEntities;
using Data.Domain.nDatabaseService.nEntities;
using System.Xml.Linq;

namespace Core.BatchJobService.nDataService.nDataManagers
{
    public class cBatchJobDataManager : cBaseDataManager
    {
        public cBatchJobDataManager(cDataServiceContext _CoreServiceContext, cDataService _DataService, IFileDateService _FileDataService)
          : base(_CoreServiceContext, _DataService, _FileDataService)
        {
        }

        public cBatchJobEntity GetBatchJobByCode(string _Code)
        {
            return cBatchJobEntity.Get(__Item => __Item.Code == _Code).FirstOrDefault();
        }
        public dynamic GetBatchJobByID(int _ID)
        {
            return cBatchJobEntity.GetEntityByID(_ID);
        }

        public List<cBatchJobEntity> GetBatchJobList()
        {
            return cBatchJobEntity.GetAll().ToList();
        }

        public cBatchJobEntity AddBatchJob(string _Code, string _Name, int _TimePeriodMilisecond, EBatchJobState _State, bool _AutoExecution, bool _ExecuteFirstWithoutWait, bool _StopAfterFirstExecution, int _MaxRetryCount)
        {
            cDatabaseContext __DatabaseContext = DataService.GetDatabaseContext();

            cBatchJobEntity __BatchJobEntity = cBatchJobEntity.Add(new cBatchJobEntity() {
                Code = _Code,
                Name = _Name,
                State = _State.ID,
                AutoAddExecution = _AutoExecution,
                ExecuteFirstWithoutWait = _ExecuteFirstWithoutWait,
                StopAfterFirstExecution = _StopAfterFirstExecution,
                TimePeriodMilisecond = _TimePeriodMilisecond,
                MaxRetryCount = _MaxRetryCount
            });

            __DatabaseContext.SaveChanges();

            return __BatchJobEntity;
        }
        public cBatchJobEntity UpdateBatchJob(cBatchJobEntity _BatchJobEntity, string _Code, string _Name, int _TimePeriodMilisecond, EBatchJobState _State, bool _AutoExecution, bool _ExecuteFirstWithoutWait, bool _StopAfterFirstExecution, int _MaxRetryCount)
        {
            cDatabaseContext __DatabaseContext = DataService.GetDatabaseContext();

            _BatchJobEntity.Code = _Code;
            _BatchJobEntity.Name = _Name;
            _BatchJobEntity.State = _State.ID;
            _BatchJobEntity.AutoAddExecution = _AutoExecution;
            _BatchJobEntity.ExecuteFirstWithoutWait = _ExecuteFirstWithoutWait;
            _BatchJobEntity.StopAfterFirstExecution = _StopAfterFirstExecution;
            _BatchJobEntity.TimePeriodMilisecond = _TimePeriodMilisecond;
            _BatchJobEntity.MaxRetryCount = _MaxRetryCount;
            __DatabaseContext.SaveChanges();

            return _BatchJobEntity;
        }
        public cBatchJobEntity UpdateBatchJob(int _ID, int _TimePeriodMilisecond,bool _AutoExecution, bool _ExecuteFirstWithoutWait, bool _StopAfterFirstExecution, int _MaxRetryCount)
        {
            cDatabaseContext __DatabaseContext = DataService.GetDatabaseContext();

            cBatchJobEntity _BatchJobEntity = cBatchJobEntity.GetEntityByID(_ID);

             
            _BatchJobEntity.AutoAddExecution = _AutoExecution;
            _BatchJobEntity.ExecuteFirstWithoutWait = _ExecuteFirstWithoutWait;
            _BatchJobEntity.StopAfterFirstExecution = _StopAfterFirstExecution;
            _BatchJobEntity.TimePeriodMilisecond = _TimePeriodMilisecond;
            _BatchJobEntity.MaxRetryCount = _MaxRetryCount;
            __DatabaseContext.SaveChanges();

            return _BatchJobEntity;
        }

        public cBatchJobEntity CreateBatchJobIfNotExists(string _Code, string _Name, int _TimePeriodMilisecond, EBatchJobState _State, bool _AutoExecution, bool _ExecuteFirstWithoutWait, bool _StopAfterFirstExecution, int _MaxRetryCount)
        {
            cDatabaseContext __DatabaseContext = DataService.GetDatabaseContext();

            cBatchJobEntity __BatchJobEntity = GetBatchJobByCode(_Code);
            if (__BatchJobEntity == null)
            {
                __BatchJobEntity = AddBatchJob(_Code, _Name, _TimePeriodMilisecond, _State, _AutoExecution, _ExecuteFirstWithoutWait, _StopAfterFirstExecution, _MaxRetryCount);
            }
            return __BatchJobEntity;
        }

        public cBatchJobEntity CreateBatchJobIfNotExists(BatchJobIDs _BatchJobID)
        {
            return CreateBatchJobIfNotExists(_BatchJobID.Code, _BatchJobID.Name, _BatchJobID.TimePeriodMilisecond, _BatchJobID.State, _BatchJobID.AutoExecution, _BatchJobID.ExecuteFirstWithoutWait, _BatchJobID.StopAfterFirstExecution, _BatchJobID.MaxRetryCount);
        }
    }
}
