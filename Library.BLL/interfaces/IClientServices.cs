using Library.Domain.DataTransferObject;

namespace Library.BLL.interfaces
{
    public interface IClientServices
    {
        public Task<ClientDto> CreateAsync(ClientDto entity);
        public Task<ClientDto> DeleteAsync(int id);
        public Task<ClientDto> UpdateAsync(ClientDto entity);
        public Task<IEnumerable<ClientDto>> GetAsync();
        public Task<ClientDto> GetAsync(int id);
    }
}
