using Domain.Models;
using Repository.Data;
using Repository.Exceptions;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementations
{
    public class EmployeeRepository : IRepository<Employee>
    {
        
        public bool Create(Employee entity)
        {
            try
            {
                if (entity == null) throw new CustomException("Entity is null");
                AppDbContext<Employee>.data.Add(entity);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Employee Get(Predicate<Employee> filter)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll(Predicate<Employee> filter)
        {
            throw new NotImplementedException();
        }

        public bool Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
