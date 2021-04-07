using Account.Application.Features.AccountFeatures;
using Account.Application.Features.AccountFeatures.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AccountController : BaseApiController
    {

        /// <summary>
        /// Creates a New Account.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountCommand command)
        {
            var result = await Mediator.Send(command);
            if (result == "")
            {
                return NotFound();
            }

            return Ok(result);
        }


        /// <summary>
        /// Gets Account Entity by CustomerId.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await Mediator.Send(new GetUserByIdQuery { CustomerID = id });

            return Ok(result);
        }
    }

}
