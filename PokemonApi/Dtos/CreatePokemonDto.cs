using System.Runtime.Serialization;
using PokemonApi.Dtos;

namespace PokemonApi.Dtos;

[DataContract(Name = "CreatePokemonDto", Namespace = "http://pokemonapi/pokemon-service")]
public class CreatePokemonDto : PokemonCommon {
}