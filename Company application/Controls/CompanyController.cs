using Domain.Models;
using Service.Helpers;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company_application.Controls
{
    public class CompanyController
    {        
        private CompanyService _companyService { get; }
        public CompanyController()
        {
            _companyService = new CompanyService();
        }
        public void Create()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add company name:");
            string companyName = Console.ReadLine();
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add company adress:");
            string adress = Console.ReadLine();
            Company company = new Company
            {
                Name = companyName,
                Adress = adress
            };
            var result = _companyService.Create(company);
            if (result != null)
            {
                Helper.WriteToConsole(ConsoleColor.Blue, $"{company.Id}.{company.Name}-{company.Adress} company created.");
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, " Something is wrong");
                return;
            }
        }
        public void GetById()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add company id:");
            EnterId: string companyId = Console.ReadLine();
            int id;
            bool isTrueName = int.TryParse(companyId, out id);
            if (isTrueName)
            {
                var company = _companyService.GetById(id);
                if (company == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, " Company not found:");
                    return;
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.DarkGreen, $" {company.Id}.{company.Name}-{company.Adress}");
                }

            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, " Try again for:");
                goto EnterId;
            }
        }
        public void Delete()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add company name:");
            string companyname = Console.ReadLine();
            var companies = _companyService.GetAll();
            foreach (var item in companies)
            {
                Helper.WriteToConsole(ConsoleColor.Blue, $"{item.Id}.{item.Name}-{item.Adress}.");
            }
        }
        public void GetAll()
        {
            var compines = _companyService.GetAll();
            foreach (var item in compines)
            {
                Helper.WriteToConsole(ConsoleColor.Yellow, $"{item.Id}.{item.Name}-{item.Adress}.");
            }
        }
        public void GetByName()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add company name:");
            string companyname = Console.ReadLine();
            var companies = _companyService.GetAll();
            foreach (var item in companies)
            {
                Helper.WriteToConsole(ConsoleColor.Blue, $"{item.Id}.{item.Name}-{item.Adress}.");
            }
        }
        public void Update()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add company ID:");
            EnterId: 
            string companyId = Console.ReadLine();
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add new company name:");
            string newName = Console.ReadLine();
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add new company Adress:");
            string newAdress = Console.ReadLine();
            int  id;
            bool isIdTrue = int.TryParse(companyId, out id);
            if (isIdTrue)
            {
               Company company = new Company
               {
                   Name = newName,
                  Adress = newAdress
               };
                 var newcompany = _companyService.Update(company,id); 
                  Helper.WriteToConsole(ConsoleColor.Blue, $"{company.Id}.{company.Name}-{company.Adress} new company created.");
                    
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, " Try again for ID:");
                goto EnterId;
            }
        }
         

    }
}
 