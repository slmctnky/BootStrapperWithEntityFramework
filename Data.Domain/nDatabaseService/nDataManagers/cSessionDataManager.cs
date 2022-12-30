using Base.FileData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Base.Data.nDatabaseService;
using Data.Domain.nDatabaseService;
using DData.Domain.nDatabaseService.nEntities;
using Microsoft.AspNetCore.Http;
using Data.Domain.nDatabaseService.nEntities;
using System.Reflection.Metadata;
using System.Net;

namespace Data.GenericWebScaffold.nDataService.nDataManagers
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

            cUserSessionEntity? __UserSessionEntity = __DatabaseContext.Sessions
                                      .Where(__Item => __Item.SessionHash == _SessionID)
                                      .FirstOrDefault();
            return __UserSessionEntity?.User;


           /* string[] nums = { "88452", "121867" };
            var q1 = s.Query<TestObject>()
                .Where(te => nums.Contains(te.Number))
                .GroupBy(te => te.Number)
                .Select(g => new { number = g.Key, date = g.Max(te => te.Date) });

            var q2 = s.Query<TestObject>()
                .Where(te => q1.Any(x => x.number == te.Number && x.date == te.Date))
                .ToList();*/

        }

        
        public int DeleteOldSessionTempDate(DateTime _Date)
        {
            cUserSessionEntity.RemoveRange(__Item => __Item.CreateDate < _Date);
        }
        public void DeleteSession(string _SessionID)
        {

            cDatabaseContext __DatabaseContext = DataService.GetDatabaseContext();

            cUserSessionEntity __UserSessionEntity = new cUserSessionEntity()
            {
                IpAddress = _IpAddress,
                SessionHash = _SessionID,
                User = _UserEntity
            };

            __DatabaseContext.Sessions.Remove(__UserSessionEntity);
            __DatabaseContext.SaveChanges();

            return __UserSessionEntity;


            IDataService __DataService = DataServiceManager.GetDataService();

            __DataService.Database.Delete<cUserSessionTempEntity>()
                   .Operand(__Item => __Item.SessionHash).Eq(_SessionID)
                   .ToQuery()
                   .ExecuteForDeleteAndUpdate();

            __DataService.Database.Delete<cUserSessionEntity>()
                   .Operand(__Item => __Item.SessionHash).Eq(_SessionID)
                   .ToQuery()
                   .ExecuteForDeleteAndUpdate();         
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

            __DatabaseContext.Sessions.Add(__UserSessionEntity);
            __DatabaseContext.SaveChanges();
            
            return __UserSessionEntity;
        }
        
        

        /*int blue = 0;


        //DataService.Perform<cPowerLineDataService, string>(Deneme, DataService);
        cSessionEntity __TempAlias = null;

        cSql __SqlStr = DataService.Database.Query<cSessionEntity>(() => __TempAlias).SelectAll().Where().Exists(
            DataService.Database.Query<cUserEntity>().SelectID().Where().Operand(__Item => __Item.ID).Eq(() => __TempAlias).ToQuery()
            ).ToQuery().ToSql();

        DataTable __Table3 = DataService.Database.DefaultConnection.Query(__SqlStr);

        //DataService.Database.Query<cSessionEntity>().Left().Join().On().EndFilter().Where().Operand().Ge().EndFilter().



        cSql __Sql = DataService.Database.Query<cSessionEntity>(() => __TempAlias).Max(__Item => __Item.ID).SelectColumn<cUserEntity>(__Item => __Item.ID, __Item => __Item.SessionHash)
           .Inner<cUserEntity>().Join
           (
                DataService.Database.Query<cUserEntity>().SelectColumn(__Item => __Item.Surname, __Item => __Item.ID)
           )
           .On()
           .Operand(__User => __User.ID).Eq(() => __TempAlias)
           .ToQuery()
           .Where()
           .Operand<cUserEntity>().Between(1, () => __TempAlias.ID)
           .ToQuery()
           .GroupBy<cUserEntity>(__Item => __Item.ID, __Item => __Item.SessionHash).Having().Count<cUserEntity>().Lt(10).ToQuery()
           .OrderBy().Asc(__Item => __Item.ID, __Item => __Item.SessionHash).ToQuery()
           //.RowNumber().OrderBy().Asc<cUserEntity>().ToQuery()
           //.Take(2, 5)
           //.Take(3, 4)
           .ToSql();

        DataTable __Table2 = DataService.Database.DefaultConnection.Query(__Sql);


        cUserEntity __TempUserAlias = null;

        IQuery __Query = DataService.Database.Query<cUserEntity>().SelectAll();
        //IQuery __Query2 = DataService.Database.Query<cUserEntity>(__Query).SelectAll();
        cQuery<cUserEntity> __Query2 = (cQuery<cUserEntity>)DataService.Database.Query<cUserEntity>(() => __TempUserAlias, __Query)
            .Max(__Item => __Item.ID)
            .Where()
            .Operand(__User => __User.ID).Eq(2)
            .And
            .Operand(__User => __User.Name).Eq("Hakan")
            .And
            .Exists(DataService.Database.Query<cSessionEntity>().SelectAll().Where().Operand<cUserEntity>().Eq(() => __TempUserAlias.ID).ToQuery())
            .ToQuery();
        __Query2.Left<cSessionEntity>().Join().On()
                .Operand("UserID").EqAny("aa","bb")
                .And
                .Operand("UserID").EqAny(3, 5, 7)
                .And
                .Operand(__Item=> __Item.SessionHash).Like("%5")
            .ToQuery();
        cSql __aa = __Query2.Cross().Apply(
            DataService.Database.Query<cSessionEntity>().SelectAll().Where().Operand<cUserEntity>().Eq(() => __TempUserAlias.ID).ToQuery()
            ).EndApply()

            //.GroupBy().End()



            .ToSql();
        //cSql __aa2 = __Query.ToSql();

        //IQuery __Query3 = DataService.Database.Query<cSessionEntity>(__Query2).SelectAll().Where().Operand("SessionID").Eq(15).End();

        // cSql __aa = __Query3.ToSql();
        DataTable __Table = DataService.Database.DefaultConnection.Query(__aa);
        //cSql __Sql = DataService.Database.Query<cUserEntity>(__Query).SelectAllColumns().ToSql();*/
    }
}
