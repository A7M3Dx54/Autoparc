using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Autoparc.Models;

namespace Autoparc.Dao
{
    public class LocationRepository : Repository<DriverLocationHistory>, ILocationRepository
    {
        public LocationRepository(VehiculeContext context) : base(context)
        {
        }


        public async Task<ActionResult<IEnumerable<DriverLocationHistory>>> GetAll()
        {
            try
            {
                return await _context.driverLocationsHistory.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }

        }
        public async Task<int> add(DriverLocationHistory driverLocationHistory)
        {
            _context.driverLocationsHistory.Add(driverLocationHistory);
            return await _context.SaveChangesAsync();
        }
        public async Task<ActionResult<DriverLocationHistory>> GetDriverLocationHistoryById(int id)
        {
            var driverLocationHistory = await _context.driverLocationsHistory.FindAsync(id);

            if (driverLocationHistory == null)
            {
                return null;
            }

            return driverLocationHistory;
        }
        public async Task<IActionResult> update(int id, DriverLocationHistory driverLocationHistory)
        {
            if (id != driverLocationHistory.idLocation)
            {
                throw new NotImplementedException();
            }

            _context.Entry(driverLocationHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverLocationHistoryExists(id))
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
        public async Task<ActionResult<DriverLocationHistory>> delete(int id)
        {
            var driverLocationHistory = await _context.driverLocationsHistory.FindAsync(id);
            if (driverLocationHistory == null)
            {
                return new EmptyResult();
            }

            _context.driverLocationsHistory.Remove(driverLocationHistory);
            await _context.SaveChangesAsync();

            return driverLocationHistory;
        }
        private bool DriverLocationHistoryExists(int id)
        {
            return _context.driverLocationsHistory.Any(e => e.idLocation == id);
        }
        public List<IQueryable<DriverLocationHistory>> GetAllRecentLocations()
        {
            var users = _context.users.Where(i => i.state=="Active" && i.role=="driver");
            List<IQueryable<DriverLocationHistory>> locations = new List<IQueryable<DriverLocationHistory>>() ; 
            IQueryable<DriverLocationHistory> allUserLocations =null; 
            foreach (User user in users)
            {
                allUserLocations = _context.driverLocationsHistory.Where(i => i.cin==user.cin);
                int max = allUserLocations.Max(i => i.idLocation);
                //var lastLocation = GetDriverLocationHistoryById(max);
                var lastLocation = _context.driverLocationsHistory.Where(i => i.idLocation == max);

                locations.Add(lastLocation);
            }
            return locations; 
        }
    }
}
