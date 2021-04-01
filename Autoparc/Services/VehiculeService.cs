using Autoparc.Dao;
using Autoparc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace Autoparc.Services
{
    public class VehiculeService: IVehiculeService
    {
        private readonly IVehiculeRepository vehiculeRepository ;
        
        public VehiculeService(IVehiculeRepository vehiculeRepository)
        {
            this.vehiculeRepository = vehiculeRepository;
        }
        
        public async Task<int> add(Vehicule vehicule)
        {
            Console.WriteLine(vehicule);
            return await vehiculeRepository.add(vehicule);
        }
        
        public async Task<ActionResult<IEnumerable<Vehicule>>> GetAll()
        {
            return await vehiculeRepository.GetAll();
        }

        public async Task<ActionResult<Vehicule>> GetVehiculeById(string registrationNumber)
        {
            return await vehiculeRepository.GetVehiculeById(registrationNumber);
        }

        public async Task<IActionResult> update(string registrationNumber, Vehicule vehicule)
        {
            return await vehiculeRepository.update(registrationNumber,vehicule);
        }

        public async Task<ActionResult<Vehicule>> delete(string registrationNumber)
        {
            return await vehiculeRepository.delete(registrationNumber);
        }
    }
}
