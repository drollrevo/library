using Library.DLL.Data;
using Library.DLL.Interfaces;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Library.DLL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDBContext _db;

        public BookRepository(AppDBContext db)
        {
            _db = db;
        }
        public async Task<Book> CreateAsync(Book entity)
        {
            try
            {
                await _db.Book.AddAsync(entity);
                await _db.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Book> DeleteAsync(int id)
        {
            try
            {
                var book = await _db.Book.FindAsync(id);

                if (book == null)
                    throw new Exception();

                _db.Book.Remove(book);
                await _db.SaveChangesAsync();
                return book;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Book>> GetAsync()
        {
            try
            {
                return await _db.Book
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Book> GetAsync(int id)
        {
            try
            {
                return await _db.Book
                    .AsNoTracking()
                    .Include(x => x.BookOrder)
                    .Include(x => x.Author)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Book> UpdateAsync(Book entity)
        {
            try
            {
                var book = _db.Entry<Book>(entity);
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