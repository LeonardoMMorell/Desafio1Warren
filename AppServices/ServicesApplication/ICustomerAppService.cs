﻿using Application.Dtos;
using DomainModels;
using System;
using System.Collections.Generic;

namespace AppServices.ServicesApplication
{
    public interface ICustomerAppService
    {
        (bool validation, string errorMessage) Add(CreateCustomerRequest model);
        bool Delete(int id);
        IEnumerable<CustomerResult> GetAll(Predicate<Customer> predicate);
        CustomerResult GetBy(Func<Customer, bool> predicate);
        CustomerResult GetByCpf(string cpf);
        CustomerResult GetByEmail(string email);
        IEnumerable<CustomerResult> GetAllByFullname(string fullname);
        CustomerResult GetById(int id);
        public (bool validation, string errorMessage) Update(UpdateCustomerRequest customerDtoUpdated);
    }
}
