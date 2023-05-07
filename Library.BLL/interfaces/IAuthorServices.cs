using Library.Domain.DataTransferObject;

namespace Library.BLL.interfaces
{
    public interface IAuthorServices
    {
        public Task<AuthorDto> CreateAsync(AuthorDto entity);
        public Task<AuthorDto> DeleteAsync(int id);
        public Task<AuthorDto> UpdateAsync(AuthorDto entity);
        public Task<IEnumerable<AuthorDto>> GetAsync();
        public Task<AuthorDto> GetAsync(int id);
    }
}
