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
            ContaBancariaDto contaDto = await _contaService.ObterContaPorId(movimentacaoDto.Conta);

            if (contaDto.Saldo < movimentacaoDto.Valor)
            {
                throw new InvalidOperationException("Não autorizado.");
            }

            MovimentacaoFinanceira movimentacao = _mapper.Map<MovimentacaoFinanceiraDto, MovimentacaoFinanceira>(movimentacaoDto);

            contaDto.Saldo -= movimentacaoDto.Valor;

            bool resultMovimentacao = await _contaService.AtualizarConta(contaDto);

            if (resultMovimentacao)
            {
                resultMovimentacao = await _movimentacaoRepository.Add(movimentacao);
            }

            return resultMovimentacao;
        }
    }
}
