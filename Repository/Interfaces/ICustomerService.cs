﻿using System;
using System.Collections.Generic;
using Models.DatabaseModels;

namespace Repository.Interfaces
{
    public interface ICustomerService: IDisposable
    {
        void Create(Customer item);
        Customer FindById(int id);
        Customer Find(Func<Customer, bool> predicate);
        Customer Find(Func<Customer, bool> predicate, string children);
        IEnumerable<Customer> Get();
        IEnumerable<Customer> Get(Func<Customer, bool> predicate);
        IEnumerable<Customer> Get(Func<Customer, bool> predicate, string children);
        void Remove(Customer item);
        void Update(Customer item);
    }
}