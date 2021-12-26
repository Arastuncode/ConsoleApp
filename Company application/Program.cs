using Company_application.Controls;
using CompanyApplication.Controllers;
using Domain.Models;
using Service.Helpers;
using Service.Services.Interfaces;
using System;

namespace Company_application
{
    class Program
    {
       static void Main(string[] args)
       {
            CompanyController companyContoller = new CompanyController();
            EmployeeController employeeContoller = new EmployeeController();
            Helper.WriteToConsole(ConsoleColor.DarkCyan,"Select options:");
            while (true)
            {
                ShowOptions();
                EnterOption: string selectOption = Console.ReadLine();
                int option;
                bool isTrueOption = int.TryParse(selectOption, out option);
                if (isTrueOption)
                {
                    switch (option)
                    {
                        case(int) MyEnums.Options.CreateCompany://1
                            companyContoller.Create();
                            break;
                        case (int)MyEnums.Options.UpdateCompany://2
                            companyContoller.Update();
                            break;
                        case (int)MyEnums.Options.DeleteCompany://3
                            companyContoller.Delete();
                            break;
                        case (int)MyEnums.Options.GetCompanyById://4
                            companyContoller.GetById();
                            break;
                        case (int)MyEnums.Options.GetAllCompanyByName://5
                            companyContoller.GetAllByName();
                            break;
                        case (int)MyEnums.Options.GetAllCompany://6
                            companyContoller.GetAll();
                            break;
                        case (int)MyEnums.Options.CreateEmployee://7
                            employeeContoller.Create();
                            break;
                        case (int)MyEnums.Options.UpdateEmployee://8
                            employeeContoller.Update();
                            break;
                        case (int)MyEnums.Options.DeleteEmployee://9
                            employeeContoller.Delete();
                            break;
                        case (int)MyEnums.Options.GetEmployeeById://10
                            employeeContoller.GetById();
                            break;
                        case (int)MyEnums.Options.GetEmployeeByAge://11
                            employeeContoller.GetByAge();
                            break;
                        case (int)MyEnums.Options.GetAllEmployeeByCompanyId://12
                            employeeContoller.GetAllByCompanyId();
                            break;
                    }
                }
                else
                {
                    goto EnterOption;
                }
            }
       }
        private static  void ShowOptions()
        {
            Helper.WriteToConsole(ConsoleColor.DarkMagenta, "1.Create company,2.Update company,3.Delete company,4.Get company by Id,5.Get company by name," +
               "6.Get all company," + "7.Create employee,8.Update employee,9.Delete employee ,10.Get employee by Id,11.Get employee by age," +
               "12.Get all employee  by company id ");
        }
    }
}
