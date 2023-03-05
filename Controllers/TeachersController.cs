using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_API.ViewModels;
using School_API.Context;
using School_API.Models;

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
                .OrderBy(l => l.LastName)
                .ToListAsync();
            var answer = _mapper.Map<List<Teacher>, List<TeacherDTO>>(context);
            return answer;
        }

        [HttpGet("class/{id}")]
        public async Task<ActionResult<IEnumerable<TeacherFullNameDTO>>> GetTeachersForClass(int id)
        {
            var context = await _context.Teachers.Where(z => z.Class == null || z.Class.Id == id).OrderBy(x => x.LastName).ToListAsync();
            if (id < 5)
            {
                context = context.Where(a => a.Position == "Учитель мл. классов").ToList();
            }

            var teachers = _mapper.Map<List<Teacher>, List<TeacherFullNameDTO>>(context);
            return teachers;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherDTO>> GetTeacher(int id)
        {
            var context = await _context.Teachers.Include(p => p.TeacherSubjects).FirstOrDefaultAsync(p => p.Id == id);
            var teacher = _mapper.Map<Teacher, TeacherDTO>(context);

            if (teacher == null)
            {
                return NotFound();
            }

            return teacher;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher(int id, TeacherDTO teacher)
        {
            if (id != teacher.Id)
            {
                return BadRequest();
            }
            var teacher_db = _mapper.Map<TeacherDTO, Teacher>(teacher);

            _context.Entry(teacher_db).State = EntityState.Modified;

            var db_teacher = await _context.Teachers
                .Include(p => p.TeacherSubjects)
                .Include(p => p.TeacherClasses).FirstOrDefaultAsync(d => d.Id == id);

            db_teacher.TeacherSubjects.RemoveRange(0, db_teacher.TeacherSubjects.Count);
            db_teacher.TeacherClasses.RemoveRange(0, db_teacher.TeacherClasses.Count);
            var subjects = _mapper.Map<List<OnlyIdDTO>, List<TeacherSubject>>(teacher.TeacherSubjects);
            var classes = _mapper.Map<List<OnlyIdDTO>, List<TeacherClass>>(teacher.TeacherClasses);
            teacher_db.TeacherSubjects.AddRange(subjects);
            teacher_db.TeacherClasses.AddRange(classes);

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
        public async Task<ActionResult<TeacherDTO>> PostTeacher(TeacherDTO teacher)
        {
            var teacher_db = _mapper.Map<TeacherDTO, Teacher>(teacher);

            _context.Teachers.Add(teacher_db);
            await _context.SaveChangesAsync();

            var teacher_answer = _mapper.Map<Teacher, TeacherDTO>(teacher_db);

            return CreatedAtAction("GetTeacher", new { id = teacher_answer.Id }, teacher_answer);
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
