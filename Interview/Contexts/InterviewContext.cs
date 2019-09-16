using Interview.Domain;
using Interview.Domain.Context;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Hosting;

namespace Interview
{
    public class InterviewContext : IInterviewContext
    {
        public InterviewContext()
        {
            var jsonPath = HostingEnvironment.MapPath(@"~/data.json");

            var json = System.IO.File.ReadAllText(jsonPath);

            Transactions = JsonConvert.DeserializeObject<IList<Transaction>>(json);
        }

        public IList<Transaction> Transactions { get; set; }
    }
}
