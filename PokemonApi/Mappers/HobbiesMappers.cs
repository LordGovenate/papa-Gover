using PokemonApi.Infrastructure.Entities;
using PokemonApi.Models;
using PokemonApi.Dtos;

namespace PokemonApi.Mappers;

public static class HobbiesMappers {
    public static HobbiesEntity ToEntity(this Hobbies hobbies) {
        return new HobbiesEntity {
            Id = hobbies.Id,
            Name = hobbies.Name,
            Top = hobbies.Top
        };
    }

    public static Hobbies ToModel(this HobbiesEntity entity) {
        if(entity == null) {
            return null;
        }

        return new Hobbies {
            Id = entity.Id,
            Name = entity.Name,
            Top = entity.Top
        };
    }

    public static HobbiesResponseDto ToDto(this Hobbies hobbies) {
        return new HobbiesResponseDto {
            Id = hobbies.Id,
            Name = hobbies.Name,
            Top = hobbies.Top
        };
    }
}