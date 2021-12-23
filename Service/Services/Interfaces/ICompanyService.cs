using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services.Interfaces
{
    public interface ICompanyService
    {
        Company Create(Company model);
        Company Update(Company model, int id);
        void Delete(Company company);
        Company GetById(int id);
        List<Company> GetByName(string name);

    }
}
