using Library.BLL.interfaces;
using Library.DLL.Interfaces;
using Library.Domain.DataTransferObject;
using Library.Domain.Entities;

namespace Library.BLL.Services
{
    public class AddressServices : IAddressServices
    {
        private readonly IAddressRepository _repository;
        private readonly IClientRepository _personRepository;
        public AddressServices(IAddressRepository repository, IClientRepository personRepository)
        {
            _repository = repository;
            _personRepository = personRepository;
        }

        public async Task<AddressDto> CreateAsync(AddressDto entity)
        {
            var address = new Address
            {
                Id = entity.Id,
                Street = entity.Street,
                Build = entity.Build,
            };
            var result = await _repository.CreateAsync(address);
            return new AddressDto
            {
                Id = result.Id,
                Street = result.Street,
                Build = result.Build,
            };
        }

        public async Task<AddressDto> DeleteAsync(int id)
        {
            var result = await _repository.DeleteAsync(id);
            return new AddressDto
            {
                Id = result.Id,
                Street = result.Street,
                Build = result.Build,
            };
        }

        public async Task<IEnumerable<AddressDto>> GetAsync()
        {
            var results = await _repository.GetAsync();
            return (from result in results
                    select
                   new AddressDto
                   {
                       Id = result.Id,
                       Street = result.Street,
                       Build = result.Build,
                   }).ToList();
        }

        public async Task<AddressDto> GetAsync(int id)
        {
            var result = await _repository.GetAsync(id);
            return new AddressDto
            {
                Id = result.Id,
                Street = result.Street,
                Build = result.Build,
                Client = (from results in result.Client
                          select
                          new ClientDto
                          {
                              Id = results.Id,
                              FullName = results.FullName,
                              BirthDate = results.BirthDate,
                              AddressId = results.AddressId,
                              Phone = results.Phone,
                          }).ToList(),
            };
        }

        public async Task<AddressDto> RemoveFromClientAsync(AddressDto address, List<int> clientsId)
        {
            try
            {
                var result = await _repository.RemoveFromClientAsync(await _repository.GetAsync(address.Id), clientsId);
                return new AddressDto
                {
                    Id = result.Id,
                    Street = result.Street,
                    Build = result.Build,
                    Client = (from p in result.Client
                              select
                              new ClientDto
                              {
                                  Id = p.Id,
                                  FullName = p.FullName,
                                  BirthDate = p.BirthDate,
                                  AddressId = p.AddressId,
                                  Phone = p.Phone,
                              }).ToList(),
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AddressDto> UpdateAsync(AddressDto entity)
        {
            var address = new Address
            {
                Id = entity.Id,
                Street = entity.Street,
                Build = entity.Build,
            };
            var result = await _repository.UpdateAsync(address);
            return new AddressDto
            {
                Id = result.Id,
                Street = result.Street,
                Build = result.Build,
            };
        }
    }
}
