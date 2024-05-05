using Bancario.Application.Dtos;

namespace Bancario.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<bool> CriarUsuario(UsuarioDto usuarioDto);
        Task<UsuarioDto> ObterUsuarioPorCpf(string cpf);
        Task<UsuarioDto> LoginUsuario(string cpf, string senha);
    }
}
