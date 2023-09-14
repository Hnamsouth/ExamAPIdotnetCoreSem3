using ExamAPI.ModelDto;
using ExamAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamAPI.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly Context _context;
        public EmployeeController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        async public Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                var es = _context.Employees.ToListAsync();
                return Ok(es);
            }
            var e = await _context.Employees.FindAsync(id);
            if (e == null) return NotFound();
            return Ok(e);
        }

        [HttpGet, Route("get-detail")]
        async public Task<IActionResult> GetDetail(int? id)
        {
            if (id == null)
            {
                var es = _context.Employees.Include(e => e.ProjectEmployees).ThenInclude(e => e.Projects).ToListAsync();
                return Ok(es);
            }
            var e = await _context.Employees.Include(e => e.ProjectEmployees).ThenInclude(e => e.Projects).Where(e => e.Id.Equals(id)).ToListAsync();
            if (e == null) return NotFound();
            return Ok(e);
        }

        [HttpPost]
        async public Task<IActionResult> Create(EmployeeDto data)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employees {Name=data.Name,Department=data.Department,DOB=data.DOB };
                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();
                return Ok(employee);
            }
            return BadRequest();
        }

        [HttpPut]
        async public Task<IActionResult> Update(Employees data)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Update(data);
                await _context.SaveChangesAsync();
                return Ok(new { status = 1 });
            }
            return BadRequest();
        }
        [HttpDelete]
        async public Task<IActionResult> Delete(int id)
        {
            if (id != null)
            {
                var e = await _context.Employees.FindAsync(id);
                if (e == null) return NotFound();
                _context.Employees.Remove(e);
                await _context.SaveChangesAsync();
            }
            return BadRequest();
        }
    }
}
