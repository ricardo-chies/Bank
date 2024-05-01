using AutoMapper;
using Bancario.Application.Dtos;
using Bancario.Domain.Entities;

namespace Bancario.Application.Mappings
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioDto, Usuario>()
                .ForMember(target => target.NomeCompleto, options => options.MapFrom(source => source.Nome))
                .ForMember(target => target.CPF, options => options.MapFrom(source => source.Cpf))
                .ForMember(target => target.Email, options => options.MapFrom(source => source.Email))
                .ForMember(target => target.Senha, options => options.MapFrom(source => source.Senha))
                .ForMember(target => target.IdTipoUsuario, options => options.MapFrom(source => source.CodigoTipoUsuario));
            CreateMap<Usuario, UsuarioDto>()
                .ForMember(target => target.Nome, options => options.MapFrom(source => source.NomeCompleto))
                .ForMember(target => target.Cpf, options => options.MapFrom(source => source.CPF))
                .ForMember(target => target.Email, options => options.MapFrom(source => source.Email))
                .ForMember(target => target.Senha, options => options.MapFrom(source => source.Senha))
                .ForMember(target => target.CodigoTipoUsuario, options => options.MapFrom(source => source.IdTipoUsuario));
        }
    }
}
