using Library.Domain.DataTransferObject;

namespace Library.BLL.interfaces
{
    public interface IBookOrderServices
    {
        public Task<BookOrderDto> CreateAsync(BookOrderDto entity);
        public Task<BookOrderDto> DeleteAsync(int id);
        public Task<BookOrderDto> UpdateAsync(BookOrderDto entity);
        public Task<IEnumerable<BookOrderDto>> GetAsync();
        public Task<BookOrderDto> GetAsync(int id);
    }
}
