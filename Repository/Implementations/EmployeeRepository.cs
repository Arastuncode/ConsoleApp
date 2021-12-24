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
            try
            {
                var employee = GetById(x => x.Id == entity.Id);
                if (employee != null)
                {
                    if (!string.IsNullOrEmpty(entity.Name))
                        employee.Name = entity.Name;
                    if (!string.IsNullOrEmpty(entity.SurName))
                        employee.SurName = entity.SurName;
                    if (!string.IsNullOrEmpty(entity.Adress))
                        employee.Adress = entity.Adress;
                    if (entity.Age!=null)
                        employee.Age = entity.Age;
                    if (entity.Id != null)
                        employee.Id = entity.Id;
                         return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public Employee GetById(Predicate<Employee> filter = null)
        {
            return filter == null ? AppDbContext<Employee>.data[0] : AppDbContext<Employee>.data.Find(filter);
        }
        public bool Delete(Employee entity)
        {
            try
            {
                AppDbContext<Employee>.data.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public Employee GetEmployeeByAge(Predicate<Employee> filter = null)
        {
            return filter == null ? AppDbContext<Employee>.data[0] : AppDbContext<Employee>.data.Find(filter);
        }
    }
}
