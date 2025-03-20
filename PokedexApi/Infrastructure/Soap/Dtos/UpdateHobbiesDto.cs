using System.Runtime.Serialization;

namespace PokedexApi.Infrastructure.Soap.Dtos;

[DataContract(Name = "UpdateHobbiesDto", Namespace = "http://pokemonapi/hobbies-service")]
public class UpdateHobbiesDto : HobbiesCommonDto {
    [DataMember(Name = "Id", Order = 0)]
    public new int Id { get; set; }
}