using Autoparc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoparc.Dao
{
    public class EntretienTypeRepository : Repository<EntretienType>, IEntretienTypeRepository
    {
        public EntretienTypeRepository(VehiculeContext context) : base(context)
        {
        }


        public async Task<ActionResult<IEnumerable<EntretienType>>> GetAll()
        {
            try
            {
                return await _context.entretienTypes.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }

        }
        public async Task<int> add(EntretienType entretienType)
        {
            _context.entretienTypes.Add(entretienType);
            return await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<EntretienType>> GetEntretienTypeById(int id)
        {
            var entretienType = await _context.entretienTypes.FindAsync(id);

            if (entretienType == null)
            {
                return null;
            }

            return entretienType;
        }

        public async Task<IActionResult> update(int id, EntretienType entretienType)
        {
            if (id != entretienType.idType)
            {
                throw new NotImplementedException();
            }

            _context.Entry(entretienType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntretienTypeExists(id))
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

        public async Task<ActionResult<EntretienType>> delete(int id)
        {
            var entretienType = await _context.entretienTypes.FindAsync(id);
            if (entretienType == null)
            {
                return new EmptyResult();
            }

            _context.entretienTypes.Remove(entretienType);
            await _context.SaveChangesAsync();

            return entretienType;
        }

        private bool EntretienTypeExists(int id)
        {
            return _context.entretienTypes.Any(e => e.idType == id);
        }
    }
}
