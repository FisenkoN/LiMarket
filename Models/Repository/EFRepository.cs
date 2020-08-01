using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LiMarket_V1._0._0.Models.Repository
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private MsContext db;
        private DbSet<TEntity> _entities;

        public MsContext Context
        {
            get { return db; }
            set 
            { 
                db = value;
                _entities = Context.Set<TEntity>();
            }
        }

        public void Create(TEntity item)
        {
            _entities.Add(item);
        }

        public void Delete(int id)
        {
            TEntity entity = _entities.Find(id);
            if (entity != null)
                _entities.Remove(entity);
        }

        public TEntity Get(int id)
        {
            return _entities.Find(id);
        }

        public ICollection<TEntity> GetAll()
        {
            var u = _entities;
            try
            {
                return _entities.ToList();
            }
            catch (Exception e)
            {
                var m = e.Message; 
                throw e;
            }
            
        }

        public void Update(TEntity item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}