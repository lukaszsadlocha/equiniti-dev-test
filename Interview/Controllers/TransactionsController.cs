using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Interview.Domain;
using Interview.Service;

namespace Interview.Controllers
{
    public class TransactionsController : ApiController
    {
        private ITransactionService TransactionService { get; }

        public TransactionsController(ITransactionService _service)
        {
            TransactionService = _service;
        }

        // GET: api/Transactions
        public IQueryable<Transaction> GetTransactions()
        {
            return TransactionService.GetAll();
        }

        // GET: api/Transactions/d2032222-47a6-4048-9894-11ab8ebb9f69
        [ResponseType(typeof(Transaction))]
        public IHttpActionResult GetTransaction(Guid id)
        {
            var transaction = TransactionService.GetByGuid(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        // PUT: api/Transactions/d2032222-47a6-4048-9894-11ab8ebb9f69
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTransaction(Guid id, Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transaction.Id)
            {
                return BadRequest();
            }

            TransactionService.Update(transaction);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Transactions
        [ResponseType(typeof(Transaction))]
        [HttpPost]
        public IHttpActionResult PostTransaction(Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (transaction.Id == Guid.Empty)
                transaction.Id = Guid.NewGuid();

            TransactionService.Create(transaction);

            return GetTransaction(transaction.Id);
        }

        // DELETE: api/Transactions/5
        [ResponseType(typeof(Transaction))]
        [HttpDelete]
        [Authorize]
        public IHttpActionResult DeleteTransaction(Guid id)
        {
            Transaction transaction = TransactionService.GetByGuid(id);
            if (transaction == null)
            {
                return NotFound();
            }

            TransactionService.Remove(id);

            return Ok(transaction);
        }
    }
}