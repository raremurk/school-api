using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Models;
using AutoMapper;
using School.ViewModels;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicSubjectsController : ControllerBase
    {
        private readonly SchoolContext _context;
        private readonly IMapper _mapper;

        public AcademicSubjectsController(SchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcademicSubjectDTO>>> GetAcademicSubjects()
        {
            var context = await _context.AcademicSubjects.ToListAsync();
            var subjects = _mapper.Map<List<AcademicSubject>, List<AcademicSubjectDTO>>(context);
            return subjects;
        }

        [Route("class/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcademicSubjectDTO>>> GetClassAcademicSubjects(int id)
        {
            var context = await _context.AcademicSubjects.Where(p => p.MinClass <= id && p.MaxClass >= id).ToListAsync();
            var subjects = _mapper.Map<List<AcademicSubject>, List<AcademicSubjectDTO>>(context);
            return subjects;
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
