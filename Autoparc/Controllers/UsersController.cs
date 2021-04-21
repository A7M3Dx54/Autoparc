using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Autoparc.Models;
using Autoparc.Dao;
using Autoparc.Services;

namespace Autoparc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly VehiculeContext _context;
        private readonly IUserService userService;
        private readonly IUserRepository _userRepository;

        public UsersController(VehiculeContext context, IUserService userService, IUserRepository userRepository)
        {
            _context = context;
            this.userService = userService;
            this._userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Getusers()
        {
            return await userService.GetAll();
        }

        [HttpGet("{cin}")]
        public async Task<ActionResult<User>> GetUser(string cin)
        {
            return await userService.GetUserById(cin);
        }

        [HttpPut("{cin}")]
        public async Task<IActionResult> PutUser(string cin, User user)
        {
            return await userService.update(cin,user);
        }

        [HttpPost]
        public async Task<int> PostUser(User user)
        {
            return await userService.add(user);
        }

        [HttpDelete("{cin}")]
        public async Task<ActionResult<User>> DeleteUser(string cin)
        {
            return await userService.delete(cin);
        }

        /*private bool UserExists(string cin)
         {
             return _context.users.Any(e => e.cin == cin);
         }
        */
        [Route("[action]/{cin}/{password}")]
        [HttpGet]
        public async Task<ActionResult<User>> login(string cin, string password)
        {
            return await userService.login(cin, password);
        }

        [Route("[action]/{cin}/{state}")]
        [HttpGet]
        public async Task<IActionResult> changeStateByCin(string cin, string state)
        {
            return await userService.changeStateByCin(cin, state);
        }

    }
}
