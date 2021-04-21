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
    public class TacheController : ControllerBase
    {
        private readonly VehiculeContext _context;
        private readonly ITacheService tacheService;
        private readonly ITacheRepository _tacheRepository;

        public TacheController(VehiculeContext context, ITacheService tacheService, ITacheRepository tacheRepository)
        {
            _context = context;
            this.tacheService = tacheService;
            this._tacheRepository = tacheRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tache>>> GetTasks()
        {
            return await tacheService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tache>> GetTask(int id)
        {
            return await tacheService.GetTacheById(id);
        }

        [Route("[action]/{matricule}")]
        [HttpGet]
        public  IQueryable<Tache> GetTaskByVehicule(string matricule)
        {
            var task =  _context.taches.Where(i=>i.registrationNumber == matricule);

            /*if (task == null)
            {
                return NotFound();
            }*/

            return task;
        }

        [Route("[action]/{cin}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tache>>> GetTaskByUser(String cin)
        {
            return await tacheService.GetTaskByUser(cin);

        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, Tache tache)
        {
            return await tacheService.update(id, tache);
        }

        [HttpPost]
        public async Task<ActionResult<Tache>> PostTache(Tache tache)
        {
            await tacheService.add(tache);
            return CreatedAtAction(nameof(GetTasks), new { id = tache.id }, tache);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Tache>> DeleteTache(int id)
        {
            return await tacheService.delete(id);
        }

        private bool TacheExists(int id)
        {
            return _context.taches.Any(e => e.id == id);
        }

        [Route("[action]/{id}/{state}")]
        [HttpGet]
        public async Task<IActionResult> changeStateById(int id, string state)
        {
            return await tacheService.changeStateById(id, state);
        }
    }
}
