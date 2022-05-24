using DomainModels;
using System;
using System.Collections.Generic;

namespace AppServices
{
    public interface ICustomerAppService
    {
        void Add(Customer customer);
        bool DeleteCustomer(int id);
        List<Customer> GetAll(Predicate<Customer> predicate = null);
        Customer GetSingle(Func<Customer, bool> predicate);
        List<Customer> SearchCpf(string Cpf);
        List<Customer> SearchEmail(string Email);
        List<Customer> SearchFullName(string FullName);
        List<Customer> SearchId(int id);
        bool Update(int id, Customer CustomerUpdated);
    }
}
