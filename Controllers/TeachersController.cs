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
    public class TeachersController : ControllerBase
    {
        private readonly SchoolContext _context;
        private readonly IMapper _mapper;

        public TeachersController(SchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherDTO>>> GetTeachers()
        {
            var context = await _context.Teachers
                .Include(p => p.TeacherSubjects)
                .Include(x => x.TeacherClasses)
                .ToListAsync();
            var answer = _mapper.Map<List<Teacher>, List<TeacherDTO>>(context);
            return answer;
        }

        [HttpGet("class/{id}")]
        public async Task<ActionResult<IEnumerable<TeacherFullName>>> GetTeachersForClass(int id)
        {
            var filter = id > 4 ? "Учитель старших классов" : "Учитель начальных классов";
            var context = await _context.Teachers
                .Where(z => z.Specialization == filter && (z.Class == null || z.Class.Id == id))
                .OrderBy(x => x.LastName)
                .ToListAsync();
            var teachers = _mapper.Map<List<Teacher>, List<TeacherFullName>>(context);
            return teachers;
        }

        [HttpGet("position/{position}")]
        public async Task<ActionResult<IEnumerable<TeacherFullName>>> GetTeachersForPosition(string position)
        {
            var filter = "Учитель старших классов";
            var context = await _context.Teachers
                .Include(p => p.Position)
                .Where(z => z.Specialization == filter && (z.Position == null || z.Position.Position.Equals(position)))
                .OrderBy(x => x.LastName)
                .ToListAsync();
            var teachers = _mapper.Map<List<Teacher>, List<TeacherFullName>>(context);
            return teachers;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherDTO>> GetTeacher(int id)
        {
            var teacher = await _context.Teachers
                .Include(p => p.TeacherSubjects)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            var teacherDTO = _mapper.Map<Teacher, TeacherDTO>(teacher);
            return teacherDTO;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher(int id, TeacherDTO teacherDTO)
        {
            if (id != teacherDTO.Id)
            {
                return BadRequest();
            }

            var teacher = _mapper.Map<TeacherDTO, Teacher>(teacherDTO);

            var existingTeacher = _context.Teachers
                .Include(p => p.TeacherSubjects)
                .FirstOrDefault(p => p.Id == id);
            if (existingTeacher != null)
            {
                _context.Entry(existingTeacher).CurrentValues.SetValues(teacher);
                existingTeacher.TeacherSubjects = teacher.TeacherSubjects;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(id))
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
        public async Task<ActionResult<TeacherDTO>> PostTeacher(TeacherDTO teacherDTO)
        {
            var teacher = _mapper.Map<TeacherDTO, Teacher>(teacherDTO);

            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            var createdTeacher = _mapper.Map<Teacher, TeacherDTO>(teacher);

            return CreatedAtAction("GetTeacher", new { id = createdTeacher.Id }, createdTeacher);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeacherExists(int id)
        {
            return _context.Teachers.Any(e => e.Id == id);
        }
    }
}
