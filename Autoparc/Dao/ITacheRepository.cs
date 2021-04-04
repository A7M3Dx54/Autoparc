using Autoparc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoparc.Dao
{
    public interface ITacheRepository : IRepository<Tache>
    {
        public Task<ActionResult<IEnumerable<Tache>>> GetAll();
        public Task<ActionResult<Tache>> GetTacheById(int id);
        public Task<ActionResult<IEnumerable<Tache>>> GetTaskByUser(String cin);
        Task<int> add(Tache tache);
        public Task<IActionResult> update(int id, Tache tache);
        public Task<ActionResult<Tache>> delete(int id);
    }
}
