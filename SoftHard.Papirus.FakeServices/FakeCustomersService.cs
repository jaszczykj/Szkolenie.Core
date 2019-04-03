using SoftHard.Papirus.FakeServices.Fakers;
using SoftHard.Papirus.IServices;
using SoftHard.Papirus.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftHard.Papirus.FakeServices
{
    public class FakeCustomersService : ICustomersService
    {
        private ICollection<Customer> customers;

        private CustomerFaker customerFaker;

        public FakeCustomersService(CustomerFaker customerFaker)
        {
            this.customerFaker = customerFaker;

            customers = customerFaker.Generate(100);
        }

        public void Add(Customer entity) => customers.Add(entity);

        public IEnumerable<Customer> Get() => customers;

        public Customer Get(int id) => customers.SingleOrDefault(c => c.Id == id);

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
