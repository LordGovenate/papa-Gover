using System.ServiceModel;
using PokedexApi.Infrastructure.Soap.Dtos;

namespace PokedexApi.Infrastructure.Soap.Contracts;

    [ServiceContract(Name = "KevinAlonsoHobbiesService", Namespace = "http://pokemonapi/hobbies-service")]
    public interface IHobbiesService
    {
        [OperationContract]
        Task<HobbiesResponseDto> GetHobbiesById(int id, CancellationToken cancellationToken);

        [OperationContract]
        Task<bool> DeleteHobbyAsync(int id, CancellationToken cancellationToken);

        [OperationContract]
        Task<List<HobbiesResponseDto>> GetHobbieByName(string name, CancellationToken cancellationToken);

        [OperationContract]
        Task<HobbiesResponseDto> CreateHobbies(CreateHobbiesDto createHobbiesDto, CancellationToken cancellationToken);

        [OperationContract]
        Task<HobbiesResponseDto> UpdateHobbies(UpdateHobbiesDto hobbies, CancellationToken cancellationToken);
        
    }