using Library.Domain.DataTransferObject;

namespace Library.BLL.interfaces
{
    public interface IAddressServices
    {
        public Task<AddressDto> CreateAsync(AddressDto entity);
        public Task<AddressDto> DeleteAsync(int id);
        public Task<AddressDto> UpdateAsync(AddressDto entity);
        public Task<IEnumerable<AddressDto>> GetAsync();
        public Task<AddressDto> GetAsync(int id);
        public Task<AddressDto> AddToClientAsync(AddressDto address, ClientDto client);
        public Task<AddressDto> RemoveFromClientAsync(AddressDto address, List<int> clientsId);
    }
}
