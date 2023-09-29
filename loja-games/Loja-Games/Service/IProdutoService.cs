using Loja_Games.Model;

namespace Loja_Games.Service
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetAll();

        Task<Produto?> GetById(long id);

        Task<IEnumerable<Produto>> GetByConsole(string console);

        Task<Produto?> Create(Produto Produto);

        Task<Produto?> Update(Produto Produto);

        Task Delete(Produto Produto);
    }
}
