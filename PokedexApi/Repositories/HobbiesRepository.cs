using System.ServiceModel;
using PokedexApi.Infrastructure.Soap.Contracts;
using PokedexApi.Mappers;
using PokedexApi.Models;

namespace PokedexApi.Repositories;

public class HobbiesRepository : IHobbiesRepository
{
    private readonly ILogger<HobbiesRepository> _logger;
    private readonly IHobbiesService _hobbiesService;

    // Constructor que inicializa el repositorio de hobbies
    public HobbiesRepository(ILogger<HobbiesRepository> logger, IConfiguration configuration)
    {
        _logger = logger;
        var endpoint = new EndpointAddress(configuration.GetValue<string>("HobbieServiceEndpoint"));
        var binding = new BasicHttpBinding();
        _hobbiesService = new ChannelFactory<IHobbiesService>(binding, endpoint).CreateChannel();
    }

    // Método para obtener un hobby por su ID
    public async Task<Hobbies> GetHobbyBYIdAsync(int id, CancellationToken cancellationToken) 
    {
        try 
        {
            // Llamada al servicio externo para obtener el hobby
            var hobbies = await _hobbiesService.GetHobbiesById(id, cancellationToken);
            // Convertir los datos obtenidos en un modelo
            return hobbies.ToModel();
        } 
        catch (FaultException ex) when(ex.Message == "Hobbies not found :(")
        {
            _logger.LogWarning(ex, "Failed to get hobbie with id: {id}", id);
            return null;
        }
    }

    // HobbiesRepository.cs
public async Task<List<Hobbies>> GetHobbiesByNameAsync(string name, CancellationToken cancellationToken)
    {
        try
        {
            var hobbies = await _hobbiesService.GetHobbieByName(name, cancellationToken);
            return hobbies?.Select(h => h.ToModel()).ToList() ?? new List<Hobbies>();
        }
        catch (FaultException ex) when (ex.Message.Contains("Hobbie not found"))
        {
            _logger.LogError(ex, "Failed to get hobbie with name: {name}", name);
            return new List<Hobbies>();
        }
    }

    public async Task<bool> DeleteHobbyAsync(int id, CancellationToken cancellationToken)
    {
        try
        {
            return await _hobbiesService.DeleteHobbyAsync(id, cancellationToken);
        }
        catch (FaultException ex)
        {
            _logger.LogError(ex, "Failed to delete hobby with id: {id}", id);
            return false;
        }
    }


}
