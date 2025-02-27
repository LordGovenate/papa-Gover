using PokemonApi.Models;

namespace PokemonApi.Repositories;
    public interface IBooksRepository
{
    Task<Books> GetBookById(int id, CancellationToken cancellationToken);
    Task<bool> DeleteBook(int id, CancellationToken cancellationToken);
}
