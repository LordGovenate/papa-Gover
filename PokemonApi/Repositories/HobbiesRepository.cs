using Microsoft.EntityFrameworkCore;
using PokemonApi.Infrastructure;
using PokemonApi.Models;
using PokemonApi.Mappers;

namespace PokemonApi.Repositories;

public class HobbiesRepository : IHobbiesRepository
{
    private readonly RelationalDbContext _context;
    public HobbiesRepository(RelationalDbContext context ){
        _context = context;
    }

    public async Task<Hobbies> GetHobbyById (int id, CancellationToken cancellationToken)
    {
        var Hobbies = await _context.Hobbies.AsNoTracking().FirstOrDefaultAsync(s=>s.Id == id, cancellationToken); //urm
        return Hobbies.ToModel();
            }

    public async Task DeleteHobby (Hobbies hobbies, CancellationToken cancellationToken) {
        _context.Hobbies.Remove(hobbies.ToEntity());
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Hobbies>> GetHobbiesByName(string name, CancellationToken cancellationToken) {
        var hobbies = await _context.Hobbies
            .AsNoTracking()
            .Where(h => EF.Functions.Like(h.Name, $"%{name}%"))
            .ToListAsync(cancellationToken);

        return hobbies.Select(h => h.ToModel()).ToList();
    }

    public async Task AddAsync(Hobbies hobbies, CancellationToken cancellationToken) {
        await _context.Hobbies.AddAsync(hobbies.ToEntity(), cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Hobbies hobbies, CancellationToken cancellationToken) {
        _context.Hobbies.Update(hobbies.ToEntity());
        await _context.SaveChangesAsync(cancellationToken);
    }
    
}
