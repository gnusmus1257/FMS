using System;
using System.Collections.Generic;
using Models.DatabaseModels;

namespace Web.Interfaces
{
    public interface IOrderService : IDisposable
    {
        void Create(Order item);
        Order FindById(int id);
        Order Find(Func<Order, bool> predicate);
        Order Find(Func<Order, bool> predicate, string children);
        IEnumerable<Order> Get();
        IEnumerable<Order> Get(Func<Order, bool> predicate);
        IEnumerable<Order> Get(Func<Order, bool> predicate, string children);
        void Remove(Order item);
        void Update(Order item);
    }
}