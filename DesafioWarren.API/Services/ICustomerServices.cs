using DesafioWarren.API.Models;

namespace DesafioWarren.API.Data
{
    public interface ICustomerServices
    {
        public void Add(Customer customer);
        public void Update(Customer customer, Customer CustomerUpdated);
        public void DeleteCustomer(Customer customer);
        List<Customer> SearchId(int id);
        List<Customer> SearchFullName(string FullName);
        List<Customer> SearchEmail(string Email);
        List<Customer> SearchCpf(string Cpf);
        List<Customer> GetAll(Predicate<Customer> predicate = null);
        Customer GetSingle(Func<Customer, bool> predicate);
    }
}