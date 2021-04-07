using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Transaction.Application.Interfaces;
using Transaction.Domain.Entities;

namespace Transaction.Application.Features.Queries
{
    public class GetTransactionsByAccountsQuery : IRequest<List<AccountTransaction>>
    {
        public string UserID { get; set; }
        public List<string> Accounts { get; set; }

        public class GetTransactionsByAccountsQueryHandler : IRequestHandler<GetTransactionsByAccountsQuery, List<AccountTransaction>>
        {
            private readonly ITransactionRepo _context;
            public GetTransactionsByAccountsQueryHandler(ITransactionRepo context)
            {
                _context = context;
            }
            public async Task<List<AccountTransaction>> Handle(GetTransactionsByAccountsQuery query, CancellationToken cancellationToken)
            {


                return await _context.GetTransactionsByAccounts(query.UserID, query.Accounts);
            }
        }
    }
}
