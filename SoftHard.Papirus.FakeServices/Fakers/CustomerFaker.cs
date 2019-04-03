using Bogus;
using SoftHard.Papirus.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftHard.Papirus.FakeServices.Fakers
{
    public class CustomerFaker : Faker<Customer>
    {
        public CustomerFaker()
        {
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.Name, f => f.Person.Company.Name);
            RuleFor(p => p.IsRemoved, f => f.Random.Bool(0.8f));

        }
    }
}
