using Autoparc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoparc.Services
{
    public interface IVehiculeService
    {
        public Task<ActionResult<IEnumerable<Vehicule>>> GetAll();
        public Task<ActionResult<Vehicule>> GetVehiculeById(string registrationNumber);
        Task<int> add(Vehicule vehicule);
        public Task<IActionResult> update(string registrationNumber, Vehicule vehicule);
        public Task<ActionResult<Vehicule>> delete(string registrationNumber);
        public Task<IActionResult> changeStateByRegistrationNumber(string registrationNumber, string state);
    }
}
