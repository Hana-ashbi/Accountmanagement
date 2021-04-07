using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Transaction.Application.Interfaces;
using Transaction.Domain.Entities;

namespace Transaction.Application.Features.Commands
{
    public class CreateAccountTransactionCommand : IRequest<string>
    {
        public string UserId { get; set; }
        public string AccountId { get; set; }
        public virtual ICollection<Domain.Entities.Transaction> Transactions { get; set; }

        public class CreateTransactionCommandHandler : IRequestHandler<CreateAccountTransactionCommand, string>
        {
            private readonly ITransactionRepo _context;
            public CreateTransactionCommandHandler(ITransactionRepo context)
            {
                _context = context;
            }
            public async Task<string> Handle(CreateAccountTransactionCommand command, CancellationToken cancellationToken)
            {
                var accountTransaction = new AccountTransaction();
                accountTransaction.UserId = command.UserId;
                accountTransaction.AccountId = command.AccountId;
                accountTransaction.Id = Guid.NewGuid().ToString();


                if (accountTransaction.Transactions == null)
                {
                    accountTransaction.Transactions = new List<Domain.Entities.Transaction>();
                }
                accountTransaction.Transactions = command.Transactions;

                await _context.CreateAccountTransaction(accountTransaction);

                return command.UserId;
            }
        }
    }
}
