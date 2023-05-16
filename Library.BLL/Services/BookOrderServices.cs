using Library.BLL.interfaces;
using Library.DLL.Interfaces;
using Library.Domain.DataTransferObject;
using Library.Domain.Entities;

namespace Library.BLL.Services
{
    public class BookOrderServices : IBookOrderServices
    {
        private readonly IBookOrderRepository _repository;
        private readonly IBookRepository _bookRepository;
        public BookOrderServices(IBookOrderRepository repository, IBookRepository bookRepository)
        {
            _repository = repository;
            _bookRepository = bookRepository;
        }
        public async Task<BookOrderDto> CreateAsync(BookOrderDto entity)
        {
            var bookOrder = new BookOrder
            {
                Id = entity.Id,
                OrderId = entity.OrderId,
            };
            var result = await _repository.CreateAsync(bookOrder);
            return new BookOrderDto
            {
                Id = result.Id,
                OrderId = result.OrderId,
            };
        }

        public async Task<BookOrderDto> DeleteAsync(int id)
        {
            var result = await _repository.DeleteAsync(id);
            return new BookOrderDto
            {
                Id = result.Id,
                OrderId = result.OrderId,
            };
        }

        public async Task<IEnumerable<BookOrderDto>> GetAsync()
        {
            var results = await _repository.GetAsync();
            return (from result in results
                    select
                   new BookOrderDto
                   {
                       Id = result.Id,
                       OrderId = result.OrderId,
                   }).ToList();
        }

        public async Task<BookOrderDto> GetAsync(int id)
        {
            var result = await _repository.GetAsync(id);
            return new BookOrderDto
            {
                Id = result.Id,
                OrderId = result.OrderId,
                Book = (from results in result.Book
                          select
                          new BookDto
                          {
                              Id = results.Id,
                              Title = results.Title,
                              Genre = results.Genre,
                              NumberOfPage = results.NumberOfPage,
                              PublishingDate = results.PublishingDate,
                              AuthorId = results.AuthorId,
                              BookOrderId= results.BookOrderId, 
                          }).ToList(),
            };
        }

        public async Task<BookOrderDto> UpdateAsync(BookOrderDto entity)
        {
            var bookOrder = new BookOrder
            {
                Id = entity.Id,
                OrderId = entity.OrderId,
            };
            var result = await _repository.UpdateAsync(bookOrder);
            return new BookOrderDto
            {
                Id = result.Id,
                OrderId = result.OrderId,
            };
        }
    }
}
