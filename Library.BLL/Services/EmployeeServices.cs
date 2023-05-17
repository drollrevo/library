using Library.BLL.interfaces;
using Library.DLL.Interfaces;
using Library.Domain.DataTransferObject;
using Library.Domain.Entities;
using System.Numerics;

namespace Library.BLL.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeServices(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public async Task<EmployeeDto> CreateAsync(EmployeeDto entity)
        {
            var employee = new Employee
            {
                Id = entity.Id,
                FullName = entity.FullName,
                BirthDate = entity.BirthDate,
                Position = entity.Position,
                Salary = entity.Salary,
                AddressId = entity.AddressId,
                Phone = entity.Phone,
            };
            var result = await _repository.CreateAsync(employee);
            return new EmployeeDto
            {
                Id = result.Id,
                FullName = result.FullName,
                BirthDate = result.BirthDate,
                Position = result.Position,
                Salary = result.Salary,
                AddressId = result.AddressId,
                Phone = result.Phone
            };
        }

        public async Task<EmployeeDto> DeleteAsync(int id)
        {
            var result = await _repository.DeleteAsync(id);
            return new EmployeeDto
            {
                Id = result.Id,
                FullName = result.FullName,
                BirthDate = result.BirthDate,
                Position = result.Position,
                Salary = result.Salary,
                AddressId = result.AddressId,
                Phone = result.Phone,
            };
        }

        public async Task<IEnumerable<EmployeeDto>> GetAsync()
        {
            var results = await _repository.GetAsync();
            return (from result in results
                    select
                   new EmployeeDto
                   {
                       Id = result.Id,
                       FullName = result.FullName,
                       BirthDate = result.BirthDate,
                       Position = result.Position,
                       Salary = result.Salary,
                       AddressId = result.AddressId,
                       Phone = result.Phone,
                   }).ToList();
        }

        public async Task<EmployeeDto> GetAsync(int id)
        {
            var result = await _repository.GetAsync(id);
            return new EmployeeDto
            {
                Id = result.Id,
                FullName = result.FullName,
                BirthDate = result.BirthDate,
                Position = result.Position,
                Salary = result.Salary,
                AddressId = result.AddressId,
                Phone = result.Phone,
                Order = (from results in result.Order
                         select
                         new OrderDto
                         {
                             Id = results.Id,
                             DateOfIssue = results.DateOfIssue,
                             ClientId = results.ClientId,
                             EmployeeId = results.EmployeeId,
                         }).ToList(),
            };
        }

        public async Task<EmployeeDto> UpdateAsync(EmployeeDto entity)
        {
            var employee = new Employee
            {
                Id = entity.Id,
                FullName = entity.FullName,
                BirthDate = entity.BirthDate,
                Position = entity.Position,
                Salary = entity.Salary,
                AddressId = entity.AddressId,
                Phone = entity.Phone,
            };
            var result = await _repository.UpdateAsync(employee);
            return new EmployeeDto
            {
                Id = result.Id,
                FullName = result.FullName,
                BirthDate = result.BirthDate,
                Position = result.Position,
                Salary = result.Salary,
                AddressId = result.AddressId,
                Phone = result.Phone,
            };
        }
    }
}
