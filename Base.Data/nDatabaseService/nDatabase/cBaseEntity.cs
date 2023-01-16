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
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public cBaseEntity()
        {
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }

        public static TEntity Add(TEntity _Entity)
        {
            DbContext __DbContext = DataService.GetCoreEFDatabaseContext();
            return __DbContext.Set<TEntity>().Add(_Entity).Entity;
        }

        public static void Remove(TEntity _Entity)
        {
            DbContext __DbContext = DataService.GetCoreEFDatabaseContext();
            __DbContext.Set<TEntity>().Remove(_Entity);
        }

        public static int RemoveRange(IEnumerable<TEntity> _Entities)
        {
            int __RemoveCount = _Entities.ToList().Count;
            DbContext __DbContext = DataService.GetCoreEFDatabaseContext();
            __DbContext.Set<TEntity>().RemoveRange(_Entities);
            return __RemoveCount;
        }

        public static int RemoveRange(Expression<Func<TEntity, bool>> _Predicate)
        {
            DbContext __DbContext = DataService.GetCoreEFDatabaseContext();
            List<TEntity> __WillRemove = __DbContext.Set<TEntity>().Where(_Predicate).ToList();
            int __RemoveCount = __WillRemove.Count;
            __DbContext.Set<TEntity>().RemoveRange(__WillRemove);
            return __RemoveCount;
        }

        public static void Find(Expression<Func<TEntity, bool>> _Predicate)
        {
            DbContext __DbContext = DataService.GetCoreEFDatabaseContext();
            __DbContext.Set<TEntity>().Where(_Predicate);
        }

        public static IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> _Predicate)
        {
            DbContext __DbContext = DataService.GetCoreEFDatabaseContext();
            return __DbContext.Set<TEntity>().Where<TEntity>(_Predicate);

        }

        public static IQueryable<TEntity> Get(Expression<Func<TEntity,int, bool>> _Predicate)
        {
            DbContext __DbContext = DataService.GetCoreEFDatabaseContext();
            return __DbContext.Set<TEntity>().Where<TEntity>(_Predicate);

        }
        public static IQueryable<TEntity> GetAll()
        {
            DbContext __DbContext = DataService.GetCoreEFDatabaseContext();
            return __DbContext.Set<TEntity>();
        }

        public static TEntity GetEntityByID(int _Id)
        {
            DbContext __DbContext = DataService.GetCoreEFDatabaseContext();
            return __DbContext.Set<TEntity>().Find(_Id);
        }
    }
}
