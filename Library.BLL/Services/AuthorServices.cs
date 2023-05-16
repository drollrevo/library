using Library.BLL.interfaces;
using Library.DLL.Interfaces;
using Library.Domain.DataTransferObject;
using Library.Domain.Entities;

namespace Library.BLL.Services
{
    public class AuthorServices : IAuthorServices
    {
        private readonly IAuthorRepository _repository;
        public AuthorServices(IAuthorRepository repository)
        {
            _repository = repository;
        }
        public async Task<AuthorDto> CreateAsync(AuthorDto entity)
        {
            var author = new Author
            {
                Id = entity.Id,
                FullName = entity.FullName,
                NumberOfBook = entity.NumberOfBook,
                BirthDate = entity.BirthDate,
            };
            var result = await _repository.CreateAsync(author);
            return new AuthorDto
            {
                Id = result.Id,
                FullName = result.FullName,
                NumberOfBook = result.NumberOfBook,
                BirthDate = result.BirthDate,
            };
        }

        public async Task<AuthorDto> DeleteAsync(int id)
        {
            var result = await _repository.DeleteAsync(id);
            return new AuthorDto
            {
                Id = result.Id,
                FullName = result.FullName,
                NumberOfBook = result.NumberOfBook,
                BirthDate = result.BirthDate,
            };
        }

        public async Task<IEnumerable<AuthorDto>> GetAsync()
        {
            var results = await _repository.GetAsync();
            return (from result in results
                   select
                   new AuthorDto
                   {
                       Id = result.Id,
                       FullName = result.FullName,
                       NumberOfBook = result.NumberOfBook,
                       BirthDate = result.BirthDate,
                   }).ToList();
        }

        public async Task<AuthorDto> GetAsync(int id)
        {
            var result = await _repository.GetAsync(id);
            return new AuthorDto
            {
                Id = result.Id,
                FullName = result.FullName,
                NumberOfBook = result.NumberOfBook,
                BirthDate = result.BirthDate,
                Book = (from results in result.Book
                          select
                          new BookDto
                          {
                              Id = results.Id,
                              Genre = results.Genre,
                              NumberOfPage = results.NumberOfPage,
                              PublishingDate = results.PublishingDate,
                              AuthorId = results.AuthorId,
                              BookOrderId = results.BookOrderId,
                          }).ToList(),
            };
        }

        public async Task<AuthorDto> UpdateAsync(AuthorDto entity)
        {
            var author = new Author
            {
                Id = entity.Id,
                FullName = entity.FullName,
                NumberOfBook = entity.NumberOfBook,
                BirthDate = entity.BirthDate,
            };
            var result = await _repository.UpdateAsync(author);
            return new AuthorDto
            {
                Id = result.Id,
                FullName = result.FullName,
                NumberOfBook = result.NumberOfBook,
                BirthDate = result.BirthDate,
            };
        }
    }
}
