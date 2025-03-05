using System.ServiceModel;
using PokemonApi.Models;
using System.Threading;
using System.Threading.Tasks;

namespace PokemonApi.Services;

    [ServiceContract(Name = "BooksService", Namespace = "http://pokemonapi/books-service")]
    public interface IBooksService
    {
        [OperationContract]
        Task<bool> DeleteBook(int id, CancellationToken cancellationToken);
    }