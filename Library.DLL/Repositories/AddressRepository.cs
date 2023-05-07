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

        public async Task<Address> AddToClientAsync(Address address, Client client)
        {
            try
            {
                var addressUpdate = _db.Entry<Address>(address);
                addressUpdate.State = EntityState.Modified;
                addressUpdate.Entity.Client.Add(client);
                await _db.SaveChangesAsync();
                return addressUpdate.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Address> CreateAsync(Address entity)
        {
            try
            {
                await _db.Address.AddAsync(entity);
                await _db.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Address> DeleteAsync(int id)
        {
            try
            {
                var address = await _db.Address.FindAsync(id);

                if (address == null)
                    throw new Exception();

                _db.Address.Remove(address);
                await _db.SaveChangesAsync();
                return address;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Address>> GetAsync()
        {
            try
            {
                return await _db.Address
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Address> GetAsync(int id)
        {
            try
            {
                return await _db.Address 
                    .Include(x => x.Client)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Address> RemoveFromClientAsync(Address address, List<int> clientsId)
        {
            try
            {
                var addressState = await _db.Address.Include(x => x.Client).FirstOrDefaultAsync(x => x.Id == address.Id);
                addressState.Client.RemoveAll(x => clientsId.Contains(x.Id));
                await _db.SaveChangesAsync();
                return addressState;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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