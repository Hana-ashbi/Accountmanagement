using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transaction.Application.Interfaces;
using Transaction.Domain.Entities;

namespace Transaction.Persistence.Context
{
    public class TransactionRepo : DbContext, ITransactionRepo
    {
        public TransactionRepo(DbContextOptions<TransactionRepo> options)
            : base(options)
        {
        }
        public DbSet<AccountTransaction> AccountTransaction { get; set; }
        public DbSet<Domain.Entities.Transaction> Transactions { get; set; }

        public async Task<int> CreateAccountTransaction(AccountTransaction transaction)
        {
            AccountTransaction.Add(transaction);
            return await base.SaveChangesAsync();
        }

        public async Task<List<AccountTransaction>> GetTransactionsByAccounts(string userId, List<string> accountIds)
        {
            return await AccountTransaction.Include(x => x.Transactions).Where(x => x.UserId == userId && accountIds.Contains(x.AccountId)).ToListAsync();
        }
    }
}
