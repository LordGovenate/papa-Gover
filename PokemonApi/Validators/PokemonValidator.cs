using System.ServiceModel;
using PokemonApi.Dtos;
using PokemonApi.Models;

namespace PokemonApi.Validators;

public static class PokemonValidator {
    public static Pokemon ValidateName (this Pokemon pokemon) =>
        string.IsNullOrWhiteSpace(pokemon.Name) ?
        throw new FaultException("Pokemon is requerid") : pokemon;

public static Pokemon ValidateType (this Pokemon pokemon) =>
    string.IsNullOrEmpty(pokemon.Type) ?
    throw new FaultException("Pokemon is requerid") : pokemon;

public static Pokemon ValidateLevel (this Pokemon pokemon) =>
    pokemon.Level <= 0 ? throw new FaultException("Pokemon is requerid") : pokemon;

}