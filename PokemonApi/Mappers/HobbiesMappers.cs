using PokemonApi.Dtos;
using PokemonApi.Infrastructure.Entities;
using PokemonApi.Models;

public static class HobbiesMappers
{
    public static HobbiesEntity ToEntity(this Hobbies hobbies)
    {
        return new HobbiesEntity
        {
            Id = hobbies.Id,
            Name = hobbies.Name,
            Top = hobbies.Top
        };
    }

    public static Hobbies ToModel(this HobbiesEntity entity)
    {
        if (entity == null)
        {
            return null;
        }

        return new Hobbies
        {
            Id = entity.Id,
            Name = entity.Name,
            Top = entity.Top
        };
    }

    // Mapeo de HobbiesResponseDto a Hobbies (modelo)
    public static Hobbies ToModel(this CreateHobbiesDto hobbies)
    {
        return new Hobbies
        {
            Id = new Random().Next(1, int.MaxValue),
            Name = hobbies.Name,
            Top = hobbies.Top
        };
    }

    public static HobbiesResponseDto ToDto(this Hobbies entity)
    {
        return new HobbiesResponseDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Top = entity.Top
        };
    }
}
