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
    public class EntretiensController : ControllerBase
    {
        private readonly VehiculeContext _context;
        private readonly IEntretienService entretienService;
        private readonly IEntretienRepository _entretienRepository;

        public EntretiensController(VehiculeContext context, IEntretienService entretienService, IEntretienRepository entretienRepository)
        {
            _context = context;
            this.entretienService = entretienService;
            this._entretienRepository = entretienRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entretien>>> GetEntretiens()
        {
            return await entretienService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Entretien>> GetEntretien(int id)
        {
            return await entretienService.GetEntretienById(id);
        }

        /*[Route("[action]/{matricule}")]
        [HttpGet]
        public IQueryable<Entretien> GetTaskByVehicule(string matricule)
        {
            var task = _context.taches.Where(i => i.registrationNumber == matricule);

            

            return task;
        }*/

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntretien(int id, Entretien entretien)
        {
            return await entretienService.update(id, entretien);
        }

        [HttpPost]
        public async Task<ActionResult<Entretien>> PostEntretien(Entretien entretien)
        {
            await entretienService.add(entretien);
            return CreatedAtAction(nameof(GetEntretiens), new { id = entretien.id }, entretien);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Entretien>> DeleteEntretien(int id)
        {
            return await entretienService.delete(id);
        }

        private bool EntretienExists(int id)
        {
            return _context.entretiens.Any(e => e.id == id);
        }
    }
}
