using DesafioWarren.API.Data;
using DesafioWarren.API.Models;
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

        public Customer GetSingle(Func<Customer, bool> predicate)
        {
            return _customerServices.GetSingle(predicate);
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

        public List<Customer> SearchId(int id)
        {
            return _customerServices.SearchId(id);
        }

        public List<Customer> SearchFullName(string FullName)
        {
            return _customerServices.SearchFullName(FullName);
        }

        public List<Customer> SearchEmail(string Email)
        {
            return _customerServices.SearchEmail(Email);
        }

        public List<Customer> SearchCpf(string Cpf)
        {
            return _customerServices.SearchCpf(Cpf);
        }
    }
}
