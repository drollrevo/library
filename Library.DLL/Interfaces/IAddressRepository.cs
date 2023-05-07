using Library.Domain.Entities;

namespace Library.DLL.Interfaces
{
    public interface IAddressRepository : IRepository<Address>
    {
        public Task<Address> AddToEmployeeAsync(Address address, Employee employee);
        public Task<Address> RemoveFromEmployeeAsync(Address address, List<int> persinsId);
        public Task<Address> AddToClientAsync(Address address, Client client);
        public Task<Address> RemoveFromClientAsync(Address address, List<int> persinsId);
    }
}
