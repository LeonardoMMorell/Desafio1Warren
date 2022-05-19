using DesafioWarren.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioWarren.API.Data
{
    public class CustomerServices : ICustomerServices
    {
        private List<Customer> CustomersClients { get; set; } = new List<Customer>();
        public List<Customer> GetAll(Predicate<Customer> predicate = null)
        {
            if (predicate is null)
            {
                return CustomersClients;
            }
            return CustomersClients.FindAll(x => x.Equals(CustomersClients));
        }

        public Customer GetSingle(Func<Customer, bool> predicate)
        {
            var customer = CustomersClients.FirstOrDefault(predicate);
            return customer;
        }

        public void Add(Customer customer)
        {
            int LastId = 0;
            if (CustomersClients.Count == 0)
            {
                customer.Id = LastId + 1;
                CustomersClients.Add(customer);
            }
            else
            {
                LastId = CustomersClients.Last().Id;
                customer.Id = LastId + 1;
                CustomersClients.Add(customer);
            }
        }

        public bool DeleteCustomer(int id)
        {
            var VariableDelete = GetSingle(c => c.Id == id);
            if (VariableDelete == null) return false;
            CustomersClients.Remove(VariableDelete);
            return true;
        }

        public bool Update(int id, Customer CustomerUpdated)
        {
            var customer = GetSingle(x => x.Id == id);
            if (customer == null)
            {
                return false;
            }
            customer.FullName = CustomerUpdated.FullName;
            customer.Email = CustomerUpdated.Email;
            customer.EmailConfirmation = CustomerUpdated.EmailConfirmation;
            customer.Cpf = CustomerUpdated.Cpf;
            customer.Cellphone = CustomerUpdated.Cellphone;
            customer.Birthdate = CustomerUpdated.Birthdate;
            customer.EmailSms = CustomerUpdated.EmailSms;
            customer.Whatsapp = CustomerUpdated.Whatsapp;
            customer.City = CustomerUpdated.City;
            customer.Country = CustomerUpdated.Country;
            customer.PostalCode = CustomerUpdated.PostalCode;
            customer.Address = CustomerUpdated.Address;
            customer.Number = CustomerUpdated.Number;
            return true;
        }

        public List<Customer> SearchId(int id)
        {
            return CustomersClients.FindAll(x => x.Id == id);
        }
        public List<Customer> SearchFullName(string FullName)
        {
            var customer = CustomersClients.FindAll(x => x.FullName == FullName);
            if (customer.Count is 0)
            {
                return null;
            }
            return customer;
        }

        public List<Customer> SearchEmail(string Email)
        {
            var customer = CustomersClients.FindAll(x => x.Email == Email);
            if (customer.Count is 0)
            {
                return null;
            }
            return customer;
        }

        public List<Customer> SearchCpf(string Cpf)
        {
            var customer = CustomersClients.FindAll(x => x.Cpf == Cpf);
            if (customer.Count is 0)
            {
                return null;
            }
            return customer;
        }
    }
}