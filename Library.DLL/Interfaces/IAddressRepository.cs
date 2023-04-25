using Library.Domain.Entities;

namespace Library.DLL.Interfaces
{
    public interface IAddressRepository : IRepository<Address>
    {
        public Task<Address> AddToEmployeeAsync(Address address, Employee employee);
        public Task<Address> RemoveFromEmployeeAsync(Address address, List<int> persinsId);
        public Task<Address> AddEmployeeRangeAsync(Address address, List<int> persinsId);
        public Task<Address> CreateWithEmployeeAsync(Address address);
    }
}
