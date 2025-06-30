using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public async Task AddAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                entity.Id = Guid.NewGuid().ToString(); // Assuming Id is a string and you want to generate a new GUID
                entity.CreatedDate = DateTime.Now;
                entity.UpdatedDate = null;
                entity.DeletedDate = null;
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(TEntity entity)
        {
            //Terminate(entity);
            //AddAsync(entity);

            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                entity.UpdatedDate = DateTime.Now;
                entity.DeletedDate = null;
                updatedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }


        // Soft Delete
        public  async Task Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                entity.DeletedDate = DateTime.Now;
                deletedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        // Real Delete
        public async Task Terminate(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var terminatedEntity = context.Entry(entity);
                terminatedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);

                //return  context.Set<TEntity>().Where(x => x.DeletedDate == null).SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //return filter == null? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();

                return filter == null ? context.Set<TEntity>().Where(x => x.DeletedDate == null).ToList() : context.Set<TEntity>().Where(x => x.DeletedDate == null).Where(filter).ToList();
            }
        }

        public List<TEntity> GetDeletedAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //return filter == null? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();

                return filter == null ? context.Set<TEntity>().Where(x => x.DeletedDate != null).ToList() : context.Set<TEntity>().Where(x => x.DeletedDate != null).Where(filter).ToList();
            }
        }
    }
}
