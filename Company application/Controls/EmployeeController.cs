using Domain.Models;
using Service.Helpers;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company_application.Controls
{
    public class EmployeeController
    {
        private EmployeeService _employeeService { get; }
        private CompanyService _companyService { get; }
        public EmployeeController()
        {
            _employeeService = new EmployeeService();
        }
        public void Create()
        {
            Helper.WriteToConsole(ConsoleColor.DarkBlue, "Add company  Id: ");
            string Id = Console.ReadLine();
            int companyId;
            EnterOption: Helper.WriteToConsole(ConsoleColor.DarkBlue, "Add employee name  : ");
            string employeeName = Console.ReadLine();
            Helper.WriteToConsole(ConsoleColor.DarkBlue, "Add employee surname : ");
            string employeeSurname = Console.ReadLine();
            Helper.WriteToConsole(ConsoleColor.DarkBlue, "Add employee age  : ");
            string Age = Console.ReadLine();
            int employeeAge;
            bool isTrueAge = int.TryParse(Age, out employeeAge);
            bool isTrueId = int.TryParse(Id, out companyId);
            if (isTrueAge && isTrueId)
            {
                if (string.IsNullOrEmpty(employeeName) || string.IsNullOrEmpty(employeeSurname))
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Try again:");
                    goto EnterOption;
                }
                else
                {
                    Employee employee = new Employee
                    {
                        Name = employeeName,
                        Surname = employeeSurname,
                        Age = employeeAge
                    };
                    var result = _employeeService.Create(employee, companyId);
                    if (result != null)
                    {
                        Helper.WriteToConsole(ConsoleColor.Green, $"ID: {employee.Id} - Name: {employee.Name} - Surname: {employee.Surname} -Age: {employee.Age} employee in {employee.Company.Name} created");
                    }
                    else
                    {
                        Helper.WriteToConsole(ConsoleColor.Red, "Company cannot found");
                        goto EnterOption;
                    }
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Try again:");
                goto EnterOption;
            }
        }
        public void Update()
        {
            Helper.WriteToConsole(ConsoleColor.DarkBlue, "Add employee  Id:");
        EnterId: string companyId = Console.ReadLine();
            int id;
            bool isIdTrue = int.TryParse(companyId, out id);
            Helper.WriteToConsole(ConsoleColor.DarkBlue, "Add new employee name  :");
            string newName = Console.ReadLine();
            Helper.WriteToConsole(ConsoleColor.DarkBlue, "Add new employee surname :");
            string newSurname = Console.ReadLine();
            Helper.WriteToConsole(ConsoleColor.DarkBlue, "Add new employee age  :");
            string newAge = Console.ReadLine();
            int age;
            bool isAgeTrue = int.TryParse(newAge, out age);
            if (isIdTrue)
            {
                Employee employee = new Employee
                {
                    Name = newName,
                    Surname = newSurname,
                    Age = age,
                };

                Employee newEmployee = _employeeService.Update(id, employee);

                Helper.WriteToConsole(ConsoleColor.Green, $"ID: {newEmployee.Id} - New name: {newEmployee.Name} - New surname: {newEmployee.Surname} - New age: {newEmployee.Age}");
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Employee cannot found. Try again:");
                goto EnterId;
            }
        }
        public void Delete()
        {
            Helper.WriteToConsole(ConsoleColor.DarkBlue, "Add employee  Id:");
        EnterId: string employeeId = Console.ReadLine();
            int id;
            bool isIdTrue = int.TryParse(employeeId, out id);
            if (isIdTrue)
            {
                var result = _employeeService.GetById(id);
                if (result == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Employee cannot found. Enter employee  Id again:");
                    goto EnterId;
                }
                else
                {
                    _employeeService.Delete(result);
                    Helper.WriteToConsole(ConsoleColor.Green, $"Employee  deleted");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Try again:");
                goto EnterId;
            }
        }
        public void GetById()
        {
            Helper.WriteToConsole(ConsoleColor.DarkBlue, "Add employee  Id: ");
        EnterId: string employeeId = Console.ReadLine();
            int id;
            bool isIdTrue = int.TryParse(employeeId, out id);
            if (isIdTrue)
            {
                var employee = _employeeService.GetById(id);
                if (employee == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Employee cannot found.");
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.Blue, $"{employee.Id}.{employee.Surname}.{employee.Name}-{employee.Age}-({employee.Company.Name}");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Try again:");
                goto EnterId;
            }
        }
        public void GetByAge()
        {
            Helper.WriteToConsole(ConsoleColor.DarkBlue, "Add employee  age: ");
        EnterId: string employeeAge = Console.ReadLine();
            int age;
            bool isIdTrue = int.TryParse(employeeAge, out age);
            if (isIdTrue)
            {
                var employee = _employeeService.GetEmployeeByAge(age);
                if (employee == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Employee cannot found.");
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.Blue, $"{employee.Id}.{employee.Surname}.{employee.Name}-{employee.Age}-({employee.Company.Name}");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Try again:");
                goto EnterId;
            }
        }
        public void GetAllByCompanyId()
        {
            Helper.WriteToConsole(ConsoleColor.DarkBlue, "Enter the company  Id:");
            string companyId = Console.ReadLine();
            int id;
            bool isIdTrue = int.TryParse(companyId, out id);
            var result = _employeeService.GetAllEmployeeByCompanyId(id);
            foreach (var item in result)
            {
                if (result == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Companies cannot found.");
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.Blue, $"{item.Id}.{item.Surname}.{item.Name}-{item.Age}({item.Company.Name}");
                }
            }
        }
    }
}
