using System;
using System.Linq;
using Interview.Domain;

namespace Interview.Repository
{
    public interface ITransactionRepository
    {
        void Add(Transaction transaction);
        IQueryable<Transaction> GetAll();
        Transaction Get(Guid id);
        void Remove(Guid id);
        void Update(Transaction transaction);
    }
}
