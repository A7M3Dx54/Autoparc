using Autoparc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoparc.Services
{
    public interface IEntretienService
    {
        public Task<ActionResult<IEnumerable<Entretien>>> GetAll();
        public Task<ActionResult<Entretien>> GetEntretienById(int id);
        Task<int> add(Entretien entretien);
        public Task<IActionResult> update(int id, Entretien entretien);
        public Task<ActionResult<Entretien>> delete(int id);
    }
}
