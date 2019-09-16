using Interview.Domain.Context;
using Interview.Repository;
using Interview.Service;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Interview
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterSingleton<ITransactionRepository, TransactionRepository>();

            container.RegisterType<ITransactionService, TransactionService>();
            container.RegisterType<IInterviewContext, InterviewContext>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            // Configures container for WebAPI
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}