using DomainModels;
using DomainServices.Interfaces;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DomainServices
{
    public class CustomerServices : ICustomerServices
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IRepositoryFactory _repositoryFactory;

        public CustomerServices(IUnitOfWork<DatabaseContext> unitOfWork, IRepositoryFactory<DatabaseContext> repositoryFactory)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repositoryFactory = repositoryFactory ?? throw new ArgumentNullException(nameof(repositoryFactory));
        }

        public IEnumerable<Customer> GetAll(Expression<Func<Customer, bool>> predicates)
        {
            var repository = _repositoryFactory.Repository<Customer>();

            var query = repository.MultipleResultQuery();
            query.AndFilter(predicates);

            return repository.Search(query);
        }

        public Customer GetBy(Expression<Func<Customer, bool>> predicates)
        {
            var repository = _repositoryFactory.Repository<Customer>();

            var query = repository.SingleResultQuery();
            query.AndFilter(predicates);

            return repository.FirstOrDefault(query);
        }

        public (bool validation, string errorMessage) Add(Customer customer)
        {
            var repository = _unitOfWork.Repository<Customer>();

            var method = CheckIfExists(customer);
            if (method.exists) return (false, method.errorMessage);

            repository.Add(customer);
            _unitOfWork.SaveChanges();
            return (true, customer.Id.ToString());
        }

        public bool Delete(int id)
        {
            var repository = _unitOfWork.Repository<Customer>();

            var variableDelete = GetBy(c => c.Id == id);
            if (variableDelete == null) return false;

            repository.Remove(variableDelete);
            _unitOfWork.SaveChanges();
            return true;
        }

        public (bool validation, string errorMessage) Update (Customer customerUpdated)
        {
            var repository = _unitOfWork.Repository<Customer>();

            var customerVerify = CheckIfExists(customerUpdated);
            if (customerVerify.exists) return (false, customerVerify.errorMessage);

            var customerFound = GetBy(x => x.Id == customerUpdated.Id);
            if (customerFound is null) return (false, $"Customer not found for Id: {customerUpdated.Id}");

            repository.Update(customerUpdated);
            _unitOfWork.SaveChanges();
            return (true, customerUpdated.Id.ToString());
        }

        private (bool exists, string errorMessage) CheckIfExists(Customer customer)
        {
            var repository = _repositoryFactory.Repository<Customer>();

            var messageTemplate = "Customer exists for {0}: {1}";
            if (repository.Any(x => x.Email.Equals(customer.Email)))
            {
                return (true, string.Format(messageTemplate, "Email", customer.Email));
            }
            if (repository.Any(x => x.Cpf.Equals(customer.Cpf)))
            {
                return (true, string.Format(messageTemplate, "Cpf", customer.Cpf));
            }
            return default;
        }
    }
}