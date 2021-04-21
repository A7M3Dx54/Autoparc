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
    public class VehiculesController : ControllerBase
    {
        private readonly VehiculeContext _context;
        private readonly IVehiculeService vehiculeService ;
        private readonly IVehiculeRepository _vehiculeRepository;

        public VehiculesController(VehiculeContext context, IVehiculeService vehiculeService , IVehiculeRepository vehiculeRepository)
        {
            _context = context;
            this.vehiculeService = vehiculeService;
            this._vehiculeRepository = vehiculeRepository; 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicule>>> Getvehicules()
        {
            return await vehiculeService.GetAll();
        }

        [HttpGet("{registrationNumber}")]
        public async Task<ActionResult<Vehicule>> GetVehicule(string registrationNumber)
        {
            return await vehiculeService.GetVehiculeById(registrationNumber);
        }

        [HttpPut("{registrationNumber}")]
        public async Task<IActionResult> PutVehicule(string registrationNumber, Vehicule vehicule)
        {
            return await vehiculeService.update(registrationNumber,vehicule);
        }

        [HttpPost]
        public async Task<ActionResult<Vehicule>> PostVehicule(Vehicule vehicule)
        {
            await vehiculeService.add(vehicule);
            return CreatedAtAction(nameof(Getvehicules), new { id = vehicule.registrationNumber }, vehicule);
        }

        [HttpDelete("{registrationNumber}")]
        public async Task<ActionResult<Vehicule>> DeleteVehicule(string registrationNumber)
        {
            return await vehiculeService.delete(registrationNumber);
        }

        private bool VehiculeExists(string registrationNumber)
        {
            return _context.vehicules.Any(e => e.registrationNumber == registrationNumber);
        }

        [Route("[action]/{registrationNumber}/{state}")]
        [HttpGet]
        public async Task<IActionResult> changeStateByRegistrationNumber(string registrationNumber, string state)
        {
            return await vehiculeService.changeStateByRegistrationNumber(registrationNumber, state);
        }

    }
}
