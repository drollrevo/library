using Library.DLL.Data;
using Library.DLL.Interfaces;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DLL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDBContext _db;

        public AuthorRepository(AppDBContext db)
        {
            _db = db;
        }
        public async Task<Employee> Create(Employee entity)
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

        public Task<Author> CreateAsync(Author entity)
        {
            throw new NotImplementedException();
        }

        public Task<Author> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> Get(int id)
        {
            try
            {
                return await _db.Employee
                    .AsNoTracking()
                    .Include(x => x.FullName)
                    .Include(x => x.Salary)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Employee>> Get()
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

        public Task<IEnumerable<Author>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> Remove(int Id)
        {
            try
            {
                var employee = await _db.Employee.FindAsync(Id);

                if (employee == null)
                    throw new Exception();
                _db.Employee.Remove(employee);
                await _db.SaveChangesAsync();
                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Employee> Update(Employee entity)
        {
            try
            {
                var employee = _db.Entry<Employee>(entity);
                employee.State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return employee.Entity;
            }
            catch
            {
                throw new Exception();
            }
        }

        public Task<Author> UpdateAsync(Author entity)
        {
            throw new NotImplementedException();
        }
    }
}
