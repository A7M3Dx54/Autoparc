using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoparc.Dao;
using Autoparc.Models;
using Microsoft.AspNetCore.Mvc;

namespace Autoparc.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        public async Task<int> add(DriverLocationHistory driverLocationHistory)
        {
            return await locationRepository.add(driverLocationHistory);
        }

        public async Task<ActionResult<IEnumerable<DriverLocationHistory>>> GetAll()
        {
            return await locationRepository.GetAll();
        }

        public async Task<ActionResult<DriverLocationHistory>> GetDriverLocationHistoryById(int id)
        {
            return await locationRepository.GetDriverLocationHistoryById(id);
        }

        public async Task<IActionResult> update(int id, DriverLocationHistory driverLocationHistory)
        {
            return await locationRepository.update(id, driverLocationHistory);
        }

        public async Task<ActionResult<DriverLocationHistory>> delete(int id)
        {
            return await locationRepository.delete(id);
        }
    }
}
