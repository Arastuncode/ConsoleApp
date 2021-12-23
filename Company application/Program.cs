using Company_application.Controls;
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
                        case(int) MyEnums.Options.CreateCompany:
                            companyContoller.Create();
                            break;
                        case (int)MyEnums.Options.UpdateCompany:
                            break;
                        case (int)MyEnums.Options.DeleteCompany:
                            companyContoller.Delete();
                            break;
                        case (int)MyEnums.Options.GetCompanyById:
                            companyContoller.GetById();
                            break;
                        case (int)MyEnums.Options.GetCompanyByName:
                            companyContoller.GetById();
                            break;
                        case (int)MyEnums.Options.GetAllCompany:
                            companyContoller.GetById();
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
            Helper.WriteToConsole(ConsoleColor.DarkCyan, "1.Create company,2.Update company,3.Delete company,4.Get company by Id,5.Get company by name," +
               "6.Get all company," + "7.Create employee,8.Update employee,9.Delete employee ,10.Get employee by Id,11.Get employee by age," +
               "12.Get all employee  by company id ");
        }
    }
}
