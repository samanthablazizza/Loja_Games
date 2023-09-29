using Loja_Games.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace Loja_Games.Data

{//Gerencia o ciclo de vida do contexto de banco de dados e o forneça automaticamente quando necessário em diferentes partes da aplicação
  
    
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("tb_produtos");

            modelBuilder.Entity<Categoria>().ToTable("tb_categorias");

            _ = modelBuilder.Entity<Produto>()
          .HasOne(_ => _.Categoria)   // lado um da relação: Categoria classifica muitos produtos
          .WithMany(p => p.Produto)   //lado muitos da relação: um Categoria pode ter muitos Produtos
          .HasForeignKey("CategoriaId")   // Chave Estrangeira na tabela tb_produtos.
          .OnDelete(DeleteBehavior.Cascade);
        }
       public DbSet<Produto> Produtos { get; set; } = null!;

       public DbSet<Categoria> Categorias { get; set; } = null!;


     }

        
}
    
