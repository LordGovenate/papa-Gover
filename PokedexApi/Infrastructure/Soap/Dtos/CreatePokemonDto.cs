using System.Runtime.Serialization;


namespace PokedexApi.Infrastructure.Soap.Dtos;

[DataContract(Name = "CreatePokemonDto", Namespace = "http://pokemonapi/pokemon-service")]
public class CreatePokemonDto : PokemonCommon {
}