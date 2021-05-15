using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoparc.Models;
using Microsoft.AspNetCore.Mvc;

namespace Autoparc.Dao
{
    public interface IVehiculeRepository:IRepository<Vehicule>
    {
        public Task<ActionResult<IEnumerable<Vehicule>>> GetAll();
        public Task<ActionResult<Vehicule>> GetVehiculeById(string registrationNumber);
        Task<int> add(Vehicule vehicule);
        public Task<IActionResult> update(string registrationNumber, Vehicule vehicule);
        public Task<ActionResult<Vehicule>> delete(string registrationNumber);
        public Task<IActionResult> changeStateByRegistrationNumber(string registrationNumber, string state);
        public object TasksNumberByVehicule();
        public object costByVehicule();
    }
}
