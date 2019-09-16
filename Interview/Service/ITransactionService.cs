using Interview.Domain;
using System;
using System.Linq;

namespace Interview.Service
{
    public interface ITransactionService
    {
        IQueryable<Transaction> GetAll();
        Transaction GetByGuid(Guid id);
        void Update(Transaction transaction);
        void Create(Transaction transaction);
        void Remove(Guid id);
    }
}