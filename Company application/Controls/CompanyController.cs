using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyApplication.Controllers
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
            Helper.WriteToConsole(ConsoleColor.DarkBlue, "Add company name :");
        EnterName: string companyName = Console.ReadLine();
            Helper.WriteToConsole(ConsoleColor.DarkBlue, "Add company address  :");
            string companyAdress = Console.ReadLine();
            Company company = new Company()
            {
                Name = companyName,
                Adress = companyAdress
            };
            var result = _companyService.Create(company);
            if (result != null)
            {
                Helper.WriteToConsole(ConsoleColor.Green, $"Id: {company.Id} - Name: {company.Name} - Address: {company.Adress}");
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Something is wrong");
                goto EnterName;
            }
        }
        public void Update()
        {
            Helper.WriteToConsole(ConsoleColor.DarkBlue, "Add company  ID:");
        EnterId: string companyId = Console.ReadLine();
            int id;
            bool isIdTrue = int.TryParse(companyId, out id);
            Helper.WriteToConsole(ConsoleColor.DarkBlue, "Add new company name :");
            string newName = Console.ReadLine();
            Helper.WriteToConsole(ConsoleColor.DarkBlue, "Add new company address :");
            string newAddress = Console.ReadLine();
            if (isIdTrue)
            {
                Company company = new Company
                {
                    Name = newName,
                    Adress = newAddress
                };
                Company newCompany = _companyService.Update(id, company);
                Helper.WriteToConsole(ConsoleColor.Green, $"ID: {newCompany.Id} - New Name: {newCompany.Name} - New Address: {newCompany.Adress}");
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Company cannot found. Try again:");
                goto EnterId;
            }
        }
        public void Delete()
        {
            Helper.WriteToConsole(ConsoleColor.DarkBlue, "Add company ID:");
        EnterId: string companyId = Console.ReadLine();
            int id;
            bool isIdTrue = int.TryParse(companyId, out id);
            if (isIdTrue)
            {
                var companys = _companyService.GetById(id);
                if (companys == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Company cannot found. Enter company's ID again:");
                    goto EnterId;
                }
                else
                {
                    _companyService.Delete(companys);
                    Helper.WriteToConsole(ConsoleColor.Green, $"Company successfuly deleted");
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
            Helper.WriteToConsole(ConsoleColor.DarkBlue, "Add company ID:");
        EnterId: string companyId = Console.ReadLine();
            int id;
            bool isIdTrue = int.TryParse(companyId, out id);
            if (isIdTrue)
            {
                var companies = _companyService.GetById(id);
                if (companies == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Company cannot found.");
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.Green, $"Name: {companies.Name} - Address: {companies.Name}");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Try again id:");
                goto EnterId;
            }
        }
        public void GetAll()
        {
            var companies = _companyService.GetAll();
            foreach (var item in companies)
            {
                Helper.WriteToConsole(ConsoleColor.Green, $"Id: {item.Id} - Name: {item.Name} - Address: {item.Adress}");
            }
        }
        public void GetAllByName()
        {
            Helper.WriteToConsole(ConsoleColor.DarkBlue, "Enter company names :");
            string name = Console.ReadLine();
            var companies = _companyService.GetAllByName(name);
            foreach (var item in companies)
            {
                if (companies == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Company cannot found.");
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.Green, $"ID: {item.Id} - Name: {item.Name} - Address: {item.Adress}");
                }
            }

        }
    }
}
