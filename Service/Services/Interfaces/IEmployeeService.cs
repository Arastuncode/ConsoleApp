using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services.Interfaces
{
    public interface IEmployeeService
    {
        Employee Create(Employee model, int companyId);
        Employee Update(int id, Employee model);
        public void Delete(Employee model);
        Employee GetById(int id);
        Employee GetEmployeeByAge(int age);
        List<Employee> GetAllEmployeeByCompanyId(int id);
    }
}
