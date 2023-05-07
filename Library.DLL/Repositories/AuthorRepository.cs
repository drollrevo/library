using Library.DLL.Data;
using Library.DLL.Interfaces;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Library.DLL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDBContext _db;

        public AuthorRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task<Author> CreateAsync(Author entity)
        {
            try
            {
                await _db.Author.AddAsync(entity);
                await _db.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Author> DeleteAsync(int id)
        {
            try
            {
                var author = await _db.Author.FindAsync(id);

                if (author == null)
                    throw new Exception();

                _db.Author.Remove(author);
                await _db.SaveChangesAsync();
                return author;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Author>> GetAsync()
        {
            try
            {
                return await _db.Author
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Author> GetAsync(int id)
        {
            try
            {
                return await _db.Author
                    .AsNoTracking()
                    .Include(x => x.Book)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Author> UpdateAsync(Author entity)
        {
            try
            {
                var author = _db.Entry<Author>(entity);
                author.State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return author.Entity;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
