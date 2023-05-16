using Library.BLL.interfaces;
using Library.DLL.Interfaces;
using Library.DLL.Repositories;
using Library.Domain.DataTransferObject;
using Library.Domain.Entities;

namespace Library.BLL.Services
{
    public class ClientServices : IClientServices
    {
        private readonly IClientRepository _repository;
        private readonly IOrderRepository _orderRepository;
        private readonly IAddressRepository _addressRepository;
        public ClientServices(IClientRepository repository, IOrderRepository orderRepository, IAddressRepository addressRepository)
        {
            _repository = repository;
            _orderRepository = orderRepository;
            _addressRepository = addressRepository;
        }

        public async Task<ClientDto> CreateAsync(ClientDto entity)
        {
            var client = new Client
            {
                Id = entity.Id,
                FullName = entity.FullName,
                BirthDate = entity.BirthDate,
                AddressId = entity.AddressId,
                Phone = entity.Phone,
            };
            var result = await _repository.CreateAsync(client);
            return new ClientDto
            {
                Id = result.Id,
                FullName = result.FullName,
                BirthDate = result.BirthDate,
                AddressId = result.AddressId,
                Phone = result.Phone,
            };
        }

        public async Task<ClientDto> DeleteAsync(int id)
        {
            var result = await _repository.DeleteAsync(id);
            return new ClientDto
            {
                Id = result.Id,
                FullName = result.FullName,
                BirthDate = result.BirthDate,
                AddressId = result.AddressId,
                Phone = result.Phone,
            };
        }

    public async Task<IEnumerable<ClientDto>> GetAsync()
        {
            var results = await _repository.GetAsync();
            return (from result in results
                    select
                   new ClientDto
                   {
                       Id = result.Id,
                       FullName = result.FullName,
                       BirthDate = result.BirthDate,
                       AddressId = result.AddressId,
                       Phone = result.Phone,
                   }).ToList();
        }

        public async Task<ClientDto> GetAsync(int id)
        {
            var result = await _repository.GetAsync(id);
            return new ClientDto
            {
                Id = result.Id,
                FullName = result.FullName,
                BirthDate = result.BirthDate,
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
                Address = (from results in result.Address
                         select
                         new AddressDto
                         {
                             Id = results.Id,
                             Street = results.Street,
                             Build = results.Build,
                         }).ToList(),
            };
        }

        public async Task<ClientDto> UpdateAsync(ClientDto entity)
        {
            var client = new Client
            {
                Id = entity.Id,
                FullName = entity.FullName,
                BirthDate = entity.BirthDate,
                AddressId = entity.AddressId,
                Phone = entity.Phone,
            };
            var result = await _repository.UpdateAsync(client);
            return new ClientDto
            {
                Id = result.Id,
                FullName = result.FullName,
                BirthDate = result.BirthDate,
                AddressId = result.AddressId,
                Phone = result.Phone,
            };
        }
    }
}
