using Autoparc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Autoparc.Dao
{
    public class TacheRepository : Repository<Tache>, ITacheRepository
    {
        public TacheRepository(VehiculeContext context) : base(context)
        {
        }


        public async Task<ActionResult<IEnumerable<Tache>>> GetAll()
        {
            try
            {
                return await _context.taches.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }

        }
        public async Task<ActionResult<IEnumerable<Tache>>> GetTaskByUser(String cin)
        {
            try
            {
                return await _context.taches.Where(item => item.cin == cin).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }

        }
      


        public async Task<int> add(Tache tache)
        {
            _context.taches.Add(tache);
            return await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<Tache>> GetTacheById(int id)
        {
            var tache = await _context.taches.FindAsync(id);

            if (tache == null)
            {
                return null;
            }

            return tache;
        }

        public async Task<IActionResult> update(int id, Tache tache)
        {
            if (id != tache.id)
            {
                throw new NotImplementedException();
            }

            _context.Entry(tache).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TacheExists(id))
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

        public async Task<ActionResult<Tache>> delete(int id)
        {
            var tache = await _context.taches.FindAsync(id);
            if (tache == null)
            {
                return new EmptyResult();
            }

            _context.taches.Remove(tache);
            await _context.SaveChangesAsync();

            return tache;
        }

        private bool TacheExists(int id)
        {
            return _context.taches.Any(e => e.id == id);
        }
    }
}
