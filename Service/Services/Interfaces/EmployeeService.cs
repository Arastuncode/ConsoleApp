using Domain.Models;
using Repository.Exceptions;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services.Interfaces
{
    public class EmployeeService : IEmployeeService
    {
        private  EmployeeRepository _employeeRepository { get; }
        private CompanyRepository  _companyRepository { get; }
        private int _count { get; set; }
        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
            _companyRepository = new CompanyRepository();
        }
        public Employee Create(Employee model,int  companyId)
        {
            try
            {
                Company company = _companyRepository.Get(x => x.Id == companyId);
                if (company == null) return null;
                model.Id =_count;
                model.Company = company;
                _employeeRepository.Create(model);
                _count++;
                return model;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public Employee GetById(int id)
        {
            return _employeeRepository.GetById(x => x.Id == id);
        }
        public Employee Update(int id, Employee model)
        {
            var employee = GetById(id);
            model.Id = employee.Id;
            _employeeRepository.Update(model);
            return model;
        }
        public void Delete(Employee employee)
        {
            _employeeRepository.Delete(employee);
            
        }
        public List<Employee> GetByName(string name)
        {
            return _employeeRepository.GetAll(x => x.Name == name);
        }
        public Employee GetByAge(int age)
        {
            return _employeeRepository.GetById(x => x.Age == age);
        }
        //public List<Employee> GetEmployeeByAge(string age)
        //{
        //    return _employeeRepository.GetEmployeeByAge(x=>x.Age=age);
        //}
    }
}

