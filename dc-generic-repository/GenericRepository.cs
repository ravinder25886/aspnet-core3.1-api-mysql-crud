﻿using dc_data_context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dc_generic_repository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal MySQLDBContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(MySQLDBContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public async virtual Task<IEnumerable<TEntity>> Get()
        {
            IQueryable<TEntity> query = dbSet;
            return await query.ToListAsync();
        }
        public async virtual Task<IList<TEntity>> FindAllBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().Where(predicate).ToListAsync();
        }
        /// <summary>
        /// Use this function when we need fetch data from dependent tables
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> FindAllByQuery(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate);
        }

        public async virtual Task<TEntity> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }
        public async virtual Task<TEntity> InsertAsync(TEntity entity)
        {
            dbSet.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public virtual async Task<bool> DeleteAsync(object id)
        {
            try
            {
                TEntity entityToDelete = await dbSet.FindAsync(id);
                Delete(entityToDelete);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            context.SaveChanges();
        }
        public async virtual Task<TEntity> UpdateAsync(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entityToUpdate;
        }
        //public virtual IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters)
        //{
        //    return dbSet.SqlQuery(query, parameters).ToList();
        //}
        //public virtual IEnumerable<TEntity> GetWithRawSql(string query)
        //{
        //    return dbSet.SqlQuery(query).ToList();
        //}
    }
}
