using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoparc.Models;
using Microsoft.AspNetCore.Mvc;

namespace Autoparc.Dao
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<ActionResult<IEnumerable<User>>> GetAll();
        public Task<ActionResult<User>> GetUserById(string cin);
        Task<int> add(User user);
        public Task<IActionResult> update(string cin, User user);
        public Task<ActionResult<User>> delete(string cin);
        public bool login(string cin, string password);
        public Task<IActionResult> changeStateByCin(string cin, string state);
    }
}
