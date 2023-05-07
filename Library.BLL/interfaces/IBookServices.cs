using Library.Domain.DataTransferObject;

namespace Library.BLL.interfaces
{
    public interface IBookServices
    {
        public Task<BookDto> CreateAsync(BookDto entity);
        public Task<BookDto> DeleteAsync(int id);
        public Task<BookDto> UpdateAsync(BookDto entity);
        public Task<IEnumerable<BookDto>> GetAsync();
        public Task<BookDto> GetAsync(int id);
    }
}
