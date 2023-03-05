using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Models;
using System.Linq;
using System.Threading.Tasks;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly SchoolContext _context;

        public AdminController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<SchoolStat>> GetInfo()
        {
            var director = await _context.Teachers.FirstOrDefaultAsync(p => p.Position == "Директор");
            var headTeacher = await _context.Teachers.FirstOrDefaultAsync(p => p.Position == "Завуч");
            var students = await _context.Students.Where(x => x.ClassId != null).ToListAsync();
            var teachers = await _context.Teachers.ToListAsync();

            SchoolStat answer = new()
            {
                Director = director.LastName + " " + director.FirstName + " " + director.MiddleName,
                HeadTeacher = headTeacher.LastName + " " + headTeacher.FirstName + " " + headTeacher.MiddleName,
                StudentsCount = students.Count,
                TeachersCount = teachers.Count
            };

            return answer;
        }

        [HttpPost]
        public async Task<IActionResult> TransferStudents()
        {
            var students = await _context.Students.ToListAsync();
            var classes = await _context.Classes.ToListAsync();

            for (int i = 0; i < students.Count; i++)
            {
                _ = students[i].ClassId < 11 ? students[i].ClassId++ : students[i].ClassId = null;
            }

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
    }
}
