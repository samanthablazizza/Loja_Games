﻿using Loja_Games.Model;

namespace Loja_Games.Service
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetAll();

        Task<Produto?> GetById(long id);

        Task<IEnumerable<Produto>> GetByNome(string nome);

        Task<Produto?> Create(Produto produto);

        Task<Produto?> Update(Produto produto);

        Task Delete(Produto produto);
    }
}
