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
}