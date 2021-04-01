using Autoparc.Dao;
using Autoparc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoparc.Services
{
    public class EntretienTypeService : IEntretienTypeService
    {
        private readonly IEntretienTypeRepository entretienTypeRepository;

        public EntretienTypeService(IEntretienTypeRepository entretienTypeRepository)
        {
            this.entretienTypeRepository = entretienTypeRepository;
        }

        public async Task<int> add(EntretienType entretienType)
        {
            return await entretienTypeRepository.add(entretienType);
        }

        public async Task<ActionResult<IEnumerable<EntretienType>>> GetAll()
        {
            return await entretienTypeRepository.GetAll();
        }

        public async Task<ActionResult<EntretienType>> GetEntretienTypeById(int id)
        {
            return await entretienTypeRepository.GetEntretienTypeById(id);
        }

        public async Task<IActionResult> update(int id, EntretienType entretienType)
        {
            return await entretienTypeRepository.update(id, entretienType);
        }

        public async Task<ActionResult<EntretienType>> delete(int id)
        {
            return await entretienTypeRepository.delete(id);
        }
    }
}
