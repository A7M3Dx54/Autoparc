using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Autoparc.Models;

namespace Autoparc.Dao
{
    public class EntretienRepository : Repository<Entretien>, IEntretienRepository
    {
        public EntretienRepository(VehiculeContext context) : base(context)
        {
        }


        public async Task<ActionResult<IEnumerable<Entretien>>> GetAll()
        {
            try
            {
                return await _context.entretiens.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }

        }
        public async Task<int> add(Entretien entretien)
        {
            _context.entretiens.Add(entretien);
            return await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<Entretien>> GetEntretienById(int id)
        {
            var entretien = await _context.entretiens.FindAsync(id);

            if (entretien == null)
            {
                return null;
            }

            return entretien;
        }

        public async Task<IActionResult> update(int id, Entretien entretien)
        {
            if (id != entretien.id)
            {
                throw new NotImplementedException();
            }

            _context.Entry(entretien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntretienExists(id))
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

        public async Task<ActionResult<Entretien>> delete(int id)
        {
            var entretien = await _context.entretiens.FindAsync(id);
            if (entretien == null)
            {
                return new EmptyResult();
            }

            _context.entretiens.Remove(entretien);
            await _context.SaveChangesAsync();

            return entretien;
        }

        private bool EntretienExists(int id)
        {
            return _context.entretiens.Any(e => e.id == id);
        }
    }
}
