using Microsoft.AspNetCore.Mvc;
using PokedexApi.Services;
using PokedexApi.Models;
using PokedexApi.Dtos;
using PokedexApi.Mappers;

namespace PokedexApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HobbiesController : ControllerBase
    {
        private readonly IHobbiesService _hobbiesService;

        public HobbiesController(IHobbiesService hobbiesService)
        {
            _hobbiesService = hobbiesService;
        }

        // Obtener Hobby por ID
        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Hobbies>> GetHobbyById(int id, CancellationToken cancellationToken)
        {
            var hobby = await _hobbiesService.GetHobbieById(id, cancellationToken);
            if (hobby == null)
            {
                return NotFound();
            }
            return Ok(hobby);
        }

        // localhost/api/v1/hobbies/byname/Chess
        [HttpGet("byname/{name}")]
        public async Task<ActionResult<List<HobbiesResponse>>> GetHobbiesByName(string name, CancellationToken cancellationToken)
        {
            var hobbies = await _hobbiesService.GetHobbiesByName(name, cancellationToken);

            if (hobbies == null || !hobbies.Any())
            {
                return Ok(new List<HobbiesResponse>()); // Retornar lista vacía si no hay coincidencias
            }
            return Ok(hobbies.Select(h => h.ToDto()).ToList());
        }
}
}