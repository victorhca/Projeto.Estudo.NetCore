using Microsoft.EntityFrameworkCore;
using Projeto.Estudo.NetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Estudo.NetCore.Data.Context
{
    public class EstudoDbContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }

        public EstudoDbContext(DbContextOptions<EstudoDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
