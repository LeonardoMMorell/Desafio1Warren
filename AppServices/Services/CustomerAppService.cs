using Application.Interfaces;
using ApplicationModels.Requests;
using ApplicationModels.Responses;
using AutoMapper;
using DomainModels;
using DomainServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerServices _customerServices;

        private readonly IMapper _mapper;

        public CustomerAppService(ICustomerServices customerServices, IMapper mapper)
        {
            _customerServices = customerServices ?? throw new ArgumentNullException(nameof(customerServices));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<CustomerResult> GetAll(Expression<Func<Customer, bool>> predicates)
        {
            var customer = _customerServices.GetAll();
            return _mapper.Map<IEnumerable<CustomerResult>>(customer);
        }

        public CustomerResult GetBy(Expression<Func<Customer, bool>> predicate)
        {
            var customer = _customerServices.GetBy(predicate);
            return _mapper.Map<CustomerResult>(customer);
        }

        public (bool validation, string errorMessage) Add(CreateCustomerRequest createCustomer)
        {
            var customerCreate = _mapper.Map<Customer>(createCustomer);
            var customerAdd = _customerServices.Add(customerCreate);
            if (customerAdd.validation) return (true, customerAdd.errorMessage);

            return (false, customerAdd.errorMessage);
        }

        public bool Delete(int id)
        {
            return _customerServices.Delete(id);
        }

        public (bool validation, string errorMessage) Update(int id, UpdateCustomerRequest modelUpdated)
        {
            var customer = _mapper.Map<Customer>(modelUpdated);
            customer.Id = id;
            return _customerServices.Update(customer);
        }

        public CustomerResult GetById(int id)
        {
            var customer = _customerServices.GetBy(x => x.Id == id);
            return _mapper.Map<CustomerResult>(customer);
        }

        public IEnumerable<CustomerResult> GetAllByFullname(string fullname)
        {
            var customer = _customerServices.GetAll(x => x.FullName == fullname);
            return _mapper.Map<IEnumerable<CustomerResult>>(customer);
        }

        public CustomerResult GetByEmail(string email)
        {
            var customer = _customerServices.GetBy(x => x.Email == email);
            return _mapper.Map<CustomerResult>(customer);
        }

        public CustomerResult GetByCpf(string cpf)
        {
            var customer = _customerServices.GetBy(x => x.Cpf == cpf);
            return _mapper.Map<CustomerResult>(customer);
        }
    }
}