using System;
using System.Collections.Generic;
using Models.DatabaseModels;
using Web.Interfaces;
using Web.Repository;

namespace Web.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _repo;

        public OrderService(IRepository<Order> repo)
        {
            _repo = repo;
        }

        public void Dispose()
        {
            _repo.Dispose();
        }

        public void Create(Order item)
        {
            _repo.Create(item);
        }

        public Order FindById(int id)
        {
            return _repo.FindById(id);
        }

        public Order Find(Func<Order, bool> predicate)
        {
            return _repo.Find(predicate);
        }

        public Order Find(Func<Order, bool> predicate, string children)
        {
            return _repo.Find(predicate, children);
        }

        public IEnumerable<Order> Get()
        {
            return _repo.Get();
        }

        public IEnumerable<Order> Get(Func<Order, bool> predicate)
        {
            return _repo.Get(predicate);
        }

        public IEnumerable<Order> Get(Func<Order, bool> predicate, string children)
        {
            return _repo.Get(predicate, children);
        }

        public void Remove(Order item)
        {
            _repo.Remove(item);
        }

        public void Update(Order item)
        {
            _repo.Update(item);
        }
    }
}