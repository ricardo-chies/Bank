using AutoMapper;
using Bancario.Application.Dtos;
using Bancario.Application.Interfaces;
using Bancario.Domain.Entities;
using Bancario.Domain.Interfaces;

namespace Bancario.Application.Services
{
    public class ContaBancariaService : IContaBancariaService
    {
        private readonly IContaBancariaRepository _contaRepository;
        private readonly IMapper _mapper;

        public ContaBancariaService(IContaBancariaRepository contaRepository, IMapper mapper)
        {
            _contaRepository = contaRepository;
            _mapper = mapper;
        }

        public async Task<ContaBancariaDto> ObterContaPorId(int idConta)
        {
            ContaBancaria conta = await _contaRepository.GetById(c => c.IdConta == idConta);
            return _mapper.Map<ContaBancaria, ContaBancariaDto>(conta);
        }

        public async Task<bool> AtualizarContas(List<ContaBancariaDto> listContaDto)
        {
            List<ContaBancaria> listConta = _mapper.Map<List<ContaBancariaDto>, List<ContaBancaria>>(listContaDto);
            bool result = false;

            foreach (var conta in listConta)
            {
                result = await _contaRepository.Update(conta, c => c.IdConta);
            }

            return result;
        }
    }
}
