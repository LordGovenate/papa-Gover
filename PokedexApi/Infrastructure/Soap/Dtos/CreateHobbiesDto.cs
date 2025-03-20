using System.Runtime.Serialization;


namespace PokedexApi.Infrastructure.Soap.Dtos;

[DataContract(Name = "CreateHobbiesDto", Namespace = "http://pokemonapi/hobbies-service")]

public class CreateHobbiesDto : HobbiesCommonDto
{
}