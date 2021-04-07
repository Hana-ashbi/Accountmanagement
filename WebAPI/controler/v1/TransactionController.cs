using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Transaction.Application.Features.Commands;
using Transaction.Application.Features.Queries;

namespace WebAPI.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class TransactionController : BaseApiController
    {

        /// <summary>
        /// Creates a New TransactionAccount.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountTransactionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        /// <summary>
        /// Gets AccountTransaction Entity by userID, List of accounts.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("listAccountTransactions")]
        public async Task<IActionResult> ListAccountTransactions(GetTransactionsByAccountsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
