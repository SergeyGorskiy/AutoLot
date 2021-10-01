using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AutoLotDAL.EF;
using AutoLotDAL.Models.Base;

namespace AutoLotDAL.Repos
{
    public class BaseRepo<T> : IDisposable, IRepo<T> where T:EntityBase, new()
    {
        private readonly DbSet<T> _table;
        private readonly AutoLotEntities _db;

        public BaseRepo()
        {
            _db = new AutoLotEntities();
            _table = _db.Set<T>();
        }

        protected AutoLotEntities Context => _db;

        public void Dispose()
        {
            _db.Dispose();
        }

        internal int SaveChanges()
        {
            try
            {
                return _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw;
            }
            catch (DbUpdateException e)
            {
                throw;
            }
            catch (CommitFailedException e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public int Add(T entity)
        {
            _table.Add(entity);
            return SaveChanges();
        }
        public int AddRange(IList<T> entities)
        {
            _table.AddRange(entities);
            return SaveChanges();
        }
        public int Save(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }
        public int Delete(int id, byte[] timeStamp)
        {
            _db.Entry(new T() {Id = id, Timestamp = timeStamp}).State = EntityState.Deleted;
            return SaveChanges();
        }
        public int Delete(T entity)
        {
            _db.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }
        public T GetOne(int? id) => _table.Find(id);
        public virtual List<T> GetAll() => _table.ToList();
        public List<T> ExecuteQuery(string sql) => _table.SqlQuery(sql).ToList();
        public List<T> ExecuteQuery(string sql, object[] sqlParametersObject) =>
            _table.SqlQuery(sql, sqlParametersObject).ToList();
    }
}