using FinancialHub.Domain.Interfaces.Services;
using FinancialHub.Domain.Models;
using FinancialHub.Domain.Responses.Errors;
using FinancialHub.Domain.Responses.Success;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FinancialHub.WebApplic.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ProducesErrorResponseType(typeof(Exception))]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountBalanceService _accountBalanceService;
        private readonly IAccountsService _accountsService;

        public AccountsController(IAccountBalanceService accountBalanceService, IAccountsService accountsService)
        {
            _accountBalanceService = accountBalanceService;
            _accountsService = accountsService;
        }

        [HttpGet("{accountId}/balances")]
        [ProducesResponseType(typeof(ListResponse<BalanceModel>), 200)]
        public async Task<ActionResult> GetAccountBalances([FromRoute] Guid accountId)
        {
            var result = await _accountBalanceService.GetBalancesByAccountAsync(accountId);
            return Ok(new ListResponse<BalanceModel>(result.Data));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ListResponse<AccountModel>), 200)]
        public async Task<IActionResult> GetMyAccounts()
        {
            var result = await _accountsService.GetAllByUserAsync(Guid.NewGuid());
            return Ok(new ListResponse<AccountModel>(result.Data));
        }

        [HttpPost]
        [ProducesResponseType(typeof(SaveResponse<AccountModel>), 200)]
        [ProducesResponseType(typeof(ValidationErrorResponse), 400)]
        public async Task<IActionResult> CreateAccount([FromBody] AccountModel account)
        {
            var result = await _accountBalanceService.CreateAsync(account);
            if(result.HasError)
                return StatusCode(result.Error.Code, new ValidationErrorResponse(result.Error.Message));

            return Ok(new SaveResponse<AccountModel>(result.Data));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(SaveResponse<AccountModel>), 200)]
        [ProducesResponseType(typeof(NotFoundErrorResponse), 404)]
        [ProducesResponseType(typeof(ValidationErrorResponse), 400)]
        public async Task<IActionResult> UpdateAccount([FromRoute] Guid id, [FromBody] AccountModel account)
        {
            var response = await _accountsService.UpdateAsync(id, account);
            if (response.HasError)
                return StatusCode(response.Error.Code, new ValidationErrorResponse(response.Error.Message));

            return Ok(new SaveResponse<AccountModel>(response.Data));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount([FromRoute] Guid id)
        {
            await _accountBalanceService.DeleteAsync(id);
            return NoContent();
        }
    }
}
