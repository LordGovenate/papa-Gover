using System.ServiceModel;
using PokemonApi.Repositories;
using PokemonApi.Mappers;
using PokemonApi.Dtos;
using PokemonApi.Validators;

namespace PokemonApi.Services;
    public class HobbiesService : IHobbiesService
    {
        private readonly IHobbiesRepository _hobbiesRepository;

        public HobbiesService(IHobbiesRepository hobbiesRepository)
        {
            _hobbiesRepository = hobbiesRepository;
        }

        public async Task<HobbiesResponseDto> GetHobbiesById(int id, CancellationToken cancellationToken)
        {
            var hobbies = await _hobbiesRepository.GetHobbyById(id, cancellationToken);
            if (hobbies == null)
            {
                throw new FaultException("Hobbies not found :(");
            }
            return hobbies.ToDto();
        }

        public async Task<bool> DeleteHobbies(int id, CancellationToken cancellationToken)
        {
            var hobbies = await _hobbiesRepository.GetHobbyById(id, cancellationToken);
            if (hobbies == null)
            {
                throw new FaultException("Hobbies not found :(");
            }
            await _hobbiesRepository.DeleteHobby(hobbies, cancellationToken);
            return true;
        }

        public async Task<List<HobbiesResponseDto>> GetHobbieByName(string name, CancellationToken cancellationToken)
        {
            var hobbies = await _hobbiesRepository.GetHobbiesByName(name, cancellationToken);
            if (hobbies == null || !hobbies.Any())
            {
                return new List<HobbiesResponseDto>();
            }
            return hobbies.Select(h => h.ToDto()).ToList();
        }

        public async Task<HobbiesResponseDto> CreateHobbies(CreateHobbiesDto createHobbiesDto, CancellationToken cancellationToken)
        {
            var hobbiesToCreate = createHobbiesDto.ToModel();

            hobbiesToCreate.ValidateName().ValidateTop();

            await _hobbiesRepository.AddAsync(hobbiesToCreate, cancellationToken);

            return hobbiesToCreate.ToDto();
        }

        public async Task<HobbiesResponseDto> UpdateHobbies(UpdateHobbiesDto hobbies, CancellationToken cancellationToken)
        {
            var hobbiesToUpdate = await _hobbiesRepository.GetHobbyById(hobbies.Id, cancellationToken);
            if (hobbiesToUpdate is null)
            {
                throw new FaultException("Hobbies not found :(");
            }

            hobbiesToUpdate.Name = hobbies.Name;
            hobbiesToUpdate.Top = hobbies.Top;

            await _hobbiesRepository.UpdateAsync(hobbiesToUpdate, cancellationToken);
            return hobbiesToUpdate.ToDto();
            
    }
}