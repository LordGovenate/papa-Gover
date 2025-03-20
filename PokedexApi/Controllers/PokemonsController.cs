using Microsoft.AspNetCore.Mvc;
using PokedexApi.Services;
using PokedexApi.Mappers;
using PokedexApi.Dtos;

namespace PokedexApi.Controllers;

    [ApiController]
    [Route("api/v1/[controller]")]
    public class PokemonsController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonsController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        // Obtener por ID
[HttpGet("by-id/{id}")]
public async Task<ActionResult<PokemonResponse>> GetPokemonById(Guid id, CancellationToken cancellationToken)
{
    var pokemon = await _pokemonService.GetPokemonById(id, cancellationToken);
    if (pokemon is null)
    {
        return NotFound();
    }
    return Ok(pokemon.ToDto());
}

// Obtener por Nombre
[HttpGet("by-name/{name}")]
public async Task<ActionResult<IEnumerable<PokemonResponse>>> GetPokemonByName(string name, CancellationToken cancellationToken)
{
    if (string.IsNullOrWhiteSpace(name))
    {
        return BadRequest("El parámetro 'name' es requerido.");
    }

    var pokemons = await _pokemonService.GetPokemonByName(name, cancellationToken);
    if (pokemons == null || !pokemons.Any())
    {
        return NotFound("No se encontraron Pokémon con ese nombre.");
    }

    return Ok(pokemons.Select(p => p.ToDto()));
}

[HttpDelete("{id}")]
    public async Task<ActionResult> DeletePokemonById(Guid id, CancellationToken cancellationToken){
        var deleted = await _pokemonService.DeletePokemonByIdAsync(id, cancellationToken);
        if (deleted){
            return NoContent();//204
        }
        return NotFound();//404
    }


    }

