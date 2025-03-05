using System.Runtime.Serialization;

namespace PokemonApi.Dtos;

[DataContract(Name = "HobbiesCommonDto", Namespace = "http://pokemonapi/hobbies-service")]
[KnownType(typeof(CreatePokemonDto))]
[KnownType(typeof(UpdatePokemonDto))]
    public class HobbiesCommonDto {

    [DataMember(Name = "Name", Order = 1)]
    public string Name { get; set; }
    
    [DataMember(Name = "Top", Order = 2)]
    public int Top { get; set; }
}