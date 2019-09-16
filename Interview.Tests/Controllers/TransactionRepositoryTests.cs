using System;
using System.Collections.Generic;
using FluentAssertions;
using Interview.Domain;
using Interview.Domain.Context;
using Interview.Repository;
using Interview.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NSubstitute;

namespace Interview.Tests.Controllers
{
    [TestClass]
    public class TransactionRepositoryTests
    {
        [TestMethod]
        public void TransactionRepository_GetAll_ShouldReturnAllTransactionsFromContext()
        {
            //arrange
            var repository = new TransactionRepository(GetContext());

            //act
            var result = repository.GetAll();

            //assert
            result.Should().NotBeNull();
            result.Should().HaveCount(3);
        }

        private IInterviewContext GetContext()
        {
            var context = Substitute.For<IInterviewContext>();

            var transactionsJson = @"[
                {
                    'Id': '0f6eb0a1-3e48-49b6-8990-705a962fb048',
                    'ApplicationId': 456299,
                    'Type': 'Debit',
                    'Summary': 'Payment',
                    'Amount': 52.92,
                    'PostingDate': '2017-01-01T00:00:00',
                    'IsCleared': true,
                    'ClearedDate': '2017-01-02T00:00:00'
                },
                {
                    'Id': '2ce5dfae-3e59-4074-9601-beace62af588',
                    'ApplicationId': 456299,
                    'Type': 'Credit',
                    'Summary': 'Refund',
                    'Amount': 24.36,
                    'PostingDate': '2017-01-19T00:00:00',
                    'IsCleared': true,
                    'ClearedDate': '2017-01-20T00:00:00'
                },
                {
                    'Id': '2b5192b3-61f6-4635-adba-69b1b3ff3718',
                    'ApplicationId': 456299,
                    'Type': 'Credit',
                    'Summary': 'Refund',
                    'Amount': 8.62,
                    'PostingDate': '2017-01-22T00:00:00',
                    'IsCleared': false,
                    'ClearedDate': null
                }
            ]";

            var transactions = JsonConvert.DeserializeObject<IList<Transaction>>(transactionsJson);

            context.Transactions.Returns(transactions);

            return context;
        }
    }
}
