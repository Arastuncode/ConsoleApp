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
        private object _employeeyService;

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
            bool IsEmployeeAge = int.TryParse(employeeAge, out age);
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
        EnterId: string id = Console.ReadLine();
            int employeeId;
            bool isEmployeeId = int.TryParse(id, out employeeId);
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add employee name:");
        EnterName: string employeeName = Console.ReadLine();
            bool isEmpolyeeName = int.TryParse(id, out employeeId);
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add employee surName:");
        EnterSurname: string employeeSurName = Console.ReadLine();
            bool isEmpolyeeSurname = int.TryParse(id, out employeeId);
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add employee age:");
        EnterAge: string employeeAge = Console.ReadLine();
            int age;
            bool IsEmployeeAge = int.TryParse(employeeAge, out age);
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add employee adress:");
        EnterAdress: string employeeAdress = Console.ReadLine();
            bool IsEmployeeAdress = int.TryParse(employeeAge, out age);
            if (isEmployeeId)
            {
                //var employee = _companyService.GetById(id);
                if (isEmpolyeeName)
                {
                    if (isEmpolyeeSurname)
                    {
                        if (IsEmployeeAge)
                        {
                            if (IsEmployeeAdress)
                            {
                                Employee employee = new Employee
                                {
                                    Name = employeeName,
                                    SurName = employeeSurName,
                                    Age = age,
                                    Adress = employeeAdress,

                                };
                                var company = _companyService.GetById(employeeId);
                                Helper.WriteToConsole(ConsoleColor.Blue, $"{employee.Id}.{employee.SurName}.{employee.Name}-{employee.Age}-{employee.Adress}({company.Name})employee created.");
                            }
                            else
                            {
                                Helper.WriteToConsole(ConsoleColor.Red, " Try Adresscc again:");
                                goto EnterAdress;
                            }

                        }
                        else
                        {
                            Helper.WriteToConsole(ConsoleColor.Red, " Try Age again:");
                            goto EnterAge;
                        }
                    }
                    else
                    {
                        Helper.WriteToConsole(ConsoleColor.Red, " Try Surname again:");
                        goto EnterSurname;
                    }
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.Red, " Try Name again:");
                    goto EnterName;
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, " Try Id again:");
                goto EnterId;
            }
        }
        public void Delete()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add employee id:");
        EnterId: string employeeId = Console.ReadLine();
            int id;
            bool isTrueId = int.TryParse(employeeId, out id);
            if (isTrueId)
            {
                var employee = _employeeService.GetById(id);
                if (employee == null)
                {
                    _employeeService.Delete(employee);//
                    Helper.WriteToConsole(ConsoleColor.DarkRed, $"employee successfully deleted");
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.Red, " employee not found:");
                    return;
                }

            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, " Try again for new ID:");
                goto EnterId;
            }
        }
        public void GetById()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add employee id:");
            int  employeeid = Console.ReadLine();
            int id;
            bool isTrueName = int.TryParse(employeeid, out id);
            foreach (var item in employee)
            {
                Helper.WriteToConsole(ConsoleColor.Blue, $"{item.Id}.{item.SurName}.{item.Name}-{item.Age}-{item.Adress}({item.Name}).");
            }
        }
        public void GetByAge()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add employee age:");
            EnterAge: string employeeAge = Console.ReadLine();
            int age;
            bool isTrueAge = int.TryParse(employeeAge, out age);
            if (isTrueAge)
            {
                var employee = _employeeService.GetByAge(age);
                if (employee == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, " Employee not found:");
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.Blue, $"{employee.Id}.{employee.SurName}.{employee.Name}-{employee.Age}-{employee.Adress}({employee.Name}).");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, " Try again :");
                goto EnterAge;
            }
            //public void GetAllByCompany()
            //{

            //}
        }
       
    }
}
