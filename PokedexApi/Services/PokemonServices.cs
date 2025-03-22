using PokedexApi.Models;
using PokedexApi.Repositories;

namespace PokedexApi.Services;

public class PokemonService : IPokemonService {

    private readonly IPokemonRepository _pokemonRepository;

    public PokemonService(IPokemonRepository pokemonRepository)
    {
        _pokemonRepository = pokemonRepository;
    }
    public async Task<Pokemon?> GetPokemonById(Guid id, CancellationToken cancellationToken)
    {
        return await _pokemonRepository.GetPokemonByIdAsync(id, cancellationToken);
    }

    public async Task<List<Pokemon>> GetPokemonByName(string name, CancellationToken cancellationToken)
{
    return await _pokemonRepository.GetPokemonByNameAsync(name, cancellationToken);
}

    public async Task<bool> DeletePokemonByIdAsync(Guid id, CancellationToken cancellationToken){
        return await _pokemonRepository.DeletePokemonByIdAsync(id, cancellationToken);

}
}