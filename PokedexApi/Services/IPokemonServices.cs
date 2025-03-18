using PokedexApi.Models;


namespace PokedexApi.Services;

public interface IPokemonService
{
    Task<Pokemon?> GetPokemonById(Guid id, CancellationToken cancellationToken);
}