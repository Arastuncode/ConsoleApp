using Domain.Models;
using Repository.Implementations;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class CompanyService : ICompanyService
    {
        private CompanyRepository _companyRepository;
        private int count { get; set; }
        public CompanyService()
        {
            _companyRepository = new CompanyRepository();
        }
        public Company Create(Company model)
        {
            model.Id = count;
            count++;
            _companyRepository.Create(model);

            return model;
        }

        public void Delete(Company company)
        {
            _companyRepository.Delete(company);
        }

        public List<Company> GetAll()
        {
            return _companyRepository.GetAll(null);
        }

        public Company GetById(int id)
        {
            return _companyRepository.Get(x => x.Id == id);
        }

        public Company Update(int id, Company model)
        {
            var company = GetById(id);
            model.Id = company.Id;
            _companyRepository.Update(model);
            return model;
        }

        public List<Company> GetAllByName(string name)
        {
            return _companyRepository.GetAll(x => x.Name == name);
        }
    }
}
