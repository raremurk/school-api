using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Models;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicSubjectsController : ControllerBase
    {
        private readonly SchoolContext _context;

        public AcademicSubjectsController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcademicSubject>>> GetAcademicSubjects()
        {
            return await _context.AcademicSubjects.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicSubject>> GetAcademicSubject(int id)
        {
            var academicSubject = await _context.AcademicSubjects.FindAsync(id);

            if (academicSubject == null)
            {
                return NotFound();
            }

            return academicSubject;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcademicSubject(int id, AcademicSubject academicSubject)
        {
            if (id != academicSubject.Id)
            {
                return BadRequest();
            }

            _context.Entry(academicSubject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcademicSubjectExists(id))
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

        [HttpPost]
        public async Task<ActionResult<AcademicSubject>> PostAcademicSubject(AcademicSubject academicSubject)
        {
            _context.AcademicSubjects.Add(academicSubject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcademicSubject", new { id = academicSubject.Id }, academicSubject);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcademicSubject(int id)
        {
            var academicSubject = await _context.AcademicSubjects.FindAsync(id);
            if (academicSubject == null)
            {
                return NotFound();
            }

            _context.AcademicSubjects.Remove(academicSubject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AcademicSubjectExists(int id)
        {
            return _context.AcademicSubjects.Any(e => e.Id == id);
        }
    }
}
