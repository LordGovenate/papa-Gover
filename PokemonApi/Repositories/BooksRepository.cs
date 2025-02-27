using Microsoft.EntityFrameworkCore;
using PokemonApi.Infrastructure;
using PokemonApi.Mappers;
using PokemonApi.Models;


namespace PokemonApi.Repositories;
    public class BooksRepository : IBooksRepository 
    {
        private readonly RelationalDbContext _context;
        public BooksRepository(RelationalDbContext context)
        {
            _context = context;
        }

        public async Task<Books> GetBookById(int id, CancellationToken cancellationToken)
        {
            var book = await _context.Books.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
            return book?.ToModel(); // Asumiendo que tienes un método de extensión ToModel() para Books
        }

        public async Task<bool> DeleteBook(int id, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
            if (book == null)
            {
                return false;
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return true;
        }
    }