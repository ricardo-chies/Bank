using AutoMapper;
using Bancario.Application.Dtos;
using Bancario.Application.Interfaces;
using Bancario.Domain.Entities;
using Bancario.Domain.Interfaces;

namespace Bancario.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<bool> CriarUsuario(UsuarioDto usuarioDto)
        {
            Usuario usuario = await _usuarioRepository.GetCpf(usuarioDto.Cpf);

            if (usuario != null)
            {
                throw new InvalidOperationException("Este CPF já possui cadastro.");
            }

            usuario = _mapper.Map<UsuarioDto, Usuario>(usuarioDto);

            return await _usuarioRepository.Add(usuario);
        }

        public async Task<UsuarioDto> ObterUsuarioPorCpf(string cpf)
        {
            Usuario usuario = await _usuarioRepository.GetCpf(cpf);
            return _mapper.Map<Usuario, UsuarioDto>(usuario);
        }

        public async Task<UsuarioDto> LoginUsuario(string cpf, string senha)
        {
            Usuario usuario = await _usuarioRepository.GetLogin(cpf, senha);
            return _mapper.Map<Usuario, UsuarioDto>(usuario);
        }
    }
}