using Transaction.Domain.Entities;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace Transaction.Application.Interfaces
{
    public interface ITransactionRepo
    {
        public Task<List<AccountTransaction>> GetTransactionsByAccounts(string userId, List<string> AccountIds);
        public Task<int> CreateAccountTransaction(AccountTransaction transaction);

    }
}
