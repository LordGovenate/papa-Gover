using System.Runtime.Serialization;

namespace PokemonApi.Dtos;

[DataContract(Name = "BooksDto", Namespace = "http://pokemonapi/books-service")]
public class BooksResponseDto
{
    [DataMember(Name = "Id", Order = 1)]
    public int Id { get; set; }
    [DataMember(Name = "Title", Order = 2)]
    public string Title { get; set; }
    [DataMember(Name = "Author", Order = 3)]
    public string Author { get; set; }
    [DataMember(Name = "PublishedDate", Order = 4)]
    public DateTime PublishedDate { get; set; }
}