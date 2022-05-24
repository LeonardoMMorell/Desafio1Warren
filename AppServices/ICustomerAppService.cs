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
        Customer GetBy(Func<Customer, bool> predicate);
        List<Customer> GetByCpf(string cpf);
        List<Customer> GetByEmail(string email);
        List<Customer> GetByFullName(string fullName);
        Customer GetById(int id);
        bool Update(int id, Customer CustomerUpdated);
    }
}
