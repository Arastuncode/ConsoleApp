using Domain.Models;
using Service.Helpers;
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
            _companyService = new CompanyService();
        }
        public void Create()
        {
            Helper.WriteToConsole(ConsoleColor.DarkCyan, " Add company id:");
            EnterCompanyId: string id = Console.ReadLine();
            int companyId;
            bool isTrueCompanyId = int.TryParse(id, out companyId);
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add employee name:");
            string employeeName = Console.ReadLine();
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add employee surName:");
            string employeeSurName = Console.ReadLine();
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add employee age:");
            EnterAge: string employeeAge = Console.ReadLine();
            int age;
            bool IsEmployeeAge = int.TryParse(employeeAge,out age);
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add employee adress:");
            string employeeAdress = Console.ReadLine();
            if (isTrueCompanyId)
            {                
                if (IsEmployeeAge)
                {
                    Employee employee = new Employee
                    {
                        Name = employeeName,
                        SurName = employeeSurName,
                        Age = age,
                        Adress = employeeAdress,

                    };
                    var company = _companyService.GetById(companyId);
                    var result = _employeeService.Create(employee, companyId);
                    if (result != null)
                    {
                        Helper.WriteToConsole(ConsoleColor.Red, " Company cannot find(controlller)");
                        goto EnterCompanyId;
                    }
                    else
                    {
                        Helper.WriteToConsole(ConsoleColor.Blue, $"{employee.Id}.{employee.SurName}.{employee.Name}-{employee.Age}-{employee.Adress}({company.Name})employee created.");
                        
                    }
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.Red, " Try again employer age");
                    goto EnterAge;
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, " Try again company Id");
                goto EnterCompanyId;
            }
        }
        public void Update()
        {
            Helper.WriteToConsole(ConsoleColor.DarkCyan, " Add company id:");
            EnterCompanyId: string id = Console.ReadLine();
            int employeeId;
            bool isEmployeeId = int.TryParse(id, out employeeId);
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add employee name:");
            string employeeName = Console.ReadLine();
            bool isEmpolyeeName = int.TryParse(id, out employeeId);
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add employee surName:");
            string employeeSurName = Console.ReadLine();
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add employee age:");
            EnterAge: string employeeAge = Console.ReadLine();
            int age;
            bool IsEmployeeAge = int.TryParse(employeeAge, out age);
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add employee adress:");
            string employeeAdress = Console.ReadLine();
            if (isEmployeeId)
            {
                if (isEmpolyeeName)
                {
                     
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, " Try again company Id");
                goto EnterCompanyId;
            }
        }
        //public void Delete()
        //{

        //}
        public void GetById()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add employee id:");
            EnterId: string employeeId = Console.ReadLine();
            int id;
            bool isTrueName = int.TryParse(employeeId, out id);
            EnterSurname: bool IsTrueSurName= int.TryParse(employeeId, out id);
            EnterAge: bool IsTrueAge = int.TryParse(employeeId, out id);
            if (isTrueName)
            {
                var employee = _companyService.GetById(id);
                if (IsTrueSurName)
                {
                    if (IsTrueAge)
                    {
                        var employee1 = _companyService.GetById(id);
                        if (employee1 == null)
                        {
                            Helper.WriteToConsole(ConsoleColor.Red, " Employee not found:");
                            return;
                        }
                        else
                        {
                            Helper.WriteToConsole(ConsoleColor.Blue, $"{employee.Id}.{employee.SurName}.{employee.Name}-{employee.Age}-{employee.Adress}({employee.Name}).");
                        }
                    }
                    else
                    {
                        Helper.WriteToConsole(ConsoleColor.Red, " Try again:");
                        goto EnterAge;
                    }
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.Red, " Try again:");
                    goto EnterSurname;
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, " Try again:");
                goto EnterId;
            }
        }
        //public void GetByAge()
        //{

        //}
        //public void GetAllByCompany()
        //{

        //}
    }
}
