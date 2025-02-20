using PokemonApi.Dtos;
using PokemonApi.Infrastructure.Entities;
using PokemonApi.Models;

namespace PokemonApi.Mappers;

public static class PokemonMappers {
    public static PokemonEntity ToEntity(this Pokemon pokemon) {
        return new PokemonEntity {
            Id = pokemon.Id,
            Type = pokemon.Type,
            Name = pokemon.Name,
            Level = pokemon.Level,
            Health = pokemon.Health,
            Attack = pokemon.Stats.Attack,
            Defense = pokemon.Stats.Defense,
            Speed = pokemon.Stats.Speed
        };
    } // <- Llave de cierre añadida aquí

    public static Pokemon ToModel(this PokemonEntity entity) {
        if(entity == null) {
            return null;
        }

        return new Pokemon {
            Id = entity.Id,
            Type = entity.Type,
            Name = entity.Name,
            Level = entity.Level,
            Health = entity.Health,
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
            Health = pokemon.Health,
            Stats = new StatsDto {
                Attack = pokemon.Stats.Attack,
                Defense = pokemon.Stats.Defense,
                Speed = pokemon.Stats.Speed
            }
        };
    }
}