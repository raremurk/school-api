using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Models;
using School.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly SchoolContext _context;
        private readonly IMapper _mapper;

        public StudentsController(SchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudents()
        {
            var context = await _context.Students.Include(x => x.Class).Where(k => k.ClassId != null).ToListAsync();
            var students = _mapper.Map<List<Student>, List<StudentDTO>>(context);
            return students;
        }

        [HttpGet("class/{id}")]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudentsForClass(int id)
        {
            var context = await _context.Students.Include(x => x.Class).Where(k => k.ClassId == id).ToListAsync();
            var students = _mapper.Map<List<Student>, List<StudentDTO>>(context);
            return students;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDTO>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            var answer = _mapper.Map<Student, StudentDTO>(student);

            if (student == null)
            {
                return NotFound();
            }

            return answer;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, StudentDTO studentDTO)
        {
            var student = _mapper.Map<StudentDTO, Student>(studentDTO);

            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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
        public async Task<ActionResult<StudentDTO>> PostStudent(StudentDTO studentDTO)
        {
            var student = _mapper.Map<StudentDTO, Student>(studentDTO);
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            var context = _context.Students.Include(x => x.Class).FirstOrDefault(x => x.Id == student.Id);
            var answer = _mapper.Map<Student, StudentDTO>(context);

            return CreatedAtAction("GetStudent", new { id = student.Id }, answer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
