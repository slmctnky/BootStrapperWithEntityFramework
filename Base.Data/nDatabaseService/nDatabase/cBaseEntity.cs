using Bootstrapper.Boundary.nValueTypes.nConstType;
using Bootstrapper.Core.nApplication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Base.Data.nDatabaseService.nDatabase
{
    public class cBaseEntity<TEntity> : cBaseEntityType where TEntity : cBaseEntityType
    {
        [Key]
        public long ID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public cBaseEntity()
        {
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }


        public static void Remove(TEntity _Entity)
        {
            DbContext __DbContext = DataService.GetCoreEFDatabaseContext();
            __DbContext.Set<TEntity>().Remove(_Entity);
        }

        public static void RemoveRange(IEnumerable<TEntity> _Entities)
        {
            DbContext __DbContext = DataService.GetCoreEFDatabaseContext();
            __DbContext.Set<TEntity>().RemoveRange(_Entities);
        }

        public static void RemoveRange(Expression<Func<TEntity, bool>> _Predicate)
        {
            DbContext __DbContext = DataService.GetCoreEFDatabaseContext();
            __DbContext.Set<TEntity>().RemoveRange(__DbContext.Set<TEntity>().Where(_Predicate));
        }

        public static void Find(Expression<Func<TEntity, bool>> _Predicate)
        {
            DbContext __DbContext = DataService.GetCoreEFDatabaseContext();
            __DbContext.Set<TEntity>().Where(_Predicate);
        }


        public static IEnumerable<TEntity> GetAll()
        {
            DbContext __DbContext = DataService.GetCoreEFDatabaseContext();
            return __DbContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(long _Id)
        {
            DbContext __DbContext = DataService.GetCoreEFDatabaseContext();
            return __DbContext.Set<TEntity>().Find(_Id);
        }
    }
}
