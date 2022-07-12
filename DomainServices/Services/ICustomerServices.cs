using DomainModels;
using System;
using System.Collections.Generic;

namespace DomainServices
{
    public interface ICustomerServices
    {
        public (bool validation, string errorMessage) Add(Customer customer);
        IEnumerable<Customer> GetAll(Predicate<Customer> predicate = null);
        Customer GetBy(Func<Customer, bool> predicate);
        public (bool validation, string errorMessage) Update(Customer CustomerUpdated);
        bool Delete(int id);
    }
}