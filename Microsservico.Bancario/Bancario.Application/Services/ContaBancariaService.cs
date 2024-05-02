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

        public async Task<bool> CriarContaBancaria(ContaBancariaDto contaDto)
        {
            ContaBancaria conta = _mapper.Map<ContaBancariaDto, ContaBancaria>(contaDto);
            return await _contaRepository.Add(conta);
        }

        public async Task<IEnumerable<ContaBancariaDto>> ObterSaldoClientes()
        {
            var listConta = await _contaRepository.GetAll();
            return _mapper.Map<IEnumerable<ContaBancaria>, IEnumerable<ContaBancariaDto>>(listConta);
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

        public async Task<IEnumerable<MovimentacaoFinanceiraDto>> ObterExtratoPorPeriodo(int idConta, DateTime dataInicio, DateTime dataFim)
        {
            List<MovimentacaoFinanceira> listMovimentacao = await _contaRepository.ObterExtratoPorPeriodo(idConta, dataInicio, dataFim);
            return _mapper.Map<List<MovimentacaoFinanceira>, List<MovimentacaoFinanceiraDto>>(listMovimentacao);
        }        
        
        public async Task<IEnumerable<MovimentacaoFinanceiraDto>> ObterExtratoPorConta(int idConta)
        {
            List<MovimentacaoFinanceira> listMovimentacao = await _contaRepository.ObterExtratoPorConta(idConta);
            return _mapper.Map<List<MovimentacaoFinanceira>, List<MovimentacaoFinanceiraDto>>(listMovimentacao);
        }

        public async Task<bool> ExcluirContaBancaria(int idConta)
        {
            return await _contaRepository.Delete(c => c.IdConta == idConta);
        }
    }
}
