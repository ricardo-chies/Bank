using AutoMapper;
using Bancario.Application.Dtos;
using Bancario.Domain.Entities;

namespace Bancario.Application.Mappings
{
    public class MovimentacaoFinanceiraProfile : Profile
    {
        public MovimentacaoFinanceiraProfile()
        {
            CreateMap<MovimentacaoFinanceiraDto, MovimentacaoFinanceira>()
                .ForMember(target => target.IdMovimentacao, options => options.MapFrom(source => source.CodigoMovimentacao))
                .ForMember(target => target.IdConta, options => options.MapFrom(source => source.Conta))
                .ForMember(target => target.DataMovimentacao, options => options.MapFrom(source => source.DataMovimentacao))
                .ForMember(target => target.Descricao, options => options.MapFrom(source => source.Descricao))
                .ForMember(target => target.Valor, options => options.MapFrom(source => source.Valor));
            CreateMap<MovimentacaoFinanceira, MovimentacaoFinanceiraDto>()
                .ForMember(target => target.CodigoMovimentacao, options => options.MapFrom(source => source.IdMovimentacao))
                .ForMember(target => target.Conta, options => options.MapFrom(source => source.IdConta))
                .ForMember(target => target.DataMovimentacao, options => options.MapFrom(source => source.DataMovimentacao))
                .ForMember(target => target.Descricao, options => options.MapFrom(source => source.Descricao))
                .ForMember(target => target.Valor, options => options.MapFrom(source => source.Valor));
        }
    }
}
