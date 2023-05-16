using Library.BLL.interfaces;
using Library.Domain.DataTransferObject;
using Library.Domain.Entities;

namespace Library.BLL.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        public Task<EmployeeDto> CreateAsync(EmployeeDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDto> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmployeeDto>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDto> UpdateAsync(EmployeeDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
