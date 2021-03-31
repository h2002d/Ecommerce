using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Novir.Ecommerce.Core.Services
{
    public interface ICommonService<TDto> where TDto : class
    {
        public Task<List<TDto>> GetAll();
        public Task<TDto> GetById(int id); 
        Task<TDto> Add(TDto entity);

        Task Update(TDto entity);

        Task Delete(int id);
    }
}
