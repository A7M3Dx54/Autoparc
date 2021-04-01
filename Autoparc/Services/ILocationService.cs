using Autoparc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoparc.Services
{
    public interface ILocationService
    {
        public Task<ActionResult<IEnumerable<DriverLocationHistory>>> GetAll();
        public Task<ActionResult<DriverLocationHistory>> GetDriverLocationHistoryById(int id);
        Task<int> add(DriverLocationHistory driverLocationHistory);
        public Task<IActionResult> update(int id, DriverLocationHistory driverLocationHistory);
        public Task<ActionResult<DriverLocationHistory>> delete(int id);
    }
}
