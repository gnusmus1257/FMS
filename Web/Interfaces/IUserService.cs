using System;
using System.Collections.Generic;
using Models.DatabaseModels;

namespace Web.Interfaces
{
    public interface IUserService : IDisposable
    {
        void Create(User item);
        User FindById(int id);
        User Find(Func<User, bool> predicate);
        User Find(Func<User, bool> predicate, string children);
        IEnumerable<User> Get();
        IEnumerable<User> Get(Func<User, bool> predicate);
        IEnumerable<User> Get(Func<User, bool> predicate, string children);
        void Remove(User item);
        void Update(User item);
    }
}