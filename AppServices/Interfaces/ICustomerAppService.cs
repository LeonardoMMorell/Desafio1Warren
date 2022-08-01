using ApplicationModels.Requests;
using ApplicationModels.Responses;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Application.Interfaces
{
    public interface ICustomerAppService
    {
        (bool validation, string errorMessage) Add(CreateCustomerRequest model);
        bool Delete(int id);
        IEnumerable<CustomerResult> GetAll();
        IEnumerable<CustomerResult> GetAllByFullname(string fullname);
        CustomerResult GetBy(Expression<Func<Customer, bool>> predicates = null);
        CustomerResult GetByCpf(string cpf);
        CustomerResult GetByEmail(string email);
        CustomerResult GetById(int id);
        public (bool validation, string errorMessage) Update(int id, UpdateCustomerRequest customerDtoUpdated);
    }
}