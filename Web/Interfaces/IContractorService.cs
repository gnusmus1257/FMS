using System;
using System.Collections.Generic;
using Models.DatabaseModels;

namespace Web.Interfaces
{
    public interface IContractorService : IDisposable
    {
        void Create(Contractor item);
        Contractor FindById(int id);
        Contractor Find(Func<Contractor, bool> predicate);
        Contractor Find(Func<Contractor, bool> predicate, string children);
        IEnumerable<Contractor> Get();
        IEnumerable<Contractor> Get(Func<Contractor, bool> predicate);
        IEnumerable<Contractor> Get(Func<Contractor, bool> predicate, string children);
        void Remove(Contractor item);
        void Update(Contractor item);
    }
}