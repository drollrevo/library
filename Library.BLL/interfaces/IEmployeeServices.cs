using Library.Domain.DataTransferObject;

namespace Library.BLL.interfaces
{
    public interface IEmployeeServices
    {
        public Task<EmployeeDto> CreateAsync(EmployeeDto entity);
        public Task<EmployeeDto> DeleteAsync(int id);
        public Task<EmployeeDto> UpdateAsync(EmployeeDto entity);
        public Task<IEnumerable<EmployeeDto>> GetAsync();
        public Task<EmployeeDto> GetAsync(int id);
    }
}
