using System;
using System.Linq;
using Interview.Domain;
using Interview.Domain.Context;

namespace Interview.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        public TransactionRepository(IInterviewContext _context)
        {
            Context = _context;
        }

        private IInterviewContext Context { get; }

        public void Add(Transaction transaction)
        {
            Context.Transactions.Add(transaction);
        }

        public Transaction Get(Guid id)
        {
            return Context.Transactions.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Transaction> GetAll()
        {
            return Context.Transactions.AsQueryable();
        }

        public void Remove(Guid id)
        {
            var transaction = Get(id);
            if (transaction == null)
                throw new ArgumentException($"Transaction with provided GUID: {id} does not exisit", nameof(id));

            Context.Transactions.Remove(transaction);
        }

        public void Update(Transaction updatedTransaction)
        {
            var transaction = Get(updatedTransaction.Id);
            if (transaction == null)
                throw new ArgumentException($"Transaction with provided GUID: {updatedTransaction.Id} does not exisit");

            transaction = updatedTransaction;
        }
    }
}