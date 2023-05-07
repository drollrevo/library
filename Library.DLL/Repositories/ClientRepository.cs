using Library.DLL.Data;
using Library.DLL.Interfaces;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Library.DLL.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDBContext _db;

        public ClientRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task<Client> AddressClientAsync(Client client, Address address)
        {
            try
            {
                var clientState = _db.Entry<Client>(client);
                clientState.State = EntityState.Modified;
                clientState.Entity.Address.Add(address);
                await _db.SaveChangesAsync();
                return clientState.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Client> CreateAsync(Client entity)
        {
            try
            {
                await _db.Client.AddAsync(entity);
                await _db.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Client> DeleteAsync(int id)
        {
            try
            {
                var client = await _db.Client.FindAsync(id);

                if (client == null)
                    throw new Exception();

                _db.Client.Remove(client);
                await _db.SaveChangesAsync();
                return client;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Client>> GetAsync()
        {
            try
            {
                return await _db.Client
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Client> GetAsync(int id)
        {
            try
            {
                return await _db.Client
                    .AsNoTracking()
                    .Include(x => x.Order)
                    .Include(x => x.Address)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Client> UpdateAsync(Client entity)
        {
            try
            {
                var client = _db.Entry<Client>(entity);
                client.State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return client.Entity;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}