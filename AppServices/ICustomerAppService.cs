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
        List<Customer> GetAllByCpf(string cpf);
        List<Customer> GetAllByEmail(string email);
        List<Customer> GetAllByFullName(string fullName);
        Customer GetById(int id);
        bool Update(int id, Customer CustomerUpdated);
    }
}
