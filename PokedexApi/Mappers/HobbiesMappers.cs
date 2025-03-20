
using PokedexApi.Dtos;
using PokedexApi.Infrastructure.Soap.Dtos;
using PokedexApi.Models;

namespace PokedexApi.Mappers;

public static class HobbiesMappers 
{
    public static HobbiesResponse ToDto(this Hobbies hobbies) {
        return new HobbiesResponse {
            Id = hobbies.Id,
            Name = hobbies.Name,
            Top = hobbies.Top,
        };
    }

    public static Hobbies ToModel(this HobbiesResponseDto hobbies) {
        return new Hobbies {
            Id = hobbies.Id,
            Name = hobbies.Name,
            Top = hobbies.Top,
        };
    }
}
