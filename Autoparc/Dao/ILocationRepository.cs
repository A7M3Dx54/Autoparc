using Autoparc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoparc.Dao
{
    public interface ILocationRepository : IRepository<DriverLocationHistory>
    {
        public Task<ActionResult<IEnumerable<DriverLocationHistory>>> GetAll();
        public Task<ActionResult<DriverLocationHistory>> GetDriverLocationHistoryById(int id);
        Task<int> add(DriverLocationHistory driverLocationHistory);
        public Task<IActionResult> update(int id, DriverLocationHistory driverLocationHistory);
        public Task<ActionResult<DriverLocationHistory>> delete(int id);
        public List<IQueryable<DriverLocationHistory>> GetAllRecentLocations(); 
    }
}
