using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Linq;
using BalanceAPI.Context;
using BalanceAPI.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using BalanceAPI.Data;


namespace BalanceAPI.Controllers
{
    
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        private readonly ApplicationDbContext _context;

        private readonly AccountsData accountsData = new AccountsData();

        public AccountsController(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAccounts([FromBody] int userId)
        {

            List<Account> accounts =  accountsData.GetAccounts(userId);

            return Ok(JsonConvert.SerializeObject(accounts));
        }


        [HttpGet]
        [Route("api/[controller]/{accountId}")]
        public IActionResult GetAccount(int accountId)
        {
            Account account = accountsData.GetAccount(accountId);

            if (account != null)
            {
                return Ok(JsonConvert.SerializeObject(account));
            }
            else
            {
                return BadRequest("Can not get an account (400)");
            }
        }
    }
}
