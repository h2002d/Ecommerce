using Novir.Ecommerce.Data.Entities;
using Novir.Ecommerce.Data.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Novir.Ecommerce.Data.Repositories
{
    public interface ICommonRepository<T> where T : BaseEntity
    {
        public Task<List<T>> GetAll();
        public Task<T> GetById(int id);
        public Task<List<T>> GetAllBySpecification(ISpecification<T> commonSpecification);
        public Task<T> GetSingleBySpecification(ISpecification<T> commonSpecification);
        Task<T> Add(T entity);

        Task Update(T entity);

        Task Delete(int id);
    }
}
