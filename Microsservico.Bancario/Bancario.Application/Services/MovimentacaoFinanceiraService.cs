using AutoMapper;
using Bancario.Application.Dtos;
using Bancario.Application.Interfaces;
using Bancario.Domain.Entities;
using Bancario.Domain.Interfaces;

namespace Bancario.Application.Services
{
    public class MovimentacaoFinanceiraService : IMovimentacaoFinanceiraService
    {
        private readonly IContaBancariaService _contaService;
        private readonly IMovimentacaoFinanceiraRepository _movimentacaoRepository;
        private readonly IMapper _mapper;

        public MovimentacaoFinanceiraService(IContaBancariaService contaService, IMovimentacaoFinanceiraRepository movimentacaoRepository, IMapper mapper)
        {
            _contaService = contaService;
            _movimentacaoRepository = movimentacaoRepository;
            _mapper = mapper;
        }

        public async Task<bool> CriarMovimentacao(MovimentacaoFinanceiraDto movimentacaoDto)
        {
            ContaBancariaDto contaOrigemDto = await _contaService.ObterContaPorId(movimentacaoDto.ContaOrigem);

            if (contaOrigemDto.Saldo < movimentacaoDto.Valor)
            {
                return false;
            }

            ContaBancariaDto contaDestinoDto = await _contaService.ObterContaPorId(movimentacaoDto.ContaDestino);

            contaOrigemDto.Saldo -= movimentacaoDto.Valor;
            contaDestinoDto.Saldo += movimentacaoDto.Valor;

            List<ContaBancariaDto> listContasDto = new List<ContaBancariaDto>
            {
                { contaOrigemDto },
                { contaDestinoDto }
            };

            MovimentacaoFinanceira movimentacao = _mapper.Map<MovimentacaoFinanceiraDto, MovimentacaoFinanceira>(movimentacaoDto);

            bool resultMovimentacao = await _contaService.AtualizarContas(listContasDto);

            if (resultMovimentacao)
            {
                resultMovimentacao = await _movimentacaoRepository.Add(movimentacao);
            }

            return resultMovimentacao;
        }

        public async Task<IEnumerable<MovimentacaoFinanceiraDto>> ObterMovimentacoes(int idConta)
        {
            List<MovimentacaoFinanceira> listMovimentacao = await _movimentacaoRepository.ObterMovimentacoesConta(idConta);
            return _mapper.Map<List<MovimentacaoFinanceira>, List<MovimentacaoFinanceiraDto>>(listMovimentacao);
        }
    }
}
