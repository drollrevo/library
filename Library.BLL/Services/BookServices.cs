using Library.BLL.interfaces;
using Library.DLL.Interfaces;
using Library.Domain.DataTransferObject;
using Library.Domain.Entities;

namespace Library.BLL.Services
{
    public class BookServices : IBookServices
    {
        private readonly IBookRepository _repository;
        public BookServices(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<BookDto> CreateAsync(BookDto entity)
        {
            var book = new Book
            {
                Id = entity.Id,
                Title = entity.Title,
                Genre = entity.Genre,
                NumberOfPage = entity.NumberOfPage,
                PublishingDate = entity.PublishingDate,
                AuthorId = entity.AuthorId,
                BookOrderId = entity.BookOrderId,
            };
            var result = await _repository.CreateAsync(book);
            return new BookDto
            {
                Id = result.Id,
                Title = result.Title,
                Genre = result.Genre,
                NumberOfPage = result.NumberOfPage,
                PublishingDate = result.PublishingDate,
                AuthorId = result.AuthorId,
                BookOrderId = result.BookOrderId,
            };
        }

        public async Task<BookDto> DeleteAsync(int id)
        {
            var result = await _repository.DeleteAsync(id);
            return new BookDto
            {
                Id = result.Id,
                Title = result.Title,
                Genre = result.Genre,
                NumberOfPage = result.NumberOfPage,
                PublishingDate = result.PublishingDate,
                AuthorId = result.AuthorId,
                BookOrderId = result.BookOrderId,
            };
        }

        public async Task<IEnumerable<BookDto>> GetAsync()
        {
            var results = await _repository.GetAsync();
            return (from result in results
                    select
                   new BookDto
                   {
                       Id = result.Id,
                       Title = result.Title,
                       Genre = result.Genre,
                       NumberOfPage = result.NumberOfPage,
                       PublishingDate = result.PublishingDate,
                       AuthorId = result.AuthorId,
                       BookOrderId = result.BookOrderId,
                   }).ToList();
        }

        public async Task<BookDto> GetAsync(int id)
        {
            var result = await _repository.GetAsync(id);
            return new BookDto
            {
                Id = result.Id,
                Title = result.Title,
                Genre = result.Genre,
                NumberOfPage = result.NumberOfPage,
                PublishingDate = result.PublishingDate,
                AuthorId = result.AuthorId,
                BookOrderId = result.BookOrderId,
            };
        }

        public async Task<BookDto> UpdateAsync(BookDto entity)
        {
            var book = new Book
            {
                Id = entity.Id,
                Title = entity.Title,
                Genre = entity.Genre,
                NumberOfPage = entity.NumberOfPage,
                PublishingDate = entity.PublishingDate,
                AuthorId = entity.AuthorId,
                BookOrderId = entity.BookOrderId,
            };
            var result = await _repository.UpdateAsync(book);
            return new BookDto
            {
                Id = result.Id,
                Title = result.Title,
                Genre = result.Genre,
                NumberOfPage = result.NumberOfPage,
                PublishingDate = result.PublishingDate,
                AuthorId = result.AuthorId,
                BookOrderId = result.BookOrderId,
            };
        }
    }
}
