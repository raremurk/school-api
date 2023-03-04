using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Models;
using School.ViewModels;

namespace School.Controllers
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
            var context = await _context.Teachers.Include(x => x.AcademicSubject).ToListAsync();
            var teachers = _mapper.Map<List<Teacher>, List<TeacherDTO>>(context);
            return teachers;
        }

        [Route("all")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherFullNameDTO>>> GetTeachersFullNames()
        {
            var context = await _context.Teachers.ToListAsync();
            var teachers = _mapper.Map<List<Teacher>, List<TeacherFullNameDTO>>(context);
            return teachers;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherDTO>> GetTeacher(int id)
        {
            var context = await _context.Teachers.FindAsync(id);
            var teacher = _mapper.Map<Teacher, TeacherDTO>(context);

            if (teacher == null)
            {
                return NotFound();
            }

            return teacher;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher(int id, Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return BadRequest();
            }

            _context.Entry(teacher).State = EntityState.Modified;

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
        public async Task<ActionResult<TeacherDTO>> PostTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            var context = _context.Teachers.Include(x => x.AcademicSubject).FirstOrDefault(x => x.Id == teacher.Id);
            var answer = _mapper.Map<Teacher, TeacherDTO>(context);

            return CreatedAtAction("GetTeacher", new { id = teacher.Id }, answer);
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
