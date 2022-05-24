using DomainModels;
using System;
using System.Collections.Generic;

namespace DomainServices
{
    public interface ICustomerServices
    {
        public void Add(Customer customer);
        List<Customer> SearchId(int id);
        List<Customer> SearchFullName(string FullName);
        List<Customer> SearchEmail(string Email);
        List<Customer> SearchCpf(string Cpf);
        List<Customer> GetAll(Predicate<Customer> predicate = null);
        Customer GetBy(Func<Customer, bool> predicate);
        bool Update(int id, Customer CustomerUpdated);
        bool DeleteCustomer(int id);
    }
}