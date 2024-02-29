using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NFTAuctionPlatform.Repository.Models;
using NFTAuctionPlatform.Services;

namespace NFTAuctionPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;
        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Verify")]
        [ProducesResponseType(200, Type = typeof(Account))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Validate(Account account)
        {
          
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Account>))]
        public IActionResult GetAccounts()
        {
            var accounts = _accountService.GetAccounts();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(accounts);
        }

        [HttpGet("{accountId}")]
        [ProducesResponseType(200, Type = typeof(Account))]
        [ProducesResponseType(400)]
        public IActionResult GetAccount(int accountId)
        {
            var account = _accountService.GetAccount(accountId);
            if (!ModelState.IsValid) return BadRequest();
            if (account == null) return NotFound();
            return Ok(account);
        }

        [HttpGet("GetByAddress/{walletAddress}")]
        [ProducesResponseType(200, Type = typeof(Account))]
        [ProducesResponseType(400)]
        public IActionResult GetAccountByAddress(string walletAddress)
        {
            var account = _accountService.GetAccount(walletAddress);
            if (!ModelState.IsValid) return BadRequest();
            if (account == null) return NotFound();
            return Ok(account);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult CreateAccount([FromBody] Account accountCreate)
        {
            if (accountCreate == null) return BadRequest(ModelState);

            var res = _accountService.CreateAccount(accountCreate);

            if (res.Status != 201)
            {
                ModelState.AddModelError("", res.StatusMessage);
                return StatusCode(res.Status, ModelState);
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return StatusCode(res.Status, res.StatusMessage);
        }

        [HttpDelete("{accountId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteAccount(int accountId)
        {
            var res = _accountService.DeleteAccount(accountId);
            if (res.Status != 204)
            {
                ModelState.AddModelError("", res.StatusMessage);
                return StatusCode(res.Status, ModelState);
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return NoContent();
        }





    }
}
