using System.Runtime.Serialization;

namespace PokedexApi.Infrastructure.Soap.Dtos;

[DataContract(Name = "UpdatePokemonDto", Namespace = "http://pokemonapi/pokemon-service")]
public class UpdatePokemonDto : PokemonCommon {
    [DataMember(Name = "Id", Order = 5)]
    public Guid Id { get; set; }
}