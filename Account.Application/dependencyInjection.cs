using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Account.Application
{
    public static class DependencyInjection
    {
        public static void AddAccountApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
