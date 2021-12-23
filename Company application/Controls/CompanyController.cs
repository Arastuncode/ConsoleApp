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
                var company1 = _companyService.GetById(id);
                if (company1 == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, " Company not found:");
                    return;
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.DarkGreen, $" {company1.Id}.{company1.Name}-{company1.Adress}");
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
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add company id:");
            EnterId: string companyId = Console.ReadLine();
            int id;
            bool isTrueId = int.TryParse(companyId, out id);
            if (isTrueId)
            {
                var company1 = _companyService.GetById(id);
                if (company1 == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, " Company not found:");
                    return;
                }
                else
                {
                    _companyService.Delete(company1);
                    Helper.WriteToConsole(ConsoleColor.DarkGreen, $"Company successfully deleted");
                }

            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, " Try again for new ID:");
                goto EnterId;
            }

        }
        public void GetAll()
        {
            var compines = _companyService.GetAll();
            foreach (var item in compines)
            {
                Helper.WriteToConsole(ConsoleColor.Blue, $"{item.Id}.{item.Name}-{item.Adress}.");
            }

        }
        public void GetByName()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add company name:");
            EnterName: string companyname = Console.ReadLine();
            string name;
            bool isTrueName= Company.(companyname, out name);
            if (isTrueName)
            {
                var company = _companyService.GetByName(name);
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
                Helper.WriteToConsole(ConsoleColor.Red, " Try again for new Name:");
                goto EnterName;
            }
        }
        public void Update()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add company ID:");
            EnterId: string companyId = Console.ReadLine();
            int id;
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add new company name:");
            EnterName: string newName = Console.ReadLine();
            Helper.WriteToConsole(ConsoleColor.Cyan, " Add new company Adress:");
            string companyAdress = Console.ReadLine();
            bool isTrueAdress = int.TryParse(companyAdress, out id);
            if (isTrueAdress)
            {
                if (isTrueAdress)
                {
                    Company company = new Company
                    {
                        Name = newName,
                        Adress = companyAdress,
                        Id = id
                    };
                    Company newcompany= _companyService.Update(company, id);
                    Helper.WriteToConsole(ConsoleColor.DarkGreen, $" {newcompany.Id}.{newcompany.Name}-{newcompany.Adress}");
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.Red, " Try again for new Adress:");
                    goto EnterName;
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, " Try again for new ID:");
                goto EnterId;
            }
        }
    }
}
