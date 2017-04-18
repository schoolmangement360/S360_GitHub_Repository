﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace S360Entity
{
    /// <summary>
    /// Base class for all SQL based service classes
    /// </summary>
    /// <typeparam name="T">The domain object type</typeparam>
    /// <typeparam name="TU">The database object type</typeparam>
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        internal System.Data.Entity.DbSet<T> dbSet;
        public BaseRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            _unitOfWork = unitOfWork;
            this.dbSet = _unitOfWork.Db.Set<T>();
        }

        /// <summary>
        /// Returns the object with the primary key specifies or throws
        /// </summary>
        /// <typeparam name="TU">The type to map the result to</typeparam>
        /// <param name="primaryKey">The primary key</param>
        /// <returns>The result mapped to the specified type</returns>
        public T Single(object primaryKey)
        {

            var dbResult = dbSet.Find(primaryKey);
            return dbResult;

        }

        /// <summary>
        /// Returns the object with the primary key specifies or the default for the type
        /// </summary>
        /// <typeparam name="TU">The type to map the result to</typeparam>
        /// <param name="primaryKey">The primary key</param>
        /// <returns>The result mapped to the specified type</returns>
        public T SingleOrDefault(object primaryKey)
        {
            var dbResult = dbSet.Find(primaryKey);
            return dbResult;
        }

        public bool Exists(object primaryKey)
        {
            return dbSet.Find(primaryKey) == null ? false : true;
        }

        public virtual int Insert(T entity)
        {
           dynamic obj= dbSet.Add(entity);
           this._unitOfWork.Db.SaveChanges();
           return obj.Id;

        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            _unitOfWork.Db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this._unitOfWork.Db.SaveChanges();
        }
        public int Delete(T entity)
        {
            if (_unitOfWork.Db.Entry(entity).State == System.Data.Entity.EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dynamic obj=dbSet.Remove(entity);
            this._unitOfWork.Db.SaveChanges();
            return obj.Id;
        }
        public IUnitOfWork UnitOfWork { get { return _unitOfWork; } }
        internal System.Data.Entity.DbContext Database { get { return _unitOfWork.Db; } }
        public Dictionary<string, string> GetAuditNames(dynamic dynamicObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable().ToList();
        }
        
        /// <summary>
        /// Excute Query And Get Result
        /// </summary>
        /// <param name="query">Query String</param>
        /// <param name="parameters">Inut Parameters</param>
        /// <returns></returns>
        public IEnumerable<T> DoQuery(string query, object[] parameters)
        {
            return dbSet.SqlQuery(query, parameters);
        }
    }
}
