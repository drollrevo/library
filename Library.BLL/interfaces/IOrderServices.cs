using Library.Domain.DataTransferObject;

namespace Library.BLL.interfaces
{
    public interface IOrderServices
    {
        public Task<OrderDto> CreateAsync(OrderDto entity);
        public Task<OrderDto> DeleteAsync(int id);
        public Task<OrderDto> UpdateAsync(OrderDto entity);
        public Task<IEnumerable<OrderDto>> GetAsync();
        public Task<OrderDto> GetAsync(int id);
    }
}
