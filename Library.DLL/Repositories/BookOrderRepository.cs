using Library.DLL.Data;
using Library.DLL.Interfaces;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Library.DLL.Repositories
{
    public class BookOrderRepository : IBookOrderRepository
    {
        private readonly AppDBContext _db;

        public BookOrderRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task<BookOrder> CreateAsync(BookOrder entity)
        {
            try
            {
                await _db.BookOrder.AddAsync(entity);
                await _db.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BookOrder> DeleteAsync(int id)
        {
            try
            {
                var bookOrder = await _db.BookOrder.FindAsync(id);

                if (bookOrder == null)
                    throw new Exception();

                _db.BookOrder.Remove(bookOrder);
                await _db.SaveChangesAsync();
                return bookOrder;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<BookOrder>> GetAsync()
        {
            try
            {
                return await _db.BookOrder
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BookOrder> GetAsync(int id)
        {
            try
            {
                return await _db.BookOrder
                    .AsNoTracking()
                    .Include(x => x.Book)
                    .Include(x => x.Order)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BookOrder> UpdateAsync(BookOrder entity)
        {
            try
            {
                var bookOrder = _db.Entry<BookOrder>(entity);
                bookOrder.State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return bookOrder.Entity;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
