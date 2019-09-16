using System;
using System.Linq;
using Interview.Domain;
using Interview.Repository;

namespace Interview.Service
{
    public class TransactionService : ITransactionService
    {
        private ITransactionRepository TransactionRepository { get; }
        public TransactionService(ITransactionRepository _repository)
        {
            TransactionRepository = _repository;
        }

        public void Create(Transaction transaction)
        {
            TransactionRepository.Add(transaction);
        }

        public IQueryable<Transaction> GetAll()
        {
            return TransactionRepository.GetAll();
        }

        public Transaction GetByGuid(Guid id)
        {
            return TransactionRepository.Get(id);
        }

        public void Remove(Guid id)
        {
            TransactionRepository.Remove(id);
        }

        public void Update(Transaction transaction)
        {
            TransactionRepository.Update(transaction);
        }
    }
}