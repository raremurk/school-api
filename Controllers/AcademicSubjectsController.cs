using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_API.Context;
using School_API.Models;
using School_API.ViewModels;

namespace School_API.Controllers
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
        public async Task<ActionResult<IEnumerable<AcademicSubjectDTO>>> GetAcademicSubjectsForClass(int id)
        {
            var context = await _context.AcademicSubjects.Where(p => p.MinClass <= id && p.MaxClass >= id).ToListAsync();
            var subjects = _mapper.Map<List<AcademicSubject>, List<AcademicSubjectDTO>>(context);
            return subjects;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicSubjectDTO>> GetAcademicSubject(int id)
        {
            var academicSubject = await _context.AcademicSubjects.FindAsync(id);
            var subject = _mapper.Map<AcademicSubject, AcademicSubjectDTO>(academicSubject);

            if (academicSubject == null)
            {
                return NotFound();
            }

            return subject;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcademicSubject(int id, AcademicSubjectDTO academicSubjectDTO)
        {
            var academicSubject = _mapper.Map<AcademicSubjectDTO, AcademicSubject>(academicSubjectDTO);

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
        public async Task<ActionResult<AcademicSubjectDTO>> PostAcademicSubject(AcademicSubjectDTO academicSubjectDTO)
        {
            var academicSubject = _mapper.Map<AcademicSubjectDTO, AcademicSubject>(academicSubjectDTO);
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
