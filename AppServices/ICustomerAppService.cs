using DomainModels;
using DomainServices.Dtos;
using System;
using System.Collections.Generic;

namespace AppServices
{
    public interface ICustomerAppService
    {
        int Add(CustomerDto model);
        bool DeleteCustomer(int id);
        IEnumerable<CustomerDto> GetAll(Predicate<Customer> predicate = null);
        CustomerDto GetBy(Func<Customer, bool> predicate);
        List<Customer> GetAllByCpf(string cpf);
        List<Customer> GetAllByEmail(string email);
        List<Customer> GetAllByFullName(string fullName);
        Customer GetById(int id);
        bool Update(int id, CustomerDto customerDtoUpdated);
    }
}
