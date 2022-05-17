using DesafioWarren.API.Models;

namespace DesafioWarren.API.Data
{
    public class Repository : ICustomerServices
    {
        public List<Customer> CustomersClients { get; set; } = new List<Customer>();
        public List<Customer> GetAll(Predicate<Customer> predicate)
        {
            return CustomersClients.FindAll(x => x.Equals(CustomersClients));
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

        public void DeleteCustomer(Customer customer)
        {
            CustomersClients.Remove(customer);
        }

        public void Update(Customer customer, Customer CustomerUpdated)
        {
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
        }

        public List<Customer> SearchId(int id)
        {
            var customer = CustomersClients.FindAll(x => x.Id == id);
            if (customer.Count is 0)
            {
                return null;
            }
            return customer;
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