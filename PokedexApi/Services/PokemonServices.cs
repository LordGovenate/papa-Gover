using PokedexApi.Exceptions;
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

    public async Task<Pokemon> CreatePokemonAsync(Pokemon pokemon, CancellationToken cancellationToken)
{
    var existingPokemons = await _pokemonRepository.GetPokemonByNameAsync(pokemon.Name, cancellationToken);
    if (existingPokemons.Any())
    {
        throw new PokemonConflictController($"El Pokémon '{pokemon.Name}' ya existe.");
    }

    return await _pokemonRepository.CreatePokemonAsync(pokemon, cancellationToken);
}

}