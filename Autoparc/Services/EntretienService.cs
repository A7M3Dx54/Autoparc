using Autoparc.Dao;
using Autoparc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoparc.Services
{
    public class EntretienService : IEntretienService
    {
        private readonly IEntretienRepository entretienRepository;

        public EntretienService(IEntretienRepository entretienRepository)
        {
            this.entretienRepository = entretienRepository;
        }

        public async Task<int> add(Entretien entretien)
        {
            return await entretienRepository.add(entretien);
        }

        public async Task<ActionResult<IEnumerable<Entretien>>> GetAll()
        {
            return await entretienRepository.GetAll();
        }

        public async Task<ActionResult<Entretien>> GetEntretienById(int id)
        {
            return await entretienRepository.GetEntretienById(id);
        }

        public async Task<IActionResult> update(int id, Entretien entretien)
        {
            return await entretienRepository.update(id, entretien);
        }

        public async Task<ActionResult<Entretien>> delete(int id)
        {
            return await entretienRepository.delete(id);
        }
    }
}
