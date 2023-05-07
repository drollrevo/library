using Library.Domain.Entities;

namespace Library.DLL.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        public Task<Employee> AddressEmployeeAsync(Employee employee, Address address);
    }
}
