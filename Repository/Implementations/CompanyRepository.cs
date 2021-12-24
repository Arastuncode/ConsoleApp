using Domain.Models;
using Repository.Data;
using Repository.Exceptions;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
namespace Repository.Implementations
{
    public class CompanyRepository : IRepository<Company>
    {
        public bool Create(Company entity)
        {
            try
            {
                if (entity == null) throw new CustomException("Entity is null");
                AppDbContext<Company>.data.Add(entity);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public Company GetById(Predicate<Company> filter = null)
        {
            return filter==null ? AppDbContext<Company>.data[0]: AppDbContext<Company>.data.Find(filter);
        }
        public List<Company> GetByName(string name)
        {
            return name == null ? AppDbContext<Company>.data : AppDbContext<Company>.data.FindAll(null);
        }
        public bool Update(Company entity)
       {
            try
            {
                AppDbContext<Company>.data.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        public bool Delete(Company company)
        {
            try
            {
                AppDbContext<Company>.data.Remove(company);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public List<Company> GetAll(Predicate<Company> filter=null)
        {
            return filter == null ? AppDbContext<Company>.data : AppDbContext<Company>.data.FindAll(filter);
        }
        public Company Get(Predicate<Company> filter)
        {
            throw new NotImplementedException();
        }
    }

}
 