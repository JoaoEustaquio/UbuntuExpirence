using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using qodeless.domain.Entities;
using qodeless.domain.Interfaces.Repositories;
using qodeless.Infra.CrossCutting.Identity.Data;

namespace qodeless.domain.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext Db;

        protected readonly DbSet<TEntity> DbSet;

        public Repository(ApplicationDbContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }
        public IQueryable<TEntity> GetAllBy(Func<TEntity, bool> exp) => DbSet.Where(exp).AsQueryable().AsNoTracking();
        public TEntity GetBy(Func<TEntity, bool> exp) => DbSet.AsNoTracking().FirstOrDefault(exp);
        public TEntity GetById(Guid id) => DbSet.Find(id);
       

        /// <summary>
        /// Function Add run sql command "INSERT INTO TABLE"
        /// </summary>
        /// <param name="obj">Entity from this table</param>
        /// <param name="bCommit">True = Save Changes, False = Does not save on database </param>
        /// <returns></returns>
        public bool Add(TEntity obj, bool bCommit)
        {
            DbSet.Add(obj);
            return !bCommit || SaveChanges() > 0;
        }

        /// <summary>
        /// Function Upsert run sql command "MERGE INTO TABLE"
        /// </summary>
        /// <param name="obj">Entity from this table</param>
        /// <param name="exp">Database Clause in Lambda expression</param>
        /// <param name="bCommit">True = Save Changes, False = Does not save on database</param>
        /// <returns></returns>
        public bool Upsert(TEntity obj, Func<TEntity, bool> exp, bool bCommit)
        {
            if (None(exp))
                return Add(obj, bCommit);
            else
                return Update(obj, bCommit);
        }
        public bool Any(Func<TEntity, bool> exp) => DbSet.AsNoTracking().Any(exp);
        public bool None(Func<TEntity, bool> exp) => !DbSet.AsNoTracking().Any(exp);
        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
        public IQueryable<TEntity> GetAll() => DbSet.AsNoTracking();
        public bool ForceDelete(Guid id, bool bCommit)
        {
            DbSet.Remove(DbSet.Find(id));
            return !bCommit || SaveChanges() > 0;
        }
        public bool SoftDelete(TEntity obj)
        {
            var entity = obj as Entity;
            if (entity == null) return false;

            return ForceDelete(entity.Id, true);
            //entity.Delete();
            //DbSet.Update(obj);
            //return SaveChanges() > 0;
        }
        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
        public bool Update(TEntity obj, bool bCommit)
        {
            var entity = obj as Entity;
            if (entity == null) return false;
            entity.Update();
            DbSet.Update(obj);
            return !bCommit || SaveChanges() > 0;
        }
        public bool Save(TEntity obj, bool bCommit = true)
        {
            var entity = obj as Entity;
            if (Guid.Empty == entity.Id)
                Add(obj, false);
            else
                Update(obj, false);

            return !bCommit || SaveChanges() > 0;
        }
    }
}
