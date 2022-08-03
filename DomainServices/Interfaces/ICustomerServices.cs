using DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DomainServices.Interfaces
{
    public interface ICustomerServices
    {
        public (bool validation, string errorMessage) Add(Customer customer);
        public Customer GetBy(Expression<Func<Customer, bool>> predicate);
        public (bool validation, string errorMessage) Update(Customer CustomerUpdated);
        bool Delete(int id);
        IEnumerable<Customer> GetAll(Expression<Func<Customer, bool>> predicates = null);
    }
}