using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Transaction.Application.Interfaces;
using Transaction.Persistence.Context;

namespace Transaction.Persistence
{
    public static class DependencyInjection
    {
        public static void AddTransctionPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TransactionRepo>(opt => opt.UseInMemoryDatabase("TransactionDB"));
            services.AddScoped<ITransactionRepo>(provider => provider.GetService<TransactionRepo>());
        }
    }
}
