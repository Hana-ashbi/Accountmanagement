using Account.Application.interfaces;
using Account.Domain.Entities;
using MediatR;
using Newtonsoft.Json;
using SharedLib.Http;
using SharedLib.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Account.Application.Features.AccountFeatures
{

    public class CreateAccountCommand : IRequest<string>
    {
        public string CustomerID { get; set; }
        public decimal InitialCredit { get; set; }


        public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, string>
        {
            private readonly IAccountRepo _context;
            private readonly TransactionService _transactionService;

            public CreateAccountCommandHandler(IAccountRepo context, TransactionService transactionService)
            {
                _context = context;
                _transactionService = transactionService;
            }
            public async Task<string> Handle(CreateAccountCommand command, CancellationToken cancellationToken)
            {
                var user = await _context.GetUserByID(command.CustomerID);
                if (user == null)
                {
                    return "";
                }
                var account = new UserAccount();
                account.Id = Guid.NewGuid().ToString();
                account.Created_At = DateTime.UtcNow;
                account.Status = AccountStatus.ACTIVE;
                account.UserId = user.Id;

                if (account.ShouldCreateInitialTransaction(command.InitialCredit))
                {
                    try
                    {
                        var transaction = new Transaction
                        {
                            Id = Guid.NewGuid().ToString(),
                            AccountId = account.Id,
                            UserId = user.Id,
                            Amount = command.InitialCredit,
                            Created_At = DateTime.UtcNow
                        };
                        var accountTransaction = new AccountTransaction { UserId = user.Id, AccountId = account.Id };
                        accountTransaction.Transactions = new List<Transaction>() { transaction };
                        string contents = JsonConvert.SerializeObject(accountTransaction);
                        await _transactionService.PostAccountTransaction(contents);
                    }
                    catch (HttpRequestException)
                    {
                        return "";
                    }
                }

                if (user.Accounts == null)
                {
                    user.Accounts = new List<UserAccount>();
                }
                user.Accounts.Add(account);

                var res = await _context.SaveUser(user);
                return account.Id;
            }
        }
    }
}
