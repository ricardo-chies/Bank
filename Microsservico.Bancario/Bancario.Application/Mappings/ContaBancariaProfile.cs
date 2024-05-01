using AutoMapper;
using Bancario.Application.Dtos;
using Bancario.Domain.Entities;

namespace Bancario.Application.Mappings
{
    public class ContaBancariaProfile : Profile
    {
        public ContaBancariaProfile()
        {
            CreateMap<ContaBancariaDto, ContaBancaria>()
                .ForMember(target => target.CPF, options => options.MapFrom(source => source.Cpf))
                .ForMember(target => target.IdConta, options => options.MapFrom(source => source.Conta))
                .ForMember(target => target.Saldo, options => options.MapFrom(source => source.Saldo))
                .ForMember(target => target.Status, options => options.MapFrom(source => source.Status));
            CreateMap<ContaBancaria, ContaBancariaDto>()
                .ForMember(target => target.Cpf, options => options.MapFrom(source => source.CPF))
                .ForMember(target => target.Conta, options => options.MapFrom(source => source.IdConta))
                .ForMember(target => target.Saldo, options => options.MapFrom(source => source.Saldo))
                .ForMember(target => target.Status, options => options.MapFrom(source => source.Status));
        }
    }
}
