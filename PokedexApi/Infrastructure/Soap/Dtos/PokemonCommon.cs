using System.Runtime.Serialization;

namespace PokedexApi.Infrastructure.Soap.Dtos;

[DataContract(Name = "PokemonCommonDto", Namespace = "http://pokemonapi/pokemon-service")]
[KnownType(typeof(CreatePokemonDto))]
[KnownType(typeof(UpdatePokemonDto))]
    public class PokemonCommon{
    [DataMember(Name = "Name", Order = 1)]
    public string Name { get; set; }

    [DataMember(Name = "Type", Order = 2)]
    public string Type { get; set; }

    [DataMember(Name = "Level", Order = 3)]
    public int Level { get; set; }

    [DataMember(Name = "Health", Order = 4)]
    public int Health { get; set; }
    
    [DataMember(Name = "Stats", Order = 5)]
    public StatsDto Stats { get; set; }
}