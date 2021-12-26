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
        private EmployeeRepository _employeeRepository { get; }
        private CompanyRepository _companyRepository { get; }
        public bool Create(Employee entity)
        {
            try
            {
                if (entity == null)
                    throw new CustomException("Entity is null");
                AppDbContext<Employee>.data.Add(entity);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool Update(Employee entity)
        {
            try
            {
                var employee = Get(x => x.Id == entity.Id);
                if (employee != null)
                {
                    if (!string.IsNullOrEmpty(entity.Name))
                        employee.Name = entity.Name;

                    if (!string.IsNullOrEmpty(entity.Surname))
                        employee.Surname = entity.Surname;

                    if (!string.IsNullOrEmpty(entity.Age.ToString()))
                        employee.Age = entity.Age;

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
        public Employee Get(Predicate<Employee> filter)
        {
            return filter == null ? AppDbContext<Employee>.data[0] : AppDbContext<Employee>.data.Find(filter);
        }
        public List<Employee> GetAll(Predicate<Employee> filter)
        {
            return filter == null ? AppDbContext<Employee>.data : AppDbContext<Employee>.data.FindAll(filter);

        }
    }
}
