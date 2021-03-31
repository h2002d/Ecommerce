using Microsoft.EntityFrameworkCore;
using Novir.Ecommerce.Data.Entities;
using Novir.Ecommerce.Data.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novir.Ecommerce.Data.Repositories
{
    public class CommonRepository<T> : ICommonRepository<T> where T : BaseEntity
    {
        protected readonly DbContext _appDbContext;

        protected CommonRepository(DbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<T>> GetAll()
        {
            var model = await _appDbContext.Set<T>().ToListAsync();
            return model;
        }

        public async Task<List<T>> GetAllBySpecification(ISpecification<T> commonSpecification)
        {
            var result = await List(commonSpecification);
            return result;
        }

        public async Task<T> GetById(int id)
        {
            return await _appDbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetSingleBySpecification(ISpecification<T> commonSpecification)
        {
            var result = await List(commonSpecification);
            return result.FirstOrDefault();
        }
        public async Task<List<T>> List(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_appDbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            var res = await secondaryResult.Where(spec.Criteria).ToListAsync();
            return res.OrderByDescending(x => x.Id).ToList();
        }
        public async Task<T> Add(T entity)
        {
            //var result = _appDbContext.Set<T>().Add(entity);
            //await _appDbContext.SaveChangesAsync();

            // ToDo: Vakkhtang - after checking correctness of code remove this comment
            // this code is here to handle concurrency conflicts in Entity Framework Core
            // approach called "client wins"
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<T> result = null;
            try
            {
                result = _appDbContext.Set<T>().Add(entity);
                await _appDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.Single();
                entry.OriginalValues.SetValues(entry.GetDatabaseValuesAsync().ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result.Entity;
        }

        public async Task Update(T entity)
        {
            //_appDbContext.Entry(entity).State = EntityState.Modified;
            //await _appDbContext.SaveChangesAsync();

            // ToDo: Vakkhtang - after checking correctness of code remove this comment
            // this code is here to handle concurrency conflicts in Entity Framework Core
            // approach called "client wins"
            try
            {
                _appDbContext.Entry(entity).State = EntityState.Modified;
                await _appDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.Single();
                entry.OriginalValues.SetValues(entry.GetDatabaseValuesAsync().ConfigureAwait(false));
            }
        }

        public async Task Delete(int id)
        {
            var ent = _appDbContext.Set<T>().Find(id);
            _appDbContext.Set<T>().Remove(ent);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
