using System;
using Microsoft.EntityFrameworkCore;
using MinimalAPICatalogo.Models;

namespace MinimalAPICatalogo.Context;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
	}

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Categoria>().HasKey(c => c.Id);
		modelBuilder.Entity<Categoria>().Property(c => c.Nome).HasMaxLength(100).IsRequired();
		modelBuilder.Entity<Categoria>().Property(c => c.Descricao).HasMaxLength(300).IsRequired();

		modelBuilder.Entity<Produto>().HasKey(p => p.Id);
        modelBuilder.Entity<Produto>().Property(p => p.Nome).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Produto>().Property(p => p.Descricao).HasMaxLength(300).IsRequired();
        modelBuilder.Entity<Produto>().Property(p => p.ImagemUrl).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Produto>().Property(p => p.Preco).HasPrecision(14, 2).IsRequired();

		modelBuilder.Entity<Produto>().HasOne<Categoria>(c => c.Categoria).WithMany(p => p.Produtos).HasForeignKey(c => c.Id);
    }
}

