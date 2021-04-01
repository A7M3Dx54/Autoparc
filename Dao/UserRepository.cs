using Autoparc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoparc.Dao
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(VehiculeContext context) : base(context)
        {
        }


        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            try
            {
                return await _context.users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }

        }
        public async Task<int> add(User user)
        {
            _context.users.Add(user);
            return await _context.SaveChangesAsync();
        }
        public async Task<ActionResult<User>> GetUserById(string cin)
        {
            var user = await _context.users.FindAsync(cin);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        public async Task<IActionResult> update(string cin, User user)
        {
            if (cin != user.cin)
            {
                throw new NotImplementedException();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(cin))
                {
                    throw new NotImplementedException();
                }
                else
                {
                    throw;
                }
            }

            return new EmptyResult(); ;
        }

        public async Task<ActionResult<User>> delete(string cin)
        {
            var user = await _context.users.FindAsync(cin);
            if (user == null)
            {
                return new EmptyResult();
            }

            _context.users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(string cin)
        {
            return _context.users.Any(e => e.cin == cin);
        }
    }
}
