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
    public class AdministrationController : ControllerBase
    {
        private readonly SchoolContext _context;
        private readonly IMapper _mapper;

        public AdministrationController(SchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("schoolStat")]
        public ActionResult<SchoolStat> GetSchoolStat()
        {
            var studentsCount = _context.Students.Count(x => x.ClassId != null);
            var teachersCount = _context.Teachers.Count();
            var stat = new SchoolStat()
            {
                StudentsCount = studentsCount,
                TeachersCount = teachersCount
            };

            return stat;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdministrationDTO>>> GetAdministration()
        {
            var administration = await _context.Administration.Include(p => p.Teacher).ToListAsync();
            var administrationDTO = _mapper.Map<List<Administration>, List<AdministrationDTO>>(administration);
            return administrationDTO;
        }

        [HttpPut("{position}")]
        public async Task<IActionResult> SetAdministrationPerson(string position, AdministrationDTO administrationDTO)
        {
            if (!position.Equals(administrationDTO.Position))
            {
                return BadRequest();
            }

            var administration = _mapper.Map<AdministrationDTO, Administration>(administrationDTO);

            if (administration.TeacherId != null && !TeacherExists((int)administration.TeacherId))
            {
                return NotFound();
            }

            _context.Entry(administration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Administration.Any(e => e.Position == position))
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

        [HttpPost("promoteStudents")]
        public async Task<IActionResult> PromoteStudents()
        {
            await _context.Students.ForEachAsync(x => x.PromoteStudent());

            var classes = await _context.Classes.ToListAsync();

            for (int i = 3; i > 0; i--)
            {
                classes[i].ClassTeacherId = classes[i - 1].ClassTeacherId;
            }
            classes[0].ClassTeacherId = null;

            for (int i = 10; i > 4; i--)
            {
                classes[i].ClassTeacherId = classes[i - 1].ClassTeacherId;
            }
            classes[4].ClassTeacherId = null;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeacherExists(int id)
        {
            return _context.Teachers.Any(e => e.Id == id);
        }
    }
}
