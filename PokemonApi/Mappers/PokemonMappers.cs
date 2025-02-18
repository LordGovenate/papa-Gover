using PokemonApi.Dtos;
using PokemonApi.Infrastructure.Entities;
using PokemonApi.Models;

namespace PokemonApi.Mappers;

public static class PokemonMappers {
    public static Pokemon ToModel(this PokemonEntity entity) {
        if(entity == null) {
            return null;
        }

        return new Pokemon {
            Id = entity.Id,
            Type = entity.Type,
            Name = entity.Name,
            Level = entity.Level,
            Stats = new Stats {
                Attack = entity.Attack,
                Defense = entity.Defense,
                Speed = entity.Speed
            }
        };
    }

    public static PokemonResponseDto ToDto(this Pokemon pokemon) {
        return new PokemonResponseDto {
            Id = pokemon.Id,
            Level = pokemon.Level,
            Type = pokemon.Type,
            Name = pokemon.Name,
            Stats = new StatsDto {
                Attack = pokemon.Stats.Attack,
                Defense = pokemon.Stats.Defense,
                Speed = pokemon.Stats.Speed
            }
        };
    }
}