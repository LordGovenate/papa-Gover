using System.Runtime.Serialization;
using PokemonApi.Dtos;

namespace PokemonApi.Dtos;

[DataContract(Name = "CreateHobbiesDto", Namespace = "http://pokemonapi/hobbies-service")]

public class CreateHobbiesDto : HobbiesCommonDto
{
}