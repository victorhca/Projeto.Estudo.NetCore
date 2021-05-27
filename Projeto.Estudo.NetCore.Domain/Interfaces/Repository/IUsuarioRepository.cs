using Projeto.Estudo.NetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Estudo.NetCore.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        Task AddAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(int id);
        Task<Usuario> GetAsync(int id);
    }
}
