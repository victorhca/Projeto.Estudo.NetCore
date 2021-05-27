using Projeto.Estudo.NetCore.Data.Context;
using Projeto.Estudo.NetCore.Domain.Entities;
using Projeto.Estudo.NetCore.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Estudo.NetCore.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        protected readonly EstudoDbContext _estudoDbContext;

        public UsuarioRepository(EstudoDbContext estudoDbContext)
        {
            _estudoDbContext = estudoDbContext;
        }

        public async Task AddAsync(Usuario usuario)
        {
            _estudoDbContext.Usuario.Add(usuario);
            await _estudoDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var usuario = new Usuario { Id = id };
            _estudoDbContext.Usuario.Remove(usuario);
            await _estudoDbContext.SaveChangesAsync();
        }

        public async Task<Usuario> GetAsync(int id)
        {
            return await _estudoDbContext.Usuario.FindAsync(id);
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            var usuarioBase = await _estudoDbContext.Usuario.FindAsync(usuario.Id);
            if(usuarioBase != null)
            {
                _estudoDbContext.Entry(usuarioBase).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                _estudoDbContext.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _estudoDbContext.SaveChangesAsync();
            }
        }
    }
}
