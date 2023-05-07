using Library.DLL.Data;
using Library.DLL.Interfaces;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;


namespace Library.DLL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDBContext _db;

        public EmployeeRepository(AppDBContext db)
        {
            _db = db;
        }
        public async Task<Employee> CreateAsync(Employee entity)
        {
            try
            {
                await _db.Employee.AddAsync(entity);
                await _db.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Employee> DeleteAsync(int id)
        {
            try
            {
                var book = await _db.Employee.FindAsync(id);

                if (book == null)
                    throw new Exception();

                _db.Employee.Remove(book);
                await _db.SaveChangesAsync();
                return book;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Employee>> GetAsync()
        {
            try
            {
                return await _db.Employee
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Employee> GetAsync(int id)
        {
            try
            {
                return await _db.Employee
                    .AsNoTracking()
                    .Include(x => x.Order)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Employee> UpdateAsync(Employee entity)
        {
            try
            {
                var book = _db.Entry<Employee>(entity);
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