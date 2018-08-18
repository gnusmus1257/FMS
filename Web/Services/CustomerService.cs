using System;
using System.Collections.Generic;
using Models.DatabaseModels;
using Web.Interfaces;
using Web.Repository;

namespace Web.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _repo;

        public CustomerService(IRepository<Customer> repo)
        {
            _repo = repo;
        }

        public void Dispose()
        {
            _repo.Dispose();
        }

        public void Create(Customer item)
        {
            _repo.Create(item);
        }

        public Customer FindById(int id)
        {
            return _repo.FindById(id);
        }

        public Customer Find(Func<Customer, bool> predicate)
        {
            return _repo.Find(predicate);
        }

        public Customer Find(Func<Customer, bool> predicate, string children)
        {
            return _repo.Find(predicate, children);
        }

        public IEnumerable<Customer> Get()
        {
            return _repo.Get();
        }

        public IEnumerable<Customer> Get(Func<Customer, bool> predicate)
        {
            return _repo.Get(predicate);
        }

        public IEnumerable<Customer> Get(Func<Customer, bool> predicate, string children)
        {
            return _repo.Get(predicate, children);
        }

        public void Remove(Customer item)
        {
            _repo.Remove(item);
        }

        public void Update(Customer item)
        {
            _repo.Update(item);
        }
    }
}