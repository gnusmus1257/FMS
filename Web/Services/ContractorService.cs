using System;
using System.Collections.Generic;
using Models.DatabaseModels;
using Web.Interfaces;
using Web.Repository;

namespace Web.Services
{
    public class ContractorService : IContractorService
    {
        private readonly IRepository<Contractor> _repo;

        public ContractorService(IRepository<Contractor> repo)
        {
            _repo = repo;
        }

        public void Dispose()
        {
            _repo.Dispose();
        }

        public void Create(Contractor item)
        {
            _repo.Create(item);
        }

        public Contractor FindById(int id)
        {
            return _repo.FindById(id);
        }

        public Contractor Find(Func<Contractor, bool> predicate)
        {
            return _repo.Find(predicate);
        }

        public Contractor Find(Func<Contractor, bool> predicate, string children)
        {
            return _repo.Find(predicate, children);
        }

        public IEnumerable<Contractor> Get()
        {
            return _repo.Get();
        }

        public IEnumerable<Contractor> Get(Func<Contractor, bool> predicate)
        {
            return _repo.Get(predicate);
        }

        public IEnumerable<Contractor> Get(Func<Contractor, bool> predicate, string children)
        {
            return _repo.Get(predicate, children);
        }

        public void Remove(Contractor item)
        {
            _repo.Remove(item);
        }

        public void Update(Contractor item)
        {
            _repo.Update(item);
        }
    }
}