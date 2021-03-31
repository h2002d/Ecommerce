using AutoMapper;
using Novir.Ecommerce.Data.Entities;
using Novir.Ecommerce.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Novir.Ecommerce.Core.Services
{
    public abstract class CommonService<TEntity, TDto> : ICommonService<TDto>
        where TDto : class
        where TEntity : BaseEntity
    {
        private readonly IMapper _mapper;
        private readonly ICommonRepository<TEntity> _commonRepository;

        public CommonService(IMapper mapper, ICommonRepository<TEntity> commonRepository)
        {
            _mapper = mapper;
            _commonRepository = commonRepository;
        }

        public async Task<TDto> Add(TDto dto)
        {
            if (dto == null) return null;

            var recordToAdd = _mapper.Map<TEntity>(dto);
            return _mapper.Map<TDto>(await _commonRepository.Add(recordToAdd));
        }

        public async Task Update(TDto dto)
        {
            await _commonRepository.Update(_mapper.Map<TEntity>(dto));
        }

        public async Task<List<TDto>> GetAll() => _mapper.Map<List<TDto>>(await _commonRepository.GetAll());

        public async Task<TDto> GetById(int id) => _mapper.Map<TDto>(await _commonRepository.GetById(id));

        public async Task Delete(int id)
        {
            await _commonRepository.Delete(id);
        }
    }
}
