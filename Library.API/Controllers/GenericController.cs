using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Library.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class GenericController<TModel, TViewModel> : Controller
        where TViewModel : class
        where TModel : class
    {
        protected readonly IGenericService<TModel> _service;
        protected readonly IMapper _mapper;
        protected readonly IValidator<TViewModel> _validator;

        public GenericController(IGenericService<TModel> service, IMapper mapper, IValidator<TViewModel> validator)
        {
            _service = service;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IEnumerable<TViewModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var tModels = await _service.GetAllAsync(cancellationToken);

            return _mapper.Map<IEnumerable<TViewModel>>(tModels);
        }

        [HttpGet("{id}")]
        public async Task<TViewModel> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var tModel = await _service.GetByIdAsync(id, cancellationToken);

            return _mapper.Map<TViewModel>(tModel);
        }

        [HttpPost]
        public async Task CreateAsync([FromBody] TViewModel tViewModel, CancellationToken cancellationToken)
        {
            ValidationResult result = await _validator.ValidateAsync(tViewModel);
            if (!result.IsValid)
            {
                throw new InvalidOperationException();
            }
            var tModel = _mapper.Map<TModel>(tViewModel);
            await _service.CreateAsync(tModel, cancellationToken);
        }

        [HttpPut]
        public async Task UpdateAsync(int id, [FromBody] TViewModel tViewModel, CancellationToken cancellationToken)
        {
            ValidationResult result = await _validator.ValidateAsync(tViewModel);
            if (!result.IsValid)
            {
                throw new InvalidOperationException();
            }
            var tModel = _mapper.Map<TModel>(tViewModel);
            await _service.UpdateAsync(id, tModel, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken)
        {
            await _service.DeleteByIdAsync(id, cancellationToken);
        }
    }
}
