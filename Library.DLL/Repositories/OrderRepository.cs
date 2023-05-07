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
        public async Task<Order> CreateAsync(Order entity)
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

        public async Task<Order> DeleteAsync(int id)
        {
            try
            {
                var book = await _db.Order.FindAsync(id);

                if (book == null)
                    throw new Exception();

                _db.Order.Remove(book);
                await _db.SaveChangesAsync();
                return book;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Order>> GetAsync()
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

        public async Task<Order> GetAsync(int id)
        {
            try
            {
                return await _db.Order
                    .AsNoTracking()
                    .Include(x => x.Employee)
                    .Include(x => x.Client)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Order> UpdateAsync(Order entity)
        {
            try
            {
                var book = _db.Entry<Order>(entity);
                book.State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return book.Entity;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}