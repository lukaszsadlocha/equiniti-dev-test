using System.Collections.Generic;

namespace Interview.Domain.Context
{
    public interface IInterviewContext
    {
        IList<Transaction> Transactions { get; set; }
    }
}