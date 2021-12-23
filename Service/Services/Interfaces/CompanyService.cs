﻿using Domain.Models;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services.Interfaces
{
    public class CompanyService:ICompanyService
    {
        private CompanyRepository _companyRepository;
        private int _count { get; set; }
        public CompanyService()
        {
            _companyRepository = new CompanyRepository();
        }
        public Company Create(Company model)
        {
            model.Id = _count;
            _companyRepository.Create(model);
            _count++;
            return model;
        }


        public Company GetById(int id)
        {
            return _companyRepository.Get(x => x.Id == id);
        }

        public List<Company> GetAll()
        {
            return _companyRepository.GetAll(null);
        }

        public Company Update(Company model, int id)
        {
            throw new NotImplementedException();
        }
        public void Delete(Company company)
        {
             _companyRepository.Delete(company);
        }

        public List<Company> GetByName(string name)
        {
            return _companyRepository.GetAll(x => x.Name == name);
        }

        public object GetAll()
        {
            throw new NotImplementedException();
        }
    }
}