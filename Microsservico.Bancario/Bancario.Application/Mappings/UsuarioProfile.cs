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
                .ForMember(target => target.NomeCompleto, options => options.MapFrom(source => source.nome))
                .ForMember(target => target.CPF, options => options.MapFrom(source => source.cpf))
                .ForMember(target => target.Email, options => options.MapFrom(source => source.email))
                .ForMember(target => target.Senha, options => options.MapFrom(source => source.senha))
                .ForMember(target => target.IdTipoUsuario, options => options.MapFrom(source => source.codigoTipoUsuario));
            CreateMap<Usuario, UsuarioDto>()
                .ForMember(target => target.nome, options => options.MapFrom(source => source.NomeCompleto))
                .ForMember(target => target.cpf, options => options.MapFrom(source => source.CPF))
                .ForMember(target => target.email, options => options.MapFrom(source => source.Email))
                .ForMember(target => target.senha, options => options.MapFrom(source => source.Senha))
                .ForMember(target => target.codigoTipoUsuario, options => options.MapFrom(source => source.IdTipoUsuario));
        }
    }
}
