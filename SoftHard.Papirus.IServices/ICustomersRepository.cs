using SoftHard.Papirus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftHard.Papirus.IServices
{


    public interface IEntitiesRepository<out T>
    {
        T Get();

        IQueryable<T> Query();
    }

    public interface ICustomersRepository : IEntitiesRepository<Customer>
    {
    }

    public interface IProductsRepository : IEntitiesRepository<Product>
    {

    }

    public class UnitOfWork
    {
        private readonly ICustomersRepository customersRepository;
        private readonly IProductsRepository productsRepository;
  
        public UnitOfWork(ICustomersRepository customersRepository, IProductsRepository productsRepository)
        {
            this.customersRepository = customersRepository;
            this.productsRepository = productsRepository;
        }

        public void Save()
        {
            
        }
    }
}
