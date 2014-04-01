using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using StudentProject.Core;
using StudentProject.Core.Entities;
using StudentProject.DALInterfaces;

namespace StudentProject.EFData
{
    public class RepositoryGeneric<TEntity, TKey> : BaseRepository, IRepositoryGeneric<TEntity, TKey> where TEntity : Entity
    {
        private readonly DbSet<TEntity> _set;

        public RepositoryGeneric(StudentContext context)
            : base(context)
        {
            _set = Context.Set<TEntity>();
        }

        public void Create(TEntity value)
        {
            _set.Add(value);
        }

        public void Update(TEntity value)
        {
            _set.Attach(value);
            Context.Entry(value).State = EntityState.Modified;
        }

        public void Remove(TEntity value)
        {
            _set.Remove(value);
        }

        public TEntity GetEntityById(TKey id)
        {
            var entity = _set.Find(id);
            return entity;
        }

        public TEntity FindEntity(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = _set.SingleOrDefault(predicate);
            return entity;
        }

        public IQueryable<TEntity> All()
        {
            return _set;
        }

        public IQueryable<TEntity> FilterEntities(Expression<Func<TEntity, bool>> predicate)
        {
            return _set.Where(predicate);
        }
    }
}
