using System;
using Microsoft.EntityFrameworkCore;
using MinimalAPICatalogo.Context;
using MinimalAPICatalogo.Models;

namespace MinimalAPICatalogo.ApiEndpoints;

	public static class ProdutosEndpoints
	{
		public static void MapProdutosEndpoints(this WebApplication app)
		{
            app.MapGet("/produtos", async (AppDbContext db) =>
                await db.Produtos.ToListAsync())
                .WithTags("Produtos")
                .RequireAuthorization();

            app.MapGet("/produtos/{id:int}", async (int id, AppDbContext db) =>
            {
                return await db.Produtos.FindAsync(id)
                    is Produto produto
                    ? Results.Ok(produto)
                    : Results.NotFound();
            })
            .WithTags("Produtos");

            app.MapPost("/produtos", async (Produto produto, AppDbContext db) =>
            {
                db.Produtos.Add(produto);
                await db.SaveChangesAsync();

                return Results.Created($"/produtos/{produto.Id}", produto);
            })
            .WithTags("Produtos");

            app.MapPut("/produtos/{id:int}", async (int id, Produto produto, AppDbContext db) =>
            {
                if (produto.Id != id) return Results.BadRequest();

                var produtoDB = await db.Produtos.FindAsync(id);
                if (produtoDB is null) return Results.NotFound();

                produtoDB.Nome = produto.Nome;
                produto.Descricao = produto.Descricao;
                produtoDB.Preco = produto.Preco;
                produtoDB.ImagemUrl = produto.ImagemUrl;
                produtoDB.DataCadastro = produto.DataCadastro;
                produtoDB.Estoque = produto.Estoque;
                produtoDB.CategoriaId = produto.CategoriaId;

                await db.SaveChangesAsync();
                return Results.Ok(produtoDB);
            })
            .WithTags("Produtos");

            app.MapDelete("/produtos/{id:int}", async (int id, AppDbContext db) =>
            {
                var produto = await db.Produtos.FindAsync(id);
                if (produto is null) return Results.NotFound();

                db.Produtos.Remove(produto);
                await db.SaveChangesAsync();

                return Results.NoContent();
            })
            .WithTags("Produtos");
        }
	}

