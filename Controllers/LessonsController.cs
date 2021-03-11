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
    public class LessonsController : ControllerBase
    {
        private readonly SchoolContext _context;
        private readonly IMapper _mapper;

        public LessonsController(SchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonDTO>>> GetLessons()
        {
            var context = await _context.Lessons.Include(p => p.AcademicSubject).ToListAsync();
            var answer = _mapper.Map<List<Lesson>, List<LessonDTO>>(context);
            return answer;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<IEnumerable<LessonDTO>>>> GetTimetable(int id)
        {
            List<List<LessonDTO>> timetable = new();
            for (int i = 1; i <= (id < 5 ? 5 : 6); i++)
            {
                var context = await _context.Lessons.Where(x => x.ClassId == id)
                                                    .Where(z => z.Day == i)
                                                    .OrderBy(y => y.Index)
                                                    .Include(p => p.AcademicSubject).ToListAsync();
                var answer = _mapper.Map<List<Lesson>, List<LessonDTO>>(context);
                timetable.Add(answer);
            }


            if (timetable[0].Count == 0)
            {
                return NotFound();
            }

            return timetable;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLesson(int id, LessonDTO lessonDTO)
        {
            var lesson = _mapper.Map<LessonDTO, Lesson>(lessonDTO);

            if (id != lesson.Id)
            {
                return BadRequest();
            }

            _context.Entry(lesson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonExists(id))
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
        public async Task<ActionResult<LessonDTO>> PostLesson(LessonDTO lessonDTO)
        {
            var lesson = _mapper.Map<LessonDTO, Lesson>(lessonDTO);
            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLesson", new { id = lesson.Id }, lesson);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }

            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LessonExists(int id)
        {
            return _context.Lessons.Any(e => e.Id == id);
        }
    }
}