using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rcs_p.Models;

namespace rcs_p.Models
{

    [ApiController]    
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly RequestsContext _context;

        public TasksController(RequestsContext context)
        {
            _context = context;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<rcs_p.Models.Task>>> GetTasks()
        {
            return await _context.Task.ToListAsync();
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<rcs_p.Models.Task>> GetTask(int id)
        {
            var task = await _context.Task.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        // PATCH: api/Tasks/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchTask(int id, rcs_p.Models.Task task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool TaskExists(int id)
        {
            return _context.Task.Any(e => e.Id == id);
        }
    }
}
/*This code uses the Entity Framework 7 to interact with 
the SQL Server database and provides basic CRUD functionality 
for tasks through API endpoints. The API endpoints are decorated
with attributes from the Microsoft.AspNetCore.Mvc namespace, 
which specify the HTTP methods and routes associated with each endpoint.

For example, the GET /api/Tasks endpoint retrieves a list of all tasks 
in the database, while the PATCH /api/Tasks/5 endpoint updates a task 
with the specified ID. The CrowdsourcingContext class is the database
 context that is used to interact with the database.*/