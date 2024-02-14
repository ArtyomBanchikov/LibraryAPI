using AutoMapper;
using Library.BLL.Interfaces;
using Library.DAL.Interfaces;

namespace Library.BLL.Services
{
    public class GenericService<TModel, TEntity> : IGenericService<TModel>
        where TModel : class
        where TEntity : class
    {
        protected readonly IGenericRepository<TEntity> _repository;

        protected readonly IMapper _mapper;

        public GenericService(IGenericRepository<TEntity> genericRepository, IMapper mapper)
        {
            _repository = genericRepository;
            _mapper = mapper;
        }

        public async Task<TModel> CreateAsync(TModel model, CancellationToken ct)
        {
            var resultEntity = await _repository.CreateAsync(_mapper.Map<TEntity>(model), ct);

            return _mapper.Map<TModel>(resultEntity);
        }

        public async Task DeleteByIdAsync(int id, CancellationToken ct)
        {
            var resultEntity = await _repository.GetByIdAsync(id, ct);

            await _repository.DeleteAsync(resultEntity, ct);
        }

        public async Task<IEnumerable<TModel>> GetAllAsync(CancellationToken ct)
        {
            var result = _mapper.Map<IEnumerable<TModel>>(await _repository.GetAllAsync(ct));

            return result;
        }

        public async Task<TModel> GetByIdAsync(int id, CancellationToken ct)
        {
            var resultEntity = await _repository.GetByIdAsync(id, ct);

            return _mapper.Map<TModel>(resultEntity);
        }

        public async Task<TModel> UpdateAsync(int id, TModel model, CancellationToken ct)
        {
            var entity = _mapper.Map<TEntity>(model);

            var resultEntity = await _repository.UpdateAsync(entity, ct);

            return _mapper.Map<TModel>(resultEntity);
        }
    }
}
