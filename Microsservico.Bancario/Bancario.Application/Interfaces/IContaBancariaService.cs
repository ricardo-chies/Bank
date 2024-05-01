﻿using Bancario.Application.Dtos;

namespace Bancario.Application.Interfaces
{
    public interface IContaBancariaService
    {
        Task<ContaBancariaDto> ObterContaPorId(int idConta);
        Task<bool> AtualizarConta(ContaBancariaDto contaDto);
    }
}