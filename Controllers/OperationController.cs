using BalanceAPI.Context;
using BalanceAPI.Data;
using BalanceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BalanceAPI.Controllers
{

    [Route("api/account")]
    public class OperationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        private readonly ApplicationDbContext _context;

        private readonly AccountsData accountsData = new AccountsData();

        private readonly OperationData operationData = new OperationData();
        public OperationController(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;

            
        }
     
        // GET: api/<OperationController>

        [HttpGet]
        [Route("{accountId:int}/operations")]
        public IActionResult GetAllOperations(int accountId)
        {

           List<Operation> OperationsList =  operationData.GetOperations(accountId);

            if(OperationsList.Count > 0 || OperationsList != null)
            {
                return Ok(JsonConvert.SerializeObject(OperationsList));
            }

            return BadRequest("Can not get all operations (400)");
        }

        [HttpGet]
        [Route("{accountId:int}/operations/{operationId:int}")]
        public IActionResult GetOperation(int accountId, int operationId)
        {

            Operation operation = operationData.GetOperation(accountId, operationId);

            if (operation != null)
            {
                return Ok(JsonConvert.SerializeObject(operation));
            }

            return BadRequest("Can not get an operation (400)");
        }

        // POST api/<OperationController>
        [HttpPost]
        [Route("{accountId: int}/operations/")]
        public void CreateOperation([FromBody] Operation operation)
        {

        }

        // PUT api/<OperationController>/5
      //  [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OperationController>/5
       // [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
