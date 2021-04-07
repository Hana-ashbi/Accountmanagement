using Account.Application.interfaces;
using Account.Domain.Entities;
using MediatR;
using SharedLib.Http;
using SharedLib.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Account.Application.Features.AccountFeatures.Queries
{
    public class GetUserByIdQuery : IRequest<UserInfo>
    {
        public string CustomerID { get; set; }
        public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserInfo>
        {
            private readonly IAccountRepo _context;
            private readonly TransactionService _transactionService;
            public GetUserByIdQueryHandler(IAccountRepo context, TransactionService transactionService)
            {
                _context = context;
                _transactionService = transactionService;
            }
            public async Task<UserInfo> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
            {
                var user = await _context.GetUserByID(query.CustomerID);
                var accountTransactions = new List<AccountTransaction>();
                try
                {


                    accountTransactions = await _transactionService.ListAccountsTransactions(user.Id, user.Accounts.Select(x => x.Id)
                        .ToList());

                    for (int i = 0; i < accountTransactions.Count(); i++)
                    {
                        accountTransactions.ElementAt(i).Balance = accountTransactions.ElementAt(i).Transactions.Sum(x => x.Amount);
                    }

                    var zeroBalanceAccounts = user.Accounts.Where(x => accountTransactions.Where(y => y.AccountId == x.Id).Count() == 0).ToList();

                    foreach (var account in zeroBalanceAccounts)
                    {
                        accountTransactions.Add(new AccountTransaction { AccountId = account.Id, UserId = account.UserId });
                    }

                }
                catch (HttpRequestException)
                {
                    return null;
                }


                return new UserInfo { Id = user.Id, Name = user.Name, Surname = user.Surname, Accounts = accountTransactions };
            }
        }
    }
}
