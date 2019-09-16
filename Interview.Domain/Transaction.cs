using System;

namespace Interview.Domain
{
    //    {
    //    "Id": "d2032222-47a6-4048-9894-11ab8ebb9f69",
    //    "ApplicationId": 197104,
    //    "Type": "Debit",
    //    "Summary": "Payment",
    //    "Amount": 50.09,
    //    "PostingDate": "2016-08-01T00:00:00",
    //    "IsCleared": true,
    //    "ClearedDate": "2016-08-02T00:00:00"
    //},

    public class Transaction
    {
        public Guid Id { get; set; }
        public int ApplicationId { get; set; }
        public string Type { get; set; }
        public string Summary { get; set; }
        public decimal Amount { get; set; }
        public DateTime PostingDate { get; set; }
        public bool IsCleared { get; set; }
        public DateTime? ClearedDate { get; set; }
    }
}
