using ExamAPI.ModelDto;
using ExamAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamAPI.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly Context _context;
        public ProjectsController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        async public Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                var projects = _context.Projects.ToListAsync();
                return Ok(projects);
            }
            var project = await _context.Projects.FindAsync(id);
            if (project == null) return NotFound() ;
            return Ok(project);
        }

        [HttpGet,Route("get-detail")]
        async public Task<IActionResult> GetDetail(int? id)
        {
            if (id == null)
            {
                var projects = _context.Projects.Include(e=>e.ProjectEmployees).ThenInclude(e=>e.Employees).ToListAsync();
                return Ok(projects);
            }
            var project = await _context.Projects.Include(e => e.ProjectEmployees).ThenInclude(e => e.Employees).Where(e=>e.Id.Equals(id)).ToListAsync();
            if (project == null) return NotFound();
            return Ok(project);
        }

        [HttpGet,Route("search-by-name")]
        async public Task<IActionResult> SearchByName(string? name)
        {
            var p = await _context.Projects.Where(e=>e.Name.Equals(name)).ToListAsync();
            return Ok(p);
        }
        [HttpGet,Route("search-by-startdate")]
        async public Task<IActionResult> SearchByStartDate(DateTime startdate)
        {
            if (startdate != null)
            {
                var ps = await _context.Projects.Where(e => e.StartDate.CompareTo(startdate)==0).ToListAsync();
                return Ok(ps);
            }

            var p = await _context.Projects.Where(e => e.StartDate.CompareTo(DateTime.Now) > 0).ToListAsync();
            return Ok(p);
        }

        [HttpGet, Route("search-by-enddate")]
        async public Task<IActionResult> SearchByEndDate( DateTime enddate)
        {
            if (enddate != null)
            {
                var ps = await _context.Projects.Where(e => e.EndDate.CompareTo(enddate) == 0).ToListAsync();
                return Ok(ps);
            }

            var p = await _context.Projects.Where(e => e.EndDate.CompareTo(DateTime.Now) < 0).ToListAsync();
            return Ok(p);
        }

        [HttpPost]
        async public Task<IActionResult> Create(ProjectDto data)
        {
            if (ModelState.IsValid)
            {
                var project = new Project {Name=data.Name,EndDate=data.EndDate,StartDate=data.StartDate };
                await _context.Projects.AddAsync(project);
                await _context.SaveChangesAsync();
                return Ok(project);
            }
            return BadRequest();
        }

        [HttpPut]
        async public Task<IActionResult> Update (Project data)
        {
            if (ModelState.IsValid) {
                 _context.Projects.Update(data);
                await _context.SaveChangesAsync();
                return Ok(new {status=1});
            }
            return BadRequest();
        }
        [HttpDelete]
        async public Task<IActionResult> Delete (int id)
        {
            if (id != null)
            {
                var p = await _context.Projects.FindAsync(id);
                if (p == null) return NotFound();
                _context.Projects.Remove(p);
                await _context.SaveChangesAsync();
            }
            return BadRequest();
        }

    }
}
