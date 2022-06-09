using AppServices.Dtos;
using DomainModels;
using DomainServices.Dtos;
using System;
using System.Collections.Generic;

namespace AppServices
{
    public interface ICustomerAppService
    {
        (bool validation, string errorMessage) Add(CreateCustomerRequest model);
        bool Delete(int id);
        IEnumerable<CustomerResult> GetAll(Predicate<Customer> predicate);
        CustomerResult GetBy(Func<Customer, bool> predicate);
        IEnumerable<CustomerResult> GetAllByCpf(string cpf);
        IEnumerable<CustomerResult> GetAllByEmail(string email);
        IEnumerable<CustomerResult> GetAllByFullName(string fullName);
        CustomerResult GetById(int id);
        public (bool validation, string errorMessage) Update(int id, UpdateCustomerRequest customerDtoUpdated);
    }
}
