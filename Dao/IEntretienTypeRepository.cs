using Autoparc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoparc.Dao
{
    public interface IEntretienTypeRepository : IRepository<EntretienType>
    {
        public Task<ActionResult<IEnumerable<EntretienType>>> GetAll();
        public Task<ActionResult<EntretienType>> GetEntretienTypeById(int id);
        Task<int> add(EntretienType entretienType);
        public Task<IActionResult> update(int id, EntretienType entretienType);
        public Task<ActionResult<EntretienType>> delete(int id);
    }
}
