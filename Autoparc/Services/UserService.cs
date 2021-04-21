using Autoparc.Dao;
using Autoparc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoparc.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<int> add(User user)
        {
            return await userRepository.add(user);
        }

        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return await userRepository.GetAll();
        }

        public async Task<ActionResult<User>> GetUserById(string cin)
        {
            return await userRepository.GetUserById(cin);
        }

        public async Task<IActionResult> update(string cin, User user)
        {
            return await userRepository.update(cin, user);
        }

        public async Task<ActionResult<User>> delete(string id)
        {
            return await userRepository.delete(id);
        }
        // try
        public async Task<ActionResult<User>> login(string cin, string password)
        {
            ActionResult<User> actionResult = await userRepository.GetUserById(cin);
            if (actionResult != null && userRepository.login(cin, password))
            {
                return actionResult;

            }
                return null;
        }

        public async Task<IActionResult> changeStateByCin(string cin, string state)
        {
            if (cin!=null && state!=null)
            {
                return await userRepository.changeStateByCin(cin,state); 
            }
            else
            {
                return null; 
            }
        }
    }
}
