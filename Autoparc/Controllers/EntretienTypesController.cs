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
    public class EntretienTypesController : ControllerBase
    {
        private readonly VehiculeContext _context;
        private readonly IEntretienTypeService entretienTypeService;
        private readonly IEntretienTypeRepository _entretienTypeRepository;

        public EntretienTypesController(VehiculeContext context, IEntretienTypeService entretienTypeService, IEntretienTypeRepository entretienTypeRepository)
        {
            _context = context;
            this.entretienTypeService = entretienTypeService;
            this._entretienTypeRepository = entretienTypeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntretienType>>> GetEntretienTypes()
        {
            return await entretienTypeService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EntretienType>> GetEntretienType(int id)
        {
            return await entretienTypeService.GetEntretienTypeById(id);
        }

        /*[Route("[action]/{matricule}")]
        [HttpGet]
        public IQueryable<Entretien> GetTaskByVehicule(string matricule)
        {
            var task = _context.taches.Where(i => i.registrationNumber == matricule);

            

            return task;
        }*/

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntretienType(int id, EntretienType entretienType)
        {
            return await entretienTypeService.update(id, entretienType);
        }

        [HttpPost]
        public async Task<ActionResult<EntretienType>> PostEntretienType(EntretienType entretienType)
        {
            await entretienTypeService.add(entretienType);
            return CreatedAtAction(nameof(GetEntretienTypes), new { id = entretienType.idType }, entretienType);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EntretienType>> DeleteEntretienType(int id)
        {
            return await entretienTypeService.delete(id);
        }

        private bool EntretienTypeExists(int id)
        {
            return _context.entretienTypes.Any(e => e.idType == id);
        }
    }
}
