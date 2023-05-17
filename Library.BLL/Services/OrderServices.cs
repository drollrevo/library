using Library.BLL.interfaces;
using Library.DLL.Interfaces;
using Library.Domain.DataTransferObject;
using Library.Domain.Entities;

namespace Library.BLL.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepository _repository;
        public OrderServices(IOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task<OrderDto> CreateAsync(OrderDto entity)
        {
            var orders = new Order
            {
                Id = entity.Id,
                DateOfIssue = entity.DateOfIssue,
                ClientId = entity.ClientId,
                EmployeeId = entity.EmployeeId,
            };
            var result = await _repository.CreateAsync(orders);
            return new OrderDto
            {
                Id = result.Id,
                DateOfIssue = result.DateOfIssue,
                ClientId = result.ClientId,
                EmployeeId = result.EmployeeId,
            };
        }

        public async Task<OrderDto> DeleteAsync(int id)
        {
            var result = await _repository.DeleteAsync(id);
            return new OrderDto
            {
                Id = result.Id,
                DateOfIssue = result.DateOfIssue,
                ClientId = result.ClientId,
                EmployeeId = result.EmployeeId,
            };
        }

        public async Task<IEnumerable<OrderDto>> GetAsync()
        {
            var results = await _repository.GetAsync();
            return (from result in results
                    select
                   new OrderDto
                   {
                       Id = result.Id,
                       DateOfIssue = result.DateOfIssue,
                       ClientId = result.ClientId,
                       EmployeeId = result.EmployeeId,
                   }).ToList();
        }

        public async Task<OrderDto> GetAsync(int id)
        {
            var result = await _repository.GetAsync(id);
            return new OrderDto
            {
                Id = result.Id,
                DateOfIssue = result.DateOfIssue,
                ClientId = result.ClientId,
                EmployeeId = result.EmployeeId,
            };
        }

        public async Task<OrderDto> UpdateAsync(OrderDto entity)
        {
            var order = new Order
            {
                Id = entity.Id,
                DateOfIssue = entity.DateOfIssue,
                ClientId = entity.ClientId,
                EmployeeId = entity.EmployeeId,
            };
            var result = await _repository.UpdateAsync(order);
            return new OrderDto
            {
                Id = result.Id,
                DateOfIssue = result.DateOfIssue,
                ClientId = result.ClientId,
                EmployeeId = result.EmployeeId,
            };
        }
    }
}
