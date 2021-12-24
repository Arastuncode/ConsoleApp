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
        public EmployeeController()
        {
            _employeeService = new EmployeeService();
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
            int employeeAge = Convert.ToInt32(Console.ReadLine());
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add employee adress:");
            string employeeAdress = Console.ReadLine();
            if (isTrueCompanyId)
            {
                Employee employee = new Employee
                {
                    Name = employeeName,
                    SurName = employeeSurName,
                    Age = employeeAge,
                    Adress = employeeAdress,
                };
                var result = _employeeService.Create(employee, companyId);
                if (result != null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, " Company cannot find(controlller)");
                    goto EnterCompanyId;
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.Blue, $"{employee.Id}.{employee.SurName}.{employee.Name}-{employee.Age}-{employee.Adress}({employee.Company.Name})employee created.");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, " Try again company Id");
                goto EnterCompanyId;
            }
        }
    }
}
