using PokemonApi.Infrastructure.Entities;
using PokemonApi.Models;
using PokemonApi.Dtos;

namespace PokemonApi.Mappers;

    public static class BooksMappers
    {
        public static BooksEntity ToEntity(this Books books)
        {
            return new BooksEntity
            {
                Id = books.Id,
                Title = books.Title,
                Author = books.Author,
                PublishedDate = books.PublishedDate
            };
        }

        public static Books ToModel(this BooksEntity entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new Books
            {
                Id = entity.Id,
                Title = entity.Title,
                Author = entity.Author,
                PublishedDate = entity.PublishedDate
            };
        }

        public static BooksResponseDto ToDto(this Books books)
        {
            return new BooksResponseDto
            {
                Id = books.Id,
                Title = books.Title,
                Author = books.Author,
                PublishedDate = books.PublishedDate
            };
        }
    }
