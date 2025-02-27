using System;
using System.Threading;
using System.Threading.Tasks;
using PokemonApi.Repositories;


namespace PokemonApi.Services;
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _booksRepository;
        public BooksService(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<bool> DeleteBook(int id, CancellationToken cancellationToken)
        {
            var book = await _booksRepository.GetBookById(id, cancellationToken);
            if (book == null)
            {
                throw new InvalidOperationException("Book not found :(");
            }
            await _booksRepository.DeleteBook(id, cancellationToken);
            return true;
        }
    }