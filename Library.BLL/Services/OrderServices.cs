using Library.BLL.interfaces;
using Library.Domain.DataTransferObject;
using Library.Domain.Entities;

namespace Library.BLL.Services
{
    public class OrderServices : IOrderServices
    {
        public Task<OrderDto> CreateAsync(OrderDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDto>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto> UpdateAsync(OrderDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
