﻿using Loja_Games.Data;
using Loja_Games.Model;
using Microsoft.EntityFrameworkCore;
using static Loja_Games.Service.Implements.ProdutoService;

namespace Loja_Games.Service.Implements
{
    public class ProdutoService : IProdutoService
    {
        private readonly AppDbContext _context;
        public ProdutoService(AppDbContext context)
            {
                _context = context;
            }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _context.Produtos
                        .Include(p => p.Categoria)
                        .ToListAsync();
        }
        public async Task<Produto?> GetById(long id)
        {
            try
            {
                var Produto = await _context.Produtos
                                    .Include(p => p.Categoria)
                                    .FirstAsync(i => i.Id == id);

                return Produto;
            }
            catch
            {
                return null;
            }
        }
        public async Task<IEnumerable<Produto>> GetByConsole(string console)
        {
            var Produto = await _context.Produtos
                                 .Include(p => p.Categoria)
                                 .Where(p => p.Nome.Contains(console))
                                 .ToListAsync();
            return Produto;
        }
        public async Task<Produto?> Create(Produto produto)
        {
            if (produto is not null)
            {
                var BuscaCategoria = await _context.Categorias.FindAsync(produto.Categoria.Id);
                if (BuscaCategoria is not null)
                    return null;
            }
            produto.Categoria = produto.Categoria is not null ? _context.Categorias.FirstOrDefault(c => c.Id == produto.Categoria.Id) : null;

            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();

            return produto;
        }
        public async Task<Produto?> Update(Produto produto)
        {
            var ProdutoUpdate = await _context.Produtos.FindAsync(produto);

            if (ProdutoUpdate is null)
            {
                return null;
            }

            if (produto.Categoria is not null)
            {
                var BuscaCategoria = await _context.Categorias.FindAsync(produto.Categoria.Id);

                if (BuscaCategoria is not null)
                    return null;
            }

            produto.Categoria = produto.Categoria is not null ? _context.Categorias.FirstOrDefault(t => t.Id == produto.Categoria.Id) : null;

            _context.Entry(ProdutoUpdate).State = EntityState.Detached;
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return produto;
        }
        public async Task Delete(Produto produto)
        {
            _context.Remove(produto);
            await _context.SaveChangesAsync();
        }

    }
}