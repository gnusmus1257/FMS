using System;
using System.Collections.Generic;
using Models.DatabaseModels;
using Web.Interfaces;
using Web.Repository;

namespace Web.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repo;

        public UserService(IRepository<User> repo)
        {
            _repo = repo;
        }

        public void Dispose()
        {
            _repo.Dispose();
        }

        public void Create(User item)
        {
            _repo.Create(item);
        }

        public User FindById(int id)
        {
            return _repo.FindById(id);
        }

        public User Find(Func<User, bool> predicate)
        {
            return _repo.Find(predicate);
        }

        public User Find(Func<User, bool> predicate, string children)
        {
            return _repo.Find(predicate, children);
        }

        public IEnumerable<User> Get()
        {
            return _repo.Get();
        }

        public IEnumerable<User> Get(Func<User, bool> predicate)
        {
            return _repo.Get(predicate);
        }

        public IEnumerable<User> Get(Func<User, bool> predicate, string children)
        {
            return _repo.Get(predicate, children);
        }

        public void Remove(User item)
        {
            _repo.Remove(item);
        }

        public void Update(User item)
        {
            _repo.Update(item);
        }
    }
}