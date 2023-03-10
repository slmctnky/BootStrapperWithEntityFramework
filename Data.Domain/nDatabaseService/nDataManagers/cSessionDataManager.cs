using Base.FileData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Base.Data.nDatabaseService;
using Data.Domain.nDatabaseService;
using Data.Domain.nDatabaseService.nSystemEntities;

namespace Data.Domain.nDataService.nDataManagers
{
    public class cSessionDataManager : cBaseDataManager
    {
        public cSessionDataManager(cDataServiceContext _CoreServiceContext, cDataService _DataService, IFileDateService _FileDataService)
          : base(_CoreServiceContext, _DataService, _FileDataService)
        {
        }

        public cUserEntity GetUserBySessionID(string _SessionID)
        {
            cDatabaseContext __DatabaseContext = DataService.GetDatabaseContext();

            cUserSessionEntity? __UserSessionEntity = cUserSessionEntity.Get(__Item => __Item.SessionHash == _SessionID).FirstOrDefault();
            return __UserSessionEntity?.User;

        }

        
        public void DeleteOldSessionTempDate(DateTime _Date)
        {
            cUserSessionEntity.RemoveRange(__Item => __Item.CreateDate < _Date);
        }
        public int DeleteSession(string _SessionID)
        {

            return cUserSessionEntity.RemoveRange(__Item => __Item.SessionHash == _SessionID);
        }

        public cUserSessionEntity AddUserSession(cUserEntity _UserEntity, string _SessionID, string _IpAddress)
        {
            cDatabaseContext __DatabaseContext = DataService.GetDatabaseContext();

            cUserSessionEntity __UserSessionEntity = new cUserSessionEntity()
            {   
                IpAddress = _IpAddress,
                SessionHash = _SessionID,
                User = _UserEntity
            };

            cUserSessionEntity.Add(__UserSessionEntity);
            __DatabaseContext.SaveChanges();
            
            return __UserSessionEntity;
        }
        
        

    }
}
