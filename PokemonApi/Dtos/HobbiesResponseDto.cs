using System.Runtime.Serialization;

[DataContract(Name = "HobbiesDto", Namespace = "http://pokemonapi/hobbies-service")]
public class HobbiesResponseDto
{
    [DataMember(Name = "Id", Order = 1)]
    public int Id { get; set; }
    [DataMember(Name = "Name", Order = 2)]
    public string Name { get; set; }
    [DataMember(Name = "Top", Order = 3)]
    public int Top { get; set; }
}