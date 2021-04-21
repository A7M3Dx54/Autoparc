using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Autoparc.Models;
using Autoparc.Services;
using Autoparc.Dao;

namespace Autoparc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverLocationHistoryController : ControllerBase
    {
        private readonly VehiculeContext _context;
        private readonly ILocationService locationService;
        private readonly ILocationRepository _locationRepository;

        public DriverLocationHistoryController(VehiculeContext context, ILocationService locationService, ILocationRepository locationRepository)
        {
            _context = context;
            this.locationService = locationService;
            this._locationRepository = locationRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriverLocationHistory>>> GetLocations()
        {
            return await locationService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DriverLocationHistory>> GetLocation(int id)
        {
            return await locationService.GetDriverLocationHistoryById(id);
        }

        [Route("[action]")]
        [HttpGet]
        public List<IQueryable<DriverLocationHistory>> GetAllRecentLocations()
        {
            return locationService.GetAllRecentLocations();
        }
        /*[Route("[action]/{matricule}")]
        [HttpGet]
        public IQueryable<Tache> GetTaskByVehicule(string matricule)
        {
            var task = _context.taches.Where(i => i.registrationNumber == matricule);

           

            return task;
        }*/

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(int id, DriverLocationHistory driverLocationHistory)
        {
            return await locationService.update(id, driverLocationHistory);
        }

        [HttpPost]
        public async Task<ActionResult<DriverLocationHistory>> PostTache(DriverLocationHistory driverLocationHistory)
        {
            await locationService.add(driverLocationHistory);
            return CreatedAtAction(nameof(GetLocations), new { id = driverLocationHistory.idLocation }, driverLocationHistory);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DriverLocationHistory>> DeleteLocation(int id)
        {
            return await locationService.delete(id);
        }

        private bool driverLocationHistoryExists(int id)
        {
            return _context.driverLocationsHistory.Any(e => e.idLocation == id);
        }
    }
}
