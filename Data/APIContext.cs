using DevSteamAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace DevSteamAPI.Data
{
    public class APIContext : IdentityDbContext<Usuario>
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options)
        { }
        // DbSet

        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<JogoCategoria> JogosCategorias { get; set; }
        public DbSet<JogoMidia> jogoMidias { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }
        public DbSet<ItemCarrinho> ItensCarrinhos { get; set; }
        public DbSet<Cupom> Cupons { get; set; }
        public DbSet<CupomCarrinho> CuponsCarrinho { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Tabelas
            builder.Entity<Jogo>().ToTable("Jogos");
            builder.Entity<Categoria>().ToTable("Categorias");
            builder.Entity<JogoCategoria>().ToTable("JogosCategorias");
            builder.Entity<JogoMidia>().ToTable("JogosMidias");
            builder.Entity<Carrinho>().ToTable("Carrinhos");
            builder.Entity<ItemCarrinho>().ToTable("ItensCarrinhos");
            builder.Entity<Cupom>().ToTable("Cupons");
            builder.Entity<CupomCarrinho>().ToTable("CuponsCarrinho");
        }
    }
}
