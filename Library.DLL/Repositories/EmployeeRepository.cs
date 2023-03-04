using Library.DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Entities;

namespace Library.DLL.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        public Employee Create(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Employee Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Employee Get()
        {
            throw new NotImplementedException();
        }

        public Employee Remove(int Id)
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
