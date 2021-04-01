using Autoparc.Dao;
using Autoparc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoparc.Services
{
    public class TacheService : ITacheService
    {
        private readonly ITacheRepository tacheRepository;

        public TacheService(ITacheRepository tacheRepository)
        {
            this.tacheRepository = tacheRepository;
        }

        public async Task<int> add(Tache tache)
        {
            return await tacheRepository.add(tache);
        }

        public async Task<ActionResult<IEnumerable<Tache>>> GetAll()
        {
            return await tacheRepository.GetAll();
        }

        public async Task<ActionResult<Tache>> GetTacheById(int id)
        {
            return await tacheRepository.GetTacheById(id);
        }

        public async Task<IActionResult> update(int id, Tache tache)
        {
            return await tacheRepository.update(id, tache);
        }

        public async Task<ActionResult<Tache>> delete(int id)
        {
            return await tacheRepository.delete(id);
        }
    }
}
