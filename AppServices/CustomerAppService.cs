using DomainModels;
using DomainServices;
using System;
using System.Collections.Generic;

namespace AppServices
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerServices _customerServices;

        public CustomerAppService(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        public List<Customer> GetAll(Predicate<Customer> predicate = null)
        {
            return _customerServices.GetAll(predicate);
        }

        public Customer GetBy(Func<Customer, bool> predicate)
        {
            return _customerServices.GetBy(predicate);
        }

        public void Add(Customer customer)
        {
            _customerServices.Add(customer);
        }

        public bool DeleteCustomer(int id)
        {
            return _customerServices.DeleteCustomer(id);
        }

        public bool Update(int id, Customer CustomerUpdated)
        {
            return _customerServices.Update(id, CustomerUpdated);
        }

        public Customer GetById(int id)
        {
            return _customerServices.GetBy(x => x.Id == id);
        }

        public List<Customer> GetByFullName(string fullName)
        {
            return GetAll(x => x.FullName.Equals(fullName));
        }

        public List<Customer> GetByEmail(string email)
        {
            return _customerServices.GetAll(x => x.Email == email);
        }

        public List<Customer> GetByCpf(string cpf)
        {
            return _customerServices.GetAll(x => x.Cpf == cpf);
        }
    }
}