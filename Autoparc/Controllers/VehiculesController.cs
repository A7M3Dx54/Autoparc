using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Autoparc.Models;

namespace Autoparc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculesController : ControllerBase
    {
        private readonly VehiculeContext _context;

        public VehiculesController(VehiculeContext context)
        {
            _context = context;
        }

        // GET: api/Vehicules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicule>>> Getvehicules()
        {
            return await _context.vehicules.ToListAsync();
        }

        // GET: api/Vehicules/5
        [HttpGet("{registrationNumber}")]
        public async Task<ActionResult<Vehicule>> GetVehicule(string registrationNumber)
        {
            var vehicule = await _context.vehicules.FindAsync(registrationNumber);

            if (vehicule == null)
            {
                return NotFound();
            }

            return vehicule;
        }

        // PUT: api/Vehicules/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{registrationNumber}")]
        public async Task<IActionResult> PutVehicule(string registrationNumber, Vehicule vehicule)
        {
            if (registrationNumber != vehicule.registrationNumber)
            {
                return BadRequest();
            }

            _context.Entry(vehicule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculeExists(registrationNumber))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vehicules
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Vehicule>> PostVehicule(Vehicule vehicule)
        {
            _context.vehicules.Add(vehicule);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Getvehicules), new { id = vehicule.registrationNumber }, vehicule);

            /*this._context.vehicules.Add(vehicule);
            this._context.SaveChanges();
            return CreatedAtAction(nameof(Getvehicules), new { id = vehicule.registrationNumber }, vehicule);*/
        }

        // DELETE: api/Vehicules/5
        [HttpDelete("{registrationNumber}")]
        public async Task<ActionResult<Vehicule>> DeleteVehicule(string registrationNumber)
        {
            var vehicule = await _context.vehicules.FindAsync(registrationNumber);
            if (vehicule == null)
            {
                return NotFound();
            }

            _context.vehicules.Remove(vehicule);
            await _context.SaveChangesAsync();

            return vehicule;
        }

        private bool VehiculeExists(string registrationNumber)
        {
            return _context.vehicules.Any(e => e.registrationNumber == registrationNumber);
        }
    }
}
