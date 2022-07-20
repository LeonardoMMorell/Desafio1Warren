using DomainModels;
using DomainServices.Interfaces;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainServices
{
    public class CustomerServices : ICustomerServices
    {
        private readonly DatabaseDbContext _dbContext;

        public CustomerServices(DatabaseDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IEnumerable<Customer> GetAll(Predicate<Customer> predicate = null)
        {
            if (predicate is null) return _dbContext.Customers;
            return _dbContext.Customers.AsEnumerable();
        }

        public Customer GetBy(Func<Customer, bool> predicate)
        {
            var customer = _dbContext.Customers.AsNoTracking().FirstOrDefault(predicate);
            return customer;
        }

        public (bool validation, string errorMessage) Add(Customer customer)
        {
            var method = CheckIfExists(customer);
            if (method.exists) return (false, method.errorMessage);

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return (true, customer.Id.ToString());
        }

        public bool Delete(int id)
        {
            var variableDelete = GetBy(c => c.Id == id);
            if (variableDelete == null) return false;
            _dbContext.Customers.Remove(variableDelete);
            _dbContext.SaveChanges();
            return true;
        }

        public (bool validation, string errorMessage) Update (Customer customerUpdated)
        {
            var customerVerify = CheckIfExists(customerUpdated);
            if (customerVerify.exists) return (false, customerVerify.errorMessage);

            var customerFound = GetBy(x => x.Id == customerUpdated.Id);
            if (customerFound is null) return (false, $"Customer not found for Id: {customerUpdated.Id}");

            _dbContext.Customers.Update(customerUpdated);
            _dbContext.SaveChanges();
            return (true, customerUpdated.Id.ToString());
        }

        private (bool exists, string errorMessage) CheckIfExists(Customer customer)
        {
            var messageTemplate = "Customer exists for {0}: {1}";
            if (_dbContext.Customers.Any(x => x.Email.Equals(customer.Email)))
            {
                return (true, string.Format(messageTemplate, "Email", customer.Email));
            }
            if (_dbContext.Customers.Any(x => x.Cpf.Equals(customer.Cpf)))
            {
                return (true, string.Format(messageTemplate, "Cpf", customer.Cpf));
            }
            return default;
        }
    }
}