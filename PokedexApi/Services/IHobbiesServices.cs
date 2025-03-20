using PokedexApi.Models;

namespace PokedexApi.Services;
public interface IHobbiesService
{
    Task<Hobbies?> GetHobbieById(int id, CancellationToken cancellationToken);
    Task<List<Hobbies>> GetHobbiesByName(string name, CancellationToken cancellationToken);

}
