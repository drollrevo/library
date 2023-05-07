using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Library.DLL.Data;
using Library.DLL.Interfaces;
using Library.Domain.Entities;

namespace Library.DLL.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDBContext _db;

        public AddressRepository(AppDBContext db)
        {
            _db = db;
        }

        public Task<Address> AddToClientAsync(Address address, Client client)
        {
            throw new NotImplementedException();
        }

        public Task<Address> AddToEmployeeAsync(Address address, Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<Address> CreateAsync(Address entity)
        {
            throw new NotImplementedException();
        }

        public Task<Address> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Address>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Address> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Address> RemoveFromClientAsync(Address address, List<int> persinsId)
        {
            throw new NotImplementedException();
        }

        public Task<Address> RemoveFromEmployeeAsync(Address address, List<int> persinsId)
        {
            throw new NotImplementedException();
        }

        public async Task<Address> UpdateAsync(Address entity)
        {
            try
            {
                var address = _db.Entry<Address>(entity);
                address.State = EntityState.Modified;

                await _db.SaveChangesAsync();
                return entity;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
