using Autoparc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Autoparc.Dao
{
    public class VehiculeRepository : Repository<Vehicule>, IVehiculeRepository
    {
        public VehiculeRepository(VehiculeContext context) : base(context)
        {
        }


        public async Task<ActionResult<IEnumerable<Vehicule>>> GetAll()
        {
            try
            {
                return await _context.vehicules.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }

        }
        public async Task<int> add(Vehicule vehicule)
        {
            _context.vehicules.Add(vehicule);
            return await _context.SaveChangesAsync();
        }
        public async Task<ActionResult<Vehicule>> GetVehiculeById(string registrationNumber)
        {
            var vehicule = await _context.vehicules.FindAsync(registrationNumber);

            if (vehicule == null)
            {
                return null;
            }

            return vehicule;
        }
        public async Task<IActionResult> update(string registrationNumber, Vehicule vehicule)
        {
           

            if (registrationNumber != vehicule.registrationNumber)
            {
                throw new NotImplementedException();
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
                    throw new NotImplementedException();
                }
                else
                {
                    throw;
                }
            }
            return new EmptyResult(); 
        }
        public async Task<ActionResult<Vehicule>> delete(string registrationNumber)
        {
            var vehicule = await _context.vehicules.FindAsync(registrationNumber);
            if (vehicule == null)
            {
                return new EmptyResult();
            }

            _context.vehicules.Remove(vehicule);
            await _context.SaveChangesAsync();

            return vehicule;
        }
        private bool VehiculeExists(string registrationNumber)
        {
            return _context.vehicules.Any(e => e.registrationNumber == registrationNumber);
        }
        public async Task<IActionResult> changeStateByRegistrationNumber(string registrationNumber, string state)
        {
            var vehicule = await _context.vehicules.FindAsync(registrationNumber);
            vehicule.state = state;
            return await update(registrationNumber, vehicule);
        }
    }
}
