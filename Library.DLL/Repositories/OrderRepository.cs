using Library.DLL.Data;
using Library.DLL.Interfaces;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Library.DLL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDBContext _db;

        public OrderRepository(AppDBContext db)
        {
            _db = db;
        }
        public async Task<Order> Create(Order entity)
        {
            try
            {
                await _db.Order.AddAsync(entity);
                await _db.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Order> CreateAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<Order> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> Get(int id)
        {
            try
            {
                return await _db.Order
                    .AsNoTracking()
                    .Include(x => x.Id)
                    .Include(x => x.DateOfIssue)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Order>> Get()
        {
            try
            {
                return await _db.Order
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<IEnumerable<Order>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> Remove(int Id)
        {
            try
            {
                var order = await _db.Order.FindAsync(Id);

                if (order == null)
                    throw new Exception();
                _db.Order.Remove(order);
                await _db.SaveChangesAsync();
                return order;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Order> Update(Order entity)
        {
            try
            {
                var order = _db.Entry<Order>(entity);
                order.State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return order.Entity;
            }
            catch
            {
                throw new Exception();
            }
        }

        public Task<Order> UpdateAsync(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
