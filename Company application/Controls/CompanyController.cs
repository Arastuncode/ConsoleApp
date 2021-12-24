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
            string companyadress = Console.ReadLine();
            Company company = new Company
            {
                Name = companyName,
                Adress = companyadress
            };
            var result = _companyService.Create(company);
            if (result != null)
            {
                Helper.WriteToConsole(ConsoleColor.Blue, $"{company.Id}.{company.Name}-{company.Adress} company created.");
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, " Something is wrong");
            }
        }
        public void GetById()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add company id:");
            EnterId: string companyId = Console.ReadLine();
            int id;
            bool isIdTrue = int.TryParse(companyId, out id);
            if (isIdTrue)
            {
                var company = _companyService.GetById(id);
                if (company == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, " Company cannot found:");
                    goto EnterId;
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.DarkGreen, $" {company.Id}.{company.Name}-{company.Adress}");
                }

            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, " Try again ID!");
                goto EnterId;
            }
        }
        public void Delete()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add company id:");
            EnterId: string companyId = Console.ReadLine();
            int id;
            bool isTrueId = int.TryParse(companyId, out id);
            if (isTrueId)
            {
                var company = _companyService.GetById(id);
                if (company == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, " Company not found:");
                    goto EnterId;
                }
                else
                {
                    _companyService.Delete(company);
                    Helper.WriteToConsole(ConsoleColor.Green, $"Company successfully deleted");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, " Try again ID:");
                goto EnterId;
            }
        }
        public void GetAll()
        {
            var compnies = _companyService.GetAll();
            foreach (var item in compnies)
            {
                Helper.WriteToConsole(ConsoleColor.Yellow, $"{item.Id}.{item.Name}-{item.Adress}.");
            }
        }
        public void GetByName()
        {
            Helper.WriteToConsole(ConsoleColor.Green, "Add company name:");
            string companyName = Console.ReadLine();
            var companies = _companyService.GetByName(companyName);
            foreach (var item in companies)
            {
                Helper.WriteToConsole(ConsoleColor.Green, $"{item.Id}-{item.Name}-{item.Adress}");
            }
        }
        public void Update()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add company ID:");
            EnterId: string companyId = Console.ReadLine();
            int  id;
            bool isIdTrue = int.TryParse(companyId, out id);
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add new company Name:");
            string newName = Console.ReadLine();
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add new company Adress:");
            string newAdress = Console.ReadLine();
            if (isIdTrue)
            {
               Company company = new Company
               {
                  Name = newName,
                  Adress = newAdress
               };
               var newcompany = _companyService.Update(id,company); 
               Helper.WriteToConsole(ConsoleColor.Blue, $"New company created:{company.Id}.{company.Name}-{company.Adress}.");
                    
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, " Try again for ID:");
                goto EnterId;
            }
        }
    }
}
           