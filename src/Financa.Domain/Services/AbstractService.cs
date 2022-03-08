using AutoMapper;
using Financa.Domain.Entities;
using Financa.Domain.Interfaces.Repositories;
using Financa.Domain.Interfaces.Services;

namespace Financa.Domain.Services
{
    public abstract class AbstractService<E, A, L, D> : IAbstractService<E, A, L, D> where E : Entity
    {
        protected readonly IMapper _mapper;
        protected readonly IRepository<E> _repository;

        public AbstractService(IMapper mapper, IRepository<E> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public virtual async Task<D> AdicionaAsync(A modelDto)
        {
            var model = _mapper.Map<E>(modelDto);
            await _repository.Adicionar(model);
            await _repository.UnityOfWork.CommitAsync();
            return _mapper.Map<D>(model);
        }

        public async Task<D> AtualizaAsync(Guid id, D modelDto)
        {
            var fromDb = await _repository.ObterPorId(id);
            if (fromDb is null)
            {
                throw new ApplicationException($"{nameof(E)} inválido");
            }

            var model = _mapper.Map<E>(modelDto);
            await _repository.Atualizar(model);
            await _repository.UnityOfWork.CommitAsync();
            return _mapper.Map<D>(model);
        }

        public async Task<D> ObterPorId(Guid id)
        {
            var model = await _repository.ObterPorId(id);
            return _mapper.Map<D>(model);
        }

        public async Task<ICollection<L>> ObterTodosAsync()
        {
            var models = await _repository.ObterTodosAsync();
            return _mapper.Map<ICollection<L>>(models);
        }

        public async Task RemoverAsync(Guid id)
        {
            var fromDb = await _repository.ObterPorId(id);
            if (fromDb is null)
            {
                throw new ApplicationException($"{nameof(E)} inválido");
            }

            await _repository.Remover(fromDb);
            await _repository.UnityOfWork.CommitAsync();
        }
    }
}
