using BalanceAPI.Context;
using BalanceAPI.Data;
using BalanceAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalanceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        private readonly ApplicationDbContext _context;

        private readonly UsersData usersData = new UsersData();

        private readonly OperationData operationData = new OperationData();

        private readonly AccountsData accountsData = new AccountsData();
        public UserController(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpGet]
        [Route("{email}/{password}")]
        public IActionResult GetUser(string email, string password)
        {
            
            User user = usersData.GetUser(email, password);
            if (user != null)
            {             
                return Ok(JsonConvert.SerializeObject(new Response("Dane użytkownika", 200, user)));
            }
            else
            {
                string message = "Nie udało się pobrać użytkownika";
                return BadRequest(JsonConvert.SerializeObject(new Response(message, 400)));
            }
        }

        
        [HttpPost]
        public IActionResult CreateUser([FromBody] User data)
        {

            if (usersData.RegisterNewUser(data.Email, data.Password))
            {

                return Ok(JsonConvert.SerializeObject(new Response("Pomyślne", 200, data)));             
            }
            else
            {
                string message = "Nie udało się stworzyć użytkownika";
                return BadRequest(JsonConvert.SerializeObject(new Response(message, 400)));
            }

        }

    }
}
