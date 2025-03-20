using System.ServiceModel;
using PokemonApi.Dtos;
using PokemonApi.Repositories;
using PokemonApi.Mappers;
using PokemonApi.Validators;

namespace PokemonApi.Services;

public class PokemonService : IPokemonService
{
    private readonly IPokemonRepository _pokemonRepository;

    public PokemonService(IPokemonRepository pokemonRepository)
    {
        _pokemonRepository = pokemonRepository;
    }
    public async Task<PokemonResponseDto> GetPokemonById(Guid id, CancellationToken cancellationToken){
        
        var pokemon = await _pokemonRepository.GetByIdAsync(id, cancellationToken);
        if (pokemon is null) {
            throw new FaultException("Pokemon not found :(");
        }
        return pokemon.ToDto();
    }

    public async Task<List<PokemonResponseDto>> GetPokemonByName(string name, CancellationToken cancellationToken)
    {
        var pokemons = await _pokemonRepository.GetPokemonByNameAsync(name, cancellationToken);  // Ahora es una lista
        if (pokemons is null || pokemons.Count == 0) {
            throw new FaultException("Pokémons no encontrados :(");
        }

        return pokemons.Select(p => p.ToDto()).ToList(); // Convertir a DTOs y devolver lista
    }

    public async Task<bool> DeletePokemon(Guid id, CancellationToken cancellationToken){
        var pokemon = await _pokemonRepository.GetByIdAsync(id, cancellationToken);
        if (pokemon is null) {
            throw new FaultException("Pokemon not found :(");
        }
        await _pokemonRepository.DeleteAsync(pokemon, cancellationToken);
        return true;
    }

    public async Task<PokemonResponseDto> CreatePokemon(CreatePokemonDto createPokemonDto, CancellationToken cancellationToken)
{
    var pokemonToCreate = createPokemonDto.ToModel();

    pokemonToCreate.ValidateName().ValidateLevel().ValidateType();

    await _pokemonRepository.AddAsync(pokemonToCreate, cancellationToken);
    return pokemonToCreate.ToDto();
}

    public async Task<PokemonResponseDto> UpdatePokemon(UpdatePokemonDto pokemon, CancellationToken cancellationToken){
        var pokemonToUpdate = await _pokemonRepository.GetByIdAsync(pokemon.Id, cancellationToken);
        if (pokemonToUpdate is null) {
            throw new FaultException("Pokemon not found :(");
        }

        pokemonToUpdate.Name = pokemon.Name;
        pokemonToUpdate.Type = pokemon.Type;
        pokemonToUpdate.Level = pokemon.Level;
        pokemonToUpdate.Health = pokemon.Health;
        pokemonToUpdate.Stats = pokemon.Stats.ToModel();
        pokemonToUpdate.Stats.Attack = pokemon.Stats.Attack;
            pokemonToUpdate.Stats.Defense = pokemon.Stats.Defense;
            pokemonToUpdate.Stats.Speed = pokemon.Stats.Speed;

            await _pokemonRepository.UpdateAsync(pokemonToUpdate, cancellationToken);
            return pokemonToUpdate.ToDto();

    }

}