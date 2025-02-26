using System.ServiceModel;
using PokemonApi.Repositories;
using PokemonApi.Mappers;
using PokemonApi.Dtos;

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
    }
