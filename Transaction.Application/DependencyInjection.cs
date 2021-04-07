using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Transaction.Application
{
    public static class DependencyInjection
    {
        public static void AddTransactionApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
