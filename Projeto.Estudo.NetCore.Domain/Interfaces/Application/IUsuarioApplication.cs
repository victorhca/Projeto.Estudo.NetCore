using Projeto.Estudo.NetCore.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Estudo.NetCore.Domain.Interfaces.Application
{
    public interface IUsuarioApplication
    {
        Task AddAsync(UsuarioDto usuario);
        Task UpdateAsync(UsuarioDto usuario);
        Task DeleteAsync(int id);
        Task<UsuarioDto> GetAsync(int id);
    }
}
